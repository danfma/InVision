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
using InVision.Bullet.LinearMath;
using InVision.GameMath;

namespace InVision.Bullet.Collision.CollisionShapes
{
    public class ShapeHull
    {
        public ShapeHull(ConvexShape convexShape)
        {
            m_shape = convexShape;
        }

        public bool BuildHull(float margin)
        {
	        int numSampleDirections = NUM_UNITSPHERE_POINTS;
	        {
		        int numPDA = m_shape.GetNumPreferredPenetrationDirections();
		        if (numPDA != 0)
		        {
			        for (int i=0;i<numPDA;i++)
			        {
				        Vector3 norm = new Vector3();
				        m_shape.GetPreferredPenetrationDirection(i,ref norm);
				        UnitSpherePoints[numSampleDirections] = norm;
				        numSampleDirections++;
			        }
		        }
	        }

	        Vector3[] supportPoints = new Vector3[NUM_UNITSPHERE_POINTS+ConvexShape.MAX_PREFERRED_PENETRATION_DIRECTIONS*2];
	        
	        for (int i = 0; i < numSampleDirections; i++)
	        {
		        supportPoints[i] = m_shape.LocalGetSupportingVertex(ref UnitSpherePoints[i]);
	        }

	        HullDesc hd = new HullDesc();
	        hd.mFlags = HullFlag.QF_TRIANGLES;
	        hd.mVcount = numSampleDirections;

            for (int i = 0; i < numSampleDirections; ++i)
            {
                hd.mVertices.Add(supportPoints[i]);
            }
            HullLibrary hl = new HullLibrary();
	        HullResult hr = new HullResult();
	        if (hl.CreateConvexHull (hd, hr) == HullError.QE_FAIL)
	        {
		        return false;
	        }


	        for (int i = 0; i < hr.mNumOutputVertices; i++)
	        {
		        m_vertices[i] = hr.m_OutputVertices[i];
	        }
            
            int numIndices = hr.mNumIndices;
	        
            for (int i = 0; i < numIndices; i++)
	        {
		        m_indices[i] = hr.m_Indices[i];
	        }

	        // free temporary hull result that we just copied
	        hl.ReleaseResult (hr);


            if (BulletGlobals.g_streamWriter != null && debugShapeHull)
			{
				BulletGlobals.g_streamWriter.WriteLine("buildHull");
				BulletGlobals.g_streamWriter.WriteLine("Vertices");
				for (int i = 0; i < m_vertices.Count; ++i)
				{
					MathUtil.PrintVector3(BulletGlobals.g_streamWriter,m_vertices[i]);
				}
				BulletGlobals.g_streamWriter.WriteLine("Indices");
				for (int i = 0; i < m_indices.Count/3; ++i)
				{
					int indexer = i*3;
					BulletGlobals.g_streamWriter.WriteLine(String.Format("{0},{1},{2}", m_indices[indexer], m_indices[indexer + 1], m_indices[indexer + 2]));
				}

			}


	        return true;

        }

        public int NumTriangles()
        {
            return m_indices.Count / 3;
        }

        public int NumVertices()
        {
            return m_vertices.Count;
        }

        public int NumIndices()
        {
            return m_indices.Count;
        }

        public IList<Vector3> m_vertices = new ObjectArray<Vector3>();
        public IList<int> m_indices = new ObjectArray<int>();
        public ConvexShape m_shape;

        const int NUM_UNITSPHERE_POINTS = 42;

        static bool debugShapeHull = true;

        //static Vector3[] UnitSpherePoints = new Vector3[NUM_UNITSPHERE_POINTS + ConvexShape.MAX_PREFERRED_PENETRATION_DIRECTIONS * 2];  
        static Vector3[] UnitSpherePoints = new Vector3[]  
        {
	        new Vector3(0.000000f, -0.000000f,-1.000000f),
	        new Vector3(0.723608f, -0.525725f,-0.447219f),
	        new Vector3(-0.276388f, -0.850649f,-0.447219f),
	        new Vector3(-0.894426f, -0.000000f,-0.447216f),
	        new Vector3(-0.276388f, 0.850649f,-0.447220f),
	        new Vector3(0.723608f, 0.525725f,-0.447219f),
	        new Vector3(0.276388f, -0.850649f,0.447220f),
	        new Vector3(-0.723608f, -0.525725f,0.447219f),
	        new Vector3(-0.723608f, 0.525725f,0.447219f),
	        new Vector3(0.276388f, 0.850649f,0.447219f),
	        new Vector3(0.894426f, 0.000000f,0.447216f),
	        new Vector3(-0.000000f, 0.000000f,1.000000f),
	        new Vector3(0.425323f, -0.309011f,-0.850654f),
	        new Vector3(-0.162456f, -0.499995f,-0.850654f),
	        new Vector3(0.262869f, -0.809012f,-0.525738f),
	        new Vector3(0.425323f, 0.309011f,-0.850654f),
	        new Vector3(0.850648f, -0.000000f,-0.525736f),
	        new Vector3(-0.525730f, -0.000000f,-0.850652f),
	        new Vector3(-0.688190f, -0.499997f,-0.525736f),
	        new Vector3(-0.162456f, 0.499995f,-0.850654f),
	        new Vector3(-0.688190f, 0.499997f,-0.525736f),
	        new Vector3(0.262869f, 0.809012f,-0.525738f),
	        new Vector3(0.951058f, 0.309013f,0.000000f),
	        new Vector3(0.951058f, -0.309013f,0.000000f),
	        new Vector3(0.587786f, -0.809017f,0.000000f),
	        new Vector3(0.000000f, -1.000000f,0.000000f),
	        new Vector3(-0.587786f, -0.809017f,0.000000f),
	        new Vector3(-0.951058f, -0.309013f,-0.000000f),
	        new Vector3(-0.951058f, 0.309013f,-0.000000f),
	        new Vector3(-0.587786f, 0.809017f,-0.000000f),
	        new Vector3(-0.000000f, 1.000000f,-0.000000f),
	        new Vector3(0.587786f, 0.809017f,-0.000000f),
	        new Vector3(0.688190f, -0.499997f,0.525736f),
	        new Vector3(-0.262869f, -0.809012f,0.525738f),
	        new Vector3(-0.850648f, 0.000000f,0.525736f),
	        new Vector3(-0.262869f, 0.809012f,0.525738f),
	        new Vector3(0.688190f, 0.499997f,0.525736f),
	        new Vector3(0.525730f, 0.000000f,0.850652f),
	        new Vector3(0.162456f, -0.499995f,0.850654f),
	        new Vector3(-0.425323f, -0.309011f,0.850654f),
	        new Vector3(-0.425323f, 0.309011f,0.850654f),
	        new Vector3(0.162456f, 0.499995f,0.850654f),
            Vector3.Zero,
            Vector3.Zero,
            Vector3.Zero,
            Vector3.Zero,
            Vector3.Zero,
            Vector3.Zero,
            Vector3.Zero,
            Vector3.Zero,
            Vector3.Zero,
            Vector3.Zero,
            Vector3.Zero,
            Vector3.Zero,
            Vector3.Zero,
            Vector3.Zero,
            Vector3.Zero,
            Vector3.Zero,
            Vector3.Zero,
            Vector3.Zero,
            Vector3.Zero,
            Vector3.Zero
        };
    }

}
