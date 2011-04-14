using InVision.Bullet.Dynamics.ConstraintSolver;
using InVision.Bullet.LinearMath;
using InVision.GameMath;

namespace InVision.Bullet.Debuging.Drawers
{
	public class HingeConstraintTypeDrawer : ConstraintTypeDrawer
	{
		public override void Draw(TypedConstraint constraint, IDebugDraw debugDraw)
		{
			var pHinge = (HingeConstraint)constraint;
			Matrix tr = MathUtil.BulletMatrixMultiply(pHinge.GetRigidBodyA().GetCenterOfMassTransform(), pHinge.GetAFrame());

			if (DrawFrames)
				debugDraw.DrawTransform(ref tr, DrawSize);

			tr = MathUtil.BulletMatrixMultiply(pHinge.GetRigidBodyB().GetCenterOfMassTransform(), pHinge.GetBFrame());

			if (DrawFrames)
				debugDraw.DrawTransform(ref tr, DrawSize);

			float minAng = pHinge.GetLowerLimit();
			float maxAng = pHinge.GetUpperLimit();

			if (minAng == maxAng)
				return;

			bool drawSect = true;

			if (minAng > maxAng)
			{
				minAng = 0f;
				maxAng = MathUtil.SIMD_2_PI;
				drawSect = false;
			}

			if (DrawLimits)
			{
				Vector3 center = tr.Translation;
				Vector3 normal = MathUtil.MatrixColumn(ref tr, 2);
				Vector3 axis = MathUtil.MatrixColumn(ref tr, 0);
				Vector3 zero = Vector3.Zero;
				debugDraw.DrawArc(ref center, ref normal, ref axis, DrawSize, DrawSize, minAng, maxAng, ref zero, drawSect);
			}
		}
	}
}