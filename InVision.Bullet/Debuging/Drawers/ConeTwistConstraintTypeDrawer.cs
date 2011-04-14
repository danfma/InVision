using InVision.Bullet.Dynamics.ConstraintSolver;
using InVision.Bullet.LinearMath;
using InVision.GameMath;

namespace InVision.Bullet.Debuging.Drawers
{
	public class ConeTwistConstraintTypeDrawer : ConstraintTypeDrawer
	{
		public override void Draw(TypedConstraint constraint, IDebugDraw debugDraw)
		{
			var pCT = (ConeTwistConstraint)constraint;
			Matrix tr = MathUtil.BulletMatrixMultiply(pCT.GetRigidBodyA().GetCenterOfMassTransform(), pCT.GetAFrame());
			if (DrawFrames) debugDraw.DrawTransform(ref tr, DrawSize);
			tr = MathUtil.BulletMatrixMultiply(pCT.GetRigidBodyB().GetCenterOfMassTransform(), pCT.GetBFrame());
			if (DrawFrames) debugDraw.DrawTransform(ref tr, DrawSize);
			Vector3 zero = Vector3.Zero;

			if (DrawLimits)
			{
				//const float length = float(5);
				float length = DrawSize;
				int nSegments = 8 * 4;
				float fAngleInRadians = MathUtil.SIMD_2_PI * (nSegments - 1) / nSegments;
				Vector3 pPrev = pCT.GetPointForAngle(fAngleInRadians, length);
				pPrev = Vector3.Transform(pPrev, tr);
				for (int i = 0; i < nSegments; i++)
				{
					fAngleInRadians = MathUtil.SIMD_2_PI * i / nSegments;
					Vector3 pCur = pCT.GetPointForAngle(fAngleInRadians, length);
					pCur = Vector3.Transform(pCur, tr);
					debugDraw.DrawLine(ref pPrev, ref pCur, ref zero);

					if (i % (nSegments / 8) == 0)
					{
						Vector3 origin = tr.Translation;
						debugDraw.DrawLine(ref origin, ref pCur, ref zero);
					}

					pPrev = pCur;
				}
				float tws = pCT.GetTwistSpan();
				float twa = pCT.GetTwistAngle();
				bool useFrameB = (pCT.GetRigidBodyB().GetInvMass() > 0f);
				if (useFrameB)
				{
					tr = MathUtil.BulletMatrixMultiply(pCT.GetRigidBodyB().GetCenterOfMassTransform(), pCT.GetBFrame());
				}
				else
				{
					tr = MathUtil.BulletMatrixMultiply(pCT.GetRigidBodyA().GetCenterOfMassTransform(), pCT.GetAFrame());
				}
				Vector3 pivot = tr.Translation;
				Vector3 normal = MathUtil.MatrixColumn(ref tr, 0);
				Vector3 axis1 = MathUtil.MatrixColumn(ref tr, 1);

				debugDraw.DrawArc(ref pivot, ref normal, ref axis1, DrawSize, DrawSize, -twa - tws, -twa + tws, ref zero, true);
			}
		}
	}
}