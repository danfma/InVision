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
using System.Diagnostics;
using InVision.Bullet.Collision.BroadphaseCollision;
using InVision.Bullet.Collision.CollisionDispatch;
using InVision.Bullet.Collision.CollisionShapes;
using InVision.Bullet.Debuging;
using InVision.Bullet.Dynamics.ConstraintSolver;
using InVision.Bullet.LinearMath;
using InVision.GameMath;

namespace InVision.Bullet.Dynamics.Dynamics
{
	public class DiscreteDynamicsWorld : DynamicsWorld
	{
		///this btDiscreteDynamicsWorld constructor gets created objects from the user, and will not delete those
		public DiscreteDynamicsWorld(IDispatcher dispatcher, IBroadphaseInterface pairCache, IConstraintSolver constraintSolver, ICollisionConfiguration collisionConfiguration)
			: base(dispatcher, pairCache, collisionConfiguration)
		{
			m_ownsIslandManager = true;
			m_constraints = new ObjectArray<TypedConstraint>();
			m_actions = new List<IActionInterface>();
			m_nonStaticRigidBodies = new ObjectArray<RigidBody>();
			m_islandManager = new SimulationIslandManager();
			m_constraintSolver = constraintSolver;

			Gravity = new Vector3(0, -10, 0);
			m_localTime = 1f / 60f;
			m_profileTimings = 0;
			m_synchronizeAllMotionStates = false;

			if (m_constraintSolver == null)
			{
				m_constraintSolver = new SequentialImpulseConstraintSolver();
				m_ownsConstraintSolver = true;
			}
			else
			{
				m_ownsConstraintSolver = false;
			}
		}

		public override void Cleanup()
		{
			base.Cleanup();
			//only delete it when we created it
			if (m_ownsIslandManager)
			{
				m_islandManager.Cleanup();
				m_islandManager = null;
				m_ownsIslandManager = false;
			}
			if (m_ownsConstraintSolver)
			{
				m_constraintSolver.Cleanup();
				m_constraintSolver = null;
				m_ownsConstraintSolver = false;
			}
		}

		///if maxSubSteps > 0, it will interpolate motion between fixedTimeStep's
		public override int StepSimulation(float timeStep, int maxSubSteps)
		{
			return StepSimulation(timeStep, maxSubSteps, s_fixedTimeStep);
		}

		public override int StepSimulation(float timeStep, int maxSubSteps, float fixedTimeStep)
		{
			StartProfiling(timeStep);

			//BT_PROFILE("stepSimulation");

			int numSimulationSubSteps = 0;

			if (maxSubSteps != 0)
			{
				//fixed timestep with interpolation
				m_localTime += timeStep;
				if (m_localTime >= fixedTimeStep)
				{
					numSimulationSubSteps = (int)(m_localTime / fixedTimeStep);
					m_localTime -= numSimulationSubSteps * fixedTimeStep;
				}
			}
			else
			{
				//variable timestep
				fixedTimeStep = timeStep;
				m_localTime = timeStep;
				if (MathUtil.FuzzyZero(timeStep))
				{
					numSimulationSubSteps = 0;
					maxSubSteps = 0;
				}
				else
				{
					numSimulationSubSteps = 1;
					maxSubSteps = 1;
				}
			}

			//process some debugging flags
			if (GetDebugDrawer() != null)
			{
				IDebugDraw debugDrawer = GetDebugDrawer();
				BulletGlobals.gDisableDeactivation = ((debugDrawer.GetDebugMode() & DebugDrawModes.DBG_NoDeactivation) != 0);
			}
			if (numSimulationSubSteps != 0)
			{

				//clamp the number of substeps, to prevent simulation grinding spiralling down to a halt
				int clampedSimulationSteps = (numSimulationSubSteps > maxSubSteps) ? maxSubSteps : numSimulationSubSteps;

				SaveKinematicState(fixedTimeStep * clampedSimulationSteps);

				ApplyGravity();

				for (int i = 0; i < clampedSimulationSteps; i++)
				{
					InternalSingleStepSimulation(fixedTimeStep);
					SynchronizeMotionStates();
				}

			}
			else
			{
				SynchronizeMotionStates();
			}
			ClearForces();

			if (m_profileManager != null)
			{
				m_profileManager.Increment_Frame_Counter();
			}

			return numSimulationSubSteps;
		}


		public override void SynchronizeMotionStates()
		{
			if (m_synchronizeAllMotionStates)
			{
				//iterate  over all collision objects
				int length = m_collisionObjects.Count;
				for (int i = 0; i < length; ++i)
				{
					RigidBody body = RigidBody.Upcast(m_collisionObjects[i]);
					if (body != null)
					{
						SynchronizeSingleMotionState(body);
					}
				}
			}
			else
			{
				//iterate over all active rigid bodies
				int length = m_nonStaticRigidBodies.Count;
				for (int i = 0; i < length; ++i)
				{
					RigidBody body = m_nonStaticRigidBodies[i];
					if (body.IsActive())
					{
						SynchronizeSingleMotionState(body);
					}
				}
			}
		}

		///this can be useful to synchronize a single rigid body . graphics object
		public void SynchronizeSingleMotionState(RigidBody body)
		{
			Debug.Assert(body != null);

			if (body.GetMotionState() != null && !body.IsStaticOrKinematicObject())
			{
				//we need to call the update at least once, even for sleeping objects
				//otherwise the 'graphics' transform never updates properly
				///@todo: add 'dirty' flag
				//if (body.getActivationState() != ISLAND_SLEEPING)
				{
					Matrix interpolatedTransform = Matrix.Identity;
					TransformUtil.IntegrateTransform(body.GetInterpolationWorldTransform(),
						body.SetInterpolationLinearVelocity(), body.GetInterpolationAngularVelocity(),
						m_localTime * body.GetHitFraction(), ref interpolatedTransform);
					body.GetMotionState().SetWorldTransform(ref interpolatedTransform);
				}
			}
		}

		public override void AddConstraint(TypedConstraint constraint, bool disableCollisionsBetweenLinkedBodies)
		{
			//if (constraint is ConeTwistConstraint)
			//if (constraint is HingeConstraint)
			//{
			//    return;
			//}
			m_constraints.Add(constraint);
			if (disableCollisionsBetweenLinkedBodies)
			{
				constraint.GetRigidBodyA().AddConstraintRef(constraint);
				constraint.GetRigidBodyB().AddConstraintRef(constraint);
			}
		}

		public override void RemoveConstraint(TypedConstraint constraint)
		{
			m_constraints.Remove(constraint);
			constraint.GetRigidBodyA().RemoveConstraintRef(constraint);
			constraint.GetRigidBodyB().RemoveConstraintRef(constraint);
		}

		public override void AddAction(IActionInterface action)
		{
			m_actions.Add(action);
		}

		public override void RemoveAction(IActionInterface action)
		{
			m_actions.Remove(action);
		}

		public SimulationIslandManager GetSimulationIslandManager()
		{
			return m_islandManager;
		}

		public CollisionWorld GetCollisionWorld()
		{
			return this;
		}

		public override Vector3 Gravity
		{
			get { return m_gravity; }
			set
			{
				m_gravity = value;

				int length = m_nonStaticRigidBodies.Count;

				for (int i = 0; i < length; ++i)
				{
					RigidBody body = m_nonStaticRigidBodies[i];

					if (body.IsActive() && ((body.GetFlags() & RigidBodyFlags.BT_DISABLE_WORLD_GRAVITY) != 0))
						body.Gravity = value;
				}
			}
		}

		public override void AddCollisionObject(CollisionObject collisionObject)
		{
			AddCollisionObject(collisionObject, CollisionFilterGroups.StaticFilter, CollisionFilterGroups.AllFilter ^ CollisionFilterGroups.StaticFilter);
		}
		public override void AddCollisionObject(CollisionObject collisionObject, CollisionFilterGroups collisionFilterGroup, CollisionFilterGroups collisionFilterMask)
		{
			base.AddCollisionObject(collisionObject, collisionFilterGroup, collisionFilterMask);
		}

		///removeCollisionObject will first check if it is a rigid body, if so call removeRigidBody otherwise call btCollisionWorld::removeCollisionObject
		public override void RemoveCollisionObject(CollisionObject collisionObject)
		{
			RigidBody body = RigidBody.Upcast(collisionObject);
			if (body != null)
			{
				RemoveRigidBody(body);
			}
			else
			{
				base.RemoveCollisionObject(collisionObject);
			}
		}

		public void SetSynchronizeAllMotionStates(bool synchronizeAll)
		{
			m_synchronizeAllMotionStates = synchronizeAll;
		}

		public bool GetSynchronizeAllMotionStates()
		{
			return m_synchronizeAllMotionStates;
		}


		public override void AddRigidBody(RigidBody body)
		{
			if (!body.IsStaticOrKinematicObject() && 0 == (body.GetFlags() & RigidBodyFlags.BT_DISABLE_WORLD_GRAVITY))
				body.Gravity = m_gravity;

			if (body.GetCollisionShape() != null)
			{
				if (!body.IsStaticObject())
				{
					m_nonStaticRigidBodies.Add(body);
				}
				else
				{
					body.SetActivationState(ActivationState.ISLAND_SLEEPING);
				}

				bool isDynamic = !(body.IsStaticObject() || body.IsKinematicObject());
				CollisionFilterGroups collisionFilterGroup = isDynamic ? CollisionFilterGroups.DefaultFilter : CollisionFilterGroups.StaticFilter;
				CollisionFilterGroups collisionFilterMask = isDynamic ? CollisionFilterGroups.AllFilter : (CollisionFilterGroups.AllFilter ^ CollisionFilterGroups.StaticFilter);

				AddCollisionObject(body, collisionFilterGroup, collisionFilterMask);
			}
		}

		public virtual void AddRigidBody(RigidBody body, CollisionFilterGroups group, CollisionFilterGroups mask)
		{
			if (!body.IsStaticOrKinematicObject() && 0 == (body.GetFlags() & RigidBodyFlags.BT_DISABLE_WORLD_GRAVITY))
				body.Gravity = m_gravity;

			if (body.GetCollisionShape() != null)
			{
				if (!body.IsStaticObject())
				{
					m_nonStaticRigidBodies.Add(body);
				}
				else
				{
					body.SetActivationState(ActivationState.ISLAND_SLEEPING);
				}

				AddCollisionObject(body, group, mask);
			}
		}

		public override void RemoveRigidBody(RigidBody body)
		{
			m_nonStaticRigidBodies.Remove(body);
			base.RemoveCollisionObject(body);
		}

		public override void DebugDrawWorld()
		{
			//BT_PROFILE("debugDrawWorld");
			//base.debugDrawWorld();
			//if (getDebugDrawer() != null && ((getDebugDrawer().getDebugMode() & DebugDrawModes.DBG_DrawContactPoints) != 0))
			//{
			//    int numManifolds = getDispatcher().getNumManifolds();
			//    Vector3 color = Vector3.Zero;
			//    for (int i=0;i<numManifolds;i++)
			//    {
			//        PersistentManifold contactManifold = getDispatcher().getManifoldByIndexInternal(i);
			//        //btCollisionObject* obA = static_cast<btCollisionObject*>(contactManifold.getBody0());
			//        //btCollisionObject* obB = static_cast<btCollisionObject*>(contactManifold.getBody1());

			//        int numContacts = contactManifold.getNumContacts();
			//        for (int j=0;j<numContacts;j++)
			//        {
			//            ManifoldPoint cp = contactManifold.getContactPoint(j);
			//            getDebugDrawer().drawContactPoint(cp.getPositionWorldOnB(),cp.getNormalWorldOnB(),cp.getDistance(),cp.getLifeTime(),color);
			//        }
			//    }
			//}
			bool drawConstraints = false;
			if (GetDebugDrawer() != null)
			{
				DebugDrawModes mode = GetDebugDrawer().GetDebugMode();
				if ((mode & (DebugDrawModes.DBG_DrawConstraints | DebugDrawModes.DBG_DrawConstraintLimits)) != 0)
				{
					drawConstraints = true;
				}
			}

			if (drawConstraints)
			{
				for (int i = GetNumConstraints() - 1; i >= 0; i--)
				{
					TypedConstraint constraint = GetConstraint(i);
					DrawHelper.DebugDrawConstraint(constraint, GetDebugDrawer());
				}
			}

			if (GetDebugDrawer() != null)
			{
				DebugDrawModes debugMode = GetDebugDrawer().GetDebugMode();
				bool wireFrame = (debugMode & DebugDrawModes.DBG_DrawWireframe) != 0;
				bool aabb = (debugMode & DebugDrawModes.DBG_DrawAabb) != 0;

				if (wireFrame || aabb)
				{
					int length = m_collisionObjects.Count;
					for (int i = 0; i < length; ++i)
					{
						CollisionObject colObj = m_collisionObjects[i];

						if (wireFrame)
						{
							Vector3 color = new Vector3(255, 255, 255);
							switch (colObj.GetActivationState())
							{
								case ActivationState.ACTIVE_TAG:
									{
										color = new Vector3(255, 255, 255);
										break;
									}
								case ActivationState.ISLAND_SLEEPING:
									{
										color = new Vector3(0, 255, 0);
										break;
									}
								case ActivationState.WANTS_DEACTIVATION:
									{
										color = new Vector3(0, 255, 255);
										break;
									}
								case ActivationState.DISABLE_DEACTIVATION:
									{
										color = new Vector3(255, 0, 0);
										break;
									}
								case ActivationState.DISABLE_SIMULATION:
									{
										color = new Vector3(255, 255, 0);
										break;
									}

								default:
									{
										color = new Vector3(255, 0, 0);
										break;
									}
							};
							Matrix transform = colObj.GetWorldTransform();
							//DrawHelper.debugDrawObject(ref transform, colObj.getCollisionShape(), ref color, getDebugDrawer());
						}
						if (aabb)
						{
							Vector3 minAabb = Vector3.Zero, maxAabb = Vector3.Zero;
							Vector3 colorvec = new Vector3(1, 0, 0);
							colObj.GetCollisionShape().GetAabb(colObj.GetWorldTransform(), ref minAabb, ref maxAabb);
							m_debugDrawer.DrawAabb(ref minAabb, ref maxAabb, ref colorvec);
						}

					}

					if (debugMode != 0)
					{
						int length2 = m_actions.Count;
						for (int i = 0; i < length2; ++i)
						{
							m_actions[i].DebugDraw(m_debugDrawer);
						}
					}
				}
			}
		}

		public override void SetConstraintSolver(IConstraintSolver solver)
		{
			//if (m_ownsConstraintSolver)
			//{
			//    btAlignedFree( m_constraintSolver);
			//}
			m_ownsConstraintSolver = false;
			m_constraintSolver = solver;
		}

		public override IConstraintSolver GetConstraintSolver()
		{
			return m_constraintSolver;
		}

		public override int GetNumConstraints()
		{
			return m_constraints.Count;
		}

		public override TypedConstraint GetConstraint(int index)
		{
			return m_constraints[index];
		}

		public override DynamicsWorldType GetWorldType()
		{
			return DynamicsWorldType.BT_DISCRETE_DYNAMICS_WORLD;
		}

		///the forces on each rigidbody is accumulating together with gravity. clear this after each timestep.
		public override void ClearForces()
		{
			int length = m_nonStaticRigidBodies.Count;
			for (int i = 0; i < length; ++i)
			{
				m_nonStaticRigidBodies[i].ClearForces();
			}
		}

		///apply gravity, call this once per timestep
		public virtual void ApplyGravity()
		{
			int length = m_nonStaticRigidBodies.Count;
			for (int i = 0; i < length; ++i)
			{
				RigidBody body = m_nonStaticRigidBodies[i];
				if (body != null && body.IsActive())
				{
					body.ApplyGravity();
				}
			}
		}

		public virtual void SetNumTasks(int numTasks)
		{
			//(void) numTasks;
		}

		///obsolete, use updateActions instead
		public virtual void UpdateVehicles(float timeStep)
		{
			UpdateActions(timeStep);
		}

		///obsolete, use addAction instead
		public override void AddVehicle(IActionInterface vehicle)
		{
			AddAction(vehicle);
		}
		///obsolete, use removeAction instead
		public override void RemoveVehicle(IActionInterface vehicle)
		{
			RemoveAction(vehicle);
		}

		///obsolete, use addAction instead
		public override void AddCharacter(IActionInterface character)
		{
			AddAction(character);
		}
		///obsolete, use removeAction instead
		public override void RemoveCharacter(IActionInterface character)
		{
			RemoveAction(character);
		}

		protected virtual void PredictUnconstraintMotion(float timeStep)
		{
			//BT_PROFILE("predictUnconstraintMotion");
			int length = m_nonStaticRigidBodies.Count;
			for (int i = 0; i < length; ++i)
			{
				RigidBody body = m_nonStaticRigidBodies[i];
				if (body != null)
				{
					if (!body.IsStaticOrKinematicObject())
					{

						body.IntegrateVelocities(timeStep);
						//damping
						body.ApplyDamping(timeStep);
						Matrix temp = body.GetInterpolationWorldTransform();
						body.PredictIntegratedTransform(timeStep, ref temp);
						body.SetInterpolationWorldTransform(ref temp);
					}
				}
			}
		}

		protected virtual void IntegrateTransforms(float timeStep)
		{
			//BT_PROFILE("integrateTransforms");
			Matrix predictedTrans = Matrix.Identity;
			int length = m_nonStaticRigidBodies.Count;
			for (int i = 0; i < length; ++i)
			{
				RigidBody body = m_nonStaticRigidBodies[i];
				if (body != null)
				{
					body.SetHitFraction(1f);

					if (body.IsActive() && (!body.IsStaticOrKinematicObject()))
					{
						body.PredictIntegratedTransform(timeStep, ref predictedTrans);
						float squareMotion = (predictedTrans.Translation - body.GetWorldTransform().Translation).LengthSquared();

						if (body.GetCcdSquareMotionThreshold() != 0 && body.GetCcdSquareMotionThreshold() < squareMotion)
						{
							//BT_PROFILE("CCD motion clamping");
							if (body.GetCollisionShape().IsConvex())
							{
								gNumClampedCcdMotions++;

								ClosestNotMeConvexResultCallback sweepResults = new ClosestNotMeConvexResultCallback(body, body.GetWorldTransform().Translation, predictedTrans.Translation, GetBroadphase().GetOverlappingPairCache(), GetDispatcher());
								//ConvexShape convexShape = (ConvexShape)(body.getCollisionShape());
								SphereShape tmpSphere = new SphereShape(body.GetCcdSweptSphereRadius());//btConvexShape* convexShape = static_cast<btConvexShape*>(body.getCollisionShape());

								sweepResults.m_collisionFilterGroup = body.GetBroadphaseProxy().m_collisionFilterGroup;
								sweepResults.m_collisionFilterMask = body.GetBroadphaseProxy().m_collisionFilterMask;

								ConvexSweepTest(tmpSphere, body.GetWorldTransform(), predictedTrans, sweepResults, 0f);
								if (sweepResults.hasHit() && (sweepResults.m_closestHitFraction < 1f))
								{
									body.SetHitFraction(sweepResults.m_closestHitFraction);
									body.PredictIntegratedTransform(timeStep * body.GetHitFraction(), ref predictedTrans);
									body.SetHitFraction(0f);
									//							printf("clamped integration to hit fraction = %f\n",fraction);
								}
							}
						}
						body.ProceedToTransform(ref predictedTrans);
					}
				}
			}
		}

		protected virtual void CalculateSimulationIslands()
		{

			//BT_PROFILE("calculateSimulationIslands");

			GetSimulationIslandManager().UpdateActivationState(GetCollisionWorld(), GetCollisionWorld().GetDispatcher());
			{
				int length = m_constraints.Count;
				for (int i = 0; i < length; ++i)
				{
					TypedConstraint constraint = m_constraints[i];
					RigidBody colObj0 = constraint.GetRigidBodyA();
					RigidBody colObj1 = constraint.GetRigidBodyB();

					if (((colObj0 != null) && (!colObj0.IsStaticOrKinematicObject())) &&
						((colObj1 != null) && (!colObj1.IsStaticOrKinematicObject())))
					{
						if (colObj0.IsActive() || colObj1.IsActive())
						{
							GetSimulationIslandManager().GetUnionFind().Unite((colObj0).GetIslandTag(),
								(colObj1).GetIslandTag());
						}
					}
				}
			}

			//Store the island id in each body
			GetSimulationIslandManager().StoreIslandActivationState(GetCollisionWorld());
		}

		protected virtual void SolveConstraints(ContactSolverInfo solverInfo)
		{
			//sorted version of all btTypedConstraint, based on islandId
			ObjectArray<TypedConstraint> sortedConstraints = new ObjectArray<TypedConstraint>(GetNumConstraints());

			if (BulletGlobals.g_streamWriter != null && debugDiscreteDynamicsWorld)
			{
				BulletGlobals.g_streamWriter.WriteLine("solveConstraints");
			}


			for (int i = 0; i < GetNumConstraints(); i++)
			{
				sortedConstraints.Add(m_constraints[i]);
			}

			//	btAssert(0);

			//sortedConstraints.quickSort(btSortConstraintOnIslandPredicate());
			sortedConstraints.Sort(new SortConstraintOnIslandPredicate());

			ObjectArray<TypedConstraint> constraintsPtr = GetNumConstraints() > 0 ? sortedConstraints : null;

			InplaceSolverIslandCallback solverCallback = new InplaceSolverIslandCallback(solverInfo, m_constraintSolver, constraintsPtr, sortedConstraints.Count, m_debugDrawer, m_dispatcher1);

			if (BulletGlobals.g_streamWriter != null && debugDiscreteDynamicsWorld)
			{
				BulletGlobals.g_streamWriter.WriteLine("prepareSolve");
			}

			m_constraintSolver.PrepareSolve(GetCollisionWorld().GetNumCollisionObjects(), GetCollisionWorld().GetDispatcher().GetNumManifolds());

			if (BulletGlobals.g_streamWriter != null && debugDiscreteDynamicsWorld)
			{
				BulletGlobals.g_streamWriter.WriteLine("buildAndProcessIsland");
			}

			/// solve all the constraints for this island
			m_islandManager.BuildAndProcessIslands(GetCollisionWorld().GetDispatcher(), GetCollisionWorld(), solverCallback);

			solverCallback.ProcessConstraints();

			m_constraintSolver.AllSolved(solverInfo, m_debugDrawer);
		}

		protected void UpdateActivationState(float timeStep)
		{
			//BT_PROFILE("updateActivationState");

			int length = m_nonStaticRigidBodies.Count;
			for (int i = 0; i < length; ++i)
			{
				RigidBody body = m_nonStaticRigidBodies[i];
				if (body != null)
				{
					body.UpdateDeactivation(timeStep);

					if (body.WantsSleeping())
					{
						if (body.IsStaticOrKinematicObject())
						{
							body.SetActivationState(ActivationState.ISLAND_SLEEPING);
						}
						else
						{
							if (body.GetActivationState() == ActivationState.ACTIVE_TAG)
								body.SetActivationState(ActivationState.WANTS_DEACTIVATION);
							if (body.GetActivationState() == ActivationState.ISLAND_SLEEPING)
							{
								Vector3 zero = Vector3.Zero;
								body.SetAngularVelocity(ref zero);
								body.SetLinearVelocity(ref zero);
							}
						}
					}
					else
					{
						if (body.GetActivationState() != ActivationState.DISABLE_DEACTIVATION)
							body.SetActivationState(ActivationState.ACTIVE_TAG);
					}
				}
			}
		}

		protected void UpdateActions(float timeStep)
		{
			//BT_PROFILE("updateActions");
			int length = m_actions.Count;
			for (int i = 0; i < length; ++i)
			{
				m_actions[i].UpdateAction(this, timeStep);
			}
		}

		protected void StartProfiling(float timeStep)
		{
			if (m_profileManager != null)
			{
				m_profileManager.Reset();
			}
		}

		protected virtual void InternalSingleStepSimulation(float timeStep)
		{
			//BT_PROFILE("internalSingleStepSimulation");

			if (BulletGlobals.g_streamWriter != null && debugDiscreteDynamicsWorld)
			{
				BulletGlobals.g_streamWriter.WriteLine("internalSingleStepSimulation");
			}

			if (null != m_internalPreTickCallback)
			{
				m_internalPreTickCallback.InternalTickCallback(this, timeStep);
			}

			///apply gravity, predict motion
			PredictUnconstraintMotion(timeStep);

			DispatcherInfo dispatchInfo = GetDispatchInfo();

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

			///integrate transforms
			IntegrateTransforms(timeStep);

			///update vehicle simulation
			UpdateActions(timeStep);

			UpdateActivationState(timeStep);

			if (m_internalTickCallback != null)
			{
				m_internalTickCallback.InternalTickCallback(this, timeStep);
			}
		}


		protected virtual void SaveKinematicState(float timeStep)
		{
			///would like to iterate over m_nonStaticRigidBodies, but unfortunately old API allows
			///to switch status _after_ adding kinematic objects to the world
			///fix it for Bullet 3.x release

			int length = m_collisionObjects.Count;
			for (int i = 0; i < length; ++i)
			{
				RigidBody body = RigidBody.Upcast(m_collisionObjects[i]);
				if (body != null && body.GetActivationState() != ActivationState.ISLAND_SLEEPING)
				{
					if (body.IsKinematicObject())
					{
						//to calculate velocities next frame
						body.SaveKinematicState(timeStep);
					}
				}
			}
		}

		public static int GetConstraintIslandId(TypedConstraint lhs)
		{
			int islandId;
			CollisionObject rcolObj0 = lhs.GetRigidBodyA();
			CollisionObject rcolObj1 = lhs.GetRigidBodyB();
			islandId = rcolObj0.GetIslandTag() >= 0 ? rcolObj0.GetIslandTag() : rcolObj1.GetIslandTag();
			return islandId;
		}

		protected IConstraintSolver m_constraintSolver;

		protected SimulationIslandManager m_islandManager;

		protected ObjectArray<TypedConstraint> m_constraints;

		protected ObjectArray<RigidBody> m_nonStaticRigidBodies;


		protected Vector3 m_gravity;

		//for variable timesteps
		protected float m_localTime;
		//for variable timesteps

		protected bool m_ownsIslandManager;
		protected bool m_ownsConstraintSolver;
		protected bool m_synchronizeAllMotionStates;

		protected IList<IActionInterface> m_actions;

		protected int m_profileTimings;
		protected int gNumClampedCcdMotions;
		protected const float s_fixedTimeStep = 1f / 60f;
		//public const float s_fixedTimeStep = 0.016666668f;
		//protected float s_fixedTimeStep2 = 1 / 60;
		//protected float s_fixedTimeStep3 = (float)(1.0 / 60.0);
		//protected float s_fixedTimeStep4 = 0.016666668f;

		public static bool debugDiscreteDynamicsWorld = true;
	}
}
