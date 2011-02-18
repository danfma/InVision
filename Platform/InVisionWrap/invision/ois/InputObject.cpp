#include "InputObject.h"

using namespace invision::ois;

__export void __entry ois_object_delete(HInputObject self)
{
	delete asObject(self);
}

__export Int32 __entry ois_object_get_type(HInputObject self)
{
	return asObject(self)->type();
}

__export ConstString __entry ois_object_get_vendor(HInputObject self)
{
	return asObject(self)->vendor().c_str();
}

__export Bool __entry ois_object_get_buffered(HInputObject self)
{
	return asObject(self)->buffered();
}

__export void __entry ois_object_set_buffered(HInputObject self, Bool value)
{
	asObject(self)->setBuffered(fromBool(value));
}

__export HInputManager __entry ois_object_get_creator(HInputObject self)
{
	return asObject(self)->getCreator();
}

__export void __entry ois_object_capture(HInputObject self)
{
	asObject(self)->capture();
}

__export Int32 __entry ois_object_get_id(HInputObject self)
{
	return asObject(self)->getID();
}

__export HInterface __entry ois_object_query_interface(HInputObject self, Int32 type)
{
	return asObject(self)->queryInterface((OIS::Interface::IType)type);
}
