#ifndef OIS_H
#define OIS_H

#include "cWrapper.h"

#ifdef __cplusplus
#	include <string>
#	include <OIS.h>
#endif

extern "C"
{
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
	 * OIS::Component
	 */
	struct OISComponent 
	{
		_handle handle;
		_int cType;
	};
	
	OISComponent* newOISComponent();
	void deleteOISComponent(OISComponent* component);
	
	/*
	 * OIS::Button
	 */
	struct OISButton
	{
		OISComponent base;
		_bool pushed;
	};
	
	OISButton* newOISButton();
	void deleteOISButton(OISButton* button);
	
	/*
	 * OIS::Axis
	 */
	struct OISAxis
	{
		OISComponent base;
		_int abs;
		_int rel;
		_bool absOnly;
	};
	
	OISAxis* newOISAxis();
	void deleteOISAxis(OISAxis* axis);
	
	/*
	 * OIS::Vector3
	 */
	struct OISVector3
	{
		OISComponent base;
		_float x;
		_float y;
		_float z;
	};
	
	OISVector3 newOISVector();
	void deleteOISVector(OISVector3* vector);
}

#endif // OIS_H
