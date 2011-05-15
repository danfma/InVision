#include "cOIS.h"

using namespace invision;

inline OIS::Object* asObject(InvHandle handle)
{
	return castHandle<OIS::Object>(handle);
}


INV_EXPORT void
INV_CALL delete_object(InvHandle self)
{
	destroyHandle(self);
}

/**
	* Method: Object::getType
	*/
INV_EXPORT _int
INV_CALL object_get_type(InvHandle self)
{
	return asObject(self)->type();
}

/**
	* Method: Object::getVendor
	*/
INV_EXPORT _string
INV_CALL object_get_vendor(InvHandle self)
{
	const std::string& str = asObject(self)->vendor();
	
	return copyString(str);
}

/**
	* Method: Object::isBuffered
	*/
INV_EXPORT _bool
INV_CALL object_is_buffered(InvHandle self)
{
	bool buffered = asObject(self)->buffered();
	
	return toBool(buffered);
}

/**
	* Method: Object::setBuffered
	*/
INV_EXPORT void
INV_CALL object_set_buffered(InvHandle self, _bool value)
{
	bool buffered = fromBool(value);
	
	return asObject(self)->setBuffered(buffered);
}

/**
	* Method: Object::getCreator
	*/
INV_EXPORT InvHandle
INV_CALL object_get_creator(InvHandle self)
{
	OIS::InputManager* creator = asObject(self)->getCreator();
	
	return getOrAddHandleByObject<OIS::InputManager>(creator);
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
INV_CALL object_query_interface(InvHandle self, _int interfaceType)
{
	OIS::Interface* interface = asObject(self)->queryInterface((OIS::Interface::IType)interfaceType);
	
	return getOrAddHandleByObject<OIS::Interface>(interface);
}
