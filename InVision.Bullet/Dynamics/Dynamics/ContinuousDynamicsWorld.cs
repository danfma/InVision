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

using InVision.Bullet.Collision.BroadphaseCollision;
using InVision.Bullet.Collision.CollisionDispatch;
using InVision.Bullet.Dynamics.ConstraintSolver;
using InVision.GameMath;

namespace InVision.Bullet.Dynamics.Dynamics
{
    public class ContinuousDynamicsWorld : DiscreteDynamicsWorld
    {

        protected void UpdateTemporalAabbs(float timeStep)
        {

            Vector3 temporalAabbMin = Vector3.Zero, temporalAabbMax = Vector3.Zero;

	        foreach(CollisionObject colObj in m_collisionObjects)
	        {
		        RigidBody body = RigidBody.Upcast(colObj);
		        if (body != null)
		        {
			        body.GetCollisionShape().GetAabb(colObj.GetWorldTransform(),ref temporalAabbMin,ref temporalAabbMax);
			        Vector3 linvel = body.GetLinearVelocity();

			        //make the AABB temporal
                    //btScalar temporalAabbMaxx = temporalAabbMax.getX();
                    //btScalar temporalAabbMaxy = temporalAabbMax.getY();
                    //btScalar temporalAabbMaxz = temporalAabbMax.getZ();
                    //btScalar temporalAabbMinx = temporalAabbMin.getX();
                    //btScalar temporalAabbMiny = temporalAabbMin.getY();
                    //btScalar temporalAabbMinz = temporalAabbMin.getZ();

			        // add linear motion
			        Vector3 linMotion = linvel*timeStep;
        		
			        if (linMotion.X > 0f)
				        temporalAabbMax.X += linMotion.X; 
			        else
				        temporalAabbMin.X += linMotion.X;
			        if (linMotion.Y > 0)
				        temporalAabbMax.Y += linMotion.Y; 
			        else
				        temporalAabbMin.Y += linMotion.Y;
			        if (linMotion.Z > 0f)
				        temporalAabbMax.Z += linMotion.Z; 
			        else
				        temporalAabbMin.Z += linMotion.Z;

			        //add conservative angular motion
			        float angularMotion = 0f;// = angvel.length() * GetAngularMotionDisc() * timeStep;
			        Vector3 angularMotion3d = new Vector3(angularMotion,angularMotion,angularMotion);

			        temporalAabbMin -= angularMotion3d;
			        temporalAabbMax += angularMotion3d;

			        m_broadphasePairCache.SetAabb(body.GetBroadphaseHandle(),ref temporalAabbMin,ref temporalAabbMax,m_dispatcher1);
		        }
	        }

	        //update aabb (of all moved objects)
	        m_broadphasePairCache.CalculateOverlappingPairs(m_dispatcher1);
        }

        public ContinuousDynamicsWorld(IDispatcher dispatcher, IBroadphaseInterface pairCache, IConstraintSolver constraintSolver, ICollisionConfiguration collisionConfiguration)
            : base(dispatcher, pairCache, constraintSolver, collisionConfiguration)
        {
        }
        		
		///time stepping with calculation of time of impact for selected fast moving objects
        protected override void InternalSingleStepSimulation(float timeStep)
        {
            StartProfiling(timeStep);

            if (null != m_internalPreTickCallback)
            {
                m_internalPreTickCallback.InternalTickCallback(this, timeStep);
            }


            ///update aabbs information
            UpdateAabbs();
            //static int frame=0;
            //	printf("frame %d\n",frame++);

            ///apply gravity, predict motion
            PredictUnconstraintMotion(timeStep);

            DispatcherInfo  dispatchInfo = GetDispatchInfo();

            dispatchInfo.SetTimeStep(timeStep);
            dispatchInfo.SetStepCount(0);
            dispatchInfo.SetDebugDraw(GetDebugDrawer());

            ///perform collision detection
            PerformDiscreteCollisionDetection();

            CalculateSimulationIslands();

            GetSolverInfo().m_timeStep = timeStep;

            ///solve contact and other joint constraints
            SolveConstraints(GetSolverInfo());

            ///CallbackTriggers();
            CalculateTimeOfImpacts(timeStep);

            float toi = dispatchInfo.GetTimeOfImpact();
            //	if (toi < 1.f)
            //		printf("toi = %f\n",toi);
            if (toi < 0f)
                System.Console.WriteLine("toi = {0}\n", toi);


            ///integrate transforms
            IntegrateTransforms(timeStep * toi);

            ///update vehicle simulation
            UpdateActions(timeStep);

            UpdateActivationState(timeStep);

            if (m_internalTickCallback != null)
            {
                m_internalTickCallback.InternalTickCallback(this, timeStep);
            }
        }

        public virtual void CalculateTimeOfImpacts(float timeStep)
        {
		    ///these should be 'temporal' aabbs!
		    UpdateTemporalAabbs(timeStep);
    		
		    ///'toi' is the global smallest time of impact. However, we just calculate the time of impact for each object individually.
		    ///so we handle the case moving versus static properly, and we cheat for moving versus moving
		    float toi = 1f;
    		
		    DispatcherInfo dispatchInfo = GetDispatchInfo();
            dispatchInfo.SetTimeStep(timeStep);
            dispatchInfo.SetStepCount(0);
            dispatchInfo.SetTimeOfImpact(1f);
            dispatchInfo.SetDispatchFunc(DispatchFunc.DISPATCH_CONTINUOUS);

		    ///calculate time of impact for overlapping pairs

		    IDispatcher dispatcher = GetDispatcher();
		    if (dispatcher != null)
            {
			    dispatcher.DispatchAllCollisionPairs(m_broadphasePairCache.GetOverlappingPairCache(),dispatchInfo,m_dispatcher1);
            }

		    toi = dispatchInfo.GetTimeOfImpact();

            dispatchInfo.SetDispatchFunc(DispatchFunc.DISPATCH_DISCRETE);
        }

		public override DynamicsWorldType GetWorldType()
		{
            return DynamicsWorldType.BT_CONTINUOUS_DYNAMICS_WORLD;
		}
    }
}
