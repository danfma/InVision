#ifndef __INVISIONNATIVE_OIS_H__
#define __INVISIONNATIVE_OIS_H__

#include <InvisionHandle.h>

extern "C"
{
	/*
	 * Enumeration COMPONENT_TYPE
	 */
	#define COMPONENT_TYPE _int
	#define COMPONENT_TYPE_UNKNOWN 0x0
	#define COMPONENT_TYPE_BUTTON 0x1
	#define COMPONENT_TYPE_AXIS 0x2
	#define COMPONENT_TYPE_SLIDER 0x3
	#define COMPONENT_TYPE_POV 0x4
	#define COMPONENT_TYPE_VECTOR3 0x5
	
	/*
	 * Enumeration ADD_ON_FACTORY
	 */
	#define ADD_ON_FACTORY _int
	#define ADD_ON_FACTORY_ALL 0x0
	#define ADD_ON_FACTORY_LIRC 0x1
	#define ADD_ON_FACTORY_WII_MOTE 0x2
	
	/*
	 * Enumeration KEY_CODE
	 */
	#define KEY_CODE _int
	#define KEY_CODE_UNASSIGNED 0x0
	#define KEY_CODE_ESCAPE 0x1
	#define KEY_CODE_ONE 0x2
	#define KEY_CODE_TWO 0x3
	#define KEY_CODE_THREE 0x4
	#define KEY_CODE_FOUR 0x5
	#define KEY_CODE_FIVE 0x6
	#define KEY_CODE_SIX 0x7
	#define KEY_CODE_SEVEN 0x8
	#define KEY_CODE_EIGHT 0x9
	#define KEY_CODE_NINE 0xA
	#define KEY_CODE_TEN 0xB
	#define KEY_CODE_MINUS 0xC
	#define KEY_CODE_EQUALS 0xD
	#define KEY_CODE_BACK 0xE
	#define KEY_CODE_TAB 0xF
	#define KEY_CODE_Q 0x10
	#define KEY_CODE_W 0x11
	#define KEY_CODE_E 0x12
	#define KEY_CODE_R 0x13
	#define KEY_CODE_T 0x14
	#define KEY_CODE_Y 0x15
	#define KEY_CODE_U 0x16
	#define KEY_CODE_I 0x17
	#define KEY_CODE_O 0x18
	#define KEY_CODE_P 0x19
	#define KEY_CODE_LBRACKET 0x1A
	#define KEY_CODE_RBRACKET 0x1B
	#define KEY_CODE_RETURN 0x1C
	#define KEY_CODE_LCONTROL 0x1D
	#define KEY_CODE_A 0x1E
	#define KEY_CODE_S 0x1F
	#define KEY_CODE_D 0x20
	#define KEY_CODE_F 0x21
	#define KEY_CODE_G 0x22
	#define KEY_CODE_H 0x23
	#define KEY_CODE_J 0x24
	#define KEY_CODE_K 0x25
	#define KEY_CODE_L 0x26
	#define KEY_CODE_SEMICOLON 0x27
	#define KEY_CODE_APOSTROPHE 0x28
	#define KEY_CODE_GRAVE 0x29
	#define KEY_CODE_LSHIFT 0x2A
	#define KEY_CODE_BACKSLASH 0x2B
	#define KEY_CODE_Z 0x2C
	#define KEY_CODE_X 0x2D
	#define KEY_CODE_C 0x2E
	#define KEY_CODE_V 0x2F
	#define KEY_CODE_B 0x30
	#define KEY_CODE_N 0x31
	#define KEY_CODE_M 0x32
	#define KEY_CODE_COMMA 0x33
	#define KEY_CODE_PERIOD 0x34
	#define KEY_CODE_SLASH 0x35
	#define KEY_CODE_RSHIFT 0x36
	#define KEY_CODE_MULTIPLY 0x37
	#define KEY_CODE_LMENU 0x38
	#define KEY_CODE_SPACE 0x39
	#define KEY_CODE_CAPITAL 0x3A
	#define KEY_CODE_F1 0x3B
	#define KEY_CODE_F2 0x3C
	#define KEY_CODE_F3 0x3D
	#define KEY_CODE_F4 0x3E
	#define KEY_CODE_F5 0x3F
	#define KEY_CODE_F6 0x40
	#define KEY_CODE_F7 0x41
	#define KEY_CODE_F8 0x42
	#define KEY_CODE_F9 0x43
	#define KEY_CODE_F10 0x44
	#define KEY_CODE_NUM_LOCK 0x45
	#define KEY_CODE_SCROLL 0x46
	#define KEY_CODE_NUMPAD7 0x47
	#define KEY_CODE_NUMPAD8 0x48
	#define KEY_CODE_NUMPAD9 0x49
	#define KEY_CODE_SUBTRACT 0x4A
	#define KEY_CODE_NUMPAD4 0x4B
	#define KEY_CODE_NUMPAD5 0x4C
	#define KEY_CODE_NUMPAD6 0x4D
	#define KEY_CODE_ADD 0x4E
	#define KEY_CODE_NUMPAD1 0x4F
	#define KEY_CODE_NUMPAD2 0x50
	#define KEY_CODE_NUMPAD3 0x51
	#define KEY_CODE_NUMPAD0 0x52
	#define KEY_CODE_DECIMAL 0x53
	#define KEY_CODE_OEM102 0x56
	#define KEY_CODE_F11 0x57
	#define KEY_CODE_F12 0x58
	#define KEY_CODE_F13 0x64
	#define KEY_CODE_F14 0x65
	#define KEY_CODE_F15 0x66
	#define KEY_CODE_KANA 0x70
	#define KEY_CODE_ABNT_C1 0x73
	#define KEY_CODE_CONVERT 0x79
	#define KEY_CODE_NO_CONVERT 0x7B
	#define KEY_CODE_YEN 0x7D
	#define KEY_CODE_ABNT_C2 0x7E
	#define KEY_CODE_NUMPAD_EQUALS 0x8D
	#define KEY_CODE_PREV_TRACK 0x90
	#define KEY_CODE_AT 0x91
	#define KEY_CODE_COLON 0x92
	#define KEY_CODE_UNDERLINE 0x93
	#define KEY_CODE_KANJI 0x94
	#define KEY_CODE_STOP 0x95
	#define KEY_CODE_AX 0x96
	#define KEY_CODE_UNLABELED 0x97
	#define KEY_CODE_NEXT_TRACK 0x99
	#define KEY_CODE_NUMPAD_ENTER 0x9C
	#define KEY_CODE_RCONTROL 0x9D
	#define KEY_CODE_MUTE 0xA0
	#define KEY_CODE_CALCULATOR 0xA1
	#define KEY_CODE_PLAY_PAUSE 0xA2
	#define KEY_CODE_MEDIA_STOP 0xA4
	#define KEY_CODE_VOLUME_DOWN 0xAE
	#define KEY_CODE_VOLUME_UP 0xB0
	#define KEY_CODE_WEB_HOME 0xB2
	#define KEY_CODE_NUMPAD_COMMA 0xB3
	#define KEY_CODE_DIVIDE 0xB5
	#define KEY_CODE_SYSRQ 0xB7
	#define KEY_CODE_RMENU 0xB8
	#define KEY_CODE_PAUSE 0xC5
	#define KEY_CODE_HOME 0xC7
	#define KEY_CODE_UP 0xC8
	#define KEY_CODE_PG_UP 0xC9
	#define KEY_CODE_LEFT 0xCB
	#define KEY_CODE_RIGHT 0xCD
	#define KEY_CODE_END 0xCF
	#define KEY_CODE_DOWN 0xD0
	#define KEY_CODE_PG_DOWN 0xD1
	#define KEY_CODE_INSERT 0xD2
	#define KEY_CODE_DELETE 0xD3
	#define KEY_CODE_LWIN 0xDB
	#define KEY_CODE_RWIN 0xDC
	#define KEY_CODE_APPS 0xDD
	#define KEY_CODE_POWER 0xDE
	#define KEY_CODE_SLEEP 0xDF
	#define KEY_CODE_WAKE 0xE3
	#define KEY_CODE_WEB_SEARCH 0xE5
	#define KEY_CODE_WEB_FAVORITES 0xE6
	#define KEY_CODE_WEB_REFRESH 0xE7
	#define KEY_CODE_WEB_STOP 0xE8
	#define KEY_CODE_WEB_FORWARD 0xE9
	#define KEY_CODE_WEB_BACK 0xEA
	#define KEY_CODE_MY_COMPUTER 0xEB
	#define KEY_CODE_MAIL 0xEC
	#define KEY_CODE_MEDIA_SELECT 0xED
	
	/*
	 * Enumeration INTERFACE_TYPE
	 */
	#define INTERFACE_TYPE _int
	#define INTERFACE_TYPE_FORCE_FEEDBACK 0x0
	#define INTERFACE_TYPE_RESERVED 0x1
	
	/*
	 * Enumeration DEVICE_TYPE
	 */
	#define DEVICE_TYPE _int
	#define DEVICE_TYPE_UNKNOWN 0x0
	#define DEVICE_TYPE_KEYBOARD 0x1
	#define DEVICE_TYPE_MOUSE 0x2
	#define DEVICE_TYPE_JOYSTICK 0x3
	#define DEVICE_TYPE_TABLET 0x4
	
	
	/*
	 * Prototypes
	 */
	
	struct EventArgDescriptor;
	struct ComponentDescriptor;
	struct Vector3Descriptor;
	struct DeviceTypeItem;
	struct ButtonDescriptor;
	struct AxisDescriptor;
	struct KeyEventDescriptor;
	struct NameValueItem;
	
	#include "invisionnative_ois_event_arg_descriptor.h"
	#include "invisionnative_ois_component_descriptor.h"
	#include "invisionnative_ois_vector3_descriptor.h"
	#include "invisionnative_ois_device_type_item.h"
	#include "invisionnative_ois_button_descriptor.h"
	#include "invisionnative_ois_axis_descriptor.h"
	#include "invisionnative_ois_key_event_descriptor.h"
	#include "invisionnative_ois_name_value_item.h"
	
	/*
	 * Function group: InVision.OIS.Native.IComponent
	 */
	
	/**
	 * Method: Component::Component
	 */
	INV_EXPORT InvHandle
	INV_CALL new_component_by_descriptor(ComponentDescriptor* descriptor);
	
	/**
	 * Method: Component::Component
	 */
	INV_EXPORT InvHandle
	INV_CALL new_component_by_descriptor_ctype(ComponentDescriptor* descriptor, COMPONENT_TYPE ctype);
	
	/**
	 * Method: Component::~Component
	 */
	INV_EXPORT void
	INV_CALL delete_component(InvHandle self);
	
	
	/*
	 * Function group: InVision.OIS.Native.IVector3
	 */
	
	/**
	 * Method: Vector3::Vector3
	 */
	INV_EXPORT InvHandle
	INV_CALL new_vector3_by_descriptor(Vector3Descriptor* descriptor);
	
	/**
	 * Method: Vector3::Vector3
	 */
	INV_EXPORT InvHandle
	INV_CALL new_vector3_by_descriptor_x_y_z(Vector3Descriptor* descriptor, _float x, _float y, _float z);
	
	
	/*
	 * Function group: InVision.OIS.Native.IButton
	 */
	
	/**
	 * Method: Button::Button
	 */
	INV_EXPORT InvHandle
	INV_CALL new_button_by_descriptor(ButtonDescriptor* descriptor);
	
	/**
	 * Method: Button::Button
	 */
	INV_EXPORT InvHandle
	INV_CALL new_button_by_descriptor_pushed(ButtonDescriptor* descriptor, _bool pushed);
	
	
	/*
	 * Function group: InVision.OIS.Native.IAxis
	 */
	
	/**
	 * Method: Axis::Axis
	 */
	INV_EXPORT InvHandle
	INV_CALL new_axis_by_descriptor(AxisDescriptor* descriptor);
	
	
}


#ifdef __cplusplus
#include <OIS.h>

using namespace invision;

inline OIS::Component* asComponent(InvHandle self) {
	return castHandle< OIS::Component >(self);
}

inline OIS::Vector3* asVector3(InvHandle self) {
	return castHandle< OIS::Vector3 >(self);
}

inline OIS::Button* asButton(InvHandle self) {
	return castHandle< OIS::Button >(self);
}

inline OIS::Axis* asAxis(InvHandle self) {
	return castHandle< OIS::Axis >(self);
}

#endif // __cplusplus
#endif // __INVISIONNATIVE_OIS_H__
