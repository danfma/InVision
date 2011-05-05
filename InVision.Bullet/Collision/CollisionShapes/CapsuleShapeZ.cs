using InVision.GameMath;

namespace InVision.Bullet.Collision.CollisionShapes
{
	///btCapsuleShapeZ represents a capsule around the Z axis
	///the total height is height+2*radius, so the height is just the height between the center of each 'sphere' of the capsule caps.
	public class CapsuleShapeZ : CapsuleShape
	{
		public CapsuleShapeZ(float radius,float height)
		{
			m_upAxis = 2;
			m_implicitShapeDimensions= new Vector3(radius, radius, 0.5f * height);
		}
		//debugging

		public override string Name
		{
			get { return "CapsuleZ"; }
		}
	}
}