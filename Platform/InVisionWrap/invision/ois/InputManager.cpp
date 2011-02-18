#include "InputManager.h"
#include "InputObject.h"
#include "invision/Collections.h"
#include <cstddef>

using namespace invision;
using namespace invision::ois;

__export HInputManager __entry ois_inputmanager_new_with_winhandle(Handle winHandle)
{
	return OIS::InputManager::createInputSystem((std::size_t)winHandle);
}

__export HInputManager __entry ois_inputmanager_new_with_paramlist(HNameValueCollection paramList)
{
	NameValueMap* map = (NameValueMap*)paramList;

	return OIS::InputManager::createInputSystem(*map);
}

__export void __entry ois_inputmanager_delete(HInputManager self)
{
	OIS::InputManager::destroyInputSystem(asInputManager(self));
}

__export ConstString __entry ois_inputmanager_get_inputsystemname(HInputManager self)
{
	return asInputManager(self)->inputSystemName().c_str();
}

__export Int32 __entry ois_inputmanager_get_number_of_devices(HInputManager self, Int32 type)
{
	return asInputManager(self)->getNumberOfDevices((OIS::Type)type);
}

__export HDeviceInfoEnumerator __entry ois_inputmanager_list_free_devices(HInputManager self)
{
	OIS::DeviceList deviceList = asInputManager(self)->listFreeDevices();

	return new DeviceInfoEnumerator(deviceList);
}

__export HInputObject __entry ois_inputmanager_create_inputobject(HInputManager self, Int32 type, Bool bufferMode, const char* vendor)
{
	return asInputManager(self)->createInputObject((OIS::Type)type, fromBool(bufferMode), vendor);
}

__export void __entry ois_inputmanager_destroy_inputobject(HInputManager self, HInputObject obj)
{
	asInputManager(self)->destroyInputObject(asObject(obj));
}


__export void __entry delete_deviceinfo(DeviceInfo* data)
{
	delete data;
}
