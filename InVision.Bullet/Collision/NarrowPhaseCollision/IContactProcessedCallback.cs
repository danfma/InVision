using System;

namespace InVision.Bullet.Collision.NarrowPhaseCollision
{
	public interface IContactProcessedCallback
	{
		bool callback(ManifoldPoint point, Object body0, Object body1);
	}
}