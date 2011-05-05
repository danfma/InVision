using InVision.Bullet.Debuging;

namespace InVision.Bullet.Collision.NarrowPhaseCollision
{
	public interface IDiscreteCollisionDetectorInterface
	{
		void GetClosestPoints(ClosestPointInput input, IDiscreteCollisionDetectorInterfaceResult output, IDebugDraw debugDraw, bool swapResults);
	}
}