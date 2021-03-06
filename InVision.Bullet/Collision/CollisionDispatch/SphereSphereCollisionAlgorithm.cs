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

using System.Collections.Generic;
using InVision.Bullet.Collision.BroadphaseCollision;
using InVision.Bullet.Collision.CollisionShapes;
using InVision.Bullet.Collision.NarrowPhaseCollision;
using InVision.Bullet.LinearMath;
using InVision.GameMath;

namespace InVision.Bullet.Collision.CollisionDispatch
{
    public class SphereSphereCollisionAlgorithm : ActivatingCollisionAlgorithm
    {
	    public SphereSphereCollisionAlgorithm(PersistentManifold mf,CollisionAlgorithmConstructionInfo ci,CollisionObject body0,CollisionObject body1) : base(ci,body0,body1)
        {

        }

	    public SphereSphereCollisionAlgorithm(CollisionAlgorithmConstructionInfo ci) : base(ci)
        {

        }

	    public override void ProcessCollision (CollisionObject body0,CollisionObject body1,DispatcherInfo dispatchInfo,ManifoldResult resultOut)
        {
	        if (m_manifoldPtr == null)
            {
		        return;
            }

	        resultOut.SetPersistentManifold(m_manifoldPtr);

	        SphereShape sphere0 = (SphereShape)body0.GetCollisionShape();
	        SphereShape sphere1 = (SphereShape)body1.GetCollisionShape();

	        Vector3 diff = body0.GetWorldTransform().Translation - body1.GetWorldTransform().Translation;
	        float len = diff.Length();
	        float radius0 = sphere0.GetRadius();
	        float radius1 = sphere1.GetRadius();

        #if CLEAR_MANIFOLD
	        m_manifoldPtr.clearManifold(); //don't do this, it disables warmstarting
        #endif

	        ///iff distance positive, don't generate a new contact
	        if ( len > (radius0+radius1))
	        {
        #if !CLEAR_MANIFOLD
		        resultOut.RefreshContactPoints();
        #endif //CLEAR_MANIFOLD
		        return;
	        }
	        ///distance (negative means penetration)
	        float dist = len - (radius0+radius1);

	        Vector3 normalOnSurfaceB = new Vector3(1,0,0);
	        if (len > MathUtil.SIMD_EPSILON)
	        {
		        normalOnSurfaceB = diff / len;
	        }

	        ///point on A (worldspace)
	        ///btVector3 pos0 = col0->getWorldTransform().getOrigin() - radius0 * normalOnSurfaceB;
	        ///point on B (worldspace)
	        Vector3 pos1 = body1.GetWorldTransform().Translation + radius1* normalOnSurfaceB;

	        /// report a contact. internally this will be kept persistent, and contact reduction is done
        	
	        resultOut.AddContactPoint(ref normalOnSurfaceB,ref pos1,dist);

        #if !CLEAR_MANIFOLD
	        resultOut.RefreshContactPoints();
        #endif //CLEAR_MANIFOLD


        }

	    public override float CalculateTimeOfImpact(CollisionObject body0,CollisionObject body1,DispatcherInfo dispatchInfo,ManifoldResult resultOut)
        {
            //not yet
            return 1f;
        }

	    public override void GetAllContactManifolds(IList<PersistentManifold> manifoldArray)
	    {
		    if (m_manifoldPtr != null && m_ownManifold)
		    {
			    manifoldArray.Add(m_manifoldPtr);
		    }
	    }

        public override void Cleanup()
        {
            if (m_ownManifold)
            {
                if (m_manifoldPtr != null)
                {
                    m_dispatcher.ReleaseManifold(m_manifoldPtr);
                    m_manifoldPtr = null;
                }
                m_ownManifold = false;
            }
            m_ownManifold = false;
        }

        public bool m_ownManifold;
        public PersistentManifold m_manifoldPtr;

    }
}
