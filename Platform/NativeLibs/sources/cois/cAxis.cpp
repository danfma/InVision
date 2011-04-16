#include "cAxis.h"

__export AxisExtended __entry ois_axis_new()
{
	OIS::Axis* axis = new OIS::Axis();

	return ois_axis_new_from(axis);
}

__export AxisExtended __entry ois_axis_new_from(HAxis self)
{
	OIS::Axis* axis = asAxis(self);

	AxisExtended axisInfo;
	axisInfo.base.handle = axis;
	axisInfo.base.componentType = (_int*) &axis->cType;
	axisInfo.abs = (_int*) &axis->abs;
	axisInfo.rel = (_int*) &axis->rel;
	axisInfo.absOnly = (_bool*) &axis->absOnly;

	return axisInfo;
}

__export void __entry ois_axis_delete(HAxis self)
{
	if (self == NULL)
		return;

	delete (OIS::Axis*)self;
}
