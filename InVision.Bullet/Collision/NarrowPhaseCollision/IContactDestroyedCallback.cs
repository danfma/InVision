using System;

namespace InVision.Bullet.Collision.NarrowPhaseCollision
{
	public interface IContactDestroyedCallback
	{
		bool callback(Object userPersistentData);
	}
}