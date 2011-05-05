namespace InVision.Bullet.Dynamics.ConstraintSolver
{
	public class ConstraintInfo2
	{
		// Workaround for the idea of having multiple solver constraints and row count.
		// This should be populated with a list of the SolverConstraint for a give Constraint. - MAN
		public SolverConstraint[] m_solverConstraints;

		// integrator parameters: frames per second (1/stepsize), default error
		// reduction parameter (0..1).
		public float fps;
		public float erp;

		// findex vector for variables. see the LCP solver interface for a
		// description of what this does. this is set to -1 on entry.
		// note that the returned indexes are relative to the first index of
		// the constraint.
		public int findex;
		public int m_numIterations;
	}
}