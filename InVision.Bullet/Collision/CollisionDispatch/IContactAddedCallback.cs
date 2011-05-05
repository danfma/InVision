using InVision.Bullet.Collision.NarrowPhaseCollision;

namespace InVision.Bullet.Collision.CollisionDispatch
{
	public interface IContactAddedCallback
	{
		bool Callback(ManifoldPoint cp, CollisionObject colObj0, int partId0, int index0, CollisionObject colObj1, int partId1, int index1);
	}
}