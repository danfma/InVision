#ifndef INPUTMANAGER_H
#define INPUTMANAGER_H

#include "cOIS.h"
#include "cObject.h"

extern "C"
{

struct NameValueItem
{
	_string name;
	_string value;
};

__export _uint __entry ois_inputmanager_get_version_number();

__export HInputManager __entry ois_inputmanager_create_input_system(_handle winHandle);

__export HInputManager __entry ois_inputmanager_create_by_param_input_system(const NameValueItem *items, _int numItems);

__export void __entry ois_inputmanager_destroy(HInputManager self);

__export _string __entry ois_inputmanager_get_version_name(HInputManager self);

__export _string __entry ois_inputmanager_input_system_name(HInputManager self);

__export _int __entry ois_inputmanager_get_number_of_devices(HInputManager self, _int deviceType);

__export HObject __entry ois_inputmanager_create_input_object(HInputManager self, _int deviceType, _bool bufferMode, _string vendor);

__export void __entry ois_inputmanager_destroy_input_object(HInputManager self, HObject obj);

}

#ifdef __cplusplus

inline OIS::InputManager* asInputManager(HInputManager handle)
{
	return (OIS::InputManager*)handle;
}

#endif // __cplusplus

#endif // INPUTMANAGER_H
