using System;
using InVision.GameMath;

namespace InVision.Bullet.Collision.BroadphaseCollision
{
	public interface IBroadphaseInterface
	{

		BroadphaseProxy CreateProxy(Vector3 aabbMin, Vector3 aabbMax, BroadphaseNativeTypes shapeType, Object userPtr, CollisionFilterGroups collisionFilterGroup, CollisionFilterGroups collisionFilterMask, IDispatcher dispatcher, Object multiSapProxy);
		BroadphaseProxy CreateProxy(ref Vector3 aabbMin, ref Vector3 aabbMax, BroadphaseNativeTypes shapeType, Object userPtr, CollisionFilterGroups collisionFilterGroup, CollisionFilterGroups collisionFilterMask, IDispatcher dispatcher, Object multiSapProxy);

		void DestroyProxy(BroadphaseProxy proxy,IDispatcher dispatcher);
		void SetAabb(BroadphaseProxy proxy,ref Vector3 aabbMin,ref Vector3 aabbMax, IDispatcher dispatcher);
		void GetAabb(BroadphaseProxy proxy,ref Vector3 aabbMin,ref Vector3 aabbMax );

		void RayTest(ref Vector3 rayFrom, ref Vector3 rayTo, BroadphaseRayCallback rayCallback);
		void RayTest(ref Vector3 rayFrom,ref Vector3 rayTo, BroadphaseRayCallback rayCallback, ref Vector3 aabbMin, ref Vector3 aabbMax);
		void AabbTest(ref Vector3 aabbMin, ref Vector3 aabbMax, IBroadphaseAabbCallback callback);

		///calculateOverlappingPairs is optional: incremental algorithms (sweep and prune) might do it during the set aabb
		void	CalculateOverlappingPairs(IDispatcher dispatcher);

		IOverlappingPairCache GetOverlappingPairCache();

		///getAabb returns the axis aligned bounding box in the 'global' coordinate frame
		///will add some transform later
		void GetBroadphaseAabb(ref Vector3 aabbMin,ref Vector3 aabbMax);

		///reset broadphase internal structures, to ensure determinism/reproducability
		void ResetPool(IDispatcher dispatcher);

		void PrintStats();

		void Cleanup();
	}
}