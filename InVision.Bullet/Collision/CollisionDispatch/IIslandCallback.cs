using InVision.Bullet.Collision.NarrowPhaseCollision;
using InVision.Bullet.LinearMath;

namespace InVision.Bullet.Collision.CollisionDispatch
{
	public interface IIslandCallback
	{
		void ProcessIsland(ObjectArray<CollisionObject> bodies,int numBodies,ObjectArray<PersistentManifold> manifolds,int numManifolds, int islandId);
	}
}