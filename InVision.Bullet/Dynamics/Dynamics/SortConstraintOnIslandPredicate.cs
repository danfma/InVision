using System.Collections.Generic;
using InVision.Bullet.Dynamics.ConstraintSolver;

namespace InVision.Bullet.Dynamics.Dynamics
{
	public class SortConstraintOnIslandPredicate : IComparer<TypedConstraint>
	{
		#region IComparer<TypedConstraint> Members

		public int Compare(TypedConstraint x, TypedConstraint y)
		{
			int id1 = DiscreteDynamicsWorld.GetConstraintIslandId(x);
			int id2 = DiscreteDynamicsWorld.GetConstraintIslandId(y);
			return id1 - id2;
		}

		#endregion
	}
}