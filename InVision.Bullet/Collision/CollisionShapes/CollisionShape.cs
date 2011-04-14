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
using InVision.Bullet.Collision.BroadphaseCollision;
using InVision.GameMath;

namespace InVision.Bullet.Collision.CollisionShapes
{
	public abstract class CollisionShape
	{
		public static float gContactThresholdFactor = 0.02f;
		protected BroadphaseNativeTypes m_shapeType;
		protected Object m_userPointer;

		public CollisionShape()
		{
			m_shapeType = BroadphaseNativeTypes.INVALID_SHAPE_PROXYTYPE;
			m_userPointer = null;
		}

		public virtual string Name
		{
			get { return "Not-Defined"; }
		}

		public BroadphaseNativeTypes ShapeType
		{
			get { return m_shapeType; }
		}

		public abstract float Margin { set; get; }

		public virtual void Cleanup()
		{
		}


		///getAabb returns the axis aligned bounding box in the coordinate frame of the given transform t.
		///
		public virtual void GetAabb
			(Matrix t, ref Vector3 aabbMin, ref Vector3 aabbMax)
		{
			// t isn't assigned to as we're just getting the bounds.
			GetAabb(ref t, ref aabbMin, ref aabbMax);
		}

		public abstract void GetAabb(ref Matrix t, ref Vector3 aabbMin, ref Vector3 aabbMax);

		public virtual void GetBoundingSphere(ref Vector3 center, ref float radius)
		{
			Matrix tr = Matrix.Identity;
			var aabbMin = new Vector3();
			var aabbMax = new Vector3();

			GetAabb(ref tr, ref aabbMin, ref aabbMax);

			radius = (aabbMax - aabbMin).Length() * 0.5f;
			center = (aabbMin + aabbMax) * 0.5f;
		}

		///getAngularMotionDisc returns the maximus radius needed for Conservative Advancement to handle time-of-impact with rotations.
		public virtual float GetAngularMotionDisc()
		{
			var center = new Vector3();
			float disc = 0f;
			GetBoundingSphere(ref center, ref disc);
			disc += (center).Length();
			return disc;
		}

		public virtual float GetContactBreakingThreshold(float defaultContactThreshold)
		{
			return GetAngularMotionDisc() * defaultContactThreshold;
		}


		///calculateTemporalAabb calculates the enclosing aabb for the moving object over interval [0..timeStep)
		///result is conservative
		public void CalculateTemporalAabb(ref Matrix curTrans, ref Vector3 linvel, ref Vector3 angvel, float timeStep,
										  ref Vector3 temporalAabbMin, ref Vector3 temporalAabbMax)
		{
			//start with static aabb
			GetAabb(ref curTrans, ref temporalAabbMin, ref temporalAabbMax);

			float temporalAabbMaxx = temporalAabbMax.X;
			float temporalAabbMaxy = temporalAabbMax.Y;
			float temporalAabbMaxz = temporalAabbMax.Z;
			float temporalAabbMinx = temporalAabbMin.X;
			float temporalAabbMiny = temporalAabbMin.Y;
			float temporalAabbMinz = temporalAabbMin.Z;

			// add linear motion
			Vector3 linMotion = linvel * timeStep;
			///@todo: simd would have a vector max/min operation, instead of per-element access
			if (linMotion.X > 0f)
				temporalAabbMaxx += linMotion.X;
			else
				temporalAabbMinx += linMotion.X;
			if (linMotion.Y > 0f)
				temporalAabbMaxy += linMotion.Y;
			else
				temporalAabbMiny += linMotion.Y;
			if (linMotion.Z > 0f)
				temporalAabbMaxz += linMotion.Z;
			else
				temporalAabbMinz += linMotion.Z;

			//add conservative angular motion
			float angularMotion = angvel.Length() * GetAngularMotionDisc() * timeStep;
			var angularMotion3d = new Vector3(angularMotion, angularMotion, angularMotion);
			temporalAabbMin = new Vector3(temporalAabbMinx, temporalAabbMiny, temporalAabbMinz);
			temporalAabbMax = new Vector3(temporalAabbMaxx, temporalAabbMaxy, temporalAabbMaxz);

			temporalAabbMin -= angularMotion3d;
			temporalAabbMax += angularMotion3d;
		}

		public bool IsPolyhedral()
		{
			return BroadphaseProxy.IsPolyhedral(ShapeType);
		}

		public bool IsConvex()
		{
			return BroadphaseProxy.IsConvex(ShapeType);
		}

		public bool IsNonMoving()
		{
			return BroadphaseProxy.IsNonMoving(ShapeType);
		}

		public bool IsConvex2D()
		{
			return BroadphaseProxy.IsConvex2D(ShapeType);
		}

		public bool IsConcave()
		{
			return BroadphaseProxy.IsConcave(ShapeType);
		}

		public bool IsCompound()
		{
			return BroadphaseProxy.IsCompound(ShapeType);
		}

		public bool IsSoftBody()
		{
			return BroadphaseProxy.IsSoftBody(ShapeType);
		}

		///isInfinite is used to catch simulation error (aabb check)
		public bool IsInfinite()
		{
			return BroadphaseProxy.IsInfinite(ShapeType);
		}

		// defining these as virtual rather then abstract as the whole impementation agains _SPU_ seems odd
		public virtual void SetLocalScaling(ref Vector3 scaling)
		{
		}

		public virtual Vector3 GetLocalScaling()
		{
			return new Vector3(1, 1, 1);
		}

		public virtual Vector3 CalculateLocalInertia(float mass)
		{
			return Vector3.Zero;
		}

		//debugging support

		///optional user data pointer
		public void SetUserPointer(Object userPtr)
		{
			m_userPointer = userPtr;
		}

		public Object GetUserPointer()
		{
			return m_userPointer;
		}
	}
}