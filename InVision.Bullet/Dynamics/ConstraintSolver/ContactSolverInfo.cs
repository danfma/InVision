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

namespace InVision.Bullet.Dynamics.ConstraintSolver
{
	public class ContactSolverInfo : ContactSolverInfoData
    {
	    public ContactSolverInfo()
	    {
		    m_tau = 0.6f;
		    m_damping = 1.0f;
		    m_friction = 0.3f;
		    m_restitution = 0f;
		    m_maxErrorReduction = 20f;
		    m_numIterations = 10;
		    m_erp = 0.2f;
		    m_erp2 = 0.1f;
		    m_globalCfm = 0f;
            m_sor = 1f;
		    m_splitImpulse = false;
		    m_splitImpulsePenetrationThreshold = -0.02f;
            m_linearSlop = 0f;
		    m_warmstartingFactor=0.85f;
            m_solverMode = SolverMode.SOLVER_USE_WARMSTARTING | SolverMode.SOLVER_SIMD;//SOLVER_RANDMIZE_ORDER
		    m_restingContactRestitutionThreshold = 2;//resting contact lifetime threshold to disable restitution
		    m_minimumSolverBatchSize = 128; //try to combine islands until the amount of constraints reaches this limit
	    }
    }
}
