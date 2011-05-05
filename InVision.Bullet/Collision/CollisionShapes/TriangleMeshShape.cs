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


using System;
using System.Diagnostics;
using InVision.Bullet.Collision.BroadphaseCollision;
using InVision.Bullet.LinearMath;
using InVision.GameMath;

namespace InVision.Bullet.Collision.CollisionShapes
{
    public class TriangleMeshShape : ConcaveShape
    {
        public TriangleMeshShape(StridingMeshInterface meshInterface)
        {
            m_inConstructor = true;
            m_meshInterface = meshInterface;
            m_shapeType = BroadphaseNativeTypes.TRIANGLE_MESH_SHAPE_PROXYTYPE;
            if (meshInterface.HasPremadeAabb())
            {
                meshInterface.GetPremadeAabb(ref m_localAabbMin, ref m_localAabbMax);
            }
            else
            {
                RecalcLocalAabb();
            }
            m_inConstructor = false;
        }


        public virtual Vector3 LocalGetSupportingVertex(ref Vector3 vec)
        {
	        Vector3 supportVertex = new Vector3();

            Matrix ident = Matrix.Identity;

	        SupportVertexCallback supportCallback = new SupportVertexCallback(ref vec,ref ident);

	        Vector3 aabbMax = MathUtil.MAX_VECTOR;
            Vector3 aabbMin = MathUtil.MIN_VECTOR;

            // URGGHHH!
            if (m_inConstructor)
            {
                this.ProcessAllTrianglesCtor(supportCallback, ref aabbMin, ref aabbMax);
            }
            else
            {
                ProcessAllTriangles(supportCallback, ref aabbMin, ref aabbMax);
            }
            
	        supportVertex = supportCallback.GetSupportVertexLocal();
            supportCallback.Cleanup();
	        return supportVertex;

        }

	    public virtual Vector3 LocalGetSupportingVertexWithoutMargin(ref Vector3 vec)
	    {
		    Debug.Assert(false);
		    return LocalGetSupportingVertex(ref vec);
	    }

	    public void	RecalcLocalAabb()
        {
		    Vector3 vec = new Vector3(1,0,0);
		    Vector3 tmp = LocalGetSupportingVertex(ref vec);
            m_localAabbMax.X = tmp.X + m_collisionMargin;
            vec = new Vector3(-1, 0, 0);
            tmp = LocalGetSupportingVertex(ref vec);
            m_localAabbMin.X = tmp.X - m_collisionMargin;

            vec = new Vector3(0, 1, 0);
            tmp = LocalGetSupportingVertex(ref vec);
            m_localAabbMax.Y = tmp.Y + m_collisionMargin;
            vec = new Vector3(0, -1, 0);
            tmp = LocalGetSupportingVertex(ref vec);
            m_localAabbMin.Y = tmp.Y - m_collisionMargin;

            vec = new Vector3(0, 0, 1);
            tmp = LocalGetSupportingVertex(ref vec);
            m_localAabbMax.Z = tmp.Z + m_collisionMargin;
            vec = new Vector3(0, 0, -1);
            tmp = LocalGetSupportingVertex(ref vec);
            m_localAabbMin.Z = tmp.Z - m_collisionMargin;
        }

        public override void GetAabb(ref Matrix trans, ref Vector3 aabbMin, ref Vector3 aabbMax)
        {
            Vector3 localHalfExtents = 0.5f * (m_localAabbMax - m_localAabbMin);
            float margin = Margin;
            localHalfExtents += new Vector3(margin, margin, margin);
            Vector3 localCenter = 0.5f * (m_localAabbMax + m_localAabbMin);

            Matrix abs_b = Matrix.Identity;
            MathUtil.AbsoluteMatrix(ref trans, ref abs_b);
            //Vector3 center = trans.Translation;
            Vector3 center = Vector3.Transform(localCenter,trans);
            Vector3 extent = new Vector3(Vector3.Dot(abs_b.Right, localHalfExtents),
                                            Vector3.Dot(abs_b.Up, localHalfExtents),
                                            Vector3.Dot(abs_b.Backward, localHalfExtents));
            Vector3 extent2 = new Vector3(Vector3.Dot(new Vector3(abs_b.M11, abs_b.M12, abs_b.M13), localHalfExtents),
                   Vector3.Dot(new Vector3(abs_b.M21, abs_b.M22, abs_b.M23), localHalfExtents),
                  Vector3.Dot(new Vector3(abs_b.M31, abs_b.M32, abs_b.M33), localHalfExtents));

            if (extent != extent2)
            {
                int ibreak = 0;
            }

            aabbMin = center - extent;
            aabbMax = center + extent;

        }
        // yuck yuck yuck
        public void ProcessAllTrianglesCtor(ITriangleCallback callback, ref Vector3 aabbMin, ref Vector3 aabbMax)
        {
            FilteredCallback filterCallback = new FilteredCallback(callback, ref aabbMin, ref aabbMax);
            m_meshInterface.InternalProcessAllTriangles(filterCallback, ref aabbMin, ref aabbMax);
            filterCallback.Cleanup();
        }


        public override void ProcessAllTriangles(ITriangleCallback callback, ref Vector3 aabbMin, ref Vector3 aabbMax)
        {
        	FilteredCallback filterCallback = new FilteredCallback(callback,ref aabbMin,ref aabbMax);
            m_meshInterface.InternalProcessAllTriangles(filterCallback,ref aabbMin,ref aabbMax);
            filterCallback.Cleanup();
        }

        public override void SetLocalScaling(ref Vector3 scaling)
        {
            m_meshInterface.SetScaling(ref scaling);
            RecalcLocalAabb();
        }

        public override Vector3 GetLocalScaling()
        {
            return m_meshInterface.GetScaling();
        }
	
	    public StridingMeshInterface GetMeshInterface()
	    {
		    return m_meshInterface;
	    }

	    public Vector3 GetLocalAabbMin()
	    {
		    return m_localAabbMin;
	    }

        public Vector3 GetLocalAabbMax()
	    {
		    return m_localAabbMax;
	    }

	    //debugging

    	public override string Name
    	{
    		get { return "TRIANGLEMESH"; }
    	}

    	private bool m_inConstructor;  // hacky attempt to get correct callback in construction
        protected Vector3 m_localAabbMin;
        protected Vector3 m_localAabbMax;
        protected StridingMeshInterface m_meshInterface;
    }
}
