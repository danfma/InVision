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

using System.Collections.Generic;
using InVision.Bullet.Collision.BroadphaseCollision;
using InVision.Bullet.Collision.CollisionShapes;
using InVision.Bullet.Debuging.Drawers;
using InVision.Bullet.Dynamics.ConstraintSolver;
using InVision.Bullet.LinearMath;
using InVision.GameMath;

namespace InVision.Bullet.Debuging
{
	public class DrawHelper
	{
		private static readonly Dictionary<TypedConstraintType, IConstraintTypeDrawer> ConstraintDrawers;

		public static short[] s_cubeIndices = new short[] {
			0, 1, 2, 2, 3, 0,	// face A
			0, 1, 5, 5, 4, 0,	// face B
			1, 2, 6, 6, 5, 1,	// face c
			2, 6, 7, 7, 3, 2,	// face d
			3, 7, 4, 4, 0, 3,	// face e
			4, 5, 6, 6, 7, 4	// face f
		}; 

		/// <summary>
		/// Initializes the <see cref="DrawHelper"/> class.
		/// </summary>
		static DrawHelper()
		{
			ConstraintDrawers = new Dictionary<TypedConstraintType, IConstraintTypeDrawer>();
			ConstraintDrawers.Add(TypedConstraintType.POINT2POINT_CONSTRAINT_TYPE, new Point2PointConstraintTypeDrawer());
			ConstraintDrawers.Add(TypedConstraintType.HINGE_CONSTRAINT_TYPE, new HingeConstraintTypeDrawer());
			ConstraintDrawers.Add(TypedConstraintType.CONETWIST_CONSTRAINT_TYPE, new ConeTwistConstraintTypeDrawer());
			ConstraintDrawers.Add(TypedConstraintType.D6_CONSTRAINT_TYPE, new D6ConstraintTypeDrawer());
			ConstraintDrawers.Add(TypedConstraintType.SLIDER_CONSTRAINT_TYPE, new SliderConstraintTypeDrawer());
		}

		private DrawHelper()
		{
		}

		public static void DebugDrawObject(ref Matrix worldTransform, CollisionShape shape, ref Vector3 color,
										   IDebugDraw debugDraw)
		{
			// Draw a small simplex at the center of the object
			{
				Vector3 start = worldTransform.Translation;
				float scale = 10f;
				debugDraw.DrawLine(start, start + (Vector3.TransformNormal(Vector3.Right, worldTransform) * scale), Vector3.Right);
				debugDraw.DrawLine(start, start + (Vector3.TransformNormal(Vector3.Up, worldTransform) * scale), Vector3.Up);
				debugDraw.DrawLine(start, start + (Vector3.TransformNormal(Vector3.Backward, worldTransform) * scale),
								   Vector3.Backward);
			}
			//return;
			if (shape.ShapeType == BroadphaseNativeTypes.COMPOUND_SHAPE_PROXYTYPE)
			{
				var compoundShape = (CompoundShape)shape;
				for (int i = compoundShape.GetNumChildShapes() - 1; i >= 0; i--)
				{
					Matrix childTrans = compoundShape.GetChildTransform(i);
					CollisionShape colShape = compoundShape.GetChildShape(i);
					Matrix temp = MathUtil.BulletMatrixMultiply(worldTransform, childTrans);
					DebugDrawObject(ref temp, colShape, ref color, debugDraw);
				}
			}
			else
			{
				switch (shape.ShapeType)
				{
					case BroadphaseNativeTypes.SPHERE_SHAPE_PROXYTYPE:
						{
							var sphereShape = (SphereShape)shape;
							float radius = sphereShape.Margin; //radius doesn't include the margin, so draw with margin
							DebugDrawSphere(radius, ref worldTransform, ref color, debugDraw);
							break;
						}
					case BroadphaseNativeTypes.MULTI_SPHERE_SHAPE_PROXYTYPE:
						{
							var multiSphereShape = (MultiSphereShape)shape;

							for (int i = multiSphereShape.GetSphereCount() - 1; i >= 0; i--)
							{
								Matrix childTransform = worldTransform;
								childTransform.Translation += multiSphereShape.GetSpherePosition(i);
								DebugDrawSphere(multiSphereShape.GetSphereRadius(i), ref childTransform, ref color, debugDraw);
							}

							break;
						}
					case BroadphaseNativeTypes.CAPSULE_SHAPE_PROXYTYPE:
						{
							var capsuleShape = (CapsuleShape)shape;

							float radius = capsuleShape.getRadius();
							float halfHeight = capsuleShape.getHalfHeight();

							int upAxis = capsuleShape.GetUpAxis();

							Vector3 capStart = Vector3.Zero;
							;
							MathUtil.VectorComponent(ref capStart, upAxis, -halfHeight);

							Vector3 capEnd = Vector3.Zero;
							MathUtil.VectorComponent(ref capEnd, upAxis, halfHeight);

							// Draw the ends
							{
								Matrix childTransform = worldTransform;
								childTransform.Translation = Vector3.Transform(capStart, worldTransform);
								DebugDrawSphere(radius, ref childTransform, ref color, debugDraw);
							}

							{
								Matrix childTransform = worldTransform;
								childTransform.Translation = Vector3.Transform(capEnd, worldTransform);
								DebugDrawSphere(radius, ref childTransform, ref color, debugDraw);
							}

							// Draw some additional lines
							Vector3 start = worldTransform.Translation;

							MathUtil.VectorComponent(ref capStart, (upAxis + 1) % 3, radius);
							MathUtil.VectorComponent(ref capEnd, (upAxis + 1) % 3, radius);
							debugDraw.DrawLine(start + Vector3.TransformNormal(capStart, worldTransform),
											   start + Vector3.TransformNormal(capEnd, worldTransform), color);

							MathUtil.VectorComponent(ref capStart, (upAxis + 1) % 3, -radius);
							MathUtil.VectorComponent(ref capEnd, (upAxis + 1) % 3, -radius);
							debugDraw.DrawLine(start + Vector3.TransformNormal(capStart, worldTransform),
											   start + Vector3.TransformNormal(capEnd, worldTransform), color);

							MathUtil.VectorComponent(ref capStart, (upAxis + 1) % 3, radius);
							MathUtil.VectorComponent(ref capEnd, (upAxis + 1) % 3, radius);

							MathUtil.VectorComponent(ref capStart, (upAxis + 2) % 3, radius);
							MathUtil.VectorComponent(ref capEnd, (upAxis + 2) % 3, radius);
							debugDraw.DrawLine(start + Vector3.TransformNormal(capStart, worldTransform),
											   start + Vector3.TransformNormal(capEnd, worldTransform), color);

							MathUtil.VectorComponent(ref capStart, (upAxis + 2) % 3, -radius);
							MathUtil.VectorComponent(ref capEnd, (upAxis + 2) % 3, -radius);
							debugDraw.DrawLine(start + Vector3.TransformNormal(capStart, worldTransform),
											   start + Vector3.TransformNormal(capEnd, worldTransform), color);

							break;
						}
					case BroadphaseNativeTypes.CONE_SHAPE_PROXYTYPE:
						{
							var coneShape = (ConeShape)shape;
							float radius = coneShape.GetRadius(); //+coneShape->getMargin();
							float height = coneShape.GetHeight(); //+coneShape->getMargin();
							Vector3 start = worldTransform.Translation;

							int upAxis = coneShape.GetConeUpIndex();


							Vector3 offsetHeight = Vector3.Zero;
							MathUtil.VectorComponent(ref offsetHeight, upAxis, height * 0.5f);
							Vector3 offsetRadius = Vector3.Zero;
							MathUtil.VectorComponent(ref offsetRadius, (upAxis + 1) % 3, radius);

							Vector3 offset2Radius = Vector3.Zero;
							MathUtil.VectorComponent(ref offsetRadius, (upAxis + 2) % 3, radius);

							debugDraw.DrawLine(start + Vector3.TransformNormal(offsetHeight, worldTransform),
											   start + Vector3.TransformNormal(-offsetHeight + offsetRadius, worldTransform), color);
							debugDraw.DrawLine(start + Vector3.TransformNormal(offsetHeight, worldTransform),
											   start + Vector3.TransformNormal(-offsetHeight - offsetRadius, worldTransform), color);
							debugDraw.DrawLine(start + Vector3.TransformNormal(offsetHeight, worldTransform),
											   start + Vector3.TransformNormal(-offsetHeight + offset2Radius, worldTransform), color);
							debugDraw.DrawLine(start + Vector3.TransformNormal(offsetHeight, worldTransform),
											   start + Vector3.TransformNormal(-offsetHeight - offset2Radius, worldTransform), color);

							break;
						}
					case BroadphaseNativeTypes.CYLINDER_SHAPE_PROXYTYPE:
						{
							var cylinder = (CylinderShape)shape;
							int upAxis = cylinder.GetUpAxis();
							float radius = cylinder.GetRadius();

							float halfHeight = MathUtil.VectorComponent(cylinder.GetHalfExtentsWithMargin(), upAxis);
							Vector3 start = worldTransform.Translation;
							Vector3 offsetHeight = Vector3.Zero;
							MathUtil.VectorComponent(ref offsetHeight, upAxis, halfHeight);
							Vector3 offsetRadius = Vector3.Zero;
							MathUtil.VectorComponent(ref offsetRadius, (upAxis + 1) % 3, radius);
							debugDraw.DrawLine(start + Vector3.TransformNormal(offsetHeight + offsetRadius, worldTransform),
											   start + Vector3.TransformNormal(-offsetHeight + offsetRadius, worldTransform), color);
							debugDraw.DrawLine(start + Vector3.TransformNormal(offsetHeight - offsetRadius, worldTransform),
											   start + Vector3.TransformNormal(-offsetHeight - offsetRadius, worldTransform), color);
							break;
						}

					case BroadphaseNativeTypes.STATIC_PLANE_PROXYTYPE:
						{
							var staticPlaneShape = (StaticPlaneShape)shape;
							float planeConst = staticPlaneShape.GetPlaneConstant();
							Vector3 planeNormal = staticPlaneShape.GetPlaneNormal();
							Vector3 planeOrigin = planeNormal * planeConst;
							Vector3 vec0 = Vector3.Zero, vec1 = Vector3.Zero;
							TransformUtil.PlaneSpace1(ref planeNormal, ref vec0, ref vec1);
							float vecLen = 100f;
							Vector3 pt0 = planeOrigin + vec0 * vecLen;
							Vector3 pt1 = planeOrigin - vec0 * vecLen;
							Vector3 pt2 = planeOrigin + vec1 * vecLen;
							Vector3 pt3 = planeOrigin - vec1 * vecLen;
							debugDraw.DrawLine(Vector3.Transform(pt0, worldTransform), Vector3.Transform(pt1, worldTransform), color);
							debugDraw.DrawLine(Vector3.Transform(pt2, worldTransform), Vector3.Transform(pt3, worldTransform), color);
							break;
						}
					//case (BroadphaseNativeTypes.BOX_SHAPE_PROXYTYPE):
					//    {
					//        BoxShape boxShape = (BoxShape)shape;
					//        Vector3 minPos = Vector3.Zero;
					//        Vector3 maxPos = Vector3.Zero;
					//        Matrix transform = Matrix.Identity;
					//        boxShape.getAabb(ref transform, ref minPos,ref maxPos);
					//        debugDraw.drawBox(ref minPos, ref maxPos, ref worldTransform, ref color);
					//        break;

					//    }
					default:
						{
							if (shape.IsConcave())
							{
								var concaveMesh = (ConcaveShape)shape;

								///@todo pass camera, for some culling? no -> we are not a graphics lib
								Vector3 aabbMax = MathUtil.MAX_VECTOR;
								Vector3 aabbMin = MathUtil.MIN_VECTOR;

								var drawCallback = new DebugDrawcallback(debugDraw, ref worldTransform, ref color);
								concaveMesh.ProcessAllTriangles(drawCallback, ref aabbMin, ref aabbMax);
								drawCallback.Cleanup();
							}
							else if (shape.ShapeType == BroadphaseNativeTypes.CONVEX_TRIANGLEMESH_SHAPE_PROXYTYPE)
							{
								var convexMesh = (ConvexTriangleMeshShape)shape;
								//todo: pass camera for some culling			
								Vector3 aabbMax = MathUtil.MAX_VECTOR;
								Vector3 aabbMin = MathUtil.MIN_VECTOR;

								//DebugDrawcallback drawCallback;
								var drawCallback = new DebugDrawcallback(debugDraw, ref worldTransform, ref color);
								convexMesh.GetMeshInterface().InternalProcessAllTriangles(drawCallback, ref aabbMin, ref aabbMax);
								drawCallback.Cleanup();
							}
							else /// for polyhedral shapes
								if (shape.IsPolyhedral())
								{
									var polyshape = (PolyhedralConvexShape)shape;

									for (int i = 0; i < polyshape.GetNumEdges(); i++)
									{
										Vector3 a = Vector3.Zero, b = Vector3.Zero;
										polyshape.GetEdge(i, ref a, ref b);
										Vector3 wa = Vector3.Transform(a, worldTransform);
										Vector3 wb = Vector3.Transform(b, worldTransform);
										debugDraw.DrawLine(ref wa, ref wb, ref color);
									}
								}
							break;
						}
				}
			}
		}

		public static void DebugDrawConstraint(TypedConstraint constraint, IDebugDraw debugDraw)
		{
			bool drawFrames = (debugDraw.GetDebugMode() & DebugDrawModes.DBG_DrawConstraints) != 0;
			bool drawLimits = (debugDraw.GetDebugMode() & DebugDrawModes.DBG_DrawConstraintLimits) != 0;
			float dbgDrawSize = constraint.GetDbgDrawSize();

			if (dbgDrawSize <= 0f)
				return;

			IConstraintTypeDrawer constraintTypeDrawer;

			if (!ConstraintDrawers.TryGetValue(constraint.GetConstraintType(), out constraintTypeDrawer))
				return;

			constraintTypeDrawer.DrawFrames = drawFrames;
			constraintTypeDrawer.DrawLimits = drawLimits;
			constraintTypeDrawer.DrawSize = dbgDrawSize;
			constraintTypeDrawer.Draw(constraint, debugDraw);
		}


		protected static void DebugDrawSphere(float radius, ref Matrix transform, ref Vector3 color, IDebugDraw debugDraw)
		{
			Vector3 start = transform.Translation;

			Vector3 xoffs = Vector3.TransformNormal(new Vector3(radius, 0, 0), transform);
			Vector3 yoffs = Vector3.TransformNormal(new Vector3(0, radius, 0), transform);
			Vector3 zoffs = Vector3.TransformNormal(new Vector3(0, 0, radius), transform);

			// XY 
			debugDraw.DrawLine(start - xoffs, start + yoffs, color);
			debugDraw.DrawLine(start + yoffs, start + xoffs, color);
			debugDraw.DrawLine(start + xoffs, start - yoffs, color);
			debugDraw.DrawLine(start - yoffs, start - xoffs, color);

			// XZ
			debugDraw.DrawLine(start - xoffs, start + zoffs, color);
			debugDraw.DrawLine(start + zoffs, start + xoffs, color);
			debugDraw.DrawLine(start + xoffs, start - zoffs, color);
			debugDraw.DrawLine(start - zoffs, start - xoffs, color);

			// YZ
			debugDraw.DrawLine(start - yoffs, start + zoffs, color);
			debugDraw.DrawLine(start + zoffs, start + yoffs, color);
			debugDraw.DrawLine(start + yoffs, start - zoffs, color);
			debugDraw.DrawLine(start - zoffs, start - yoffs, color);
		}

		#region Unused methods

		//public static ShapeData CreateCube()
		//{
		//    Matrix identity = Matrix.Identity;

		//    return CreateBox(Vector3.Zero, new Vector3(1, 1, 1), Color.Yellow, ref identity);
		//}

		//public static ShapeData CreateBox(Vector3 position, Vector3 sideLength, Color color, ref Matrix transform)
		//{
		//    var shapeData = new ShapeData(8, 36);
		//    int index = 0;
		//    shapeData.m_verticesArray[index++] =
		//        new VertexPositionColor(Vector3.Transform(position + new Vector3(0, 0, 0), transform), color);
		//    shapeData.m_verticesArray[index++] =
		//        new VertexPositionColor(Vector3.Transform(position + new Vector3(sideLength.X, 0, 0), transform), color);
		//    shapeData.m_verticesArray[index++] =
		//        new VertexPositionColor(Vector3.Transform(position + new Vector3(sideLength.X, 0, sideLength.Z), transform), color);
		//    shapeData.m_verticesArray[index++] =
		//        new VertexPositionColor(Vector3.Transform(position + new Vector3(0, 0, sideLength.Z), transform), color);
		//    shapeData.m_verticesArray[index++] =
		//        new VertexPositionColor(Vector3.Transform(position + new Vector3(0, sideLength.Y, 0), transform), color);
		//    shapeData.m_verticesArray[index++] =
		//        new VertexPositionColor(Vector3.Transform(position + new Vector3(sideLength.X, sideLength.Y, 0), transform), color);
		//    shapeData.m_verticesArray[index++] =
		//        new VertexPositionColor(
		//            Vector3.Transform(position + new Vector3(sideLength.X, sideLength.Y, sideLength.Z), transform), color);
		//    shapeData.m_verticesArray[index++] =
		//        new VertexPositionColor(Vector3.Transform(position + new Vector3(0, sideLength.Y, sideLength.Z), transform), color);
		//    shapeData.m_indexArray = s_cubeIndices;
		//    return shapeData;
		//}

		//public static ShapeData CreateSphere(int slices, int stacks, float radius, Color color)
		//{
		//    var shapeData = new ShapeData((slices + 1) * (stacks + 1), (slices * stacks * 6));

		//    float phi = 0f;
		//    float theta = 0f;
		//    ;
		//    float deltaPhi = MathHelper.Pi / stacks;
		//    float dtheta = MathHelper.TwoPi / slices;
		//    float x, y, z, sc;

		//    short index = 0;

		//    for (int stack = 0; stack <= stacks; stack++)
		//    {
		//        phi = MathHelper.PiOver2 - (stack * deltaPhi);
		//        y = radius * (float)System.Math.Sin(phi);
		//        sc = -radius * (float)System.Math.Cos(phi);

		//        for (int slice = 0; slice <= slices; slice++)
		//        {
		//            theta = slice * dtheta;
		//            x = sc * (float)System.Math.Sin(theta);
		//            z = sc * (float)System.Math.Cos(theta);

		//            //s_sphereVertices[index++] = new VertexPositionNormalTexture(new Vector3(x, y, z),
		//            //                            new Vector3(x, y, z),
		//            //                            new Vector2((float)slice / (float)slices, (float)stack / (float)stacks));

		//            shapeData.m_verticesArray[index++] = new VertexPositionColor(new Vector3(x, y, z), color);
		//        }
		//    }

		//    int stride = slices + 1;
		//    index = 0;
			
		//    for (int stack = 0; stack < stacks; stack++)
		//    {
		//        for (int slice = 0; slice < slices; slice++)
		//        {
		//            shapeData.m_indexList[index++] = (short)((stack + 0) * stride + slice);
		//            shapeData.m_indexList[index++] = (short)((stack + 1) * stride + slice);
		//            shapeData.m_indexList[index++] = (short)((stack + 0) * stride + slice + 1);

		//            shapeData.m_indexList[index++] = (short)((stack + 0) * stride + slice + 1);
		//            shapeData.m_indexList[index++] = (short)((stack + 1) * stride + slice);
		//            shapeData.m_indexList[index++] = (short)((stack + 1) * stride + slice + 1);
		//        }
		//    }

		//    return shapeData;
		//}

		#endregion
	}
}