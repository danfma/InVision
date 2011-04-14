using InVision.Bullet.Dynamics.ConstraintSolver;
using InVision.Bullet.LinearMath;
using InVision.GameMath;

namespace InVision.Bullet.Debuging.Drawers
{
	public class D6ConstraintTypeDrawer : ConstraintTypeDrawer
	{
		/// <summary>
		/// Draws the specified constraint.
		/// </summary>
		/// <param name="constraint">The constraint.</param>
		/// <param name="debugDraw">The debug draw.</param>
		public override void Draw(TypedConstraint constraint, IDebugDraw debugDraw)
		{
			var p6DOF = (Generic6DofConstraint)constraint;
			Matrix tr = p6DOF.GetCalculatedTransformA();
			if (DrawFrames)
			{
				debugDraw.DrawTransform(ref tr, DrawSize);
			}
			tr = p6DOF.GetCalculatedTransformB();
			if (DrawFrames)
			{
				debugDraw.DrawTransform(ref tr, DrawSize);
			}
			Vector3 zero = Vector3.Zero;
			if (DrawLimits)
			{
				tr = p6DOF.GetCalculatedTransformA();
				Vector3 center = p6DOF.GetCalculatedTransformB().Translation;
				// up is axis 1 not 2 ?
				Vector3 up = MathUtil.MatrixColumn(ref tr, 1);
				Vector3 axis = MathUtil.MatrixColumn(ref tr, 0);
				float minTh = p6DOF.GetRotationalLimitMotor(1).m_loLimit;
				float maxTh = p6DOF.GetRotationalLimitMotor(1).m_hiLimit;
				float minPs = p6DOF.GetRotationalLimitMotor(2).m_loLimit;
				float maxPs = p6DOF.GetRotationalLimitMotor(2).m_hiLimit;
				debugDraw.DrawSpherePatch(ref center, ref up, ref axis, DrawSize * .9f, minTh, maxTh, minPs, maxPs, ref zero);
				axis = MathUtil.MatrixColumn(ref tr, 1);
				float ay = p6DOF.GetAngle(1);
				float az = p6DOF.GetAngle(2);
				var cy = (float)System.Math.Cos(ay);
				var sy = (float)System.Math.Sin(ay);
				var cz = (float)System.Math.Cos(az);
				var sz = (float)System.Math.Sin(az);
				var ref1 = new Vector3();
				ref1.X = cy * cz * axis.X + cy * sz * axis.Y - sy * axis.Z;
				ref1.Y = -sz * axis.X + cz * axis.Y;
				ref1.Z = cz * sy * axis.X + sz * sy * axis.Y + cy * axis.Z;
				tr = p6DOF.GetCalculatedTransformB();
				Vector3 normal = -MathUtil.MatrixColumn(ref tr, 0);
				float minFi = p6DOF.GetRotationalLimitMotor(0).m_loLimit;
				float maxFi = p6DOF.GetRotationalLimitMotor(0).m_hiLimit;
				if (minFi > maxFi)
				{
					debugDraw.DrawArc(ref center, ref normal, ref ref1, DrawSize, DrawSize, -MathUtil.SIMD_PI, MathUtil.SIMD_PI,
					                  ref zero, false);
				}
				else if (minFi < maxFi)
				{
					debugDraw.DrawArc(ref center, ref normal, ref ref1, DrawSize, DrawSize, minFi, maxFi, ref zero, false);
				}
				tr = p6DOF.GetCalculatedTransformA();
				Vector3 bbMin = p6DOF.GetTranslationalLimitMotor().m_lowerLimit;
				Vector3 bbMax = p6DOF.GetTranslationalLimitMotor().m_upperLimit;
				debugDraw.DrawBox(ref bbMin, ref bbMax, ref tr, ref zero);
			}
		}
	}
}