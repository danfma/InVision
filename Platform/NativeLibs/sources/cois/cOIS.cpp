#include "cOIS.h"

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
* OIS::Component
*/
OISComponent* newOISComponent()
{
	OIS::Component* component = new OIS::Component();
	
	OISComponent* result = new OISComponent();
	result->cType = component->cType;
	result->handle = component;
	
	return result;
}

void deleteOISComponent(OISComponent* component)
{
	if (component == NULL)
		return;
	
	delete component->handle;
	delete component;
}

/*
 * OIS::Button
 */
OISButton* newOISButton()
{
	OIS::Button* button = new OIS::Button();
	
	OISButton* result = new OISButton();
	result->base.handle = button;
	result->base.cType = button->cType;
	result->pushed = button->pushed;
	
	return result;
}

void deleteOISButton(OISButton* button)
{
}
