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
using InVision.GameMath;

namespace InVision.Bullet.Collision.BroadphaseCollision
{
///The btBroadphaseProxy is the main class that can be used with the Bullet broadphases. 
///It stores collision shape type information, collision filter information and a client object, typically a btCollisionObject or btRigidBody.
    public class BroadphaseProxy
    {
	    ///optional filtering to cull potential collisions

	    //Usually the client btCollisionObject or Rigidbody class
	    public Object	m_clientObject;
        public CollisionFilterGroups m_collisionFilterGroup;
        public CollisionFilterGroups m_collisionFilterMask;
        public Object m_multiSapParentProxy;
        public int m_uniqueId;//m_uniqueId is introduced for paircache. could get rid of this, by calculating the address offset etc.

        public Vector3 m_aabbMin;
        public Vector3 m_aabbMax;

	    public int GetUid()
	    {
		    return m_uniqueId;
	    }

	    //used for memory pools
	    public BroadphaseProxy()
	    {
            m_clientObject = null;
            m_multiSapParentProxy = null;
	    }

        public BroadphaseProxy(ref Vector3 aabbMin, ref Vector3 aabbMax, Object userPtr, CollisionFilterGroups collisionFilterGroup, CollisionFilterGroups collisionFilterMask, Object multiSapParentProxy)
	    {
		    m_clientObject = userPtr;
		    m_collisionFilterGroup = collisionFilterGroup;
		    m_collisionFilterMask = collisionFilterMask;
		    m_aabbMin = aabbMin;
		    m_aabbMax = aabbMax;
		    m_multiSapParentProxy = multiSapParentProxy;
	    }

        public static bool IsPolyhedral(BroadphaseNativeTypes proxyType)
	    {
		    return (proxyType < BroadphaseNativeTypes.IMPLICIT_CONVEX_SHAPES_START_HERE);
	    }

        public static bool IsConvex(BroadphaseNativeTypes proxyType)
	    {
		    return (proxyType < BroadphaseNativeTypes.CONCAVE_SHAPES_START_HERE);
	    }

        public static bool IsNonMoving(BroadphaseNativeTypes proxyType)
	    {
		    return (IsConcave(proxyType) && !(proxyType==BroadphaseNativeTypes.GIMPACT_SHAPE_PROXYTYPE));
	    }


        public static bool IsConcave(BroadphaseNativeTypes proxyType)
	    {
		    return ((proxyType > BroadphaseNativeTypes.CONCAVE_SHAPES_START_HERE) &&
			    (proxyType < BroadphaseNativeTypes.CONCAVE_SHAPES_END_HERE));
	    }
        public static bool IsCompound(BroadphaseNativeTypes proxyType)
	    {
		    return (proxyType == BroadphaseNativeTypes.COMPOUND_SHAPE_PROXYTYPE);
	    }

        public static bool IsSoftBody(BroadphaseNativeTypes proxyType)
	    {
		    return (proxyType == BroadphaseNativeTypes.SOFTBODY_SHAPE_PROXYTYPE);
	    }


        public static bool IsInfinite(BroadphaseNativeTypes proxyType)
	    {
            return (proxyType == BroadphaseNativeTypes.STATIC_PLANE_PROXYTYPE);
	    }

        public static bool IsConvex2D(BroadphaseNativeTypes proxyType)
	    {
            return (proxyType == BroadphaseNativeTypes.BOX_2D_SHAPE_PROXYTYPE) || (proxyType == BroadphaseNativeTypes.CONVEX_2D_SHAPE_PROXYTYPE);
	    }


        public Vector3 GetMinAABB()
        {
            return m_aabbMin;
        }

        public Vector3 GetMaxAABB()
        {
            return m_aabbMax;
        }

        public void SetMinAABB(ref Vector3 min)
        {
            m_aabbMin = min;
        }

        public void SetMaxAABB(ref Vector3 max)
        {
            m_aabbMax = max;
        }

        public Object GetClientObject()
        {
            return m_clientObject;
        }

        public void SetClientObject(Object o)
        {
            m_clientObject = o;
        }

        public virtual void Cleanup()
        {
        }
    }
}
