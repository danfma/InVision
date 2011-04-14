using InVision.Bullet.Dynamics.ConstraintSolver;
using InVision.GameMath;

namespace InVision.Bullet.Debuging.Drawers
{
	public class Point2PointConstraintTypeDrawer : ConstraintTypeDrawer
	{
		public override void Draw(TypedConstraint constraint, IDebugDraw debugDraw)
		{
			var p2pC = (Point2PointConstraint)constraint;
			Matrix tr = Matrix.Identity;
			Vector3 pivot = p2pC.GetPivotInA();
			pivot = Vector3.Transform(pivot, p2pC.GetRigidBodyA().GetCenterOfMassTransform());
			tr.Translation = pivot;
			debugDraw.DrawTransform(ref tr, DrawSize);
			// that ideally should draw the same frame	
			pivot = p2pC.GetPivotInB();
			pivot = Vector3.Transform(pivot, p2pC.GetRigidBodyB().GetCenterOfMassTransform());
			tr.Translation = pivot;

			if (DrawFrames)
				debugDraw.DrawTransform(ref tr, DrawSize);
		}
	}
}