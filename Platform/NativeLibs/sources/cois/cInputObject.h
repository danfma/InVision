#ifndef INPUTOBJECT_H
#define INPUTOBJECT_H

#include "cOIS.h"

extern "C"
{
	__export void __entry ois_object_delete(HInputObject self);

	__export Int32 __entry ois_object_get_type(HInputObject self);
	__export ConstString __entry ois_object_get_vendor(HInputObject self);

	__export Bool __entry ois_object_get_buffered(HInputObject self);
	__export void __entry ois_object_set_buffered(HInputObject self, Bool value);

	__export HInputManager __entry ois_object_get_creator(HInputObject self);

	__export void __entry ois_object_capture(HInputObject self);

	__export Int32 __entry ois_object_get_id(HInputObject self);

	__export HInterface __entry ois_object_query_interface(HInputObject self, Int32 type);
}

#ifdef __cplusplus
#include <OIS.h>

namespace invision
{
	namespace ois
	{
		inline OIS::Object* asObject(HInputObject self)
		{
			return (OIS::Object*)self;
		}
	}
}

#endif

#endif // INPUTOBJECT_H
