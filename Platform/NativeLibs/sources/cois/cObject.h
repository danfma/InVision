#ifndef INPUTOBJECT_H
#define INPUTOBJECT_H

#include "cOIS.h"

extern "C"
{
	__export void __entry oisDeleteObject(OISObjectHandle self);

	__export _int __entry oisObject_getType(OISObjectHandle self);
	__export const _string __entry oisObject_getVendor(OISObjectHandle self);

	__export _bool __entry oisObject_getBuffered(OISObjectHandle self);
	__export void __entry oisObject_setBuffered(OISObjectHandle self, _bool value);

	__export OISInputManagerHandle __entry oisObject_getCreator(OISObjectHandle self);

	__export void __entry oisObject_capture(OISObjectHandle self);

	__export _int __entry oisObject_getId(OISObjectHandle self);

	__export OISInterfaceHandle __entry oisObject_queryInterface(OISObjectHandle self, _int type);
}

#ifdef __cplusplus

namespace invision
{
	namespace ois
	{
		inline OIS::Object* asObject(OISObjectHandle self)
		{
			return (OIS::Object*)self;
		}
	}
}

#endif

#endif // INPUTOBJECT_H
