#include "cObject.h"

__export void __entry ois_object_delete(HObject self)
{
	if (self == NULL)
		return;

	delete asDeviceObject(self);
}

__export _int __entry ois_object_type(HObject self)
{
	return (_int) asDeviceObject(self)->type();
}

__export _string __entry ois_object_vendor(HObject self)
{
	std::string result = asDeviceObject(self)->vendor();

	return copyString(result);
}

__export _bool __entry ois_object_get_buffered(HObject self)
{
	bool result = asDeviceObject(self)->buffered();

	return toBool(result);
}

__export void __entry ois_object_set_buffered(HObject self, _bool value)
{
	asDeviceObject(self)->setBuffered(fromBool(value));
}

__export HInputManager __entry ois_object_get_creator(HObject self)
{
	return asDeviceObject(self)->getCreator();
}

__export void __entry ois_object_capture(HObject self)
{
	asDeviceObject(self)->capture();
}

__export _int __entry ois_object_get_id(HObject self)
{
	return asDeviceObject(self)->getID();
}

__export HInterface __entry ois_object_query_interface(HObject self, _int itype)
{
	return asDeviceObject(self)->queryInterface((OIS::Interface::IType)itype);
}

