namespace InVision.Bullet.Collision.BroadphaseCollision
{
	public class DbvtTreeCollider : Collide
	{
		public DbvtBroadphase	pbp;
		public DbvtProxy		proxy;
		public DbvtTreeCollider(DbvtBroadphase p) 
		{
			pbp = p;
		}
		public override void Process(DbvtNode na,DbvtNode nb)
		{
			if(na!=nb)
			{
				DbvtProxy	pa=(DbvtProxy)na.data;
				DbvtProxy	pb=(DbvtProxy)nb.data;
#if DBVT_BP_SORTPAIRS
			    if(pa.m_uniqueId>pb.m_uniqueId) 
				    btSwap(pa,pb);
#endif
				pbp.m_paircache.AddOverlappingPair(pa,pb);
				++pbp.m_newpairs;
			}
		}
		public override void Process(DbvtNode n)
		{
			Process(n,proxy.leaf);
		}
	}
}