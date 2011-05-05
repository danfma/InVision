using System;
using InVision.Bullet.Collision.CollisionDispatch;
using InVision.Bullet.Collision.NarrowPhaseCollision;
using InVision.Bullet.LinearMath;

namespace InVision.Bullet.Collision.BroadphaseCollision
{
	public interface IDispatcher
	{
		CollisionAlgorithm FindAlgorithm(CollisionObject body0, CollisionObject body1);

		CollisionAlgorithm FindAlgorithm(CollisionObject body0, CollisionObject body1, PersistentManifold sharedManifold);

		PersistentManifold GetNewManifold(CollisionObject body0, CollisionObject body1);

		void ReleaseManifold(PersistentManifold manifold);

		void ClearManifold(PersistentManifold manifold);

		bool	NeedsCollision(CollisionObject body0,CollisionObject body1);

		bool	NeedsResponse(CollisionObject body0,CollisionObject body1);

		void	DispatchAllCollisionPairs(IOverlappingPairCache pairCache,DispatcherInfo dispatchInfo,IDispatcher dispatcher);

		int GetNumManifolds();

		PersistentManifold GetManifoldByIndexInternal(int index);

		ObjectArray<PersistentManifold> GetInternalManifoldPointer();

		Object AllocateCollisionAlgorithm(int size);

		void FreeCollisionAlgorithm(CollisionAlgorithm collisionAlgorithm);
	}
}