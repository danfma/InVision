using InVision.Bullet.Collision.BroadphaseCollision;

namespace InVision.Bullet.Collision.CollisionDispatch
{
	public class SingleContactCallback : IBroadphaseAabbCallback
	{
		CollisionObject m_collisionObject;
		CollisionWorld	m_world;
		ContactResultCallback m_resultCallback;
    	
		public SingleContactCallback(CollisionObject collisionObject, CollisionWorld world,ContactResultCallback resultCallback)
		{
			m_collisionObject = collisionObject;
			m_world = world;
			m_resultCallback = resultCallback;
		}

		public virtual void Cleanup()
		{
		}

		public virtual bool Process(BroadphaseProxy proxy)
		{
			CollisionObject collisionObject = (CollisionObject)proxy.m_clientObject;
			if (collisionObject == m_collisionObject)
			{
				return true;
			}

			//only perform raycast if filterMask matches
			if(m_resultCallback.NeedsCollision(collisionObject.GetBroadphaseHandle())) 
			{
				CollisionAlgorithm algorithm = m_world.GetDispatcher().FindAlgorithm(m_collisionObject,collisionObject);
				if (algorithm != null)
				{
					BridgedManifoldResult contactPointResult = new BridgedManifoldResult(m_collisionObject,collisionObject, m_resultCallback);
					//discrete collision detection query
					algorithm.ProcessCollision(m_collisionObject,collisionObject, m_world.GetDispatchInfo(),contactPointResult);

					algorithm.Cleanup();
					m_world.GetDispatcher().FreeCollisionAlgorithm(algorithm);
				}
			}
			return true;
		}
	}
}