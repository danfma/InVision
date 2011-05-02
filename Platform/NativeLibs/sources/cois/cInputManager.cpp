#include "cInputManager.h"

INV_EXPORT _uint
INV_CALL ois_inputmanager_get_version_number()
{
	return OIS::InputManager::getVersionNumber();
}

INV_EXPORT OIS::InputManager*
INV_CALL ois_inputmanager_create_input_system(
	int winHandle)
{
	return OIS::InputManager::createInputSystem((size_t)winHandle);
}

INV_EXPORT OIS::InputManager*
INV_CALL ois_inputmanager_create_by_param_input_system(
	const NameValueItem *items,
	_int numItems)
{
	OIS::ParamList parameters;

	for (int i = 0; i < numItems; i++) {
		NameValueItem item = items[i];
		OIS::ParamList::value_type paramItem(item.name, item.value);

		parameters.insert(paramItem);
	}

	return OIS::InputManager::createInputSystem(parameters);
}

INV_EXPORT void
INV_CALL ois_inputmanager_destroy(
	OIS::InputManager* self)
{
	OIS::InputManager::destroyInputSystem(self);
}

INV_EXPORT _string
INV_CALL ois_inputmanager_get_version_name(
	OIS::InputManager* self)
{
	std::string name = self->getVersionName();

	return copyString(name);
}

INV_EXPORT _string
INV_CALL ois_inputmanager_input_system_name(
	OIS::InputManager* self)
{
	std::string name = self->inputSystemName();

	return copyString(name);
}

INV_EXPORT _int
INV_CALL ois_inputmanager_get_number_of_devices(
	OIS::InputManager* self,
	OIS::Type deviceType)
{
	return self->getNumberOfDevices(deviceType);
}

INV_EXPORT OIS::Object*
INV_CALL ois_inputmanager_create_input_object(
	OIS::InputManager* self,
	OIS::Type deviceType,
	bool bufferMode,
	_string vendor)
{
	return self->createInputObject(deviceType, bufferMode, vendor);
}

INV_EXPORT void
INV_CALL ois_inputmanager_destroy_input_object(
	OIS::InputManager* self,
	OIS::Object* obj)
{
	self->destroyInputObject(obj);
}
