/*
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

using InVision.Bullet.Dynamics.Dynamics;
using InVision.Bullet.LinearMath;
using InVision.GameMath;

namespace InVision.Bullet.Dynamics.ConstraintSolver
{
    public class Generic6DofConstraint : TypedConstraint
    {
        public Generic6DofConstraint(RigidBody rbA, RigidBody rbB,  ref Matrix frameInA,  ref Matrix frameInB ,bool useLinearReferenceFrameA) : base(TypedConstraintType.D6_CONSTRAINT_TYPE,rbA,rbB)
        {
            m_frameInA = frameInA;
            m_frameInB = frameInB;
            m_useLinearReferenceFrameA = useLinearReferenceFrameA;
            m_useOffsetForConstraintFrame = D6_USE_FRAME_OFFSET;
            m_flags = 0;
            m_linearLimits = new TranslationalLimitMotor();
            m_angularLimits[0] = new RotationalLimitMotor();
            m_angularLimits[1] = new RotationalLimitMotor();
            m_angularLimits[2] = new RotationalLimitMotor();
            CalculateTransforms();
        }

        protected Generic6DofConstraint(RigidBody rbB, ref Matrix frameInB, bool useLinearReferenceFrameB) : base(TypedConstraintType.D6_CONSTRAINT_TYPE,GetFixedBody(),rbB)
        {
            m_frameInB = frameInB;
            m_useLinearReferenceFrameA = useLinearReferenceFrameB;
            m_useOffsetForConstraintFrame = D6_USE_FRAME_OFFSET;
            m_flags = 0;
            m_linearLimits = new TranslationalLimitMotor();
            m_angularLimits[0] = new RotationalLimitMotor();
            m_angularLimits[1] = new RotationalLimitMotor();
            m_angularLimits[2] = new RotationalLimitMotor();

            ///not providing rigidbody A means implicitly using worldspace for body A
	        m_frameInA = MathUtil.BulletMatrixMultiply(rbB.GetCenterOfMassTransform(),m_frameInB);

            CalculateTransforms();
        }

        protected virtual int SetAngularLimits(ConstraintInfo2 info, int row_offset,ref Matrix transA,ref Matrix transB,ref Vector3 linVelA,ref Vector3 linVelB,ref Vector3 angVelA,ref Vector3 angVelB)
        {
	        Generic6DofConstraint d6constraint = this;
	        int row = row_offset;
	        //solve angular limits
	        for (int i=0;i<3 ;i++ )
	        {
		        if(d6constraint.GetRotationalLimitMotor(i).NeedApplyTorques())
		        {
			        Vector3 axis = d6constraint.GetAxis(i);
                    int tempFlags = ((int)m_flags) >> ((i + 3) * BT_6DOF_FLAGS_AXIS_SHIFT);
                    SixDofFlags flags = (SixDofFlags)tempFlags;
                    if (0 == (flags & SixDofFlags.BT_6DOF_FLAGS_CFM_NORM))
			        {
				        m_angularLimits[i].m_normalCFM = info.m_solverConstraints[0].m_cfm;
			        }
                    if (0 == (flags & SixDofFlags.BT_6DOF_FLAGS_CFM_STOP))
			        {
                        m_angularLimits[i].m_stopCFM = info.m_solverConstraints[0].m_cfm;
			        }
                    if (0 == (flags & SixDofFlags.BT_6DOF_FLAGS_ERP_STOP))
			        {
                        m_angularLimits[i].m_stopERP = info.erp;
			        }
			        row += GetLimitMotorInfo2(d6constraint.GetRotationalLimitMotor(i),
												        ref transA,ref transB,ref linVelA,ref linVelB,ref angVelA,ref angVelB, info,row,ref axis,1,false);
		        }
	        }

	        return row;
        }



        protected virtual int SetLinearLimits(ConstraintInfo2 info, int row, ref Matrix transA,ref Matrix transB,ref Vector3 linVelA,ref Vector3 linVelB,ref Vector3 angVelA,ref Vector3 angVelB)
        {
            //solve linear limits
            RotationalLimitMotor limot = new RotationalLimitMotor();
            for (int i = 0; i < 3; i++)
            {
                if (m_linearLimits.NeedApplyForce(i))
                { // re-use rotational motor code
                    limot.m_bounce = 0f;
                    limot.m_currentLimit = m_linearLimits.m_currentLimit[i];
        			limot.m_currentPosition = MathUtil.VectorComponent(ref m_linearLimits.m_currentLinearDiff,i);
                    limot.m_currentLimitError = MathUtil.VectorComponent(ref m_linearLimits.m_currentLimitError,i);
                    limot.m_damping = m_linearLimits.m_damping;
                    limot.m_enableMotor = m_linearLimits.m_enableMotor[i];
                    limot.m_hiLimit = MathUtil.VectorComponent(m_linearLimits.m_upperLimit,i);
                    limot.m_limitSoftness = m_linearLimits.m_limitSoftness;
                    limot.m_loLimit = MathUtil.VectorComponent(m_linearLimits.m_lowerLimit,i);
                    limot.m_maxLimitForce = 0f;
                    limot.m_maxMotorForce = MathUtil.VectorComponent(m_linearLimits.m_maxMotorForce,i);
                    limot.m_targetVelocity = MathUtil.VectorComponent(m_linearLimits.m_targetVelocity,i);
                    Vector3 axis = MathUtil.MatrixColumn(m_calculatedTransformA,i);
                    int tempFlags = (((int)m_flags) >> (i * BT_6DOF_FLAGS_AXIS_SHIFT));
                    SixDofFlags flags = (SixDofFlags)tempFlags;
                    limot.m_normalCFM = ((flags & SixDofFlags.BT_6DOF_FLAGS_CFM_NORM) != 0) ? MathUtil.VectorComponent(ref m_linearLimits.m_normalCFM,i) : info.m_solverConstraints[0].m_cfm;
                    limot.m_stopCFM = ((flags & SixDofFlags.BT_6DOF_FLAGS_CFM_STOP) != 0) ? MathUtil.VectorComponent(ref m_linearLimits.m_stopCFM,i) : info.m_solverConstraints[0].m_cfm;
                    limot.m_stopERP = ((flags & SixDofFlags.BT_6DOF_FLAGS_ERP_STOP) != 0) ? MathUtil.VectorComponent(ref m_linearLimits.m_stopERP,i) : info.erp;
			        if(m_useOffsetForConstraintFrame)
			        {
				        int indx1 = (i + 1) % 3;
				        int indx2 = (i + 2) % 3;
				        bool rotAllowed = true; // rotations around orthos to current axis
				        if(m_angularLimits[indx1].m_currentLimit != 0 && m_angularLimits[indx2].m_currentLimit != 0)
				        {
					        rotAllowed = false;
				        }
				        row += GetLimitMotorInfo2(limot, ref transA,ref transB,ref linVelA,ref linVelB,ref angVelA,ref angVelB, info, row, ref axis, 0, rotAllowed);
			        }
			        else
			        {
				        row += GetLimitMotorInfo2(limot, ref transA,ref transB,ref linVelA,ref linVelB,ref angVelA,ref angVelB, info, row, ref axis, 0,false);
			        }
                }
            }
            return row;
        }

        protected virtual void BuildLinearJacobian(
            ref JacobianEntry jacLinear, ref Vector3 normalWorld,
            ref Vector3 pivotAInW, ref Vector3 pivotBInW)
        {
	        jacLinear = new JacobianEntry(
                MathUtil.TransposeBasis(m_rbA.GetCenterOfMassTransform()),
                MathUtil.TransposeBasis(m_rbB.GetCenterOfMassTransform()),
                pivotAInW - m_rbA.GetCenterOfMassPosition(),
                pivotBInW - m_rbB.GetCenterOfMassPosition(),
                normalWorld,
                m_rbA.GetInvInertiaDiagLocal(),
                m_rbA.GetInvMass(),
                m_rbB.GetInvInertiaDiagLocal(),
                m_rbB.GetInvMass());
        }

        protected virtual void BuildAngularJacobian(ref JacobianEntry jacAngular, ref Vector3 jointAxisW)
        {
	        jacAngular = new JacobianEntry(jointAxisW,
                                      MathUtil.TransposeBasis(m_rbA.GetCenterOfMassTransform()),
                                      MathUtil.TransposeBasis(m_rbB.GetCenterOfMassTransform()),
                                      m_rbA.GetInvInertiaDiagLocal(),
                                      m_rbB.GetInvInertiaDiagLocal());

        }

	    // tests linear limits
        protected virtual void CalculateLinearInfo()
        {
            m_calculatedLinearDiff = m_calculatedTransformB.Translation - m_calculatedTransformA.Translation;
            m_calculatedLinearDiff = Vector3.TransformNormal(m_calculatedLinearDiff,MathUtil.InverseBasis(ref m_calculatedTransformA));
            //for (int i = 0; i < 3; i++)
            //{
            //    m_linearLimits.testLimitValue(i, m_[i]);
            //}

            m_linearLimits.m_currentLinearDiff = m_calculatedLinearDiff;

            m_linearLimits.TestLimitValue(0, m_calculatedLinearDiff.X);
            m_linearLimits.TestLimitValue(1, m_calculatedLinearDiff.Y);
            m_linearLimits.TestLimitValue(2, m_calculatedLinearDiff.Z);

        }

	    //! calcs the euler angles between the two bodies.
        protected virtual void CalculateAngleInfo()
        {
            Matrix relative_frame = MathUtil.BulletMatrixMultiplyBasis(MathUtil.InverseBasis(m_calculatedTransformA),MathUtil.BasisMatrix(ref m_calculatedTransformB));
            MathUtil.MatrixToEulerXYZ(ref relative_frame,ref m_calculatedAxisAngleDiff);

            // in euler angle mode we do not actually constrain the angular velocity
            // along the axes axis[0] and axis[2] (although we do use axis[1]) :
            //
            //    to get			constrain w2-w1 along		...not
            //    ------			---------------------		------
            //    d(angle[0])/dt = 0	ax[1] x ax[2]			ax[0]
            //    d(angle[1])/dt = 0	ax[1]
            //    d(angle[2])/dt = 0	ax[0] x ax[1]			ax[2]
            //
            // constraining w2-w1 along an axis 'a' means that a'*(w2-w1)=0.
            // to prove the result for angle[0], write the expression for angle[0] from
            // GetInfo1 then take the derivative. to prove this for angle[2] it is
            // easier to take the euler rate expression for d(angle[2])/dt with respect
            // to the components of w and set that to 0.
            Vector3 axis0 = MathUtil.MatrixColumn(ref m_calculatedTransformB,0);
            Vector3 axis2 = MathUtil.MatrixColumn(ref m_calculatedTransformA,2);

            m_calculatedAxis[1] = Vector3.Cross(axis2,axis0);
            m_calculatedAxis[0] = Vector3.Cross(m_calculatedAxis[1],axis2);
            m_calculatedAxis[2] = Vector3.Cross(axis0,m_calculatedAxis[1]);

            m_calculatedAxis[0].Normalize();
            m_calculatedAxis[1].Normalize();
            m_calculatedAxis[2].Normalize();

        }



	    //! Calcs global transform of the offsets
	    /*!
	    Calcs the global transform for the joint offset for body A an B, and also calcs the agle differences between the bodies.
	    \sa btGeneric6DofConstraint.getCalculatedTransformA , btGeneric6DofConstraint.getCalculatedTransformB, btGeneric6DofConstraint.calculateAngleInfo
	    */
        public virtual void CalculateTransforms()
        {
        	CalculateTransforms(m_rbA.GetCenterOfMassTransform(),m_rbB.GetCenterOfMassTransform());
        }

        public virtual void CalculateTransforms(Matrix transA, Matrix transB)
        {
            CalculateTransforms(ref transA, ref transB);
        }

        public virtual void CalculateTransforms(ref Matrix transA,ref Matrix transB)
        {
	        m_calculatedTransformA = MathUtil.BulletMatrixMultiply(transA,m_frameInA);
	        m_calculatedTransformB = MathUtil.BulletMatrixMultiply(transB,m_frameInB);
	        CalculateLinearInfo();
	        CalculateAngleInfo();
	        if(m_useOffsetForConstraintFrame)
	        {	//  get weight factors depending on masses
		        float miA = GetRigidBodyA().GetInvMass();
		        float miB = GetRigidBodyB().GetInvMass();
		        m_hasStaticBody = (miA < MathUtil.SIMD_EPSILON) || (miB < MathUtil.SIMD_EPSILON);
		        float miS = miA + miB;
		        if(miS > 0.0f)
		        {
			        m_factA = miB / miS;
		        }
		        else 
		        {
			        m_factA = 0.5f;
		        }
		        m_factB = 1.0f - m_factA;
	        }
        }

	    //! Gets the global transform of the offset for body A
        /*!
        \sa btGeneric6DofConstraint.getFrameOffsetA, btGeneric6DofConstraint.getFrameOffsetB, btGeneric6DofConstraint.calculateAngleInfo.
        */
        public Matrix GetCalculatedTransformA()
        {
    	    return m_calculatedTransformA;
        }

        //! Gets the global transform of the offset for body B
        /*!
        \sa btGeneric6DofConstraint.getFrameOffsetA, btGeneric6DofConstraint.getFrameOffsetB, btGeneric6DofConstraint.calculateAngleInfo.
        */
        public Matrix GetCalculatedTransformB() 
        {
    	    return m_calculatedTransformB;
        }

        public Matrix GetFrameOffsetA() 
        {
    	    return m_frameInA;
        }

        public Matrix GetFrameOffsetB() 
        {
    	    return m_frameInB;
        }

        public override void GetInfo1(ConstraintInfo1 info)
        {
            //prepare constraint
		    CalculateTransforms(m_rbA.GetCenterOfMassTransform(),m_rbB.GetCenterOfMassTransform());
            info.m_numConstraintRows = 0;
            info.nub = 6;
            int i;
            //test linear limits
            for (i = 0; i < 3; i++)
            {
                if (m_linearLimits.NeedApplyForce(i))
                {
                    info.m_numConstraintRows++;
                    info.nub--;
                }
            }
            //test angular limits
            for (i = 0; i < 3; i++)
            {
                if (TestAngularLimitMotor(i))
                {
                    info.m_numConstraintRows++;
                    info.nub--;
                }
            }
        }

        public void GetInfo1NonVirtual(ConstraintInfo1 info)
        {
		    //pre-allocate all 6
		    info.m_numConstraintRows = 6;
		    info.nub = 0;
        }


        public override void GetInfo2(ConstraintInfo2 info)
        {
            GetInfo2NonVirtual(info,m_rbA.GetCenterOfMassTransform(),m_rbB.GetCenterOfMassTransform(), m_rbA.GetLinearVelocity(),m_rbB.GetLinearVelocity(),m_rbA.GetAngularVelocity(), m_rbB.GetAngularVelocity());        
        }

        public void GetInfo2NonVirtual(ConstraintInfo2 info,Matrix transA,Matrix transB,Vector3 linVelA,Vector3 linVelB,Vector3 angVelA,Vector3 angVelB)
        {
	        //prepare constraint
            CalculateTransforms(ref transA, ref transB);
	        if(m_useOffsetForConstraintFrame)
	        { // for stability better to solve angular limits first
                int row = SetAngularLimits(info, 0, ref transA, ref transB, ref linVelA, ref linVelB, ref angVelA, ref angVelB);
                SetLinearLimits(info, row, ref transA, ref transB, ref linVelA, ref linVelB, ref angVelA, ref angVelB);
	        }
	        else
	        { // leave old version for compatibility
                int row = SetLinearLimits(info, 0, ref transA, ref transB, ref linVelA, ref linVelB, ref angVelA, ref angVelB);
                SetAngularLimits(info, row, ref transA, ref transB, ref linVelA, ref linVelB, ref angVelA, ref angVelB);
	        }
        }

        public virtual void UpdateRHS(float timeStep)
        {
        }

	    //! Get the rotation axis in global coordinates
	    /*!
	    \pre btGeneric6DofConstraint.buildJacobian must be called previously.
	    */
        public virtual Vector3 GetAxis(int axis_index)
        {
            return m_calculatedAxis[axis_index];
        }

        //! Get the relative Euler angle
        /*!
	    \pre btGeneric6DofConstraint.buildJacobian must be called previously.
	    */
        public virtual float GetAngle(int axis_index)
        {
            return MathUtil.VectorComponent(ref m_calculatedAxisAngleDiff,axis_index);
        }

        //! Get the relative position of the constraint pivot
        /*!
	    \pre btGeneric6DofConstraint::calculateTransforms() must be called previously.
	    */
    	public float GetRelativePivotPosition(int axisIndex)
        {
	        return MathUtil.VectorComponent(ref m_calculatedLinearDiff,axisIndex);
        }


	    //! Test angular limit.
	    /*!
	    Calculates angular correction and returns true if limit needs to be corrected.
	    \pre btGeneric6DofConstraint::calculateTransforms() must be called previously.
	    */
        public virtual bool TestAngularLimitMotor(int axis_index)
        {
            float angle = MathUtil.VectorComponent(ref m_calculatedAxisAngleDiff, axis_index);
    	    angle = AdjustAngleToLimits(angle, m_angularLimits[axis_index].m_loLimit, m_angularLimits[axis_index].m_hiLimit);
	        m_angularLimits[axis_index].m_currentPosition = angle;

            //test limits
            m_angularLimits[axis_index].TestLimitValue(angle);
            return m_angularLimits[axis_index].NeedApplyTorques();
        }
        public void SetLinearLowerLimit(Vector3 linearLower)
        {
            SetLinearLowerLimit(ref linearLower);
        }

        public void	SetLinearLowerLimit(ref Vector3 linearLower)
        {
    	    m_linearLimits.m_lowerLimit = linearLower;
        }

        public void SetLinearUpperLimit(Vector3 linearUpper)
        {
            SetLinearUpperLimit(ref linearUpper);
        }

        public void SetLinearUpperLimit(ref Vector3 linearUpper)
        {
    	    m_linearLimits.m_upperLimit = linearUpper;
        }

        public void SetAngularLowerLimit(Vector3 angularLower)
        {
            SetAngularLowerLimit(ref angularLower);
        }

        public void SetAngularLowerLimit(ref Vector3 angularLower)
        {
            m_angularLimits[0].m_loLimit = MathUtil.NormalizeAngle(angularLower.X);
            m_angularLimits[1].m_loLimit = MathUtil.NormalizeAngle(angularLower.Y);
            m_angularLimits[2].m_loLimit = MathUtil.NormalizeAngle(angularLower.Z);
        }

        public void SetAngularUpperLimit(Vector3 angularUpper)
        {
            SetAngularUpperLimit(ref angularUpper);
        }

        public void SetAngularUpperLimit(ref Vector3 angularUpper)
        {
            m_angularLimits[0].m_hiLimit = MathUtil.NormalizeAngle(angularUpper.X);
            m_angularLimits[1].m_hiLimit = MathUtil.NormalizeAngle(angularUpper.Y);
            m_angularLimits[2].m_hiLimit = MathUtil.NormalizeAngle(angularUpper.Z);

        }

	    //! Retrieves the angular limit informacion
        public RotationalLimitMotor GetRotationalLimitMotor(int index)
        {
    	    return m_angularLimits[index];
        }

        //! Retrieves the  limit informacion
        public TranslationalLimitMotor GetTranslationalLimitMotor()
        {
    	    return m_linearLimits;
        }

        //first 3 are linear, next 3 are angular
        void SetLimit(int axis, float lo, float hi)
        {
    	    if(axis<3)
    	    {
    		    MathUtil.VectorComponent(ref m_linearLimits.m_lowerLimit,axis,lo);
    		    MathUtil.VectorComponent(ref m_linearLimits.m_upperLimit,axis,hi);
    	    }
    	    else
    	    {
			    lo = MathUtil.NormalizeAngle(lo);
			    hi = MathUtil.NormalizeAngle(hi);
    		    MathUtil.VectorComponent(ref m_linearLimits.m_lowerLimit,axis-3,lo);
    		    MathUtil.VectorComponent(ref m_linearLimits.m_upperLimit,axis-3,hi);
    	    }
        }

	    //! Test limit
	    /*!
        - free means upper < lower,
        - locked means upper == lower
        - limited means upper > lower
        - limitIndex: first 3 are linear, next 3 are angular
        */
        public bool	IsLimited(int limitIndex)
        {
    	    if(limitIndex<3)
    	    {
			    return m_linearLimits.IsLimited(limitIndex);

    	    }
            return m_angularLimits[limitIndex-3].IsLimited();
        }

        public virtual void CalcAnchorPos() // overridable
        {
	        float imA = m_rbA.GetInvMass();
	        float imB = m_rbB.GetInvMass();
	        float weight;
	        if(MathUtil.FuzzyZero(imB))
	        {
		        weight = 1.0f;
	        }
	        else
	        {
		        weight = imA / (imA + imB);
	        }
	        Vector3 pA = m_calculatedTransformA.Translation;
            Vector3 pB = m_calculatedTransformB.Translation;
	        m_AnchorPos = pA * weight + pB * (1.0f - weight);
	        return;
        }

        public virtual int GetLimitMotorInfo2(RotationalLimitMotor limot,
	                                ref Matrix transA,ref Matrix transB,ref Vector3 linVelA,
                                    ref Vector3 linVelB,ref Vector3 angVelA,ref Vector3 angVelB,
                                    ConstraintInfo2 info, int row, ref Vector3 ax1, int rotational,bool rotAllowed)
        {
            bool powered = limot.m_enableMotor;
            int limit = limot.m_currentLimit;
            if (powered || limit != 0)
            {   
                // if the joint is powered, or has joint limits, add in the extra row
                //btScalar* J1 = rotational ? info->m_J1angularAxis : info->m_J1linearAxis;
                //btScalar* J2 = rotational ? info->m_J2angularAxis : 0;
                //info2.m_J1linearAxis = currentConstraintRow->m_contactNormal;
                //info2.m_J1angularAxis = currentConstraintRow->m_relpos1CrossNormal;
                //info2.m_J2linearAxis = 0;
                //info2.m_J2angularAxis = currentConstraintRow->m_relpos2CrossNormal;
                if(rotational != 0)
                {
                    info.m_solverConstraints[row].m_relpos1CrossNormal = ax1;
                    MathUtil.ZeroCheckVector(info.m_solverConstraints[row].m_relpos1CrossNormal);
                }
                else
                {
                    info.m_solverConstraints[row].m_contactNormal = ax1;
                    MathUtil.ZeroCheckVector(info.m_solverConstraints[row].m_contactNormal);
                }

                if (rotational != 0)
                {
                    info.m_solverConstraints[row].m_relpos2CrossNormal = -ax1;
                }

                //MathUtil.zeroCheckVector(info.m_solverConstraints[row].m_relpos2CrossNormal);

                if (rotational == 0)
                {
                    if (m_useOffsetForConstraintFrame)
			        {
				        Vector3 tmpA = Vector3.Zero, tmpB= Vector3.Zero, relA= Vector3.Zero, relB= Vector3.Zero;
				        // get vector from bodyB to frameB in WCS
				        relB = m_calculatedTransformB.Translation - transB.Translation;
				        // get its projection to constraint axis
				        Vector3 projB = ax1 * Vector3.Dot(relB,ax1);
				        // get vector directed from bodyB to constraint axis (and orthogonal to it)
				        Vector3 orthoB = relB - projB;
				        // same for bodyA
				        relA = m_calculatedTransformA.Translation - transA.Translation;
				        Vector3 projA = ax1 * Vector3.Dot(relA,ax1);
				        Vector3 orthoA = relA - projA;
				        // get desired offset between frames A and B along constraint axis
				        float desiredOffs = limot.m_currentPosition - limot.m_currentLimitError;
				        // desired vector from projection of center of bodyA to projection of center of bodyB to constraint axis
				        Vector3 totalDist = projA + ax1 * desiredOffs - projB;
				        // get offset vectors relA and relB
				        relA = orthoA + totalDist * m_factA;
				        relB = orthoB - totalDist * m_factB;
				        tmpA = Vector3.Cross(relA,ax1);
				        tmpB = Vector3.Cross(relB,ax1);
				        if(m_hasStaticBody && (!rotAllowed))
				        {
					        tmpA *= m_factA;
					        tmpB *= m_factB;
				        }
                        info.m_solverConstraints[row].m_relpos1CrossNormal = tmpA;
                        MathUtil.ZeroCheckVector(ref tmpA);
                        info.m_solverConstraints[row].m_relpos2CrossNormal = -tmpB;
                        MathUtil.ZeroCheckVector(ref tmpB);
                    } 
                    else
                    {
                        Vector3 ltd;	// Linear Torque Decoupling vector
                        Vector3 c = m_calculatedTransformB.Translation - transA.Translation;
                        ltd = Vector3.Cross(c,ax1);
                        info.m_solverConstraints[row].m_relpos1CrossNormal = ltd;
                        MathUtil.ZeroCheckVector(info.m_solverConstraints[row].m_relpos1CrossNormal);

                        c = m_calculatedTransformB.Translation - transB.Translation;
                        ltd = -Vector3.Cross(c,ax1);
                        info.m_solverConstraints[row].m_relpos2CrossNormal = ltd;
                        MathUtil.ZeroCheckVector(info.m_solverConstraints[row].m_relpos2CrossNormal);
                    }
                }
                // if we're limited low and high simultaneously, the joint motor is
                // ineffective
                if (limit != 0 && (MathUtil.CompareFloat(limot.m_loLimit,limot.m_hiLimit)))
                {
                    powered = false;
                }
                info.m_solverConstraints[row].m_rhs = 0f;
                if (powered)
                {
                    info.m_solverConstraints[row].m_cfm = limot.m_normalCFM;
                    if (limit == 0)
                    {
                        float tag_vel = (rotational != 0)? limot.m_targetVelocity : -limot.m_targetVelocity;
        				float mot_fact = GetMotorFactor(limot.m_currentPosition, 
													limot.m_loLimit,
													limot.m_hiLimit, 
													tag_vel, 
													info.fps * limot.m_stopERP);

                        info.m_solverConstraints[row].m_rhs  += mot_fact * limot.m_targetVelocity;
                        info.m_solverConstraints[row].m_lowerLimit = -limot.m_maxMotorForce;
                        info.m_solverConstraints[row].m_upperLimit = limot.m_maxMotorForce;
                    }
                }
                if (limit != 0)
                {
                    float k = info.fps * limot.m_stopERP;
                    if (rotational == 0)
                    {
                        info.m_solverConstraints[row].m_rhs += k * limot.m_currentLimitError;
                    }
                    else
                    {
                        info.m_solverConstraints[row].m_rhs += -k * limot.m_currentLimitError;
                    }
                    info.m_solverConstraints[row].m_cfm = limot.m_stopCFM;
                    if (MathUtil.CompareFloat(limot.m_loLimit,limot.m_hiLimit))
                    {   // limited low and high simultaneously
                        info.m_solverConstraints[row].m_lowerLimit = -MathUtil.SIMD_INFINITY;
                        info.m_solverConstraints[row].m_upperLimit = MathUtil.SIMD_INFINITY;
                    }
                    else
                    {
                        if (limit == 1)
                        {
                            info.m_solverConstraints[row].m_lowerLimit = 0;
                            info.m_solverConstraints[row].m_upperLimit = MathUtil.SIMD_INFINITY;
                        }
                        else
                        {
                            info.m_solverConstraints[row].m_lowerLimit = -MathUtil.SIMD_INFINITY;
                            info.m_solverConstraints[row].m_upperLimit = 0;
                        }
                        // deal with bounce
                        if (limot.m_bounce > 0)
                        {
                            // calculate joint velocity
                            float vel;
                            if (rotational != 0)
                            {
                                vel = Vector3.Dot(angVelA,ax1);
                                vel -= Vector3.Dot(angVelB,ax1);
                            }
                            else
                            {
                                vel = Vector3.Dot(linVelA,ax1);
                                vel -= Vector3.Dot(linVelB,ax1);
                            }
                            // only apply bounce if the velocity is incoming, and if the
                            // resulting c[] exceeds what we already have.
                            if (limit == 1)
                            {
                                if (vel < 0)
                                {
                                    float newc = -limot.m_bounce * vel;
                                    if (newc > info.m_solverConstraints[row].m_rhs)
                                    {
                                        info.m_solverConstraints[row].m_rhs = newc;
                                    }
                                }
                            }
                            else
                            {
                                if (vel > 0)
                                {
                                    float newc = -limot.m_bounce * vel;
                                    if (newc < info.m_solverConstraints[row].m_rhs)
                                    {
                                        info.m_solverConstraints[row].m_rhs = newc;
                                    }
                                }
                            }
                        }
                    }
                }
                return 1;
            }
            else return 0;
        }

    	// access for UseFrameOffset
        public bool GetUseFrameOffset() { return m_useOffsetForConstraintFrame; }
        public void SetUseFrameOffset(bool frameOffsetOnOff) { m_useOffsetForConstraintFrame = frameOffsetOnOff; }

        
        //! relative_frames
        //!@{
	    protected Matrix m_frameInA= Matrix.Identity; //!< the constraint space w.r.t body A
        protected Matrix m_frameInB= Matrix.Identity; //!< the constraint space w.r.t body B
        //!@}

        //! Jacobians
        //!@{
        protected JacobianEntry[] m_jacLinear = new JacobianEntry[3];//!< 3 orthogonal linear constraints
        protected JacobianEntry[] m_jacAng = new JacobianEntry[3];//!< 3 orthogonal angular constraints
        //!@}

	    //! Linear_Limit_parameters
        //!@{
        protected TranslationalLimitMotor m_linearLimits;
        //!@}


        //! hinge_parameters
        //!@{
        protected RotationalLimitMotor[] m_angularLimits = new RotationalLimitMotor[3];
	    //!@}

        //! temporal variables
        //!@{
        protected float m_timeStep;
        protected Matrix m_calculatedTransformA= Matrix.Identity;
        protected Matrix m_calculatedTransformB= Matrix.Identity;
        protected Vector3 m_calculatedAxisAngleDiff;
        protected Vector3[] m_calculatedAxis = new Vector3[3];
        protected Vector3 m_calculatedLinearDiff;
       	protected float m_factA;
	    protected float m_factB;
	    protected bool m_hasStaticBody;
 
	    protected Vector3 m_AnchorPos; // point betwen pivots of bodies A and B to solve linear axes

        protected bool m_useLinearReferenceFrameA;
        protected bool m_useOffsetForConstraintFrame;
        protected int m_flags;

        public const int BT_6DOF_FLAGS_AXIS_SHIFT  = 3; // bits per axis
        public const bool D6_USE_FRAME_OFFSET = true;
        //!@}


    }
}
