using InVision.Bullet.Collision.BroadphaseCollision;
using InVision.Bullet.Collision.CollisionDispatch;
using InVision.Bullet.Collision.NarrowPhaseCollision;
using InVision.Bullet.Debuging;
using InVision.Bullet.Dynamics.ConstraintSolver;
using InVision.Bullet.LinearMath;

namespace InVision.Bullet.Dynamics.Dynamics
{
	public class InplaceSolverIslandCallback : IIslandCallback
	{
		public ContactSolverInfo m_solverInfo;
		public IConstraintSolver m_solver;
		public ObjectArray<TypedConstraint> m_sortedConstraints;
		public int m_numConstraints;
		public IDebugDraw m_debugDrawer;
		public IDispatcher m_dispatcher;
		public ObjectArray<CollisionObject> m_bodies;
		public ObjectArray<PersistentManifold> m_manifolds;
		public ObjectArray<TypedConstraint> m_constraints;

		public InplaceSolverIslandCallback(
			ContactSolverInfo solverInfo,
			IConstraintSolver solver,
			ObjectArray<TypedConstraint> sortedConstraints,
			int numConstraints,
			IDebugDraw debugDrawer,
			IDispatcher dispatcher)
		{
			m_solverInfo = solverInfo;
			m_solver = solver;
			m_sortedConstraints = sortedConstraints;
			m_numConstraints = numConstraints;
			m_debugDrawer = debugDrawer;
			m_dispatcher = dispatcher;
			m_bodies = new ObjectArray<CollisionObject>();
			m_manifolds = new ObjectArray<PersistentManifold>();
			m_constraints = new ObjectArray<TypedConstraint>();
		}

		//InplaceSolverIslandCallback operator=(InplaceSolverIslandCallback& other)
		//{
		//    Debug.Assert(false);
		//    //(void)other;
		//    return *this;
		//}


		public virtual void ProcessIsland(ObjectArray<CollisionObject> bodies, int numBodies, ObjectArray<PersistentManifold> manifolds, int numManifolds, int islandId)
		{
			if (islandId < 0)
			{
				if (numManifolds + m_numConstraints > 0)
				{
					///we don't split islands, so all constraints/contact manifolds/bodies are passed into the solver regardless the island id
					m_solver.SolveGroup(bodies, numBodies, manifolds, numManifolds, m_sortedConstraints, m_numConstraints, m_solverInfo, m_debugDrawer, m_dispatcher);
				}
			}
			else
			{
				//also add all non-contact constraints/joints for this island
				ObjectArray<TypedConstraint> startConstraint = new ObjectArray<TypedConstraint>();
				int numCurConstraints = 0;
				int i = 0;

				//find the first constraint for this island
				for (i = 0; i < m_numConstraints; i++)
				{
					if (DiscreteDynamicsWorld.GetConstraintIslandId(m_sortedConstraints[i]) == islandId)
					{
						// FIXME - Do we need add everything after i to mirror the pointer?
						for (int k = i; k < m_numConstraints; ++k)
						{
							startConstraint.Add(m_sortedConstraints[k]);
						}
						break;
					}
				}
				//count the number of constraints in this island
				for (; i < m_numConstraints; i++)
				{
					if (DiscreteDynamicsWorld.GetConstraintIslandId(m_sortedConstraints[i]) == islandId)
					{
						numCurConstraints++;
					}
				}

				if (m_solverInfo.m_minimumSolverBatchSize <= 1)
				{
					///only call solveGroup if there is some work: avoid virtual function call, its overhead can be excessive
					if (numManifolds + numCurConstraints != 0)
					{
						m_solver.SolveGroup(bodies, numBodies, manifolds, numManifolds, startConstraint, numCurConstraints, m_solverInfo, m_debugDrawer, m_dispatcher);
					}
				}
				else
				{
					for (i = 0; i < numBodies; i++)
					{
						m_bodies.Add(bodies[i]);
					}
					for (i = 0; i < numManifolds; i++)
					{
						m_manifolds.Add(manifolds[i]);
					}
					for (i = 0; i < numCurConstraints; i++)
					{
						m_constraints.Add(startConstraint[i]);
					}
					if ((m_constraints.Count + m_manifolds.Count) > m_solverInfo.m_minimumSolverBatchSize)
					{
						ProcessConstraints();
					}
					else
					{
						//printf("deferred\n");
					}
				}


				//                ///only call solveGroup if there is some work: avoid virtual function call, its overhead can be excessive
				//                if (numManifolds + numCurConstraints > 0)
				//                {
				////solveGroup(ObjectArray<CollisionObject> bodies,int numBodies,ObjectArray<PersistentManifold> manifold,int numManifolds,ObjectArray<TypedConstraint> constraints,int numConstraints, ContactSolverInfo info,IDebugDraw debugDrawer, IDispatcher dispatcher);
				//                    m_solver.solveGroup(bodies,numBodies,manifolds, numManifolds,startConstraint,numCurConstraints,m_solverInfo,m_debugDrawer,m_dispatcher);
				//                }

			}
		}

		public void ProcessConstraints()
		{
			if (m_manifolds.Count + m_constraints.Count > 0)
			{
				m_solver.SolveGroup(m_bodies, m_bodies.Count, m_manifolds, m_manifolds.Count, m_constraints, m_constraints.Count, m_solverInfo, m_debugDrawer, m_dispatcher);
			}
			m_bodies.Clear();
			m_manifolds.Clear();
			m_constraints.Clear();

		}


	}
}