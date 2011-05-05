using System;

namespace InVision.Bullet.LinearMath
{
	[Flags]
	public enum PlaneIntersectType
	{
		COPLANAR = 0, //(0)
		UNDER = 1,  //(1)
		OVER = 2,  //(2)
		SPLIT = 3 //(OVER|UNDER)
	}
}