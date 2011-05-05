namespace InVision.Bullet.Collision.BroadphaseCollision
{
	public class Collide
	{
		public virtual void Process(DbvtNode n, DbvtNode n2)
		{
		}
		public virtual void Process(DbvtNode n)
		{
		}
		public virtual void Process(DbvtNode n, float f)
		{
			Process(n);
		}
		public virtual bool Descent(DbvtNode n)
		{
			return true;
		}
		public virtual bool AllLeaves(DbvtNode n)
		{
			return true;
		}
	}
}