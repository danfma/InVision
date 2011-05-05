namespace InVision.Bullet.Dynamics.Dynamics
{
	/// Type for the callback for each tick
	public interface IInternalTickCallback
	{
		void InternalTickCallback(DynamicsWorld world, float timeStep);
	}
}