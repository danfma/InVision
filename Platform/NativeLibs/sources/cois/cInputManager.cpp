#include "cOIS.h"

/**
 * Method: InputManager::getVersionNumber
 */
INV_EXPORT _uint
INV_CALL inputmanager_get_version_number()
{
	return OIS::InputManager::getVersionNumber();
}

/**
 * Method: InputManager::getVersionName
 */
INV_EXPORT _string
INV_CALL inputmanager_get_version_name(InvHandle self)
{
	const std::string& versionName = asInputManager(self)->getVersionName();

	return copyString(versionName);
}

/**
 * Method: InputManager::createInputSystem
 */
INV_EXPORT InvHandle
INV_CALL inputmanager_create_input_system_m1(_int winHandle)
{
	OIS::InputManager* inputManager = OIS::InputManager::createInputSystem(winHandle);

	return createReference<OIS::InputManager>(inputManager);
}

/**
 * Method: InputManager::createInputSystem
 */
INV_EXPORT InvHandle
INV_CALL inputmanager_create_input_system_m2(NameValueItem* parameters, _int parametersCount)
{
	OIS::ParamList params;

	for (int i = 0; i < parametersCount; i++) {
		OIS::ParamList::value_type pair(parameters[i].name, parameters[i].value);
		params.insert(pair);
	}

	OIS::InputManager* inputManager = OIS::InputManager::createInputSystem(params);

	return createReference<OIS::InputManager>(inputManager);
}

/**
 * Method: InputManager::destroyInputSystem
 */
INV_EXPORT void
INV_CALL inputmanager_destroy_input_system(InvHandle manager)
{
	OIS::InputManager::destroyInputSystem(asInputManager(manager));
	destroyHandle(manager);
}

/**
 * Method: InputManager::inputSystemName
 */
INV_EXPORT _string
INV_CALL inputmanager_input_system_name(InvHandle self)
{
	return copyString(asInputManager(self)->inputSystemName());
}

/**
 * Method: InputManager::getNumberOfDevices
 */
INV_EXPORT _int
INV_CALL inputmanager_get_number_of_devices(InvHandle self, DEVICE_TYPE iType)
{
	return asInputManager(self)->getNumberOfDevices((OIS::Type)iType);
}

/**
 * Method: InputManager::listFreeDevices
 */
INV_EXPORT _any
INV_CALL inputmanager_list_free_devices(InvHandle self)
{
	OIS::DeviceList deviceList = asInputManager(self)->listFreeDevices();

	::DeviceList* list = new ::DeviceList();
	list->count = deviceList.size();

	DeviceTypeItem* itemList = new DeviceTypeItem[list->count];
	list->items = itemList;

	int i = 0;

	for (OIS::DeviceList::iterator it = deviceList.begin(); it != deviceList.end(); it++, i++) {
		OIS::DeviceList::value_type pair = *it;
		itemList[i].deviceType = (DEVICE_TYPE)pair.first;
		itemList[i].name = copyString(pair.second);
	}

	return list;
}

/**
 * Method: InputManager::createInputObject
 */
INV_EXPORT InvHandle
INV_CALL inputmanager_create_input_object_m1(InvHandle self, DEVICE_TYPE iType, _bool bufferMode)
{
	OIS::Object* obj = asInputManager(self)->createInputObject((OIS::Type)iType, fromBool(bufferMode));

	return createHandle<OIS::Object>(obj);
}

/**
 * Method: InputManager::createInputObject
 */
INV_EXPORT InvHandle
INV_CALL inputmanager_create_input_object_m2(InvHandle self, DEVICE_TYPE iType, _bool bufferMode, _string vendor)
{
	OIS::Object* obj = asInputManager(self)->createInputObject((OIS::Type)iType, fromBool(bufferMode), vendor);

	return createHandle<OIS::Object>(obj);
}

/**
 * Method: InputManager::destroyInputObject
 */
INV_EXPORT void
INV_CALL inputmanager_destroy_input_object(InvHandle self, InvHandle obj)
{
	asInputManager(self)->destroyInputObject(asObject(obj));
}

/**
 * Method: InputManager::addFactoryCreator
 */
INV_EXPORT void
INV_CALL inputmanager_add_factory_creator(InvHandle self, InvHandle factory)
{
	asInputManager(self)->addFactoryCreator(asFactoryCreator(factory));
}

/**
 * Method: InputManager::removeFactoryCreator
 */
INV_EXPORT void
INV_CALL inputmanager_remove_factory_creator(InvHandle self, InvHandle factory)
{
	asInputManager(self)->removeFactoryCreator(asFactoryCreator(factory));
}

/**
 * Method: InputManager::enableAddOnFactory
 */
INV_EXPORT void
INV_CALL inputmanager_enable_add_on_factory(InvHandle self, ADD_ON_FACTORY factory)
{
	asInputManager(self)->enableAddOnFactory((OIS::InputManager::AddOnFactories)factory);
}
