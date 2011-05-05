using InVision.GameMath;

namespace InVision.Bullet.Collision.CollisionShapes
{
	///btCapsuleShapeX represents a capsule around the Z axis
	///the total height is height+2*radius, so the height is just the height between the center of each 'sphere' of the capsule caps.
	public class CapsuleShapeX : CapsuleShape
	{
		public CapsuleShapeX(float radius,float height)
		{
			m_upAxis = 0;
			m_implicitShapeDimensions = new Vector3(0.5f * height, radius, radius);
		}
    		
		//debugging

		public override string Name
		{
			get { return "CapsuleX"; }
		}
	}
}