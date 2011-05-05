namespace InVision.Bullet.Collision.BroadphaseCollision
{
	public struct sStkNPS
	{
		public DbvtNode node;
		public uint mask;
		public float value;
		public sStkNPS(DbvtNode n, uint m, float v) { node = n; mask = m; value = v; }
	};
}