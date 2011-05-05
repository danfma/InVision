namespace InVision.Bullet.Collision.CollisionDispatch
{
	public enum ActivationState
	{
		UNDEFINED=0,
		ACTIVE_TAG=1,
		ISLAND_SLEEPING=2,
		WANTS_DEACTIVATION=3,
		DISABLE_DEACTIVATION=4,
		DISABLE_SIMULATION=5
	}
}