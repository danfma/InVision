namespace InVision.Bullet.Collision.NarrowPhaseCollision
{
	public class sSimplex
	{
		public sSimplex()
		{
			//for (int i = 0; i < c.Length; ++i)
			//{
			//    c[i] = new sSV();
			//}
		}
		public sSV[] c = new sSV[4];
		public float[] p = new float[4];
		public uint rank;
	}
}