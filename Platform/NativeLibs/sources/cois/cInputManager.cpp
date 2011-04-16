#include "cInputManager.h"

__export _uint __entry ois_inputmanager_get_version_number()
{
	return OIS::InputManager::getVersionNumber();
}

__export HInputManager __entry ois_inputmanager_create_input_system(_handle winHandle)
{
	return OIS::InputManager::createInputSystem((size_t)winHandle);
}

__export HInputManager __entry ois_inputmanager_create_by_param_input_system(const NameValueItem *items, _int numItems)
{
	OIS::ParamList parameters;

	for (int i = 0; i < numItems; i++) {
		NameValueItem item = items[i];
		OIS::ParamList::value_type paramItem(item.name, item.value);

		parameters.insert(paramItem);
	}

	return OIS::InputManager::createInputSystem(parameters);
}

__export void __entry ois_inputmanager_destroy(HInputManager self)
{
	OIS::InputManager::destroyInputSystem(asInputManager(self));
}

__export _string __entry ois_inputmanager_get_version_name(HInputManager self)
{
	std::string name = asInputManager(self)->getVersionName();

	return copyString(name);
}

__export _string __entry ois_inputmanager_input_system_name(HInputManager self)
{
	std::string name = asInputManager(self)->inputSystemName();

	return copyString(name);
}

__export _int __entry ois_inputmanager_get_number_of_devices(HInputManager self, _int deviceType)
{
	return (_int)asInputManager(self)->getNumberOfDevices((OIS::Type)deviceType);
}

__export HObject __entry ois_inputmanager_create_input_object(HInputManager self, _int deviceType, _bool bufferMode, _string vendor)
{
	return asInputManager(self)->createInputObject((OIS::Type)deviceType, fromBool(bufferMode), vendor);
}

__export void __entry ois_inputmanager_destroy_input_object(HInputManager self, HObject obj)
{
	asInputManager(self)->destroyInputObject(asDeviceObject(obj));
}
