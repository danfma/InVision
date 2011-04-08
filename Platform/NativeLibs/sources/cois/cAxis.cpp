#include "cAxis.h"

using namespace invision::ois;

__export HInputAxis __entry ois_axis_new()
{
	return new OIS::Axis();
}

__export void __entry ois_axis_delete(HInputAxis axis)
{
	delete asAxis(axis);
}

__export _int __entry ois_axis_get_absolute(HInputAxis axis)
{
	return asAxis(axis)->abs;
}

__export void __entry ois_axis_set_absolute(HInputAxis axis, _int value)
{
	asAxis(axis)->abs = value;
}

__export _int __entry ois_axis_get_relative(HInputAxis axis)
{
	return asAxis(axis)->rel;
}

__export void __entry ois_axis_set_relative(HInputAxis axis, _int value)
{
	asAxis(axis)->rel = value;
}

__export _bool __entry ois_axis_get_absolute_only(HInputAxis axis)
{
	return toBool(asAxis(axis)->absOnly);
}

__export void __entry ois_axis_set_absolute_only(HInputAxis axis, _bool value)
{
	asAxis(axis)->absOnly = fromBool(value);
}
