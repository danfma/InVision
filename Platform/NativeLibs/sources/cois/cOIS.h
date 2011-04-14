#ifndef COIS_H
#define COIS_H

#include "cWrapper.h"

extern "C"
{
	/*
	 * Handle types
	 */
	typedef _handle OISComponentHandle;
	typedef _handle OISAxisHandle;
	typedef _handle OISButtonHandle;
	typedef _handle OISVector3Handle;

	typedef _handle OISObjectHandle;
	typedef _handle OISInputManagerHandle;
	typedef _handle OISInterfaceHandle;

	/*
	 * OIS::Type
	 */
	extern _int OIS_TYPE_UNKNONW;
	extern _int OIS_TYPE_KEYBOARD;
	extern _int OIS_TYPE_MOUSE;
	extern _int OIS_TYPE_JOYSTICK;
	extern _int OIS_TYPE_TABLET;
	
	/*
	 * OIS::ComponentType
	 */
	extern _int OIS_COMPONENT_TYPE_UNKNOWN;
	extern _int OIS_COMPONENT_TYPE_BUTTON;
	extern _int OIS_COMPONENT_TYPE_AXIS;
	extern _int OIS_COMPONENT_TYPE_SLIDER;
	extern _int OIS_COMPONENT_TYPE_POV;
	extern _int OIS_COMPONENT_TYPE_VECTOR3;

	/*
	 * OIS::OIS_ERROR
	 */
	extern _int OIS_ERROR_INPUT_DISCONNECTED;
	extern _int OIS_ERROR_INPUT_DEVICE_NON_EXISTENT;
	extern _int OIS_ERROR_INPUT_DEVICE_NOT_SUPPORTED;
	extern _int OIS_ERROR_DEVICE_FULL;
	extern _int OIS_ERROR_NOT_IMPLEMENTED;
	extern _int OIS_ERROR_DUPLICATE;
	extern _int OIS_ERROR_INVALID_PARAM;
	extern _int OIS_ERROR_GENERAL;

	/*
	 * OIS::Interface::IType
	 */
	extern _int OIS_ITYPE_FORCE_FEEDBACK;
	extern _int OIS_ITYPE_RESERVED;

	/*
	 * Exception handler
	 */
	typedef void (*ExceptionHandler)(const _string message, _int errorType, const _string filename, _int line);

	__export void __entry _oisRegisterExceptionHandler(ExceptionHandler handler);
	__export void __entry _oisRaiseException(const _string message, _int errorType, const _string filename, _int line);
}

#ifdef __cplusplus
# include <string>
# include <OIS.h>

namespace invision
{
namespace ois
{
	inline void raiseException(std::string message, OIS::OIS_ERROR error, std::string filename, int line)
	{
		_oisRaiseException((const _string)message.c_str(), (_int)error, (const _string)filename.c_str(), (_int)line);
	}

	inline void raiseException(std::string message)
	{
		_oisRaiseException((const _string)message.c_str(), OIS_ERROR_GENERAL, NULL, 0);
	}

	inline bool ensureNotNull(_handle handle)
	{
		bool isNull = handle == NULL;
		
		if (isNull)
			raiseException("Parameter is null");
		
		return !isNull;
	}
}
}

#endif

#endif // COIS_H
