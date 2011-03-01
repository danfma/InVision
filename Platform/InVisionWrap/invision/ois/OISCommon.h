#ifndef OIS_H
#define OIS_H

#include "invision/Common.h"

#ifdef __cplusplus
#	include <string>
#	include <OIS.h>
#endif

extern "C"
{
	//
	// handles
	//
	typedef InVisionHandle HInputAxis;
	typedef InVisionHandle HInputVector3;
	typedef InVisionHandle HInputAxis;
	typedef InVisionHandle HInputButton;
	typedef InVisionHandle HInputComponent;
	typedef InVisionHandle HInputObject;
	typedef InVisionHandle HInputManager;
	typedef InVisionHandle HInterface;
	typedef InVisionHandle HMouseState;
	typedef InVisionHandle HEventArgs;
	typedef InVisionHandle HMouseEventArgs;
	
	typedef InVisionHandle HInputManager;
	typedef InVisionHandle HKeyboard;

	//
	// custom classes
	//
	typedef InVisionHandle HCustomMouseListener;
	typedef InVisionHandle HCustomKeyListener;

	//
	// Enumerators
	//
	typedef InVisionHandle HDeviceInfoEnumerator;

	//
	// Data types
	//
	struct DeviceInfo
	{
		Int32 type;
		const char* name;

#ifdef __cplusplus
		DeviceInfo(Int32 type, std::string& name)
		{
			this->type = type;
			this->name = copyString(name);
		}

		~DeviceInfo()
		{
			delete[] name;
		}
#endif
	};

	struct AxisComponent
	{
		InVisionHandle handle;
		Int32 componentType;
		Int32 absolute;
		Int32 relative;
		Bool absoluteOnly;

#ifdef __cplusplus
		AxisComponent(OIS::Axis* axis)
		{
			handle = axis;
			componentType = axis->cType;
			absolute = axis->abs;
			relative = axis->rel;
			absoluteOnly = axis->absOnly;
		}

		AxisComponent(InVisionHandle handle, OIS::ComponentType cType, int abs, int rel, bool absOnly)
			: handle(handle), componentType(cType), absolute(abs), relative(rel), absoluteOnly(toBool(absOnly))
		{

		}

#endif
	};

	struct ButtonComponent
	{
		InVisionHandle handle;
		Int32 componentType;
		Bool isPushed;

#ifdef __cplusplus
		ButtonComponent(InVisionHandle handle, OIS::ComponentType cType, bool isPushed)
			: handle(handle), componentType(cType), isPushed(toBool(isPushed))
		{

		}

#endif
	};

	struct Vector3Component
	{
		InVisionHandle handle;
		Int32 componentType;
		float x, y, z;

#if __cplusplus
		Vector3Component(InVisionHandle handle, OIS::ComponentType cType, float x, float y, float z)
			: handle(handle), componentType(cType), x(x), y(y), z(z)
		{ }
#endif
	};

	struct MouseState
	{
		InVisionHandle handle;
		Int32 width;
		Int32 height;
		AxisComponent x, y, z;
		Int32 buttons;

#ifdef __cplusplus
		MouseState(OIS::MouseState* state)
			: handle(state),
			  width(state->width),
			  height(state->height),
			  x(AxisComponent(&(state->X))),
			  y(AxisComponent(&(state->Y))),
			  z(AxisComponent(&(state->Z))),
			  buttons(state->buttons)
		{
		}

		MouseState(InVisionHandle handle,
				   int width, int height,
				   OIS::Axis& x, OIS::Axis& y, OIS::Axis& z,
				   int buttons)
			: handle(handle),
			  width(width),
			  height(height),
			  x(AxisComponent(&x)),
			  y(AxisComponent(&y)),
			  z(AxisComponent(&z)),
			  buttons(buttons)
		{
		}
#endif
	};

	struct MouseEventArgs
	{
		Int32 deviceType;
		InVisionHandle device;
		MouseState state;

#ifdef __cplusplus
		MouseEventArgs(OIS::MouseEvent& e)
			: deviceType( e.device->type() ),
			  device( &(e.device) ),
			  state( MouseState((OIS::MouseState*) &(e.state)) )
		{
		}

#endif
	};
	
	
	struct KeyEventArgs
	{
		Int32 deviceType;
		InVisionHandle device;
		Int32 keyCode;
		UInt32 textCode;
		
#ifdef __cplusplus
		KeyEventArgs(OIS::KeyEvent& e)
			:	deviceType(e.device->type()),
				device( &(e.device) ),
				keyCode( e.key ),
				textCode( e.text )
		{
		}
#endif
	};
}

#endif // OIS_H
