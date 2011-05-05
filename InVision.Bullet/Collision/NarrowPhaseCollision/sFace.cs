using InVision.GameMath;

namespace InVision.Bullet.Collision.NarrowPhaseCollision
{
	public class sFace
	{
		public Vector3	n;
		public float d;
		public float p;
		public sSV[] c = new sSV[3];
		public sFace[] f = new sFace[3];
		//public sFace[] l = new sFace[2];
		public uint[] e = new uint[3];
		public uint pass =0;
	}
}