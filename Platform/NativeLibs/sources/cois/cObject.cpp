#include "cOIS.h"

/**
 * Method: Object::type
 */
INV_EXPORT COMPONENT_TYPE
INV_CALL object_type(InvHandle self)
{
	return asObject(self)->type();
}

/**
 * Method: Object::vendor
 */
INV_EXPORT _string
INV_CALL object_vendor(InvHandle self)
{
	const std::string& vendor = asObject(self)->vendor();
	
	return copyString(vendor);
}

/**
 * Method: Object::buffered
 */
INV_EXPORT _bool
INV_CALL object_buffered(InvHandle self)
{
	return toBool(asObject(self)->buffered());
}

/**
 * Method: Object::setBuffered
 */
INV_EXPORT void
INV_CALL object_set_buffered(InvHandle self, _bool value)
{
	asObject(self)->setBuffered(fromBool(value));
}

/**
 * Method: Object::getCreator
 */
INV_EXPORT InvHandle
INV_CALL object_get_creator(InvHandle self)
{
	OIS::InputManager* inputManager = asObject(self)->getCreator();
	
	return getOrCreateReference<OIS::InputManager>(inputManager, false);
}

/**
 * Method: Object::capture
 */
INV_EXPORT void
INV_CALL object_capture(InvHandle self)
{
	asObject(self)->capture();
}

/**
 * Method: Object::getID
 */
INV_EXPORT _int
INV_CALL object_get_id(InvHandle self)
{
	return asObject(self)->getID();
}

/**
 * Method: Object::queryInterface
 */
INV_EXPORT InvHandle
INV_CALL object_query_interface(InvHandle self, INTERFACE_TYPE interfaceType)
{
	OIS::Interface* interface = asObject(self)->queryInterface((OIS::Interface::IType)interfaceType);
	
	return getOrCreateReference<OIS::Interface>(interface);
}
