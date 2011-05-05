namespace InVision.Bullet.Collision.BroadphaseCollision
{
	public struct sStkNP
	{
		public DbvtNode node;
		public uint mask;
		public sStkNP(DbvtNode n, uint m) { node = n; mask = m; }
	};
}