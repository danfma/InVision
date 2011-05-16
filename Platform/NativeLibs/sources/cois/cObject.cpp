#include "cOIS.h"

using namespace invision;


INV_EXPORT void
INV_CALL delete_device(InvHandle self)
{
	destroyHandle(self);
}

/**
	* Method: device::getType
	*/
INV_EXPORT _int
INV_CALL device_get_type(InvHandle self)
{
	return asObject(self)->type();
}

/**
	* Method: device::getVendor
	*/
INV_EXPORT _string
INV_CALL device_get_vendor(InvHandle self)
{
	const std::string& str = asObject(self)->vendor();
	
	return copyString(str);
}

/**
	* Method: device::isBuffered
	*/
INV_EXPORT _bool
INV_CALL device_is_buffered(InvHandle self)
{
	bool buffered = asObject(self)->buffered();
	
	return toBool(buffered);
}

/**
	* Method: device::setBuffered
	*/
INV_EXPORT void
INV_CALL device_set_buffered(InvHandle self, _bool value)
{
	bool buffered = fromBool(value);
	
	return asObject(self)->setBuffered(buffered);
}

/**
	* Method: device::getCreator
	*/
INV_EXPORT InvHandle
INV_CALL device_get_creator(InvHandle self)
{
	OIS::InputManager* creator = asObject(self)->getCreator();
	
	return getOrCreateHandle<OIS::InputManager>(creator);
}

/**
	* Method: device::capture
	*/
INV_EXPORT void
INV_CALL device_capture(InvHandle self)
{
	asObject(self)->capture();
}

/**
	* Method: device::getID
	*/
INV_EXPORT _int
INV_CALL device_get_id(InvHandle self)
{
	return asObject(self)->getID();
}

/**
	* Method: device::queryInterface
	*/
INV_EXPORT InvHandle
INV_CALL device_query_interface(InvHandle self, _int interfaceType)
{
	OIS::Interface* interface = asObject(self)->queryInterface((OIS::Interface::IType)interfaceType);
	
	return getOrCreateHandle<OIS::Interface>(interface);
}
