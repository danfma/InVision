/*
 * C# / XNA  port of Bullet (c) 2011 Mark Neale <xexuxjy@hotmail.com>
 *
 * Bullet Continuous Collision Detection and Physics Library
 * Copyright (c) 2003-2008 Erwin Coumans  http://www.bulletphysics.com/
 *
 * This software is provided 'as-is', without any express or implied warranty.
 * In no event will the authors be held liable for any damages arising from
 * the use of this software.
 * 
 * Permission is granted to anyone to use this software for any purpose, 
 * including commercial applications, and to alter it and redistribute it
 * freely, subject to the following restrictions:
 * 
 * 1. The origin of this software must not be misrepresented; you must not
 *    claim that you wrote the original software. If you use this software
 *    in a product, an acknowledgment in the product documentation would be
 *    appreciated but is not required.
 * 2. Altered source versions must be plainly marked as such, and must not be
 *    misrepresented as being the original software.
 * 3. This notice may not be removed or altered from any source distribution.
 */

using InVision.Bullet.Collision.CollisionShapes;
using InVision.Bullet.LinearMath;
using InVision.GameMath;

namespace InVision.Bullet.Collision.NarrowPhaseCollision
{
    public class GjkEpaSolver2
    {
        public static bool debugGJK = true;

        public static void Initialize(ConvexShape shape0,ref Matrix wtrs0,
            ConvexShape shape1,ref Matrix wtrs1,
            GjkEpaSolver2Results results,
            GjkEpaSolver2MinkowskiDiff shapeR,
            bool withmargins)
        {
            /* Results		*/ 
            results.witnesses0 = Vector3.Zero;
            results.witnesses1 = Vector3.Zero;
            results.status = GjkEpaSolver2Status.Separated;
            /* Shape		*/ 
            shapeR.m_shapes[0] =	shape0;
            shapeR.m_shapes[1] =	shape1;

            shapeR.m_toshape1 = MathUtil.TransposeTimesBasis(ref wtrs1,ref wtrs0);
            shapeR.m_toshape0 = MathUtil.InverseTimes(ref wtrs0, ref wtrs1);

            if (BulletGlobals.g_streamWriter != null && debugGJK)
            {
                MathUtil.PrintMatrix(BulletGlobals.g_streamWriter, "gjksolver2::init::shape0", shapeR.m_toshape0);
                MathUtil.PrintMatrix(BulletGlobals.g_streamWriter, "gjksolver2::init::shape1", shapeR.m_toshape1);
            }


            shapeR.EnableMargin(withmargins);
        }

        
        
        public static bool	Distance(ConvexShape shape0,ref Matrix wtrs0,ConvexShape shape1,ref Matrix wtrs1,ref Vector3 guess,GjkEpaSolver2Results	results)
        {
            GjkEpaSolver2MinkowskiDiff shape = new GjkEpaSolver2MinkowskiDiff();
            Initialize(shape0,ref wtrs0,shape1,ref wtrs1,results,shape,false);
            GJK	gjk = new GJK();
            GJKStatus gjk_status= gjk.Evaluate(shape,ref guess);
            if(gjk_status == GJKStatus.Valid)
            {
                Vector3	w0 = Vector3.Zero;
                Vector3	w1 = Vector3.Zero;
                for(uint i=0;i<gjk.m_simplex.rank;++i)
                {
                    float p=gjk.m_simplex.p[i];
                    w0+=shape.Support(ref gjk.m_simplex.c[i].d,0)*p;
                    Vector3 temp = -gjk.m_simplex.c[i].d;
                    w1+=shape.Support(ref temp,1)*p;
                }
                results.witnesses0	= Vector3.Transform(w0,wtrs0);
                results.witnesses1	= Vector3.Transform(w1,wtrs0);
                results.normal = w0-w1;
                results.distance =	results.normal.Length();
                results.normal	/=	results.distance>GJK_MIN_DISTANCE?results.distance:1;
                return(true);
            }
            else
            {
                //GjkEpaSolver2Status
                results.status = (gjk_status==GJKStatus.Inside)?GjkEpaSolver2Status.Penetrating :GjkEpaSolver2Status.GJK_Failed	;
                return(false);
            }
        }

        public static bool Penetration(ConvexShape shape0, ref Matrix wtrs0, ConvexShape shape1, ref Matrix wtrs1, ref Vector3 guess, GjkEpaSolver2Results results)
        {
            return Penetration(shape0, ref wtrs0, shape1, ref wtrs1, ref guess, results, true);
        }

        public static bool Penetration(ConvexShape shape0,ref Matrix wtrs0,ConvexShape shape1,ref Matrix wtrs1,ref Vector3 guess,GjkEpaSolver2Results results,bool usemargins)
        {
            GjkEpaSolver2MinkowskiDiff shape = new GjkEpaSolver2MinkowskiDiff();
            Initialize(shape0,ref wtrs0,shape1,ref wtrs1,results, shape,usemargins);
            GJK	gjk = new GJK();	
            Vector3 minusGuess = -guess;
            GJKStatus	gjk_status=gjk.Evaluate(shape,ref minusGuess);
            switch(gjk_status)
            {
            case GJKStatus.Inside:
                {
                    EPA	epa = new EPA();
                    eStatus	epa_status=epa.Evaluate(gjk,ref minusGuess);
                    if(epa_status!=eStatus.Failed)
                    {
                        Vector3	w0 = Vector3.Zero;
                        for(uint i=0;i<epa.m_result.rank;++i)
                        {
                            // order of results here is 'different' , EPA.evaluate.
                            w0+=shape.Support(ref epa.m_result.c[i].d,0)*epa.m_result.p[i];
                        }
                        results.status			=	GjkEpaSolver2Status.Penetrating;
                        results.witnesses0	=	Vector3.Transform(w0,wtrs0);
                        results.witnesses1	=	Vector3.Transform((w0-epa.m_normal*epa.m_depth),wtrs0);
                        results.normal			=	-epa.m_normal;
                        results.distance		=	-epa.m_depth;
                        return(true);
                    } else results.status=GjkEpaSolver2Status.EPA_Failed;
                }
                break;
            case GJKStatus.Failed:
                results.status=GjkEpaSolver2Status.GJK_Failed;
                break;
            }
            return(false);
        }

        //
        public float SignedDistance(ref Vector3 position, float margin, ConvexShape shape0, ref Matrix wtrs0, GjkEpaSolver2Results results)
        {
            GjkEpaSolver2MinkowskiDiff shape = new GjkEpaSolver2MinkowskiDiff();
            SphereShape	shape1 = new SphereShape(margin);
            Matrix wtrs1 = Matrix.CreateFromQuaternion(Quaternion.Identity);
            wtrs0.Translation = position;
	        
            Initialize(shape0,ref wtrs0,shape1,ref wtrs1,results,shape,false);
            GJK	gjk = new GJK();	
            Vector3 guess = new Vector3(1,1,1);
            GJKStatus	gjk_status=gjk.Evaluate(shape,ref guess);
            if(gjk_status==GJKStatus.Valid)
            {
                Vector3	w0=Vector3.Zero;
                Vector3	w1=Vector3.Zero;
                for(int i=0;i<gjk.m_simplex.rank;++i)
                {
                    float p=gjk.m_simplex.p[i];
                    w0+=shape.Support( ref gjk.m_simplex.c[i].d,0)*p;
                    Vector3 temp = -gjk.m_simplex.c[i].d;
                    w1+=shape.Support(ref temp,1)*p;
                }
                results.witnesses0 = Vector3.Transform(w0,wtrs0);
                results.witnesses1 = Vector3.Transform(w1,wtrs0);
                Vector3	delta=	results.witnesses1-results.witnesses0;
                float margin2 = shape0.GetMarginNonVirtual()+shape1.GetMarginNonVirtual();
                float length = delta.Length();	
                results.normal = delta/length;
                results.witnesses0 +=	results.normal*margin2;
                return(length-margin2);
            }
            else
            {
                if(gjk_status==GJKStatus.Inside)
                {
                    if(Penetration(shape0,ref wtrs0,shape1,ref wtrs1,ref gjk.m_ray,results))
                    {
                        Vector3	delta=	results.witnesses0-results.witnesses1;
                        float length= delta.Length();
                        if (length >= MathUtil.SIMD_EPSILON)
                            results.normal	=	delta/length;			
                        return(-length);
                    }
                }	
            }
            return(MathUtil.SIMD_INFINITY);
        }

        //
        public bool SignedDistance(ConvexShape	shape0,ref Matrix wtrs0,ConvexShape shape1,ref Matrix wtrs1,ref Vector3 guess,GjkEpaSolver2Results results)
        {
            if(!Distance(shape0,ref wtrs0,shape1,ref wtrs1,ref guess,results))
                return(Penetration(shape0,ref wtrs0,shape1,ref wtrs1,ref guess,results,false));
            else
                return(true);
        }


        /* GJK	*/
        public const int GJK_MAX_ITERATIONS = 128;
        public const float GJK_ACCURARY = 0.0001f;
        public const float GJK_MIN_DISTANCE = 0.0001f;
        public const float GJK_DUPLICATED_EPS = 0.0001f;
        public const float GJK_SIMPLEX2_EPS = 0f;
        public const float GJK_SIMPLEX3_EPS = 0f;
        public const float GJK_SIMPLEX4_EPS = 0f;

        /* EPA	*/
        public const int EPA_MAX_VERTICES = 64;
        public const int EPA_MAX_FACES = EPA_MAX_VERTICES * 2;
        public const int EPA_MAX_ITERATIONS = 255;
        public const float EPA_ACCURACY = 0.0001f;
        public const float EPA_FALLBACK = 10 * EPA_ACCURACY;
        public const float EPA_PLANE_EPS = 0.00001f;
        public const float EPA_INSIDE_EPS = 0.01f;

    }


	// MinkowskiDiff


	// EPA
}


