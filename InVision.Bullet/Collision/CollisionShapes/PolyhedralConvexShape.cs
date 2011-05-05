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

#define TRUE

using System.Collections.Generic;
using InVision.Bullet.LinearMath;
using InVision.GameMath;

namespace InVision.Bullet.Collision.CollisionShapes
{

	public abstract class PolyhedralConvexShape : ConvexInternalShape
	{
		public override Vector3 LocalGetSupportingVertexWithoutMargin(ref Vector3 vec)
		{
			return Vector3.Zero;
		}

		public override void BatchedUnitVectorGetSupportingVertexWithoutMargin(IList<Vector3> vectors, IList<Vector4> supportVerticesOut, int numVectors)
		{
			int i;

			Vector3 vtx = Vector3.Zero;
			float newDot = 0f;

			for (i = 0; i < numVectors; i++)
			{
				Vector4 temp = supportVerticesOut[i];
				temp.W = -MathUtil.BT_LARGE_FLOAT;
				supportVerticesOut[i] = temp;
			}


			for (int j = 0; j < numVectors; j++)
			{

				Vector3 vec = vectors[j];

				for (i = 0; i < GetNumVertices(); i++)
				{
					GetVertex(i, ref vtx);
					newDot = Vector3.Dot(vec, vtx);
					if (newDot > supportVerticesOut[j].W)
					{
						supportVerticesOut[j] = new Vector4(vtx, newDot);
					}
				}
			}


		}

		public override Vector3 CalculateLocalInertia(float mass)
		{
			//not yet, return box inertia

			float margin = Margin;

			Matrix ident = Matrix.Identity;

			Vector3 aabbMin = Vector3.Zero, aabbMax = Vector3.Zero;
			GetAabb(ref ident, ref aabbMin, ref aabbMax);
			Vector3 halfExtents = (aabbMax - aabbMin) * 0.5f;

			float lx = 2.0f * (halfExtents.X + margin);
			float ly = 2.0f * (halfExtents.Y + margin);
			float lz = 2.0f * (halfExtents.Z + margin);
			float x2 = lx * lx;
			float y2 = ly * ly;
			float z2 = lz * lz;
			float scaledmass = mass * 0.08333333f;

			return scaledmass * (new Vector3(y2 + z2, x2 + z2, x2 + y2));
		}


		public abstract int GetNumVertices();
		public abstract int GetNumEdges();
		public abstract void GetEdge(int i, ref Vector3 pa, ref Vector3 pb);
		public abstract void GetVertex(int i, ref Vector3 vtx);
		public abstract int GetNumPlanes();
		public abstract void GetPlane(ref Vector3 planeNormal, ref Vector3 planeSupport, int i);
		//	virtual int getIndex(int i) const = 0 ; 

		public abstract bool IsInside(ref Vector3 pt, float tolerance);
	}
}
