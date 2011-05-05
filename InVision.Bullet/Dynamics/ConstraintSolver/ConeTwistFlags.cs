using System;

namespace InVision.Bullet.Dynamics.ConstraintSolver
{
	[Flags]
	public enum ConeTwistFlags
	{
		BT_CONETWIST_FLAGS_LIN_CFM = 1,
		BT_CONETWIST_FLAGS_LIN_ERP = 2,
		BT_CONETWIST_FLAGS_ANG_CFM = 4
	}
}