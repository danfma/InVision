using System;

namespace InVision.Bullet.Collision.BroadphaseCollision
{
	public class DbvtNode
	{
		public DbvtNode()
		{
		}
		public DbvtNode(Dbvt tree, DbvtNode aparent, ref DbvtAabbMm avolume, Object adata)
		{ 
			volume = avolume; 
			parent = aparent; 
			data = adata;
			if (data is int)
			{
				dataAsInt = (int)data;
			}
		}
		public DbvtAabbMm volume;
		public DbvtNode parent;
		public DbvtNode[] _children = new DbvtNode[2];
		public Object data;
		public int	dataAsInt;

		public bool IsLeaf() { return (_children[1] == null); }
		public bool IsInternal() { return (!IsLeaf()); }
	}
}