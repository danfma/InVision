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

	INV_EXPORT _uint
	INV_CALL ois_inputmanager_get_version_number();

	INV_EXPORT OIS::InputManager*
	INV_CALL ois_inputmanager_create_input_system(
		int winHandle);

	INV_EXPORT OIS::InputManager*
	INV_CALL ois_inputmanager_create_by_param_input_system(
		const NameValueItem *items,
		_int numItems);

	INV_EXPORT void
	INV_CALL ois_inputmanager_destroy(
		OIS::InputManager* self);

	INV_EXPORT _string
	INV_CALL ois_inputmanager_get_version_name(
		OIS::InputManager* self);

	INV_EXPORT _string
	INV_CALL ois_inputmanager_input_system_name(
		OIS::InputManager* self);

	INV_EXPORT _int
	INV_CALL ois_inputmanager_get_number_of_devices(
		OIS::InputManager* self,
		OIS::Type deviceType);

	INV_EXPORT OIS::Object*
	INV_CALL ois_inputmanager_create_input_object(
		OIS::InputManager* self,
		OIS::Type deviceType,
		bool bufferMode,
		_string vendor);

	INV_EXPORT void
	INV_CALL ois_inputmanager_destroy_input_object(
		OIS::InputManager* self,
		OIS::Object* obj);

}

#endif // INPUTMANAGER_H
