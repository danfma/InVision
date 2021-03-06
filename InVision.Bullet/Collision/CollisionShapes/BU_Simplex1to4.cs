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
using InVision.Bullet.Collision.BroadphaseCollision;
using InVision.GameMath;

namespace InVision.Bullet.Collision.CollisionShapes
{

    ///The btBU_Simplex1to4 implements tetrahedron, triangle, line, vertex collision shapes. In most cases it is better to use btConvexHullShape instead.
    public class BU_Simplex1to4 : PolyhedralConvexAabbCachingShape
    {
	    public BU_Simplex1to4()
        {
            m_shapeType = BroadphaseNativeTypes.TETRAHEDRAL_SHAPE_PROXYTYPE;
        }

	    public BU_Simplex1to4(ref Vector3 pt0)
        {
            m_shapeType = BroadphaseNativeTypes.TETRAHEDRAL_SHAPE_PROXYTYPE;
            AddVertex(ref pt0);
        }
	    public BU_Simplex1to4(ref Vector3 pt0,ref Vector3 pt1)
        {
            m_shapeType = BroadphaseNativeTypes.TETRAHEDRAL_SHAPE_PROXYTYPE;
            AddVertex(ref pt0);
            AddVertex(ref pt1);
        }
	    public BU_Simplex1to4(ref Vector3 pt0,ref Vector3 pt1,ref Vector3 pt2)
        {
            m_shapeType = BroadphaseNativeTypes.TETRAHEDRAL_SHAPE_PROXYTYPE;
            AddVertex(ref pt0);
            AddVertex(ref pt1);
            AddVertex(ref pt2);
        }
	    public BU_Simplex1to4(ref Vector3 pt0,ref Vector3 pt1,ref Vector3 pt2,ref Vector3 pt3)
        {
            m_shapeType = BroadphaseNativeTypes.TETRAHEDRAL_SHAPE_PROXYTYPE;
            AddVertex(ref pt0);
            AddVertex(ref pt1);
            AddVertex(ref pt2);
            AddVertex(ref pt3);
        }

        
	    public void Reset()
	    {
            m_numVertices = 0;
	    }


        public override void GetAabb(ref Matrix t, ref Vector3 aabbMin, ref Vector3 aabbMax)
        {
            #if true
	            base.GetAabb(ref t,ref aabbMin,ref aabbMax);
            #else
            aabbMin = MathUtil.MAX_VECTOR;
            aabbMax = MathUtil.MIN_VECTOR;

	            //just transform the vertices in worldspace, and take their AABB
	            for (int i=0;i<m_numVertices;i++)
	            {
		            Vector3 worldVertex = Vector3.Transformt(m_vertices[i],t);
                    MathUtil.vectorMin(ref worldVertex, ref aabbMin);
                    MathUtil.vectorMin(ref worldVertex,ref aabbMax);
	            }
            #endif

        }

	    public void AddVertex(ref Vector3 pt)
        {
            m_vertices[m_numVertices++] = pt;
            RecalcLocalAabb();
        }

	    //PolyhedralConvexShape interface

	    public override int	GetNumVertices()
        {
            return m_numVertices;
        }

	    public override int GetNumEdges()
        {
            //euler formula, F-E+V = 2, so E = F+V-2

            switch (m_numVertices)
            {
                case 0:
                    return 0;
                case 1: return 0;
                case 2: return 1;
                case 3: return 3;
                case 4: return 6;
            }

            return 0;
        }

	    public override void GetEdge(int i,ref Vector3 pa, ref Vector3 pb)
        {
            pa = Vector3.Zero;
            pb = Vector3.Zero;

            switch (m_numVertices)
            {
                case 2:
                    pa = m_vertices[0];
                    pb = m_vertices[1];
                    break;
                case 3:

                    switch (i)
                    {
                        case 0:
                            pa = m_vertices[0];
                            pb = m_vertices[1];
                            break;
                        case 1:
                            pa = m_vertices[1];
                            pb = m_vertices[2];
                            break;
                        case 2:
                            pa = m_vertices[2];
                            pb = m_vertices[0];
                            break;

                    }
                    break;
                case 4:
                    switch (i)
                    {
                        case 0:
                            pa = m_vertices[0];
                            pb = m_vertices[1];
                            break;
                        case 1:
                            pa = m_vertices[1];
                            pb = m_vertices[2];
                            break;
                        case 2:
                            pa = m_vertices[2];
                            pb = m_vertices[0];
                            break;
                        case 3:
                            pa = m_vertices[0];
                            pb = m_vertices[3];
                            break;
                        case 4:
                            pa = m_vertices[1];
                            pb = m_vertices[3];
                            break;
                        case 5:
                            pa = m_vertices[2];
                            pb = m_vertices[3];
                            break;
                    }
                    break;
            }
        }
    	
	    public override void GetVertex(int i,ref Vector3 vtx) 
        {
            vtx = m_vertices[i];
        }

	    public override int	GetNumPlanes()
        {
            switch (m_numVertices)
            {
                case 0:
                    return 0;
                case 1:
                    return 0;
                case 2:
                    return 0;
                case 3:
                    return 2;
                case 4:
                    return 4;
                default:
                    {
                        return 0;
                    }
            }
        }

	    public override void GetPlane(ref Vector3 planeNormal,ref Vector3 planeSupport,int i)
        {
            planeNormal = Vector3.Up;
            planeSupport = Vector3.Zero;
        }

	    public virtual int GetIndex(int i)
        {
            return 0;
        }

        public override bool IsInside(ref Vector3 pt, float tolerance)
        {
            return false;
        }


    	///getName is for debugging
    	public override string Name
    	{
    		get { return "btBU_Simplex1to4"; }
    	}

    	protected int	m_numVertices;
	    protected Vector3[]	m_vertices = new Vector3[4];


    }
}
