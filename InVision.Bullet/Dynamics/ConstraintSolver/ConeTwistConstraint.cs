﻿/*
 * C# / XNA  port of Bullet (c) 2011 Mark Neale <xexuxjy@hotmail.com>
 *
 * Bullet Continuous Collision Detection and Physics Library
 * Copyright (c) 2003-2008 Erwin Coumans  http://www.bulletphysics.com/
 *
 * This software is provided 'as-is', without any express or implied warranty.
 * In no event will the authors be held liable for any damages arising from
 * the use of this software.
 * 
 * Permission is granted to anyone to use this software for any purpose, 
 * including commercial applications, and to alter it and redistribute it
 * freely, subject to the following restrictions:
 * 
 * 1. The origin of this software must not be misrepresented; you must not
 *    claim that you wrote the original software. If you use this software
 *    in a product, an acknowledgment in the product documentation would be
 *    appreciated but is not required.
 * 2. Altered source versions must be plainly marked as such, and must not be
 *    misrepresented as being the original software.
 * 3. This notice may not be removed or altered from any source distribution.
 */

using System.Diagnostics;
using InVision.Bullet.Dynamics.Dynamics;
using InVision.Bullet.LinearMath;
using InVision.GameMath;

namespace InVision.Bullet.Dynamics.ConstraintSolver
{
	public class ConeTwistConstraint : TypedConstraint
	{
		public const float CONETWIST_DEF_FIX_THRESH = .05f;
		public static Vector3 vTwist = new Vector3(1, 0, 0); // twist axis in constraint's space

		public JacobianEntry[] m_jac = new JacobianEntry[3]; //3 orthogonal linear constraints

		public Matrix m_rbAFrame = Matrix.Identity;
		public Matrix m_rbBFrame = Matrix.Identity;

		public float m_limitSoftness;
		public float m_biasFactor;
		public float m_relaxationFactor;

		public float m_damping;

		public float m_swingSpan1;
		public float m_swingSpan2;
		public float m_twistSpan;

		public float m_fixThresh;

		public Vector3 m_swingAxis;
		public Vector3 m_twistAxis;

		public float m_kSwing;
		public float m_kTwist;

		public float m_twistLimitSign;
		public float m_swingCorrection;
		public float m_twistCorrection;

		public float m_twistAngle;

		public float m_accSwingLimitImpulse;
		public float m_accTwistLimitImpulse;

		public bool m_angularOnly;
		public bool m_solveTwistLimit;
		public bool m_solveSwingLimit;

		// not yet used...
		public float m_swingLimitRatio;
		public float m_twistLimitRatio;
		public Vector3 m_twistAxisA;

		// motor
		public bool m_bMotorEnabled;
		public bool m_bNormalizedMotorStrength;
		public Quaternion m_qTarget = Quaternion.Identity;
		public float m_maxMotorImpulse;
		public Vector3 m_accMotorImpulse;

		// parameters
		public int m_flags;
		public float m_linCFM;
		public float m_linERP;
		public float m_angCFM;

		public ConeTwistConstraint(RigidBody rbA, RigidBody rbB, ref Matrix rbAFrame, ref Matrix rbBFrame) :
			base(TypedConstraintType.CONETWIST_CONSTRAINT_TYPE, rbA, rbB)
		{
			m_angularOnly = false;
			m_rbAFrame = rbAFrame;
			m_rbBFrame = rbBFrame;
			Init();
		}

		public ConeTwistConstraint(RigidBody rbA, ref Matrix rbAFrame)
			: base(TypedConstraintType.CONETWIST_CONSTRAINT_TYPE, rbA)
		{
			m_rbAFrame = rbAFrame;
			m_rbBFrame = rbAFrame;
			m_angularOnly = false;
			Init();
		}

		protected void Init()
		{
			m_angularOnly = false;
			m_solveTwistLimit = false;
			m_solveSwingLimit = false;
			m_bMotorEnabled = false;
			m_maxMotorImpulse = -1f;

			SetLimit(MathUtil.BT_LARGE_FLOAT, MathUtil.BT_LARGE_FLOAT, MathUtil.BT_LARGE_FLOAT);
			m_damping = 0.01f;
			m_fixThresh = CONETWIST_DEF_FIX_THRESH;
			m_flags = 0;
			m_linCFM = 0f;
			m_linERP = 0.7f;
			m_angCFM = 0.0f;
		}



		public static float ComputeAngularImpulseDenominator(ref Vector3 axis, ref Matrix invInertiaWorld)
		{
			Vector3 vec = MathUtil.TransposeTransformNormal(axis, invInertiaWorld);
			return Vector3.Dot(axis, vec);
		}


		public void GetInfo1NonVirtual(ConstraintInfo1 info)
		{
			//always reserve 6 rows: object transform is not available on SPU
			info.m_numConstraintRows = 6;
			info.nub = 0;
		}

		public override void GetInfo1(ConstraintInfo1 info)
		{
			info.m_numConstraintRows = 3;
			info.nub = 3;
			if(BulletGlobals.g_streamWriter != null && debugConstraint)
			{
				PrintInfo1(BulletGlobals.g_streamWriter, this, info);
			}

			CalcAngleInfo2(m_rbA.GetCenterOfMassTransform(), m_rbB.GetCenterOfMassTransform(), m_rbA.GetInvInertiaTensorWorld(), m_rbB.GetInvInertiaTensorWorld());
			if (m_solveSwingLimit)
			{
				info.m_numConstraintRows++;
				info.nub--;
				if ((m_swingSpan1 < m_fixThresh) && (m_swingSpan2 < m_fixThresh))
				{
					info.m_numConstraintRows++;
					info.nub--;
				}
			}
			if (m_solveTwistLimit)
			{
				info.m_numConstraintRows++;
				info.nub--;
			}
		}

		public override void GetInfo2(ConstraintInfo2 info)
		{
			GetInfo2NonVirtual(info, m_rbA.GetCenterOfMassTransform(),
								m_rbB.GetCenterOfMassTransform(),
								m_rbA.GetInvInertiaTensorWorld(),
								m_rbB.GetInvInertiaTensorWorld());
		}

		public void GetInfo2NonVirtual(ConstraintInfo2 info, Matrix transA, Matrix transB, Matrix invInertiaWorldA, Matrix invInertiaWorldB)
		{
			CalcAngleInfo2(ref transA, ref transB, ref invInertiaWorldA, ref invInertiaWorldB);

			// set jacobian
			info.m_solverConstraints[0].m_contactNormal.X = 1f;
			info.m_solverConstraints[1].m_contactNormal.Y = 1f;
			info.m_solverConstraints[2].m_contactNormal.Z = 1f;

			Vector3 a1 = Vector3.TransformNormal(m_rbAFrame.Translation, transA);
			{
				Vector3 a1neg = -a1;
				MathUtil.GetSkewSymmetricMatrix(ref a1neg, ref info.m_solverConstraints[0].m_relpos1CrossNormal, ref info.m_solverConstraints[1].m_relpos1CrossNormal, ref info.m_solverConstraints[2].m_relpos1CrossNormal);
			}

			Vector3 a2 = Vector3.TransformNormal(m_rbBFrame.Translation, transB);
			{
				MathUtil.GetSkewSymmetricMatrix(ref a2, ref info.m_solverConstraints[0].m_relpos2CrossNormal, ref info.m_solverConstraints[1].m_relpos2CrossNormal, ref info.m_solverConstraints[2].m_relpos2CrossNormal);
			}

			// set right hand side
			float linERP = ((m_flags & (int)ConeTwistFlags.BT_CONETWIST_FLAGS_LIN_ERP) != 0) ? m_linERP : info.erp;
			float k = info.fps * linERP;

			for (int j = 0; j < 3; j++)
			{
				info.m_solverConstraints[j].m_rhs = k * (MathUtil.VectorComponent(ref a2, j) + MathUtil.VectorComponent(transB.Translation, j) - MathUtil.VectorComponent(ref a1, j) - MathUtil.VectorComponent(transA.Translation, j));
				info.m_solverConstraints[j].m_lowerLimit = -MathUtil.SIMD_INFINITY;
				info.m_solverConstraints[j].m_upperLimit = MathUtil.SIMD_INFINITY;
				if ((m_flags & (int)ConeTwistFlags.BT_CONETWIST_FLAGS_LIN_CFM) != 0)
				{
					info.m_solverConstraints[j].m_cfm = m_linCFM;
				}
			}
			int row = 3;

			Vector3 ax1;
			// angular limits
			if (m_solveSwingLimit)
			{
				if ((m_swingSpan1 < m_fixThresh) && (m_swingSpan2 < m_fixThresh))
				{
					Matrix trA = MathUtil.BulletMatrixMultiply(transA, m_rbAFrame);

					Vector3 p = MathUtil.MatrixColumn(ref trA, 1);
					Vector3 q = MathUtil.MatrixColumn(ref trA, 2);
					info.m_solverConstraints[row].m_relpos1CrossNormal = p;
					info.m_solverConstraints[row + 1].m_relpos1CrossNormal = q;
					info.m_solverConstraints[row].m_relpos2CrossNormal = -p;
					info.m_solverConstraints[row + 1].m_relpos2CrossNormal = -q;

					float fact = info.fps * m_relaxationFactor;
					info.m_solverConstraints[row].m_rhs = fact * Vector3.Dot(m_swingAxis, p);
					info.m_solverConstraints[row + 1].m_rhs = fact * Vector3.Dot(m_swingAxis, q);
					info.m_solverConstraints[row].m_lowerLimit = -MathUtil.SIMD_INFINITY;
					info.m_solverConstraints[row].m_upperLimit = MathUtil.SIMD_INFINITY;
					info.m_solverConstraints[row + 1].m_lowerLimit = -MathUtil.SIMD_INFINITY;
					info.m_solverConstraints[row + 1].m_upperLimit = MathUtil.SIMD_INFINITY;
					row += 2;
				}
				else
				{
					ax1 = m_swingAxis * m_relaxationFactor * m_relaxationFactor;
					info.m_solverConstraints[row].m_relpos1CrossNormal = ax1;
					info.m_solverConstraints[row].m_relpos2CrossNormal = -ax1;

					float k1 = info.fps * m_biasFactor;

					info.m_solverConstraints[row].m_rhs = k1 * m_swingCorrection;
					if ((m_flags & (int)ConeTwistFlags.BT_CONETWIST_FLAGS_ANG_CFM) != 0)
					{
						info.m_solverConstraints[row].m_cfm = m_angCFM;
					}
					// m_swingCorrection is always positive or 0
					info.m_solverConstraints[row].m_lowerLimit = 0;
					info.m_solverConstraints[row].m_upperLimit = MathUtil.SIMD_INFINITY;
					++row;
				}
			}
			if (m_solveTwistLimit)
			{
				ax1 = m_twistAxis * m_relaxationFactor * m_relaxationFactor;
				info.m_solverConstraints[row].m_relpos1CrossNormal = ax1;
				info.m_solverConstraints[row].m_relpos2CrossNormal = -ax1;
				float k1 = info.fps * m_biasFactor;
				info.m_solverConstraints[row].m_rhs = k1 * m_twistCorrection;
				if ((m_flags & (int)ConeTwistFlags.BT_CONETWIST_FLAGS_ANG_CFM) != 0)
				{
					info.m_solverConstraints[row].m_cfm = m_angCFM;
				}

				if (m_twistSpan > 0.0f)
				{
					if (m_twistCorrection > 0.0f)
					{
						info.m_solverConstraints[row].m_lowerLimit = 0;
						info.m_solverConstraints[row].m_upperLimit = MathUtil.SIMD_INFINITY;
					}
					else
					{
						info.m_solverConstraints[row].m_lowerLimit = -MathUtil.SIMD_INFINITY;
						info.m_solverConstraints[row].m_upperLimit = 0;
					}
				}
				else
				{
					info.m_solverConstraints[row].m_lowerLimit = -MathUtil.SIMD_INFINITY;
					info.m_solverConstraints[row].m_upperLimit = MathUtil.SIMD_INFINITY;
				}
				++row;
			}

			if (BulletGlobals.g_streamWriter != null && debugConstraint)
			{
				PrintInfo2(BulletGlobals.g_streamWriter, this, info);
			}

		}

		public void UpdateRHS(float timeStep)
		{
		}

		void SetAngularOnly(bool angularOnly)
		{
			m_angularOnly = angularOnly;
		}

		void SetLimit(int limitIndex, float limitValue)
		{
			switch (limitIndex)
			{
				case 3:
					{
						m_twistSpan = limitValue;
						break;
					}
				case 4:
					{
						m_swingSpan2 = limitValue;
						break;
					}
				case 5:
					{
						m_swingSpan1 = limitValue;
						break;
					}
				default:
					{
						break;
					}
			}
		}
		public void SetLimit(float _swingSpan1, float _swingSpan2, float _twistSpan)
		{
			SetLimit(_swingSpan1, _swingSpan2, _twistSpan, 1f, .3f, 1f);
		}

		public void SetLimit(float _swingSpan1, float _swingSpan2, float _twistSpan, float _softness, float _biasFactor, float _relaxationFactor)
		{
			m_swingSpan1 = _swingSpan1;
			m_swingSpan2 = _swingSpan2;
			m_twistSpan = _twistSpan;

			m_limitSoftness = _softness;
			m_biasFactor = _biasFactor;
			m_relaxationFactor = _relaxationFactor;
		}

		public Matrix GetAFrame() { return m_rbAFrame; }
		public Matrix GetBFrame() { return m_rbBFrame; }

		public bool GetSolveTwistLimit()
		{
			return m_solveTwistLimit;
		}

		public bool GetSolveSwingLimit()
		{
			return m_solveTwistLimit;
		}

		public float GetTwistLimitSign()
		{
			return m_twistLimitSign;
		}

		public void CalcAngleInfo()
		{
			m_swingCorrection = 0f;
			m_twistLimitSign = 0f;
			m_solveTwistLimit = false;
			m_solveSwingLimit = false;

			Vector3 b1Axis1 = Vector3.Zero, b1Axis2 = Vector3.Zero, b1Axis3 = Vector3.Zero;
			Vector3 b2Axis1 = Vector3.Zero, b2Axis2 = Vector3.Zero;

			Matrix transA = GetRigidBodyA().GetCenterOfMassTransform();
			Matrix transB = GetRigidBodyB().GetCenterOfMassTransform();

			b1Axis1 = Vector3.TransformNormal(MathUtil.MatrixColumn(this.m_rbAFrame, 0), transA);
			b2Axis1 = Vector3.TransformNormal(MathUtil.MatrixColumn(this.m_rbBFrame, 0), transB);

			float swing1 = 0f, swing2 = 0f;

			float swx = 0f, swy = 0f;
			float thresh = 10f;
			float fact;

			// Get Frame into world space
			if (m_swingSpan1 >= 0.05f)
			{
				b1Axis2 = Vector3.TransformNormal(MathUtil.MatrixColumn(this.m_rbAFrame, 1), transA);
				swx = Vector3.Dot(b2Axis1, b1Axis1);
				swy = Vector3.Dot(b2Axis1, b1Axis2);
				swing1 = (float)System.Math.Atan2(swy, swx);
				fact = (swy * swy + swx * swx) * thresh * thresh;
				fact = fact / (fact + 1f);
				swing1 *= fact;
			}

			if (m_swingSpan2 >= 0.05f)
			{
				b1Axis3 = Vector3.TransformNormal(MathUtil.MatrixColumn(this.m_rbAFrame, 2), transA);
				swx = Vector3.Dot(b2Axis1, b1Axis1);
				swy = Vector3.Dot(b2Axis1, b1Axis3);
				swing2 = (float)System.Math.Atan2(swy, swx);
				fact = (swy * swy + swx * swx) * thresh * thresh;
				fact = fact / (fact + 1f);
				swing2 *= fact;
			}

			float RMaxAngle1Sq = 1.0f / (m_swingSpan1 * m_swingSpan1);
			float RMaxAngle2Sq = 1.0f / (m_swingSpan2 * m_swingSpan2);
			float EllipseAngle = System.Math.Abs(swing1 * swing1) * RMaxAngle1Sq + System.Math.Abs(swing2 * swing2) * RMaxAngle2Sq;

			if (EllipseAngle > 1.0f)
			{
				m_swingCorrection = EllipseAngle - 1.0f;
				m_solveSwingLimit = true;
				// Calculate necessary axis & factors
				m_swingAxis = Vector3.Cross(b2Axis1, (b1Axis2 * Vector3.Dot(b2Axis1, b1Axis2) + b1Axis3 * Vector3.Dot(b2Axis1, b1Axis3)));
				m_swingAxis.Normalize();
				float swingAxisSign = (Vector3.Dot(b2Axis1, b1Axis1) >= 0.0f) ? 1.0f : -1.0f;
				m_swingAxis *= swingAxisSign;
			}

			// Twist limits
			if (m_twistSpan >= 0f)
			{
				Vector3 b2Axis2a = Vector3.TransformNormal(MathUtil.MatrixColumn(this.m_rbBFrame, 1), transB);
				Quaternion rotationArc = MathUtil.ShortestArcQuat(ref b2Axis1, ref b1Axis1);
				Vector3 TwistRef = MathUtil.QuatRotate(ref rotationArc, ref b2Axis2a);
				float twist = (float)System.Math.Atan2(Vector3.Dot(TwistRef, b1Axis3), Vector3.Dot(TwistRef, b1Axis2));
				m_twistAngle = twist;

				//		float lockedFreeFactor = (m_twistSpan > float(0.05f)) ? m_limitSoftness : float(0.);
				float lockedFreeFactor = (m_twistSpan > 0.05f) ? 1.0f : 0f;
				if (twist <= -m_twistSpan * lockedFreeFactor)
				{
					m_twistCorrection = -(twist + m_twistSpan);
					m_solveTwistLimit = true;
					m_twistAxis = (b2Axis1 + b1Axis1) * 0.5f;
					m_twistAxis.Normalize();
					m_twistAxis *= -1.0f;
				}
				else if (twist > m_twistSpan * lockedFreeFactor)
				{
					m_twistCorrection = (twist - m_twistSpan);
					m_solveTwistLimit = true;
					m_twistAxis = (b2Axis1 + b1Axis1) * 0.5f;
					m_twistAxis.Normalize();
				}
			}

		}

		public void CalcAngleInfo2(Matrix transA, Matrix transB, Matrix invInertiaWorldA, Matrix invInertiaWorldB)
		{
			CalcAngleInfo2(ref transA, ref transB, ref invInertiaWorldA, ref invInertiaWorldB);
		}

		public void CalcAngleInfo2(ref Matrix transA, ref Matrix transB, ref Matrix invInertiaWorldA, ref Matrix invInertiaWorldB)
		{
			m_swingCorrection = 0;
			m_twistLimitSign = 0;
			m_solveTwistLimit = false;
			m_solveSwingLimit = false;

			// compute rotation of A wrt B (in constraint space)
			if (m_bMotorEnabled)
			{	// it is assumed that setMotorTarget() was alredy called 
				// and motor target m_qTarget is within constraint limits
				// TODO : split rotation to pure swing and pure twist
				// compute desired transforms in world
				Matrix trPose = Matrix.CreateFromQuaternion(m_qTarget);
				Matrix trA = MathUtil.BulletMatrixMultiply(ref transA, ref m_rbAFrame);
				Matrix trB = MathUtil.BulletMatrixMultiply(ref transB, ref m_rbBFrame);
				Matrix trDeltaAB = MathUtil.BulletMatrixMultiply(trB, MathUtil.BulletMatrixMultiply(trPose, Matrix.Invert(trA)));
				Quaternion qDeltaAB = Quaternion.CreateFromRotationMatrix(trDeltaAB);
				Vector3 swingAxis = new Vector3(qDeltaAB.X, qDeltaAB.Y, qDeltaAB.Z);
				m_swingAxis = swingAxis;
				m_swingAxis.Normalize();
				m_swingCorrection = MathUtil.QuatAngle(ref qDeltaAB);
				if (!MathUtil.FuzzyZero(m_swingCorrection))
				{
					m_solveSwingLimit = true;
				}
				return;
			}


			{

				// compute rotation of A wrt B (in constraint space)
				// Not sure if these need order swapping as well?
				Quaternion q1 = Quaternion.CreateFromRotationMatrix(transA);
				Quaternion q2 = Quaternion.CreateFromRotationMatrix(m_rbAFrame);
				Quaternion q3 = Quaternion.CreateFromRotationMatrix(transB);
				Quaternion q4 = Quaternion.CreateFromRotationMatrix(m_rbBFrame);

				Quaternion qA = Quaternion.CreateFromRotationMatrix(transA) * Quaternion.CreateFromRotationMatrix(m_rbAFrame);
				Quaternion qB = Quaternion.CreateFromRotationMatrix(transB) * Quaternion.CreateFromRotationMatrix(m_rbBFrame);
				Quaternion qAB = MathUtil.QuaternionInverse(qB) * qA;

				// split rotation into cone and twist
				// (all this is done from B's perspective. Maybe I should be averaging axes...)
				Vector3 vConeNoTwist = MathUtil.QuatRotate(ref qAB, ref vTwist);
				vConeNoTwist.Normalize();
				Quaternion qABCone = MathUtil.ShortestArcQuat(ref vTwist, ref vConeNoTwist);
				qABCone.Normalize();
				Quaternion qABTwist = MathUtil.QuaternionInverse(qABCone) * qAB;
				qABTwist.Normalize();

				if (m_swingSpan1 >= m_fixThresh && m_swingSpan2 >= m_fixThresh)
				{
					float swingAngle = 0f, swingLimit = 0f;
					Vector3 swingAxis = Vector3.Zero;
					ComputeConeLimitInfo(ref qABCone, ref swingAngle, ref swingAxis, ref swingLimit);

					if (swingAngle > swingLimit * m_limitSoftness)
					{
						m_solveSwingLimit = true;

						// compute limit ratio: 0->1, where
						// 0 == beginning of soft limit
						// 1 == hard/real limit
						m_swingLimitRatio = 1f;
						if (swingAngle < swingLimit && m_limitSoftness < 1f - MathUtil.SIMD_EPSILON)
						{
							m_swingLimitRatio = (swingAngle - swingLimit * m_limitSoftness) /
												(swingLimit - (swingLimit * m_limitSoftness));
						}

						// swing correction tries to get back to soft limit
						m_swingCorrection = swingAngle - (swingLimit * m_limitSoftness);

						// adjustment of swing axis (based on ellipse normal)
						AdjustSwingAxisToUseEllipseNormal(ref swingAxis);

						// Calculate necessary axis & factors		
						m_swingAxis = MathUtil.QuatRotate(qB, -swingAxis);

						m_twistAxisA = Vector3.Zero;

						m_kSwing = 1f /
							(ComputeAngularImpulseDenominator(ref m_swingAxis, ref invInertiaWorldA) +
							 ComputeAngularImpulseDenominator(ref m_swingAxis, ref invInertiaWorldB));
					}
				}
				else
				{
					// you haven't set any limits;
					// or you're trying to set at least one of the swing limits too small. (if so, do you really want a conetwist constraint?)
					// anyway, we have either hinge or fixed joint

					Vector3 ivA = Vector3.TransformNormal(MathUtil.MatrixColumn(this.m_rbAFrame, 0), transA);
					Vector3 jvA = Vector3.TransformNormal(MathUtil.MatrixColumn(this.m_rbAFrame, 1), transA);
					Vector3 kvA = Vector3.TransformNormal(MathUtil.MatrixColumn(this.m_rbAFrame, 2), transA);
					Vector3 ivB = Vector3.TransformNormal(MathUtil.MatrixColumn(this.m_rbBFrame, 0), transB);
					Vector3 target = Vector3.Zero;
					float x = Vector3.Dot(ivB, ivA);
					float y = Vector3.Dot(ivB, jvA);
					float z = Vector3.Dot(ivB, kvA);
					if ((m_swingSpan1 < m_fixThresh) && (m_swingSpan2 < m_fixThresh))
					{ // fixed. We'll need to add one more row to constraint
						if ((!MathUtil.FuzzyZero(y)) || (!(MathUtil.FuzzyZero(z))))
						{
							m_solveSwingLimit = true;
							m_swingAxis = -Vector3.Cross(ivB, ivA);
						}
					}
					else
					{
						if (m_swingSpan1 < m_fixThresh)
						{ // hinge around Y axis
							if (!(MathUtil.FuzzyZero(y)))
							{
								m_solveSwingLimit = true;
								if (m_swingSpan2 >= m_fixThresh)
								{
									y = 0;
									float span2 = (float)System.Math.Atan2(z, x);
									if (span2 > m_swingSpan2)
									{
										x = (float)System.Math.Cos(m_swingSpan2);
										z = (float)System.Math.Sin(m_swingSpan2);
									}
									else if (span2 < -m_swingSpan2)
									{
										x = (float)System.Math.Cos(m_swingSpan2);
										z = -(float)System.Math.Sin(m_swingSpan2);
									}
								}
							}
						}
						else
						{ // hinge around Z axis
							if (!MathUtil.FuzzyZero(z))
							{
								m_solveSwingLimit = true;
								if (m_swingSpan1 >= m_fixThresh)
								{
									z = 0f;
									float span1 = (float)System.Math.Atan2(y, x);
									if (span1 > m_swingSpan1)
									{
										x = (float)System.Math.Cos(m_swingSpan1);
										y = (float)System.Math.Sin(m_swingSpan1);
									}
									else if (span1 < -m_swingSpan1)
									{
										x = (float)System.Math.Cos(m_swingSpan1);
										y = -(float)System.Math.Sin(m_swingSpan1);
									}
								}
							}
						}
						target.X = x * ivA.X + y * jvA.X + z * kvA.X;
						target.Y = x * ivA.Y + y * jvA.Y + z * kvA.Y;
						target.Z = x * ivA.Z + y * jvA.Z + z * kvA.Z;
						target.Normalize();
						m_swingAxis = -Vector3.Cross(ivB, target);
						m_swingCorrection = m_swingAxis.Length();
						m_swingAxis.Normalize();
					}
				}

				if (m_twistSpan >= 0f)
				{
					Vector3 twistAxis = Vector3.Zero;
					ComputeTwistLimitInfo(ref qABTwist, ref m_twistAngle, ref twistAxis);

					if (m_twistAngle > m_twistSpan * m_limitSoftness)
					{
						m_solveTwistLimit = true;

						m_twistLimitRatio = 1f;
						if (m_twistAngle < m_twistSpan && m_limitSoftness < 1f - MathUtil.SIMD_EPSILON)
						{
							m_twistLimitRatio = (m_twistAngle - m_twistSpan * m_limitSoftness) /
												(m_twistSpan - m_twistSpan * m_limitSoftness);
						}

						// twist correction tries to get back to soft limit
						m_twistCorrection = m_twistAngle - (m_twistSpan * m_limitSoftness);

						m_twistAxis = MathUtil.QuatRotate(qB, -twistAxis);

						m_kTwist = 1f /
							(ComputeAngularImpulseDenominator(ref m_twistAxis, ref invInertiaWorldA) +
							 ComputeAngularImpulseDenominator(ref m_twistAxis, ref invInertiaWorldB));
					}

					if (m_solveSwingLimit)
					{
						m_twistAxisA = MathUtil.QuatRotate(qA, -twistAxis);
					}
				}
				else
				{
					m_twistAngle = 0f;
				}
			}
		}

		public float GetSwingSpan1()
		{
			return m_swingSpan1;
		}
		public float GetSwingSpan2()
		{
			return m_swingSpan2;
		}
		public float GetTwistSpan()
		{
			return m_twistSpan;
		}
		public float GetTwistAngle()
		{
			return m_twistAngle;
		}
		public bool IsPastSwingLimit()
		{
			return m_solveSwingLimit;
		}

		public void SetDamping(float damping) 
		{ 
			m_damping = damping; 
		}

		public void EnableMotor(bool b) 
		{ 
			m_bMotorEnabled = b; 
		}
		public void SetMaxMotorImpulse(float maxMotorImpulse) 
		{ 
			m_maxMotorImpulse = maxMotorImpulse; 
			m_bNormalizedMotorStrength = false; 
		}
		public void SetMaxMotorImpulseNormalized(float maxMotorImpulse) 
		{ 
			m_maxMotorImpulse = maxMotorImpulse; 
			m_bNormalizedMotorStrength = true; 
		}

		public float GetFixThresh() 
		{ 
			return m_fixThresh; 
		}
		
		public void SetFixThresh(float fixThresh) 
		{ 
			m_fixThresh = fixThresh; 
		}

		// setMotorTarget:
		// q: the desired rotation of bodyA wrt bodyB.
		// note: if q violates the joint limits, the internal target is clamped to avoid conflicting impulses (very bad for stability)
		// note: don't forget to enableMotor()
		public void SetMotorTarget(ref Quaternion q)
		{
			Matrix trACur = m_rbA.GetCenterOfMassTransform();
			Matrix trBCur = m_rbB.GetCenterOfMassTransform();
			Matrix trABCur = MathUtil.BulletMatrixMultiply(Matrix.Invert(trBCur), trACur);
			Quaternion qABCur = Quaternion.CreateFromRotationMatrix(trABCur);
			Matrix trConstraintCur = MathUtil.BulletMatrixMultiply(Matrix.Invert(MathUtil.BulletMatrixMultiply(ref trBCur, ref m_rbBFrame)), MathUtil.BulletMatrixMultiply(ref trACur, ref m_rbAFrame));
			Quaternion qConstraintCur = Quaternion.CreateFromRotationMatrix(trConstraintCur);

			Quaternion qConstraint = MathUtil.QuaternionInverse(Quaternion.CreateFromRotationMatrix(m_rbBFrame)) * q * Quaternion.CreateFromRotationMatrix(m_rbAFrame);
			SetMotorTargetInConstraintSpace(ref qConstraint);
		}

		// same as above, but q is the desired rotation of frameA wrt frameB in constraint space
		public void SetMotorTargetInConstraintSpace(ref Quaternion q)
		{
			m_qTarget = q;

			// clamp motor target to within limits
			{
				float softness = 1f;//m_limitSoftness;

				// split into twist and cone
				Vector3 vTwisted = MathUtil.QuatRotate(ref m_qTarget, ref vTwist);
				Quaternion qTargetCone = MathUtil.ShortestArcQuat(ref vTwist, ref vTwisted); 
				qTargetCone.Normalize();
				Quaternion qTargetTwist = MathUtil.QuaternionMultiply(MathUtil.QuaternionInverse(qTargetCone), m_qTarget); 
				qTargetTwist.Normalize();

				// clamp cone
				if (m_swingSpan1 >= 0.05f && m_swingSpan2 >= 0.05f)
				{
					float swingAngle = 0f, swingLimit = 0f; Vector3 swingAxis = Vector3.Zero;
					ComputeConeLimitInfo(ref qTargetCone, ref swingAngle, ref swingAxis, ref swingLimit);

					if (System.Math.Abs(swingAngle) > MathUtil.SIMD_EPSILON)
					{
						if (swingAngle > swingLimit * softness)
						{
							swingAngle = swingLimit * softness;
						}
						else if (swingAngle < -swingLimit * softness)
						{
							swingAngle = -swingLimit * softness;
						}
						qTargetCone = Quaternion.CreateFromAxisAngle(swingAxis, swingAngle);
					}
				}

				// clamp twist
				if (m_twistSpan >= 0.05f)
				{
					float twistAngle = 0f; Vector3 twistAxis = Vector3.Zero;
					ComputeTwistLimitInfo(ref qTargetTwist, ref twistAngle, ref twistAxis);

					if (System.Math.Abs(twistAngle) > MathUtil.SIMD_EPSILON)
					{
						// eddy todo: limitSoftness used here???
						if (twistAngle > m_twistSpan * softness)
						{
							twistAngle = m_twistSpan * softness;
						}
						else if (twistAngle < -m_twistSpan * softness)
						{
							twistAngle = -m_twistSpan * softness;
						}
						qTargetTwist = Quaternion.CreateFromAxisAngle(twistAxis, twistAngle);
					}
				}

				m_qTarget = qTargetCone * qTargetTwist;
			}


		}

		public Vector3 GetPointForAngle(float fAngleInRadians, float fLength)
		{
			// compute x/y in ellipse using cone angle (0 -> 2*PI along surface of cone)
			float xEllipse = (float)System.Math.Cos(fAngleInRadians);
			float yEllipse = (float)System.Math.Sin(fAngleInRadians);

			// Use the slope of the vector (using x/yEllipse) and find the length
			// of the line that intersects the ellipse:
			//  x^2   y^2
			//  --- + --- = 1, where a and b are semi-major axes 2 and 1 respectively (ie. the limits)
			//  a^2   b^2
			// Do the math and it should be clear.

			float swingLimit = m_swingSpan1; // if xEllipse == 0, just use axis b (1)
			if (System.Math.Abs(xEllipse) > MathUtil.SIMD_EPSILON)
			{
				float surfaceSlope2 = (yEllipse * yEllipse) / (xEllipse * xEllipse);
				float norm = 1 / (m_swingSpan2 * m_swingSpan2);
				norm += surfaceSlope2 / (m_swingSpan1 * m_swingSpan1);
				float swingLimit2 = (1 + surfaceSlope2) / norm;
				swingLimit = (float)System.Math.Sqrt(swingLimit2);
			}

			// convert into point in constraint space:
			// note: twist is x-axis, swing 1 and 2 are along the z and y axes respectively
			Vector3 vSwingAxis = new Vector3(0, xEllipse, -yEllipse);
			Quaternion qSwing = Quaternion.CreateFromAxisAngle(vSwingAxis, swingLimit);
			Vector3 vPointInConstraintSpace = new Vector3(fLength, 0, 0);
			return MathUtil.QuatRotate(ref qSwing, ref vPointInConstraintSpace);
		}

		protected void ComputeConeLimitInfo(ref Quaternion qCone, // in
			ref float swingAngle, ref Vector3 vSwingAxis, ref float swingLimit) // all outs
		{
			swingAngle = MathUtil.QuatAngle(ref qCone);
			if (swingAngle > MathUtil.SIMD_EPSILON)
			{
				vSwingAxis = new Vector3(qCone.X, qCone.Y, qCone.Z);
				vSwingAxis.Normalize();
				if (System.Math.Abs(vSwingAxis.X) > MathUtil.SIMD_EPSILON)
				{
					// non-zero twist?! this should never happen.
					Debug.Assert(false);
				}

				// Compute limit for given swing. tricky:
				// Given a swing axis, we're looking for the intersection with the bounding cone ellipse.
				// (Since we're dealing with angles, this ellipse is embedded on the surface of a sphere.)

				// For starters, compute the direction from center to surface of ellipse.
				// This is just the perpendicular (ie. rotate 2D vector by PI/2) of the swing axis.
				// (vSwingAxis is the cone rotation (in z,y); change vars and rotate to (x,y) coords.)
				float xEllipse = vSwingAxis.Y;
				float yEllipse = -vSwingAxis.Z;

				// Now, we use the slope of the vector (using x/yEllipse) and find the length
				// of the line that intersects the ellipse:
				//  x^2   y^2
				//  --- + --- = 1, where a and b are semi-major axes 2 and 1 respectively (ie. the limits)
				//  a^2   b^2
				// Do the math and it should be clear.

				swingLimit = m_swingSpan1; // if xEllipse == 0, we have a pure vSwingAxis.z rotation: just use swingspan1
				if (System.Math.Abs(xEllipse) > MathUtil.SIMD_EPSILON)
				{
					float surfaceSlope2 = (yEllipse * yEllipse) / (xEllipse * xEllipse);
					float norm = 1f / (m_swingSpan2 * m_swingSpan2);
					norm += surfaceSlope2 / (m_swingSpan1 * m_swingSpan1);
					float swingLimit2 = (1 + surfaceSlope2) / norm;
					swingLimit = (float)System.Math.Sqrt(swingLimit2);
				}

				// test!
				/*swingLimit = m_swingSpan2;
				if (fabs(vSwingAxis.z()) > SIMD_EPSILON)
				{
				btScalar mag_2 = m_swingSpan1*m_swingSpan1 + m_swingSpan2*m_swingSpan2;
				btScalar sinphi = m_swingSpan2 / sqrt(mag_2);
				btScalar phi = asin(sinphi);
				btScalar theta = atan2(fabs(vSwingAxis.y()),fabs(vSwingAxis.z()));
				btScalar alpha = 3.14159f - theta - phi;
				btScalar sinalpha = sin(alpha);
				swingLimit = m_swingSpan1 * sinphi/sinalpha;
				}*/
			}
			else if (swingAngle < 0)
			{
				// this should never happen!
				Debug.Assert(false);
			}
		}

		protected void ComputeTwistLimitInfo(ref Quaternion qTwist, // in
			ref float twistAngle, ref Vector3 vTwistAxis) // all outs
		{
			Quaternion qMinTwist = qTwist;
			twistAngle = MathUtil.QuatAngle(ref qTwist);

			if (twistAngle > MathUtil.SIMD_PI) // long way around. flip quat and recalculate.
			{
				qMinTwist = Quaternion.Negate(qTwist);
				twistAngle = MathUtil.QuatAngle(ref qTwist);
			}
			if (twistAngle < 0f)
			{
				// this should never happen
				Debug.Assert(false);
			}

			vTwistAxis = new Vector3(qMinTwist.X, qMinTwist.Y, qMinTwist.Z);
			if (twistAngle > MathUtil.SIMD_EPSILON)
			{
				vTwistAxis.Normalize();
			}
		}

		protected void AdjustSwingAxisToUseEllipseNormal(ref Vector3 vSwingAxis)
		{
			// the swing axis is computed as the "twist-free" cone rotation,
			// but the cone limit is not circular, but elliptical (if swingspan1 != swingspan2).
			// so, if we're outside the limits, the closest way back inside the cone isn't 
			// along the vector back to the center. better (and more stable) to use the ellipse normal.

			// convert swing axis to direction from center to surface of ellipse
			// (ie. rotate 2D vector by PI/2)
			float y = -vSwingAxis.Z;
			float z = vSwingAxis.Y;

			// do the math...
			if (System.Math.Abs(z) > MathUtil.SIMD_EPSILON) // avoid division by 0. and we don't need an update if z == 0.
			{
				// compute gradient/normal of ellipse surface at current "point"
				float grad = y / z;
				grad *= m_swingSpan2 / m_swingSpan1;

				// adjust y/z to represent normal at point (instead of vector to point)
				if (y > 0)
				{
					y = System.Math.Abs(grad * z);
				}
				else
				{
					y = -System.Math.Abs(grad * z);
				}

				// convert ellipse direction back to swing axis
				vSwingAxis.Z = -y;
				vSwingAxis.Y = z;
				vSwingAxis.Normalize();
			}
		}
	}
}
