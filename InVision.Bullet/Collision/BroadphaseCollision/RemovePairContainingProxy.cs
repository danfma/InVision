namespace InVision.Bullet.Collision.BroadphaseCollision
{
	public class RemovePairContainingProxy
	{
		public virtual void Cleanup()
		{
		}
		protected virtual bool ProcessOverlap(ref BroadphasePair pair)
		{
			SimpleBroadphaseProxy proxy0 = (SimpleBroadphaseProxy)(pair.m_pProxy0);
			SimpleBroadphaseProxy proxy1 = (SimpleBroadphaseProxy)(pair.m_pProxy1);
			return ((m_targetProxy == proxy0 || m_targetProxy == proxy1));
		}
		private BroadphaseProxy	m_targetProxy;
	}
}