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
 * Method: InputManager::createInputSystem
 */
INV_EXPORT InvHandle
INV_CALL inputmanager_create_input_system1(_int winHandle)
{
	OIS::InputManager* inputManager = OIS::InputManager::createInputSystem(winHandle);

	return createHandle<OIS::InputManager>(inputManager);
}

/**
 * Method: InputManager::createInputSystem
 */
INV_EXPORT InvHandle
INV_CALL inputmanager_create_input_system2(NameValueItem* parameters, _int paramCount)
{
	OIS::ParamList paramList;

	for (int i = 0; i < paramCount; i++) {
		NameValueItem param = parameters[i];

		OIS::ParamList::value_type item(param.name, param.value);
		paramList.insert(item);
	}

	OIS::InputManager* inputManager = OIS::InputManager::createInputSystem(paramList);

	return createHandle<OIS::InputManager>(inputManager);
}

/**
 * Method: InputManager::destroyInputSystem
 */
INV_EXPORT void
INV_CALL inputmanager_destroy_input_system(InvHandle handle)
{
	destroyHandle(handle);
}

/**
 * Method: InputManager::getVersionName
 */
INV_EXPORT _string
INV_CALL inputmanager_get_version_name(InvHandle self)
{
	std::string& result = asInputManager(self)->getVersionName();

	return copyString(&result);
}

/**
 * Method: InputManager::inputSystemName
 */
INV_EXPORT _string
INV_CALL inputmanager_input_system_name(InvHandle self)
{
	std::string& result = asInputManager(self)->inputSystemName();

	return copyString(&result);
}

/**
 * Method: InputManager::getNumberOfDevices
 */
INV_EXPORT _int
INV_CALL inputmanager_get_number_of_devices(InvHandle self, DEVICE_TYPE deviceType)
{
	return asInputManager(self)->getNumberOfDevices((OIS::Type)deviceType);
}

/**
 * Method: InputManager::createInputObject
 */
INV_EXPORT InvHandle
INV_CALL inputmanager_create_input_object1(InvHandle self, DEVICE_TYPE deviceType, _bool bufferMode)
{
	OIS::Object *obj = asInputManager(self)->createInputObject((OIS::Type)deviceType, fromBool(bufferMode));

	return createHandle<OIS::Object>(obj);
}

/**
 * Method: InputManager::createInputObject
 */
INV_EXPORT InvHandle
INV_CALL inputmanager_create_input_object2(InvHandle self, DEVICE_TYPE deviceType, _bool bufferMode, _string vendor)
{
	OIS::Object *obj = asInputManager(self)->createInputObject((OIS::Type)deviceType, fromBool(bufferMode), vendor);

	return createHandle<OIS::Object>(obj);
}

/**
 * Method: InputManager::destroyInputObject
 */
INV_EXPORT void
INV_CALL inputmanager_destroy_input_object(InvHandle self, InvHandle deviceHandle)
{
	OIS::Object* obj = asObject(deviceHandle);

	asInputManager(self)->destroyInputObject(obj);
	removeHandle(obj);
}

/**
 * Method: InputManager::addFactoryCreator
 */
INV_EXPORT void
INV_CALL inputmanager_add_factory_creator(InvHandle self, InvHandle factoryHandle)
{
	OIS::FactoryCreator* factory = asFactoryCreator(factoryHandle);

	asInputManager(self)->addFactoryCreator(factory);
}

/**
 * Method: InputManager::removeFactoryCreator
 */
INV_EXPORT void
INV_CALL inputmanager_remove_factory_creator(InvHandle self, InvHandle factoryHandle)
{
	OIS::FactoryCreator* factory = asFactoryCreator(factoryHandle);

	asInputManager(self)->removeFactoryCreator(factory);
}

/**
 * Method: InputManager::enableAddOnFactory
 */
INV_EXPORT void
INV_CALL inputmanager_enable_add_on_factory(InvHandle self, ADD_ON_FACTORY factory)
{
	asInputManager(self)->enableAddOnFactory((OIS::InputManager::AddOnFactories)factory);
}
