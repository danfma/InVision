#ifndef INPUTOBJECT_H
#define INPUTOBJECT_H

#include "cOIS.h"

extern "C"
{
	__export void __entry ois_object_delete(HObject self);
	__export _int __entry ois_object_type(HObject self);
	__export _string __entry ois_object_vendor(HObject self);

	__export _bool __entry ois_object_get_buffered(HObject self);
	__export void __entry ois_object_set_buffered(HObject self, _bool value);

	__export HInputManager __entry ois_object_get_creator(HObject self);
	__export void __entry ois_object_capture(HObject self);

	__export _int __entry ois_object_get_id(HObject self);

	__export HInterface __entry ois_object_query_interface(HObject self, _int itype);
}

#ifdef __cplusplus

inline OIS::Object* asDeviceObject(HObject self) {
	return (OIS::Object*)self;
}

#endif // __cplusplus

#endif // INPUTOBJECT_H
