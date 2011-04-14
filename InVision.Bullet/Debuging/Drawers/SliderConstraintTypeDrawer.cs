using InVision.Bullet.Dynamics.ConstraintSolver;
using InVision.Bullet.LinearMath;
using InVision.GameMath;

namespace InVision.Bullet.Debuging.Drawers
{
	public class SliderConstraintTypeDrawer : ConstraintTypeDrawer
	{
		public override void Draw(TypedConstraint constraint, IDebugDraw debugDraw)
		{
			var pSlider = (SliderConstraint)constraint;
			Matrix tr = pSlider.GetCalculatedTransformA();
			if (DrawFrames) debugDraw.DrawTransform(ref tr, DrawSize);
			tr = pSlider.GetCalculatedTransformB();
			if (DrawFrames) debugDraw.DrawTransform(ref tr, DrawSize);
			Vector3 zero = Vector3.Zero;
			if (DrawLimits)
			{
				Matrix tr2 = pSlider.GetCalculatedTransformA();
				Vector3 li_min = Vector3.Transform(new Vector3(pSlider.GetLowerLinLimit(), 0f, 0f), tr2);
				Vector3 li_max = Vector3.Transform(new Vector3(pSlider.GetUpperLinLimit(), 0f, 0f), tr2);
				debugDraw.DrawLine(ref li_min, ref li_max, ref zero);
				Vector3 normal = MathUtil.MatrixColumn(ref tr, 0);
				Vector3 axis = MathUtil.MatrixColumn(ref tr, 1);
				float a_min = pSlider.GetLowerAngLimit();
				float a_max = pSlider.GetUpperAngLimit();
				Vector3 center = pSlider.GetCalculatedTransformB().Translation;
				debugDraw.DrawArc(ref center, ref normal, ref axis, DrawSize, DrawSize, a_min, a_max, ref zero, true);
			}
		}
	}
}