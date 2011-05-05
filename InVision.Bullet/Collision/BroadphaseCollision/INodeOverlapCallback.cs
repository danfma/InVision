namespace InVision.Bullet.Collision.BroadphaseCollision
{
	public interface INodeOverlapCallback
	{
		void ProcessNode(int subPart, int triangleIndex);
		void Cleanup();
	}
}