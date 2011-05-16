#include "cOIS.h"

/**
 * Method: FactoryCreator::~FactoryCreator
 */
INV_EXPORT void
INV_CALL delete_factorycreator(InvHandle self)
{
	destroyHandle(self);
}

/**
 * Method: FactoryCreator::freeDeviceList
 */
INV_EXPORT DeviceTypeItem*
INV_CALL factorycreator_free_device_list(InvHandle self)
{
	OIS::DeviceList deviceList = asFactoryCreator(self)->freeDeviceList();
	DeviceTypeItem* list = new DeviceTypeItem[deviceList.size() + 1];

	int i = 0;

	for (OIS::DeviceList::iterator it = deviceList.begin();
		 it != deviceList.end();
		 it++) {

		OIS::DeviceList::value_type listItem = *it;

		DeviceTypeItem item;
		item.deviceType = (DEVICE_TYPE)listItem.first;
		item.name = copyString(listItem.second);
		list[i++] = item;
	}

	list[i] = NULL;

	return list;
}

/**
 * Method: FactoryCreator::totalDevices
 */
INV_EXPORT _int
INV_CALL factorycreator_total_devices(InvHandle self, DEVICE_TYPE deviceType)
{
	return asFactoryCreator(self)->totalDevices((OIS::Type)deviceType);
}

/**
 * Method: FactoryCreator::freeDevices
 */
INV_EXPORT _int
INV_CALL factorycreator_free_devices(InvHandle self, DEVICE_TYPE deviceType)
{
	return asFactoryCreator(self)->freeDevices((OIS::Type)deviceType);
}

/**
 * Method: FactoryCreator::vendorExist
 */
INV_EXPORT _bool
INV_CALL factorycreator_vendor_exist1(InvHandle self, DEVICE_TYPE deviceType)
{
	bool result = asFactoryCreator(self)->vendorExist((OIS::Type)deviceType);

	return toBool(result);
}

/**
 * Method: FactoryCreator::vendorExist
 */
INV_EXPORT _bool
INV_CALL factorycreator_vendor_exist2(InvHandle self, DEVICE_TYPE deviceType, _string vendor)
{
	bool result = asFactoryCreator(self)->vendorExist((OIS::Type)deviceType, vendor);

	return toBool(result);
}

/**
 * Method: FactoryCreator::createObject
 */
INV_EXPORT InvHandle
INV_CALL factorycreator_create_object1(InvHandle self, InvHandle inputManagerHandle, DEVICE_TYPE deviceType, _bool bufferMode)
{
	OIS::InputManager* creator = asInputManager(inputManagerHandle);
	OIS::Object* result = asFactoryCreator(self)->createObject(creator, (OIS::Type)deviceType, bufferMode);

	return getOrCreateHandle<OIS::Object>(result);
}

/**
 * Method: FactoryCreator::createObject
 */
INV_EXPORT InvHandle
INV_CALL factorycreator_create_object2(InvHandle self, InvHandle inputManagerHandle, DEVICE_TYPE deviceType, _bool bufferMode, _string vendor)
{
	OIS::InputManager* creator = asInputManager(inputManagerHandle);
	OIS::Object* result = asFactoryCreator(self)->createObject(creator, (OIS::Type)deviceType, bufferMode, vendor);

	return getOrCreateHandle<OIS::Object>(result);
}

/**
 * Method: FactoryCreator::destroyObject
 */
INV_EXPORT void
INV_CALL factorycreator_destroy_object(InvHandle self, InvHandle deviceHandle)
{
	asFactoryCreator(self)->destroyObject(asObject(deviceHandle));
}
