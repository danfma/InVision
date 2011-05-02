#ifndef INPUTOBJECT_H
#define INPUTOBJECT_H

#include "cOIS.h"

extern "C"
{
	INV_EXPORT void
	INV_CALL ois_delete_object(OIS::Object* self);

	INV_EXPORT OIS::Type
	INV_CALL ois_object_type(OIS::Object* self);

	INV_EXPORT _string
	INV_CALL ois_object_vendor(OIS::Object* self);

	INV_EXPORT bool
	INV_CALL ois_object_get_buffered(OIS::Object* self);

	INV_EXPORT void
	INV_CALL ois_object_set_buffered(OIS::Object* self, bool value);

	INV_EXPORT OIS::InputManager*
	INV_CALL ois_object_get_creator(OIS::Object* self);

	INV_EXPORT void
	INV_CALL ois_object_capture(OIS::Object* self);

	INV_EXPORT int
	INV_CALL ois_object_get_id(OIS::Object* self);

	INV_EXPORT OIS::Interface*
	INV_CALL ois_object_query_interface(OIS::Object* self, OIS::Interface::IType itype);
}

#endif // INPUTOBJECT_H
