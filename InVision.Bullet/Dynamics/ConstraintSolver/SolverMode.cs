using System;

namespace InVision.Bullet.Dynamics.ConstraintSolver
{
	[Flags]
	public enum SolverMode
	{
		SOLVER_RANDMIZE_ORDER = 1,
		SOLVER_FRICTION_SEPARATE = 2,
		SOLVER_USE_WARMSTARTING = 4,
		SOLVER_USE_FRICTION_WARMSTARTING = 8,
		SOLVER_USE_2_FRICTION_DIRECTIONS = 16,
		SOLVER_ENABLE_FRICTION_DIRECTION_CACHING = 32,
		SOLVER_DISABLE_VELOCITY_DEPENDENT_FRICTION_DIRECTION = 64,
		SOLVER_CACHE_FRIENDLY = 128,
		SOLVER_SIMD = 256,	//enabled for Windows, the solver innerloop is branchless SIMD, 40% faster than FPU/scalar version
		SOLVER_CUDA = 512	//will be open sourced during Game Developers Conference 2009. Much faster.
	}
}