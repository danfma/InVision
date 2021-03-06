﻿/*
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
using System.Collections.Generic;
using System.Diagnostics;
using InVision.Bullet.Collision.BroadphaseCollision;
using InVision.Bullet.LinearMath;
using InVision.GameMath;

namespace InVision.Bullet.Collision.CollisionShapes
{
    public class BoxShape : PolyhedralConvexShape
    {
	    public virtual Vector3 GetHalfExtentsWithMargin()
	    {
		    Vector3 halfExtents = GetHalfExtentsWithoutMargin();
		    Vector3 margin = new Vector3(Margin,Margin,Margin);
		    halfExtents += margin;
		    return halfExtents;
	    }
	
	    public virtual Vector3 GetHalfExtentsWithoutMargin()
	    {
		    return m_implicitShapeDimensions;//changed in Bullet 2.63: assume the scaling and margin are included
	    }
	

	    public override Vector3	LocalGetSupportingVertex(ref Vector3 vec)
	    {
		    Vector3 halfExtents = GetHalfExtentsWithoutMargin();
		    Vector3 margin = new Vector3(Margin,Margin,Margin);
		    halfExtents += margin;
    		
		    return new Vector3(MathUtil.FSel(vec.X, halfExtents.X, -halfExtents.X),
                                MathUtil.FSel(vec.Y, halfExtents.Y, -halfExtents.Y),
                                MathUtil.FSel(vec.Z, halfExtents.Z, -halfExtents.Z));
	    }

	    public override Vector3 LocalGetSupportingVertexWithoutMargin(ref Vector3 vec)
	    {
		    Vector3 halfExtents = GetHalfExtentsWithoutMargin();

            return new Vector3(MathUtil.FSel(vec.X, halfExtents.X, -halfExtents.X),
                                MathUtil.FSel(vec.Y, halfExtents.Y, -halfExtents.Y),
                                MathUtil.FSel(vec.Z, halfExtents.Z, -halfExtents.Z));
        }


	    public override void BatchedUnitVectorGetSupportingVertexWithoutMargin(IList<Vector3> vectors,IList<Vector4> supportVerticesOut,int numVectors)
	    {
		    Vector3 halfExtents = GetHalfExtentsWithoutMargin();
    	
		    for (int i=0;i<numVectors;i++)
		    {
			    Vector3 vec = vectors[i];
                supportVerticesOut[i] = new Vector4(MathUtil.FSel(vec.X, halfExtents.X, -halfExtents.X),
                                MathUtil.FSel(vec.Y, halfExtents.Y, -halfExtents.Y),
                                MathUtil.FSel(vec.Z, halfExtents.Z, -halfExtents.Z),0f);
		    }
	    }

        public BoxShape(Vector3 boxHalfExtents) : this(ref boxHalfExtents) { }

	    public BoxShape(ref Vector3 boxHalfExtents) 
		    : base()
	    {
		    m_shapeType = BroadphaseNativeTypes.BOX_SHAPE_PROXYTYPE;
		    Vector3 margin = new Vector3(Margin,Margin,Margin);
		    m_implicitShapeDimensions = (boxHalfExtents * m_localScaling) - margin;
            int ibreak = 0;
	    }

    	public override float Margin
    	{
			get { return base.Margin; }
    		set
    		{
    			//correct the m_implicitShapeDimensions for the margin
    			Vector3 oldMargin = new Vector3(Margin, Margin, Margin);
    			Vector3 implicitShapeDimensionsWithMargin = m_implicitShapeDimensions + oldMargin;

    			base.Margin = value;
    			Vector3 newMargin = new Vector3(Margin, Margin, Margin);
    			m_implicitShapeDimensions = implicitShapeDimensionsWithMargin - newMargin;
    		}
    	}

    	public override void SetLocalScaling(ref Vector3 scaling)
	    {
		    Vector3 oldMargin = new Vector3(Margin,Margin,Margin);
		    Vector3 implicitShapeDimensionsWithMargin = m_implicitShapeDimensions+oldMargin;
		    Vector3 unScaledImplicitShapeDimensionsWithMargin = implicitShapeDimensionsWithMargin / m_localScaling;

		    base.SetLocalScaling(ref scaling);

		    m_implicitShapeDimensions = (unScaledImplicitShapeDimensionsWithMargin * m_localScaling) - oldMargin;

	    }

        public override void GetAabb(ref Matrix trans, ref Vector3 aabbMin, ref Vector3 aabbMax)
        {
            Vector3 halfExtents = GetHalfExtentsWithoutMargin();
            AabbUtil2.TransformAabb(ref halfExtents, Margin, ref trans, ref aabbMin, ref aabbMax);
        }

        public override Vector3 CalculateLocalInertia(float mass)
        {
	        //btScalar margin = btScalar(0.);
	        Vector3 halfExtents = GetHalfExtentsWithMargin();

	        float lx=2f*(halfExtents.X);
	        float ly=2f*(halfExtents.Y);
	        float lz=2f*(halfExtents.Z);

	        return new Vector3(
				mass/(12.0f) * (ly*ly + lz*lz),
				mass/(12.0f) * (lx*lx + lz*lz),
				mass/(12.0f) * (lx*lx + ly*ly));
        }

	    public override void GetPlane(ref Vector3 planeNormal,ref Vector3 planeSupport,int i )
	    {
		    //this plane might not be aligned...
            Plane plane = new Plane();
		    GetPlaneEquation(ref plane,i);
            planeNormal = plane.Normal;
            Vector3 negNormal = -planeNormal;
		    planeSupport = LocalGetSupportingVertex(ref negNormal);
	    }
	
	    public override int GetNumPlanes()
	    {
		    return 6;
	    }	
	
	    public override int	GetNumVertices()
	    {
		    return 8;
	    }

	    public override int GetNumEdges()
	    {
		    return 12;
	    }


	    public override  void GetVertex(int i,ref Vector3 vtx)
	    {
		    Vector3 halfExtents = GetHalfExtentsWithoutMargin();

		    vtx.X = halfExtents.X * (1-(i&1)) - halfExtents.X * (i&1);
            vtx.Y = halfExtents.Y * (1-((i&2)>>1)) - halfExtents.Y * ((i&2)>>1);
            vtx.Z = halfExtents.Z * (1-((i&4)>>2)) - halfExtents.Z * ((i&4)>>2);
	    }
	

	    public virtual void	GetPlaneEquation(ref Plane plane,int i)
	    {
		    Vector3 halfExtents = GetHalfExtentsWithoutMargin();


		    switch (i)
		    {
		    case 0:
                plane.Normal = Vector3.Right;
                plane.D = -halfExtents.X;
			    break;
		    case 1:
                plane.Normal = Vector3.Left;
                plane.D = -halfExtents.X;
			    break;
		    case 2:
                plane.Normal = Vector3.Up;
                plane.D = -halfExtents.Y;
			    break;
		    case 3:
                plane.Normal = Vector3.Down;
                plane.D = -halfExtents.Y;
			    break;
		    case 4:
                plane.Normal = Vector3.Backward;
                plane.D = -halfExtents.Z;
			    break;
		    case 5:
                plane.Normal = Vector3.Forward;
                plane.D = -halfExtents.Z;
			    break;
		    default:
			    Debug.Assert(false);
                break;
		    }
	    }


        public override void GetEdge(int i, ref Vector3 pa, ref Vector3 pb)
	    //virtual void getEdge(int i,Edge& edge) const
	    {
		    int edgeVert0 = 0;
		    int edgeVert1 = 0;

		    switch (i)
		    {
		    case 0:
				    edgeVert0 = 0;
				    edgeVert1 = 1;
			    break;
		    case 1:
				    edgeVert0 = 0;
				    edgeVert1 = 2;
			    break;
		    case 2:
			    edgeVert0 = 1;
			    edgeVert1 = 3;

			    break;
		    case 3:
			    edgeVert0 = 2;
			    edgeVert1 = 3;
			    break;
		    case 4:
			    edgeVert0 = 0;
			    edgeVert1 = 4;
			    break;
		    case 5:
			    edgeVert0 = 1;
			    edgeVert1 = 5;

			    break;
		    case 6:
			    edgeVert0 = 2;
			    edgeVert1 = 6;
			    break;
		    case 7:
			    edgeVert0 = 3;
			    edgeVert1 = 7;
			    break;
		    case 8:
			    edgeVert0 = 4;
			    edgeVert1 = 5;
			    break;
		    case 9:
			    edgeVert0 = 4;
			    edgeVert1 = 6;
			    break;
		    case 10:
			    edgeVert0 = 5;
			    edgeVert1 = 7;
			    break;
		    case 11:
			    edgeVert0 = 6;
			    edgeVert1 = 7;
			    break;
		    default:
			   Debug.Assert(false);
               break;
		    }

		    GetVertex(edgeVert0,ref pa );
		    GetVertex(edgeVert1,ref pb );
	    }
	
	    public override bool IsInside(ref Vector3 pt,float tolerance)
	    {
		    Vector3 halfExtents = GetHalfExtentsWithoutMargin();

		    //btScalar minDist = 2*tolerance;
    		
		    bool result =	(pt.X <= (halfExtents.X+tolerance)) &&
						    (pt.X >= (-halfExtents.X-tolerance)) &&
						    (pt.Y <= (halfExtents.Y+tolerance)) &&
						    (pt.Y >= (-halfExtents.Y-tolerance)) &&
						    (pt.Z <= (halfExtents.Z+tolerance)) &&
						    (pt.Z >= (-halfExtents.Z-tolerance));
    		
		    return result;
	    }


	    //debugging

    	public override string Name
    	{
    		get { return "Box"; }
    	}

    	public override int GetNumPreferredPenetrationDirections()
	    {
		    return 6;
	    }
	
	    public override void GetPreferredPenetrationDirection(int index, ref Vector3 penetrationVector)
	    {
		    switch (index)
		    {
		    case 0:
			    penetrationVector = Vector3.Right;
			    break;
		    case 1:
			    penetrationVector = Vector3.Left;
			    break;
		    case 2:
			    penetrationVector = Vector3.Up;
			    break;
		    case 3:
			    penetrationVector = Vector3.Down;
			    break;
		    case 4:
			    penetrationVector = Vector3.Backward;
			    break;
		    case 5:
                penetrationVector = Vector3.Forward;
			    break;
		    default:
                Debug.Assert(false);
                break;
		    }
	    }

    }
}
