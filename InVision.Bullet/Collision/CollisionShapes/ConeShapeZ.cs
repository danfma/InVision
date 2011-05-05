namespace InVision.Bullet.Collision.CollisionShapes
{
	///btConeShapeZ implements a Cone shape, around the Z axis
	public class ConeShapeZ : ConeShape
	{
		public ConeShapeZ(float radius,float height)
			: base(radius, height)
		{
			SetConeUpIndex(2);
		}

	}
}