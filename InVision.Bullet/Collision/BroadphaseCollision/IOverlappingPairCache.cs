using InVision.Bullet.LinearMath;

namespace InVision.Bullet.Collision.BroadphaseCollision
{
	public interface IOverlappingPairCache : IOverlappingPairCallback
	{
		//BroadphasePair getOverlappingPairArrayPtr();
		ObjectArray<BroadphasePair> GetOverlappingPairArray();
		void CleanOverlappingPair(BroadphasePair pair,IDispatcher dispatcher);
		int GetNumOverlappingPairs();
		void CleanProxyFromPairs(BroadphaseProxy proxy,IDispatcher dispatcher);
		void SetOverlapFilterCallback(IOverlapFilterCallback callback);
		void ProcessAllOverlappingPairs(IOverlapCallback callback,IDispatcher dispatcher);
		BroadphasePair FindPair(BroadphaseProxy proxy0, BroadphaseProxy proxy1);
		bool HasDeferredRemoval();
		void SetInternalGhostPairCallback(IOverlappingPairCallback ghostPairCallback);
		void SortOverlappingPairs(IDispatcher dispatcher);
		void Cleanup();

	}
}