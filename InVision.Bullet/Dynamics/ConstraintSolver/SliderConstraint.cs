﻿using System.Diagnostics;
using InVision.Bullet.Dynamics.Dynamics;
using InVision.Bullet.LinearMath;
using InVision.GameMath;

namespace InVision.Bullet.Dynamics.ConstraintSolver
{
    public class SliderConstraint : TypedConstraint
    {
        public const float SLIDER_CONSTRAINT_DEF_SOFTNESS = 1.0f;
        public const float SLIDER_CONSTRAINT_DEF_DAMPING = 1.0f;
        public const float SLIDER_CONSTRAINT_DEF_RESTITUTION = 0.7f;
        public const float SLIDER_CONSTRAINT_DEF_CFM = 0.0f;

        private const bool m_useSolveConstraintObsolete = false;
        private static bool USE_OFFSET_FOR_CONSTANT_FRAME = true;

        protected bool m_useOffsetForConstraintFrame;

        protected Matrix m_frameInA = Matrix.Identity;
        protected Matrix m_frameInB = Matrix.Identity; 
	    // use frameA fo define limits, if true
	    protected bool m_useLinearReferenceFrameA;
	    // linear limits
	    protected float m_lowerLinLimit;
	    protected float m_upperLinLimit;
	    // angular limits
	    protected float m_lowerAngLimit;
	    protected float m_upperAngLimit;
	    // softness, restitution and damping for different cases
	    // DirLin - moving inside linear limits
	    // LimLin - hitting linear limit
	    // DirAng - moving inside angular limits
	    // LimAng - hitting angular limit
	    // OrthoLin, OrthoAng - against raint axis
	    protected float m_softnessDirLin;
	    protected float m_restitutionDirLin;
	    protected float m_dampingDirLin;
        protected float m_cfmDirLin;
 
        protected float m_softnessDirAng;
	    protected float m_restitutionDirAng;
	    protected float m_dampingDirAng;
        protected float m_cfmDirAng;

        protected float m_softnessLimLin;
	    protected float m_restitutionLimLin;
	    protected float m_dampingLimLin;
        protected float m_cfmLimLin;

	    protected float m_softnessLimAng;
	    protected float m_restitutionLimAng;
	    protected float m_dampingLimAng;
        protected float m_cfmLimAng;

	    protected float m_softnessOrthoLin;
	    protected float m_restitutionOrthoLin;
	    protected float m_dampingOrthoLin;
        protected float m_cfmOrthoLin;

	    protected float m_softnessOrthoAng;
	    protected float m_restitutionOrthoAng;
	    protected float m_dampingOrthoAng;
        protected float m_cfmOrthoAng;

	    // for interlal use
	    protected bool m_solveLinLim;
	    protected bool m_solveAngLim;

        protected int m_flags;


	    protected JacobianEntry[]	m_jacLin = new JacobianEntry[3];
	    protected float[]	m_jacLinDiagABInv = new float[3];

        protected JacobianEntry[]	m_jacAng = new JacobianEntry[3];

	    protected float m_timeStep;
        protected Matrix m_calculatedTransformA = Matrix.Identity;
        protected Matrix m_calculatedTransformB = Matrix.Identity; 

        protected Vector3 m_sliderAxis;
	    protected Vector3 m_realPivotAInW;
	    protected Vector3 m_realPivotBInW;
	    protected Vector3 m_projPivotInW;
	    protected Vector3 m_delta;
	    protected Vector3 m_depth;
	    protected Vector3 m_relPosA;
	    protected Vector3 m_relPosB;

	    protected float m_linPos;
	    protected float m_angPos;

	    protected float m_angDepth;
	    protected float m_kAngle;

	    protected bool m_poweredLinMotor;
        protected float m_targetLinMotorVelocity;
        protected float m_maxLinMotorForce;
        protected float m_accumulatedLinMotorImpulse;
    	
	    protected bool m_poweredAngMotor;
        protected float m_targetAngMotorVelocity;
        protected float m_maxAngMotorForce;
        protected float m_accumulatedAngMotorImpulse;

	    //------------------------    

        // constructors
        public SliderConstraint(RigidBody rbA, RigidBody rbB, ref Matrix frameInA, ref Matrix frameInB, bool useLinearReferenceFrameA)
            : base(TypedConstraintType.SLIDER_CONSTRAINT_TYPE, rbA, rbB)
        {
            m_frameInA = frameInA;
            m_frameInB = frameInB;
            m_useLinearReferenceFrameA = useLinearReferenceFrameA;
            InitParams();

        }
        public SliderConstraint(RigidBody rbB, ref Matrix frameInB, bool useLinearReferenceFrameA)
            : base(TypedConstraintType.SLIDER_CONSTRAINT_TYPE, GetFixedBody(), rbB)
        {
            m_frameInB = frameInB;
            m_frameInA = MathUtil.BulletMatrixMultiply(rbB.GetCenterOfMassTransform(),m_frameInB);
            InitParams();
        }
        
        protected void InitParams()
        {
            m_lowerLinLimit = 1.0f;
            m_upperLinLimit = -1.0f;
            m_lowerAngLimit = 0f;
            m_upperAngLimit = 0f;
	        m_softnessDirLin = SLIDER_CONSTRAINT_DEF_SOFTNESS;
	        m_restitutionDirLin = SLIDER_CONSTRAINT_DEF_RESTITUTION;
	        m_dampingDirLin = 0f;
            m_cfmDirLin = SLIDER_CONSTRAINT_DEF_CFM;
	        m_softnessDirAng = SLIDER_CONSTRAINT_DEF_SOFTNESS;
	        m_restitutionDirAng = SLIDER_CONSTRAINT_DEF_RESTITUTION;
	        m_dampingDirAng = 0f;
            m_cfmDirAng = SLIDER_CONSTRAINT_DEF_CFM;
            m_softnessOrthoLin = SLIDER_CONSTRAINT_DEF_SOFTNESS;
	        m_restitutionOrthoLin = SLIDER_CONSTRAINT_DEF_RESTITUTION;
	        m_dampingOrthoLin = SLIDER_CONSTRAINT_DEF_DAMPING;
            m_cfmOrthoLin = SLIDER_CONSTRAINT_DEF_CFM;
            m_softnessOrthoAng = SLIDER_CONSTRAINT_DEF_SOFTNESS;
	        m_restitutionOrthoAng = SLIDER_CONSTRAINT_DEF_RESTITUTION;
	        m_dampingOrthoAng = SLIDER_CONSTRAINT_DEF_DAMPING;
            m_cfmOrthoAng = SLIDER_CONSTRAINT_DEF_CFM;
            m_softnessLimLin = SLIDER_CONSTRAINT_DEF_SOFTNESS;
	        m_restitutionLimLin = SLIDER_CONSTRAINT_DEF_RESTITUTION;
	        m_dampingLimLin = SLIDER_CONSTRAINT_DEF_DAMPING;
            m_cfmLimLin = SLIDER_CONSTRAINT_DEF_CFM;
            m_softnessLimAng = SLIDER_CONSTRAINT_DEF_SOFTNESS;
	        m_restitutionLimAng = SLIDER_CONSTRAINT_DEF_RESTITUTION;
	        m_dampingLimAng = SLIDER_CONSTRAINT_DEF_DAMPING;
            m_cfmLimAng = SLIDER_CONSTRAINT_DEF_CFM;

	        m_poweredLinMotor = false;
            m_targetLinMotorVelocity = 0f;
            m_maxLinMotorForce = 0f;
	        m_accumulatedLinMotorImpulse = 0f;

	        m_poweredAngMotor = false;
            m_targetAngMotorVelocity = 0f;
            m_maxAngMotorForce = 0f;
	        m_accumulatedAngMotorImpulse = 0f;

            m_useOffsetForConstraintFrame = USE_OFFSET_FOR_CONSTANT_FRAME;

			m_flags = 0;

            CalculateTransforms(m_rbA.GetCenterOfMassTransform(), m_rbB.GetCenterOfMassTransform());

        }
    

        public override void GetInfo1(ConstraintInfo1 info)
        {
            info.m_numConstraintRows = 4; // Fixed 2 linear + 2 angular
            info.nub = 2;
            //prepare constraint
            CalculateTransforms(m_rbA.GetCenterOfMassTransform(), m_rbB.GetCenterOfMassTransform());
            TestAngLimits();
            TestLinLimits();
            if (GetSolveLinLimit() || GetPoweredLinMotor())
            {
                info.m_numConstraintRows++; // limit 3rd linear as well
                info.nub--;
            }
			//testAngLimits();
            if (GetSolveAngLimit() || GetPoweredAngMotor())
            {
                info.m_numConstraintRows++; // limit 3rd angular as well
                info.nub--;
            }
            if (BulletGlobals.g_streamWriter != null && debugConstraint)
            {
                PrintInfo1(BulletGlobals.g_streamWriter,this,info);
            }
        }

        public void GetInfo1NonVirtual(ConstraintInfo1 info)
        {
            info.m_numConstraintRows = 6; // Fixed 2 linear + 2 angular + 1 limit (even if not used)
            info.nub = 0; 
        }


        public override void GetInfo2(ConstraintInfo2 info)
        {
            GetInfo2NonVirtual(info,m_rbA.GetCenterOfMassTransform(),m_rbB.GetCenterOfMassTransform(), m_rbA.GetLinearVelocity(),m_rbB.GetLinearVelocity(), m_rbA.GetInvMass(),m_rbB.GetInvMass());
        }

        public void GetInfo2NonVirtual(ConstraintInfo2 info, Matrix transA, Matrix transB, Vector3 linVelA, Vector3 linVelB, float rbAinvMass, float rbBinvMass)
        {
			
	        Matrix trA = GetCalculatedTransformA();
	        Matrix trB = GetCalculatedTransformB();
        	
	        Debug.Assert(!m_useSolveConstraintObsolete);
	        int i, s = 1;
        	
	        float signFact = m_useLinearReferenceFrameA ? 1.0f : -1.0f;
        	
	        // difference between frames in WCS
	        Vector3 ofs = trB.Translation - trA.Translation;
	        // now get weight factors depending on masses
	        float miA = rbAinvMass;
	        float miB = rbBinvMass;
	        bool hasStaticBody = (miA < MathUtil.SIMD_EPSILON) || (miB < MathUtil.SIMD_EPSILON);
	        float miS = miA + miB;
	        float factA, factB;
	        if(miS > 0.0f)
	        {
		        factA = miB / miS;
	        }
	        else 
	        {
		        factA = 0.5f;
	        }
	        factB = 1.0f - factA;
	        Vector3 ax1 = Vector3.Zero, p= Vector3.Zero, q= Vector3.Zero;
	        Vector3 ax1A = MathUtil.MatrixColumn(ref trA,0);
	        Vector3 ax1B = MathUtil.MatrixColumn(ref trB,0);
	        if(m_useOffsetForConstraintFrame)
	        {
		        // get the desired direction of slider axis
		        // as weighted sum of X-orthos of frameA and frameB in WCS
		        ax1 = ax1A * factA + ax1B * factB;
		        ax1.Normalize();
		        // construct two orthos to slider axis
		        TransformUtil.PlaneSpace1 (ref ax1, ref p, ref q);
	        }
	        else
	        { // old way - use frameA
		        ax1 = MathUtil.MatrixColumn(ref trA,0);
		        // get 2 orthos to slider axis (Y, Z)
		        p = MathUtil.MatrixColumn(ref trA,1);
		        q = MathUtil.MatrixColumn(ref trA,2);
	        }
	        // make rotations around these orthos equal
	        // the slider axis should be the only unconstrained
	        // rotational axis, the angular velocity of the two bodies perpendicular to
	        // the slider axis should be equal. thus the constraint equations are
	        //    p*w1 - p*w2 = 0
	        //    q*w1 - q*w2 = 0
	        // where p and q are unit vectors normal to the slider axis, and w1 and w2
	        // are the angular velocity vectors of the two bodies.
	        info.m_solverConstraints[0].m_relpos1CrossNormal = p;
	        info.m_solverConstraints[s].m_relpos1CrossNormal = q;

            info.m_solverConstraints[0].m_relpos2CrossNormal = -p;
	        info.m_solverConstraints[s].m_relpos2CrossNormal = -q;

            // compute the right hand side of the constraint equation. set relative
	        // body velocities along p and q to bring the slider back into alignment.
	        // if ax1A,ax1B are the unit length slider axes as computed from bodyA and
	        // bodyB, we need to rotate both bodies along the axis u = (ax1 x ax2).
	        // if "theta" is the angle between ax1 and ax2, we need an angular velocity
	        // along u to cover angle erp*theta in one step :
	        //   |angular_velocity| = angle/time = erp*theta / stepsize
	        //                      = (erp*fps) * theta
	        //    angular_velocity  = |angular_velocity| * (ax1 x ax2) / |ax1 x ax2|
	        //                      = (erp*fps) * theta * (ax1 x ax2) / sin(theta)
	        // ...as ax1 and ax2 are unit length. if theta is smallish,
	        // theta ~= sin(theta), so
	        //    angular_velocity  = (erp*fps) * (ax1 x ax2)
	        // ax1 x ax2 is in the plane space of ax1, so we project the angular
	        // velocity to p and q to find the right hand side.
        //	float k = info.fps * info.erp * getSoftnessOrthoAng();
	        float currERP = ((m_flags & (int)SliderFlags.BT_SLIDER_FLAGS_ERP_ORTANG) != 0) ? m_softnessOrthoAng : m_softnessOrthoAng * info.erp;
	        float k = info.fps * currERP;

	        Vector3 u = Vector3.Cross(ax1A,ax1B);
	        info.m_solverConstraints[0].m_rhs = k * Vector3.Dot(u,p);
	        info.m_solverConstraints[s].m_rhs = k * Vector3.Dot(u,q);
			if ((m_flags & (int)SliderFlags.BT_SLIDER_FLAGS_CFM_ORTANG) != 0)
	        {
		        info.m_solverConstraints[0].m_cfm = m_cfmOrthoAng;
		        info.m_solverConstraints[s].m_cfm = m_cfmOrthoAng;
	        }

	        int nrow = 1; // last filled row
	        int srow = nrow;
	        float limit_err;
	        int limit;
	        bool powered;

	        // next two rows. 
	        // we want: velA + wA x relA == velB + wB x relB ... but this would
	        // result in three equations, so we project along two orthos to the slider axis

	        Matrix bodyA_trans = transA;
	        Matrix bodyB_trans = transB;
	        nrow++;
	        int s2 = nrow * s;
	        nrow++;
	        int s3 = nrow * s;
            Vector3 tmpA = Vector3.Zero, tmpB = Vector3.Zero, relA = Vector3.Zero, relB = Vector3.Zero, c = Vector3.Zero;
	        if(m_useOffsetForConstraintFrame)
	        {
		        // get vector from bodyB to frameB in WCS
		        relB = trB.Translation - bodyB_trans.Translation;
		        // get its projection to slider axis
		        Vector3 projB = ax1 * Vector3.Dot(relB,ax1);
		        // get vector directed from bodyB to slider axis (and orthogonal to it)
		        Vector3 orthoB = relB - projB;
		        // same for bodyA
		        relA = trA.Translation - bodyA_trans.Translation;
		        Vector3 projA = ax1 * Vector3.Dot(relA,ax1);
		        Vector3 orthoA = relA - projA;
		        // get desired offset between frames A and B along slider axis
		        float sliderOffs = m_linPos - m_depth.X;
		        // desired vector from projection of center of bodyA to projection of center of bodyB to slider axis
		        Vector3 totalDist = projA + ax1 * sliderOffs - projB;
		        // get offset vectors relA and relB
		        relA = orthoA + totalDist * factA;
		        relB = orthoB - totalDist * factB;
		        // now choose average ortho to slider axis
		        p = orthoB * factA + orthoA * factB;
		        float len2 = p.LengthSquared();
		        if(len2 > MathUtil.SIMD_EPSILON)
		        {
					p.Normalize();
		        }
		        else
		        {
			        p = MathUtil.MatrixColumn(ref trA,1);
		        }
		        // make one more ortho
		        q = Vector3.Cross(ax1,p);
		        // fill two rows
		        tmpA = Vector3.Cross(relA,p);
		        tmpB = Vector3.Cross(relB,p);

                info.m_solverConstraints[s2].m_relpos1CrossNormal = tmpA;
                info.m_solverConstraints[s2].m_relpos2CrossNormal = -tmpB;

		        tmpA = Vector3.Cross(relA,q);
		        tmpB = Vector3.Cross(relB,q);

		        if(hasStaticBody && GetSolveAngLimit())
		        { // to make constraint between static and dynamic objects more rigid
			        // remove wA (or wB) from equation if angular limit is hit
			        tmpB *= factB;
			        tmpA *= factA;
		        }
                info.m_solverConstraints[s3].m_relpos1CrossNormal = tmpA;
                info.m_solverConstraints[s3].m_relpos2CrossNormal = -tmpB;
                info.m_solverConstraints[s2].m_contactNormal = p;
                info.m_solverConstraints[s3].m_contactNormal = q;
	        }
	        else
	        {	
                // old way - maybe incorrect if bodies are not on the slider axis
                // see discussion "Bug in slider constraint" http://bulletphysics.org/Bullet/phpBB3/viewtopic.php?f=9&t=4024&start=0
                Vector3 tmp = Vector3.Cross(c, p);

                info.m_solverConstraints[s2].m_relpos1CrossNormal = factA * tmp;
                info.m_solverConstraints[s2].m_relpos2CrossNormal = factB * tmp;

                tmp = Vector3.Cross(c, q);
                info.m_solverConstraints[s3].m_relpos1CrossNormal = factA * tmp;
                info.m_solverConstraints[s3].m_relpos2CrossNormal = factB * tmp;

                info.m_solverConstraints[s2].m_contactNormal = p;
                info.m_solverConstraints[s3].m_contactNormal = q;
	        }
	        // compute two elements of right hand side

	        //	k = info.fps * info.erp * getSoftnessOrthoLin();
			currERP = ((m_flags & (int)SliderFlags.BT_SLIDER_FLAGS_ERP_ORTLIN) != 0) ? m_softnessOrthoLin : m_softnessOrthoLin * info.erp;
	        k = info.fps * currERP;

	        float rhs = k * Vector3.Dot(p,ofs);
	        info.m_solverConstraints[s2].m_rhs = rhs;
	        rhs = k * Vector3.Dot(q,ofs);
	        info.m_solverConstraints[s3].m_rhs = rhs;
			if ((m_flags & (int)SliderFlags.BT_SLIDER_FLAGS_CFM_ORTLIN) != 0)
	        {
		        info.m_solverConstraints[s2].m_cfm = m_cfmOrthoLin;
		        info.m_solverConstraints[s3].m_cfm = m_cfmOrthoLin;
	        }

	        // check linear limits
	        limit_err = 0.0f;
	        limit = 0;
	        if(GetSolveLinLimit())
	        {
		        limit_err = GetLinDepth() *  signFact;
		        limit = (limit_err > 0f) ? 2 : 1;
	        }
	        powered = false;
	        if(GetPoweredLinMotor())
	        {
		        powered = true;
	        }
	        // if the slider has joint limits or motor, add in the extra row
	        if (limit != 0 || powered) 
	        {
		        nrow++;
		        srow = nrow;
                info.m_solverConstraints[srow].m_contactNormal = ax1;
		        // linear torque decoupling step:
		        //
		        // we have to be careful that the linear constraint forces (+/- ax1) applied to the two bodies
		        // do not create a torque couple. in other words, the points that the
		        // constraint force is applied at must lie along the same ax1 axis.
		        // a torque couple will result in limited slider-jointed free
		        // bodies from gaining angular momentum.
		        if(m_useOffsetForConstraintFrame)
		        {
			        // this is needed only when bodyA and bodyB are both dynamic.
			        if(!hasStaticBody)
			        {
				        tmpA = Vector3.Cross(relA,ax1);
				        tmpB = Vector3.Cross(relB,ax1);
                        info.m_solverConstraints[srow].m_relpos1CrossNormal = tmpA;
                        info.m_solverConstraints[srow].m_relpos2CrossNormal = -tmpB;
			        }
		        }
		        else
		        { 
                    // The old way. May be incorrect if bodies are not on the slider axis
			        Vector3 ltd = Vector3.Cross(c,ax1); // Linear Torque Decoupling vector (a torque)
                    info.m_solverConstraints[nrow].m_relpos1CrossNormal = factA * ltd;
                    info.m_solverConstraints[nrow].m_relpos2CrossNormal = factB * ltd;
		        }
		        // right-hand part
		        float lostop = GetLowerLinLimit();
		        float histop = GetUpperLinLimit();
		        if(limit != 0 && (MathUtil.CompareFloat(lostop,histop)))
		        {  // the joint motor is ineffective
			        powered = false;
		        }
		        info.m_solverConstraints[nrow].m_rhs= 0f;
		        info.m_solverConstraints[nrow].m_lowerLimit = 0f;
		        info.m_solverConstraints[nrow].m_upperLimit = 0f;

				currERP = ((m_flags & (int)SliderFlags.BT_SLIDER_FLAGS_ERP_LIMLIN) != 0) ? m_softnessLimLin : info.erp;
		        if(powered)
		        {
					if ((m_flags & (int)SliderFlags.BT_SLIDER_FLAGS_CFM_DIRLIN) != 0)
			        {
				        info.m_solverConstraints[nrow].m_cfm = m_cfmDirLin;
			        }
			        float tag_vel = GetTargetLinMotorVelocity();
			        float mot_fact = GetMotorFactor(m_linPos, m_lowerLinLimit, m_upperLinLimit, tag_vel, info.fps * currERP);
			        info.m_solverConstraints[nrow].m_rhs  -= signFact * mot_fact * GetTargetLinMotorVelocity();
			        info.m_solverConstraints[nrow].m_lowerLimit += -GetMaxLinMotorForce() * info.fps;
			        info.m_solverConstraints[nrow].m_upperLimit += GetMaxLinMotorForce() * info.fps;
		        }
		        if(limit != 0)
		        {
			        k = info.fps * currERP;
			        info.m_solverConstraints[nrow].m_rhs += k * limit_err;
					if ((m_flags & (int)SliderFlags.BT_SLIDER_FLAGS_CFM_LIMLIN) != 0)
			        {
				        info.m_solverConstraints[nrow].m_cfm = m_cfmLimLin;
			        }
			        if(MathUtil.CompareFloat(lostop,histop))
			        {	// limited low and high simultaneously
				        info.m_solverConstraints[nrow].m_lowerLimit = -MathUtil.SIMD_INFINITY;
                        info.m_solverConstraints[nrow].m_upperLimit = MathUtil.SIMD_INFINITY;
			        }
			        else if(limit == 1) 
			        { // low limit
				        info.m_solverConstraints[nrow].m_lowerLimit = -MathUtil.SIMD_INFINITY;
				        info.m_solverConstraints[nrow].m_upperLimit = 0f;
			        }
			        else 
			        { // high limit
				        info.m_solverConstraints[nrow].m_lowerLimit = 0f;
				        info.m_solverConstraints[nrow].m_upperLimit = MathUtil.SIMD_INFINITY;
			        }
			        // bounce (we'll use slider parameter abs(1.0 - m_dampingLimLin) for that)
			        float bounce = System.Math.Abs(1.0f - GetDampingLimLin());
					
			        if(bounce > 0.0f)
			        {
				        float vel = Vector3.Dot(linVelA,ax1);
				        vel -= Vector3.Dot(linVelB,ax1);
				        vel *= signFact;
				        // only apply bounce if the velocity is incoming, and if the
				        // resulting c[] exceeds what we already have.
				        if(limit == 1)
				        {	// low limit
					        if(vel < 0)
					        {
						        float newc = -bounce * vel;
						        if (newc > info.m_solverConstraints[nrow].m_rhs)
						        {
							        info.m_solverConstraints[nrow].m_rhs = newc;
						        }
					        }
				        }
				        else
				        { // high limit - all those computations are reversed
					        if(vel > 0)
					        {
						        float newc = -bounce * vel;
						        if(newc < info.m_solverConstraints[nrow].m_rhs) 
						        {
							        info.m_solverConstraints[nrow].m_rhs = newc;
						        }
					        }
				        }
			        }
			        info.m_solverConstraints[nrow].m_rhs *= GetSoftnessLimLin();
		        } // if(limit)
	        } // if linear limit
	        // check angular limits
	        limit_err = 0.0f;
	        limit = 0;
	        if(GetSolveAngLimit())
	        {
		        limit_err = GetAngDepth();
		        limit = (limit_err > 0.0f) ? 1 : 2;
	        }
	        // if the slider has joint limits, add in the extra row
	        powered = false;
	        if(GetPoweredAngMotor())
	        {
		        powered = true;
	        }
	        if(limit != 0 || powered) 
	        {
		        nrow++;
		        srow = nrow;
		        info.m_solverConstraints[srow].m_relpos1CrossNormal = ax1;
		        info.m_solverConstraints[srow].m_relpos2CrossNormal = -ax1;

		        float lostop = GetLowerAngLimit();
		        float histop = GetUpperAngLimit();
		        if(limit != 0 && (MathUtil.CompareFloat(lostop,histop)))
		        {  // the joint motor is ineffective
			        powered = false;
		        }
				currERP = ((m_flags & (int)SliderFlags.BT_SLIDER_FLAGS_ERP_LIMANG) != 0) ? m_softnessLimAng : info.erp;

                if(powered)
		        {
					if ((m_flags & (int)SliderFlags.BT_SLIDER_FLAGS_CFM_DIRANG) != 0)
			        {
				        info.m_solverConstraints[nrow].m_cfm = m_cfmDirAng;
			        }
			        float mot_fact = GetMotorFactor(m_angPos, m_lowerAngLimit, m_upperAngLimit, GetTargetAngMotorVelocity(), info.fps * currERP);
			        info.m_solverConstraints[nrow].m_rhs = mot_fact * GetTargetAngMotorVelocity();
			        info.m_solverConstraints[nrow].m_lowerLimit = -GetMaxAngMotorForce() * info.fps;
			        info.m_solverConstraints[nrow].m_upperLimit = GetMaxAngMotorForce() * info.fps;
		        }
		        if(limit != 0)
		        {
                    k = info.fps * currERP;
                    info.m_solverConstraints[nrow].m_rhs += k * limit_err;
					if ((m_flags & (int)SliderFlags.BT_SLIDER_FLAGS_CFM_LIMANG) != 0)
                    {
                        info.m_solverConstraints[nrow].m_cfm = m_cfmLimAng;
                    }
                    if (MathUtil.CompareFloat(lostop,histop))
                    {
                        // limited low and high simultaneously
                        info.m_solverConstraints[nrow].m_lowerLimit = -MathUtil.SIMD_INFINITY;
                        info.m_solverConstraints[nrow].m_upperLimit = MathUtil.SIMD_INFINITY;
                    }
                    else if (limit == 1)
                    { // low limit
                        info.m_solverConstraints[nrow].m_lowerLimit = 0;
                        info.m_solverConstraints[nrow].m_upperLimit = MathUtil.SIMD_INFINITY;
                    }
                    else
                    { // high limit
                        info.m_solverConstraints[nrow].m_lowerLimit = -MathUtil.SIMD_INFINITY;
                        info.m_solverConstraints[nrow].m_upperLimit = 0;
                    }
                    // bounce (we'll use slider parameter abs(1.0 - m_dampingLimAng) for that)
                    float bounce = System.Math.Abs(1.0f - GetDampingLimAng());
                    if (bounce > 0.0f)
                    {
                        float vel = Vector3.Dot(m_rbA.GetAngularVelocity(), ax1);
                        vel -= Vector3.Dot(m_rbB.GetAngularVelocity(), ax1);
                        // only apply bounce if the velocity is incoming, and if the
                        // resulting c[] exceeds what we already have.
                        if (limit == 1)
                        {	// low limit
                            if (vel < 0)
                            {
                                float newc = -bounce * vel;
                                if (newc > info.m_solverConstraints[nrow].m_rhs)
                                {
                                    info.m_solverConstraints[nrow].m_rhs = newc;
                                }
                            }
                        }
                        else
                        {	// high limit - all those computations are reversed
                            if (vel > 0)
                            {
                                float newc = -bounce * vel;
                                if (newc < info.m_solverConstraints[nrow].m_rhs)
                                {
                                    info.m_solverConstraints[nrow].m_rhs = newc;
                                }
                            }
                        }
                    }
                    info.m_solverConstraints[nrow].m_rhs *= GetSoftnessLimAng();
                } // if(limit)
	        } // if angular limit or powered
            if (BulletGlobals.g_streamWriter != null && debugConstraint)
            {
                PrintInfo2(BulletGlobals.g_streamWriter, this, info);
            }

        
        }
       


	    // access
        public      Matrix  GetCalculatedTransformA()  { return m_calculatedTransformA; }
        public         Matrix  GetCalculatedTransformB()  { return m_calculatedTransformB; }
        public         Matrix  GetFrameOffsetA()  { return m_frameInA; }
        public         Matrix  GetFrameOffsetB()  { return m_frameInB; }
        public        float GetLowerLinLimit() { return m_lowerLinLimit; }
        public        void SetLowerLinLimit(float lowerLimit) { m_lowerLinLimit = lowerLimit; }
        public        float GetUpperLinLimit() { return m_upperLinLimit; }
        public        void SetUpperLinLimit(float upperLimit) { m_upperLinLimit = upperLimit; }
        public        float GetLowerAngLimit() { return m_lowerAngLimit; }
        public        void SetLowerAngLimit(float lowerLimit) { m_lowerAngLimit = MathUtil.NormalizeAngle(lowerLimit); }
        public        float GetUpperAngLimit() { return m_upperAngLimit; }
        public        void SetUpperAngLimit(float upperLimit) { m_upperAngLimit = MathUtil.NormalizeAngle(upperLimit); }
        public	    bool GetUseLinearReferenceFrameA() { return m_useLinearReferenceFrameA; }
        public	    float GetSoftnessDirLin() { return m_softnessDirLin; }
        public	    float GetRestitutionDirLin() { return m_restitutionDirLin; }
        public	    float GetDampingDirLin() { return m_dampingDirLin ; }
        public	    float GetSoftnessDirAng() { return m_softnessDirAng; }
        public	    float GetRestitutionDirAng() { return m_restitutionDirAng; }
        public	    float GetDampingDirAng() { return m_dampingDirAng; }
        public	    float GetSoftnessLimLin() { return m_softnessLimLin; }
        public	    float GetRestitutionLimLin() { return m_restitutionLimLin; }
        public	    float GetDampingLimLin() { return m_dampingLimLin; }
        public	    float GetSoftnessLimAng() { return m_softnessLimAng; }
        public	    float GetRestitutionLimAng() { return m_restitutionLimAng; }
        public	    float GetDampingLimAng() { return m_dampingLimAng; }
        public	    float GetSoftnessOrthoLin() { return m_softnessOrthoLin; }
        public	    float GetRestitutionOrthoLin() { return m_restitutionOrthoLin; }
        public	    float GetDampingOrthoLin() { return m_dampingOrthoLin; }
        public	    float GetSoftnessOrthoAng() { return m_softnessOrthoAng; }
        public	    float GetRestitutionOrthoAng() { return m_restitutionOrthoAng; }
        public	    float GetDampingOrthoAng() { return m_dampingOrthoAng; }
        public	    void SetSoftnessDirLin(float softnessDirLin) { m_softnessDirLin = softnessDirLin; }
        public	    void SetRestitutionDirLin(float restitutionDirLin) { m_restitutionDirLin = restitutionDirLin; }
        public	    void SetDampingDirLin(float dampingDirLin) { m_dampingDirLin = dampingDirLin; }
        public	    void SetSoftnessDirAng(float softnessDirAng) { m_softnessDirAng = softnessDirAng; }
        public	    void SetRestitutionDirAng(float restitutionDirAng) { m_restitutionDirAng = restitutionDirAng; }
        public	    void SetDampingDirAng(float dampingDirAng) { m_dampingDirAng = dampingDirAng; }
        public	    void SetSoftnessLimLin(float softnessLimLin) { m_softnessLimLin = softnessLimLin; }
        public	    void SetRestitutionLimLin(float restitutionLimLin) { m_restitutionLimLin = restitutionLimLin; }
        public	    void SetDampingLimLin(float dampingLimLin) { m_dampingLimLin = dampingLimLin; }
        public	    void SetSoftnessLimAng(float softnessLimAng) { m_softnessLimAng = softnessLimAng; }
        public	    void SetRestitutionLimAng(float restitutionLimAng) { m_restitutionLimAng = restitutionLimAng; }
        public	    void SetDampingLimAng(float dampingLimAng) { m_dampingLimAng = dampingLimAng; }
        public	    void SetSoftnessOrthoLin(float softnessOrthoLin) { m_softnessOrthoLin = softnessOrthoLin; }
        public	    void SetRestitutionOrthoLin(float restitutionOrthoLin) { m_restitutionOrthoLin = restitutionOrthoLin; }
        public	    void SetDampingOrthoLin(float dampingOrthoLin) { m_dampingOrthoLin = dampingOrthoLin; }
        public	    void SetSoftnessOrthoAng(float softnessOrthoAng) { m_softnessOrthoAng = softnessOrthoAng; }
        public	    void SetRestitutionOrthoAng(float restitutionOrthoAng) { m_restitutionOrthoAng = restitutionOrthoAng; }
        public	    void SetDampingOrthoAng(float dampingOrthoAng) { m_dampingOrthoAng = dampingOrthoAng; }
        public	    void SetPoweredLinMotor(bool onOff) { m_poweredLinMotor = onOff; }
        public	    bool GetPoweredLinMotor() { return m_poweredLinMotor; }
        public	    void SetTargetLinMotorVelocity(float targetLinMotorVelocity) { m_targetLinMotorVelocity = targetLinMotorVelocity; }
        public	    float GetTargetLinMotorVelocity() { return m_targetLinMotorVelocity; }
        public	    void SetMaxLinMotorForce(float maxLinMotorForce) { m_maxLinMotorForce = maxLinMotorForce; }
        public	    float GetMaxLinMotorForce() { return m_maxLinMotorForce; }
        public	    void SetPoweredAngMotor(bool onOff) { m_poweredAngMotor = onOff; }
        public	    bool GetPoweredAngMotor() { return m_poweredAngMotor; }
        public	    void SetTargetAngMotorVelocity(float targetAngMotorVelocity) { m_targetAngMotorVelocity = targetAngMotorVelocity; }
        public	    float GetTargetAngMotorVelocity() { return m_targetAngMotorVelocity; }
        public	    void SetMaxAngMotorForce(float maxAngMotorForce) { m_maxAngMotorForce = maxAngMotorForce; }
        public	    float GetMaxAngMotorForce() { return m_maxAngMotorForce; }
        public	    float GetLinearPos() { return m_linPos; }

        // access for ODE solver
        public	    bool GetSolveLinLimit() { return m_solveLinLim; }
        public	    float GetLinDepth() { return m_depth.X; }
        public	    bool GetSolveAngLimit() { return m_solveAngLim; }
        public	    float GetAngDepth() { return m_angDepth; }

        // shared code used by ODE solver
        public void CalculateTransforms(Matrix transA, Matrix transB)
        {
            CalculateTransforms(ref transA, ref transB);
        }

        public void CalculateTransforms(ref Matrix transA, ref Matrix transB)
        {
	        if(m_useLinearReferenceFrameA || (!m_useSolveConstraintObsolete))
	        {
		        m_calculatedTransformA = MathUtil.BulletMatrixMultiply(transA,m_frameInA);
		        m_calculatedTransformB = MathUtil.BulletMatrixMultiply(transB,m_frameInB);
	        }
	        else
	        {
		        m_calculatedTransformA = MathUtil.BulletMatrixMultiply(transB,m_frameInB);
		        m_calculatedTransformB = MathUtil.BulletMatrixMultiply(transA,m_frameInA);
	        }
	        m_realPivotAInW = m_calculatedTransformA.Translation;
	        m_realPivotBInW = m_calculatedTransformB.Translation;

	        m_sliderAxis = MathUtil.MatrixColumn(ref m_calculatedTransformA,0); // along X

	        if(m_useLinearReferenceFrameA || m_useSolveConstraintObsolete)
	        {
		        m_delta = m_realPivotBInW - m_realPivotAInW;
	        }
	        else
	        {
		        m_delta = m_realPivotAInW - m_realPivotBInW;
	        }
	        m_projPivotInW = m_realPivotAInW + Vector3.Dot(m_sliderAxis,m_delta) * m_sliderAxis;
            Vector3 normalWorld;
            //linear part
            for(int i = 0; i < 3; i++)
            {
		        normalWorld = MathUtil.MatrixColumn(ref m_calculatedTransformA,i);
		        MathUtil.VectorComponent(ref m_depth, i,Vector3.Dot(m_delta,normalWorld));
            }
        }
            
        public void TestLinLimits()
        {
            m_solveLinLim = false;
	        m_linPos = m_depth.X;
	        if(m_lowerLinLimit <= m_upperLinLimit)
	        {
		        if(m_depth.X > m_upperLinLimit)
		        {
			        m_depth.X -= m_upperLinLimit;
			        m_solveLinLim = true;
		        }
		        else if(m_depth.X < m_lowerLinLimit)
		        {
			        m_depth.X -= m_lowerLinLimit;
			        m_solveLinLim = true;
		        }
		        else
		        {
			        m_depth.X = 0f;
		        }
	        }
	        else
	        {
		        m_depth.X = 0f;
	        }
        }
    
        public void TestLinLimits2(ConstraintInfo2 info)
        {
        }
        public void TestAngLimits()
        {
	        m_angDepth = 0f;
	        m_solveAngLim = false;
	        if(m_lowerAngLimit <= m_upperAngLimit)
	        {
		        Vector3 axisA0 = MathUtil.MatrixColumn(ref m_calculatedTransformA,1);
		        Vector3 axisA1 = MathUtil.MatrixColumn(ref m_calculatedTransformA,2);
		        Vector3 axisB0 = MathUtil.MatrixColumn(ref m_calculatedTransformB,1);
		        float rot = (float)System.Math.Atan2(Vector3.Dot(axisB0,axisA1), Vector3.Dot(axisB0,axisA0));
				rot = AdjustAngleToLimits(rot, m_lowerAngLimit, m_upperAngLimit);

		        m_angPos = rot;
		        if(rot < m_lowerAngLimit)
		        {
			        m_angDepth = rot - m_lowerAngLimit;
			        m_solveAngLim = true;
		        } 
		        else if(rot > m_upperAngLimit)
		        {
			        m_angDepth = rot - m_upperAngLimit;
			        m_solveAngLim = true;
		        }
	        }
        }
        // access for PE Solver
        public Vector3 GetAncorInA()
        {
            Vector3 ancorInA = m_realPivotAInW + (m_lowerLinLimit + m_upperLinLimit) * 0.5f * m_sliderAxis;
            ancorInA = Vector3.Transform(ancorInA,Matrix.Invert(m_rbA.GetCenterOfMassTransform()));
            return ancorInA;
        }
        public Vector3 GetAncorInB()
        {
            return m_frameInB.Translation;
        }

        // access for UseFrameOffset
        public bool GetUseFrameOffset() 
        { 
            return m_useOffsetForConstraintFrame; 
        }
        
        public void SetUseFrameOffset(bool frameOffsetOnOff) 
        { 
            m_useOffsetForConstraintFrame = frameOffsetOnOff; 
        }

    }
}
