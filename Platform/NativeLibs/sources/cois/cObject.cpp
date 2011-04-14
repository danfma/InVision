#include "cObject.h"

using namespace invision::ois;

__export void __entry oisDeleteObject(OISObjectHandle self)
{
	delete asObject(self);
}

__export _int __entry oisObject_getType(OISObjectHandle self)
{
	return asObject(self)->type();
}

__export ConstString __entry oisObject_getVendor(OISObjectHandle self)
{
	return asObject(self)->vendor().c_str();
}

__export _bool __entry oisObject_getBuffered(OISObjectHandle self)
{
	return asObject(self)->buffered();
}

__export void __entry oisObject_setBuffered(OISObjectHandle self, _bool value)
{
	asObject(self)->setBuffered(fromBool(value));
}

__export OISInputManagerHandle __entry oisObject_getCreator(OISObjectHandle self)
{
	return asObject(self)->getCreator();
}

__export void __entry oisObject_capture(OISObjectHandle self)
{
	asObject(self)->capture();
}

__export _int __entry oisObject_getId(OISObjectHandle self)
{
	return asObject(self)->getID();
}

__export HInterface __entry oisObject_queryInterface(OISObjectHandle self, _int type)
{
	return asObject(self)->queryInterface((OIS::Interface::IType)type);
}
