#ifndef COIS_H
#define COIS_H

#include "cWrapper.h"

extern "C"
{
	/*
	 * Handle types
	 */
	typedef _handle HComponent;
	typedef _handle HAxis;
	typedef _handle HButton;
	typedef _handle HVector3;
	typedef _handle HObject;
	typedef _handle HInputManager;
	typedef _handle HInterface;
	typedef _handle HEventArg;

	typedef _handle HMouseState;
	typedef _handle HMouseListener;
	typedef _handle HMouseEvent;
	typedef _handle HMouse;

	typedef _handle HKeyEvent;
	typedef _handle HKeyListener;
	typedef _handle HKeyboard;

	typedef _handle HJoystickState;

	typedef _handle HVector;
	typedef HVector HVectorBool;
	typedef HVector HVectorAxis;
	typedef HVector HVectorVector3;

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
}

#ifdef __cplusplus
# include <string>
# include <OIS.h>

namespace invision
{
namespace ois
{
	inline void raiseException(std::string message, std::string filename, int line)
	{
		_raise_exception((const _string)message.c_str(), (const _string)filename.c_str(), (_int)line);
	}

	inline void raiseException(std::string message)
	{
		_raise_exception((const _string)message.c_str(), NULL, 0);
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
