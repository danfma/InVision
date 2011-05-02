#include "cObject.h"

INV_EXPORT void
INV_CALL ois_delete_object(OIS::Object* self)
{
	if (self)
		delete self;
}

INV_EXPORT OIS::Type
INV_CALL ois_object_type(OIS::Object* self)
{
	return self->type();
}

INV_EXPORT _string
INV_CALL ois_object_vendor(OIS::Object* self)
{
	return copyString(self->vendor());
}

INV_EXPORT bool
INV_CALL ois_object_get_buffered(OIS::Object* self)
{
	return self->buffered();
}

INV_EXPORT void
INV_CALL ois_object_set_buffered(OIS::Object* self, bool value)
{
	self->setBuffered(value);
}

INV_EXPORT OIS::InputManager*
INV_CALL ois_object_get_creator(OIS::Object* self)
{
	return self->getCreator();
}

INV_EXPORT void
INV_CALL ois_object_capture(OIS::Object* self)
{
	self->capture();
}

INV_EXPORT int
INV_CALL ois_object_get_id(OIS::Object* self)
{
	return self->getID();
}

INV_EXPORT OIS::Interface*
INV_CALL ois_object_query_interface(OIS::Object* self, OIS::Interface::IType itype)
{
	return self->queryInterface(itype);
}
