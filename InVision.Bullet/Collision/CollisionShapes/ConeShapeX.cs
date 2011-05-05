namespace InVision.Bullet.Collision.CollisionShapes
{
	///btConeShape implements a Cone shape, around the X axis
	public class ConeShapeX : ConeShape
	{
		public ConeShapeX(float radius, float height)
			: base(radius, height)
		{
			SetConeUpIndex(0);
		}
	}
}