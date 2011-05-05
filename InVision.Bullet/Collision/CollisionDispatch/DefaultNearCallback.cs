using InVision.Bullet.Collision.BroadphaseCollision;

namespace InVision.Bullet.Collision.CollisionDispatch
{
	public class DefaultNearCallback : INearCallback
	{
		public void NearCallback(BroadphasePair collisionPair, CollisionDispatcher dispatcher, DispatcherInfo dispatchInfo)
		{
			CollisionObject colObj0 = (CollisionObject)collisionPair.m_pProxy0.GetClientObject();
			CollisionObject colObj1 = (CollisionObject)collisionPair.m_pProxy1.GetClientObject();

			if (dispatcher.NeedsCollision(colObj0,colObj1))
			{
				//dispatcher will keep algorithms persistent in the collision pair
				if (collisionPair.m_algorithm == null)
				{
					collisionPair.m_algorithm = dispatcher.FindAlgorithm(colObj0,colObj1,null);
				}

				if (collisionPair.m_algorithm != null)
				{
					ManifoldResult contactPointResult = new ManifoldResult(colObj0,colObj1);

					if (dispatchInfo.GetDispatchFunc() == DispatchFunc.DISPATCH_DISCRETE)
					{
						//discrete collision detection query
						collisionPair.m_algorithm.ProcessCollision(colObj0,colObj1,dispatchInfo,contactPointResult);
					} 
					else
					{
						//continuous collision detection query, time of impact (toi)
						float toi = collisionPair.m_algorithm.CalculateTimeOfImpact(colObj0,colObj1,dispatchInfo,contactPointResult);
						if (dispatchInfo.GetTimeOfImpact() > toi)
						{
							dispatchInfo.SetTimeOfImpact(toi);
						}
					}
				}
			}
		}
	}
}