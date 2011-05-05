using InVision.GameMath;

namespace InVision.Bullet.Collision.BroadphaseCollision
{
	public class BroadphaseBenchmarkObject
	{
		public Vector3 center;
		public Vector3 extents;
		public BroadphaseProxy	proxy;
		public float time;
		public void update(float speed,float amplitude,IBroadphaseInterface pbi)
		{
			time +=	speed;
			center.X = (float)(System.Math.Cos(time*2.17f)*amplitude+System.Math.Sin(time)*amplitude/2f);
			center.Y =	(float)(System.Math.Cos(time*1.38f)*amplitude+System.Math.Sin(time)*amplitude);
			center.Z = (float)(System.Math.Sin(time*0.777f)*amplitude);
			Vector3 temp1 = center-extents;
			Vector3 temp2 = center+extents;
			pbi.SetAabb(proxy,ref temp1,ref temp2,null);
		}
	}
}