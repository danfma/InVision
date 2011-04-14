using InVision.Bullet.Dynamics.ConstraintSolver;

namespace InVision.Bullet.Debuging.Drawers
{
	public abstract class ConstraintTypeDrawer : IConstraintTypeDrawer
	{
		#region IConstraintTypeDrawer Members

		public bool DrawFrames { get; set; }
		public bool DrawLimits { get; set; }
		public float DrawSize { get; set; }
		public abstract void Draw(TypedConstraint constraint, IDebugDraw debugDraw);

		#endregion
	}
}