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
    public class TriangleShape : PolyhedralConvexShape
    {

        public TriangleShape()
        {
            m_shapeType = BroadphaseNativeTypes.TRIANGLE_SHAPE_PROXYTYPE;
        }

        public TriangleShape(Vector3 p0, Vector3 p1, Vector3 p2)
            : this(ref p0, ref p1, ref p2)
        {
        }



	    public TriangleShape(ref Vector3 p0,ref Vector3 p1,ref Vector3 p2) : base ()
        {
		    m_shapeType = BroadphaseNativeTypes.TRIANGLE_SHAPE_PROXYTYPE;
            m_vertices1[0] = p0;
            m_vertices1[1] = p1;
            m_vertices1[2] = p2;
        }


        public override void GetPlane(ref Vector3 planeNormal, ref Vector3 planeSupport, int i)
	    {
		    GetPlaneEquation(i,ref planeNormal,ref planeSupport);
	    }

        public override int GetNumPlanes()
	    {
		    return 1;
	    }

	    public void CalcNormal(ref Vector3 normal) 
	    {
            normal = Vector3.Cross(m_vertices1[1]-m_vertices1[0],m_vertices1[2]-m_vertices1[0]);
		    normal.Normalize();
	    }

        public virtual void GetPlaneEquation(int i, ref Vector3 planeNormal, ref Vector3 planeSupport)
	    {
		    CalcNormal(ref planeNormal);
		    planeSupport = m_vertices1[0];
	    }

        public override bool IsInside(ref Vector3 pt, float tolerance)
	    {
		    Vector3 normal = Vector3.Up;
		    CalcNormal(ref normal);
		    //distance to plane
            float dist = Vector3.Dot(pt,normal);
		    float planeconst = Vector3.Dot(m_vertices1[0],normal);
		    dist -= planeconst;
		    if (dist >= -tolerance && dist <= tolerance)
		    {
			    //inside check on edge-planes
			    int i;
			    for (i=0;i<3;i++)
			    {
				    Vector3 pa = Vector3.Zero,pb=Vector3.Zero;
				    GetEdge(i,ref pa,ref pb);
				    Vector3 edge = pb-pa;
                    Vector3 edgeNormal = Vector3.Cross(edge,normal);
				    edgeNormal.Normalize();
                    float dist2 = Vector3.Dot(pt, edgeNormal);
				    float edgeConst = Vector3.Dot(pa, edgeNormal);
				    dist2 -= edgeConst;
				    if (dist2 < -tolerance)
                    {
					    return false;
                    }
			    }
    			
			    return true;
		    }

		    return false;
	    }

    	public override string Name
    	{
    		get { return "Triangle"; }
    	}

    	public override int GetNumPreferredPenetrationDirections()
	    {
		    return 2;
	    }

        public override void GetPreferredPenetrationDirection(int index, ref Vector3 penetrationVector)
        {
	        CalcNormal(ref penetrationVector);
	        if (index > 0)
            {
		        penetrationVector *= -1f;
            }
        }

        public override int GetNumVertices()
        {
            return 3;
        }

        public virtual IList<Vector3> GetVertexPtr(int i)
        {
            return m_vertices1;
        }

        public override void GetVertex(int i, ref Vector3 vert)
        {
            vert = m_vertices1[i];
        }

        public override int GetNumEdges()
        {
            return 3;
        }

        public override void GetEdge(int i, ref Vector3 pa, ref Vector3 pb)
        {
            GetVertex(i, ref pa);
            GetVertex((i + 1) % 3, ref pb);
        }

        public override void GetAabb(ref Matrix trans, ref Vector3 aabbMin, ref Vector3 aabbMax)
        {
            GetAabbSlow(ref trans, ref aabbMin, ref aabbMax);
        }

        public override Vector3 LocalGetSupportingVertexWithoutMargin(ref Vector3 dir)
	    {
            float a,b,c;
            a = Vector3.Dot(dir, m_vertices1[0]);
            b = Vector3.Dot(dir, m_vertices1[1]);
            c = Vector3.Dot(dir, m_vertices1[2]);
		    Vector3 dots = new Vector3(a,b,c);
            return m_vertices1[MathUtil.MaxAxis(ref dots)];
	    }

	    public override void BatchedUnitVectorGetSupportingVertexWithoutMargin(IList<Vector3> vectors,IList<Vector4> supportVerticesOut,int numVectors)
	    {
		    for (int i=0;i<numVectors;i++)
		    {
			    Vector3 dir = vectors[i];
                float a, b, c;
                a = Vector3.Dot(dir, m_vertices1[0]);
                b = Vector3.Dot(dir, m_vertices1[1]);
                c = Vector3.Dot(dir, m_vertices1[2]);

                Vector3 dots = new Vector3(a, b, c);
                supportVerticesOut[i] = new Vector4(m_vertices1[MathUtil.MaxAxis(ref dots)],0);
		    }
	    }


        public IList<Vector3> m_vertices1 = new ObjectArray<Vector3>(3);
    }
}
