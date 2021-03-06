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
using InVision.Bullet.Collision.BroadphaseCollision;
using InVision.GameMath;

namespace InVision.Bullet.Collision.CollisionShapes
{

	///The btConvex2dShape allows to use arbitrary convex shapes are 2d convex shapes, with the Z component assumed to be 0.
	///For 2d boxes, the btBox2dShape is recommended.
	public class Convex2dShape : ConvexShape
	{
		private ConvexShape	m_childConvexShape;

		
		public Convex2dShape(ConvexShape convexChildShape)
		{
			m_childConvexShape = convexChildShape;
			m_shapeType = BroadphaseNativeTypes.CONVEX_2D_SHAPE_PROXYTYPE;
		}
		
		public override void Cleanup()
		{

			base.Cleanup();
		}

	
		public override Vector3	LocalGetSupportingVertexWithoutMargin(ref Vector3 vec)
		{
			return m_childConvexShape.LocalGetSupportingVertexWithoutMargin(ref vec);
		}

		public override Vector3	LocalGetSupportingVertex(ref Vector3 vec)
		{
			return m_childConvexShape.LocalGetSupportingVertex(ref vec);
		}

		public override void BatchedUnitVectorGetSupportingVertexWithoutMargin(IList<Vector3> vectors,IList<Vector4> supportVerticesOut,int numVectors)
		{
			m_childConvexShape.BatchedUnitVectorGetSupportingVertexWithoutMargin(vectors,supportVerticesOut,numVectors);
		}

		public override Vector3 CalculateLocalInertia(float mass)
		{
			return m_childConvexShape.CalculateLocalInertia(mass);
		}

		public ConvexShape GetChildShape() 
		{
			return m_childConvexShape;
		}


		public override string Name
		{
			get { return "Convex2dShape"; }
		}


		///////////////////////////


		///getAabb's default implementation is brute force, expected derived classes to implement a fast dedicated version
		public override void GetAabb(ref Matrix t,ref Vector3 aabbMin,ref Vector3 aabbMax)
		{
			m_childConvexShape.GetAabb(ref t,ref aabbMin,ref aabbMax);
		}

		public override void GetAabbSlow(ref Matrix t,ref Vector3 aabbMin,ref Vector3 aabbMax)
		{
			m_childConvexShape.GetAabbSlow(ref t,ref aabbMin,ref aabbMax);
		}

		public void SetLocalScaling(Vector3 scaling)
		{
			m_childConvexShape.SetLocalScaling(ref scaling);
		}

		public override Vector3 GetLocalScaling()
		{
			return m_childConvexShape.GetLocalScaling();
		}

		public override float Margin
		{
			set { m_childConvexShape.Margin = value; }
			get { return m_childConvexShape.Margin; }
		}

		public override int	GetNumPreferredPenetrationDirections()
		{
			return m_childConvexShape.GetNumPreferredPenetrationDirections();
		}
		
		public override void GetPreferredPenetrationDirection(int index, ref Vector3 penetrationVector)
		{
			m_childConvexShape.GetPreferredPenetrationDirection(index,ref penetrationVector);
		}


	}

}
