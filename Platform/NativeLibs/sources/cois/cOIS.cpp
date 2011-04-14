#include "cOIS.h"
#include "cOIS.h"

using namespace invision::ois;
using namespace std;

/*
* OIS::Type
*/
_int OIS_TYPE_UNKNONW = OIS::OISUnknown;
_int OIS_TYPE_KEYBOARD = OIS::OISKeyboard;
_int OIS_TYPE_MOUSE = OIS::OISMouse;
_int OIS_TYPE_JOYSTICK = OIS::OISJoyStick;
_int OIS_TYPE_TABLET = OIS::OISTablet;

/*
* OIS::ComponentType
*/
_int OIS_COMPONENT_TYPE_UNKNOWN = OIS::OIS_Unknown;
_int OIS_COMPONENT_TYPE_BUTTON = OIS::OIS_Button;
_int OIS_COMPONENT_TYPE_AXIS = OIS::OIS_Axis;
_int OIS_COMPONENT_TYPE_SLIDER = OIS::OIS_Slider;
_int OIS_COMPONENT_TYPE_POV = OIS::OIS_POV;
_int OIS_COMPONENT_TYPE_VECTOR3 = OIS::OIS_Vector3;

/*
 * OIS::OIS_ERROR
 */
_int OIS_ERROR_INPUT_DISCONNECTED			= (_int)E_InputDisconnected;
_int OIS_ERROR_INPUT_DEVICE_NON_EXISTENT	= (_int)E_InputDeviceNonExistant;
_int OIS_ERROR_INPUT_DEVICE_NOT_SUPPORTED	= (_int)E_InputDeviceNotSupported;
_int OIS_ERROR_DEVICE_FULL					= (_int)E_DeviceFull;
_int OIS_ERROR_NOT_IMPLEMENTED				= (_int)E_NotImplemented;
_int OIS_ERROR_DUPLICATE					= (_int)E_Duplicate;
_int OIS_ERROR_INVALID_PARAM				= (_int)E_InvalidParam;
_int OIS_ERROR_GENERAL						= (_int)E_General;

/*
 * OIS::Interface::IType
 */
_int OIS_ITYPE_FORCE_FEEDBACK	= (_int)OIS::Interface::ForceFeedback;
_int OIS_ITYPE_RESERVED			= (_int)OIS::Interface::Reserved;

/*
 * Exception handler
 */
ExceptionHandler exceptionHandler = NULL;

__export void __entry _oisRegisterExceptionHandler(ExceptionHandler handler)
{
	exceptionHandler = handler;
}

__export void __entry _oisRaiseException(const _string message, _int errorType, const _string filename, _int line)
{
	if (exceptionHandler == NULL)
		cerr << "Exception (" << errorType << " - file: " << filename << " line: " << line << "): " << message << endl;
	else
		exceptionHandler(message, errorType, filename, line);
}