using InVision.Bullet.Collision.NarrowPhaseCollision;
using InVision.Bullet.Dynamics.Dynamics;

namespace InVision.Bullet.Dynamics.ConstraintSolver
{
	public interface IContactSolverFunc
	{
		float ContactSolverFunc(RigidBody body1,RigidBody body2,ManifoldPoint contactPoint,
		                        ContactSolverInfo info);
	}
}