using System;

namespace InVision.Bullet.LinearMath
{
	[Flags]
	public enum HullFlag
	{
		QF_TRIANGLES         = (1<<0),             // report results as triangles, not polygons.
		QF_REVERSE_ORDER     = (1<<1),             // reverse order of the triangle indices.
		QF_DEFAULT           = QF_TRIANGLES
	}
}