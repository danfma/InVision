using InVision.Bullet.Dynamics.ConstraintSolver;

namespace InVision.Bullet.Debuging
{
	public interface IConstraintTypeDrawer
	{
		bool DrawFrames { get; set; }
		bool DrawLimits { get; set; }
		float DrawSize { get; set; }

		void Draw(TypedConstraint constraint, IDebugDraw debugDraw);
	}
}