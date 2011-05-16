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
	 * Prototypes
	 */
	
	struct ComponentDescriptor;
	
	#include "invisionnative_ois_component_descriptor.h"
	
}


#ifdef __cplusplus

using namespace invision;

#endif // __cplusplus
#endif // __INVISIONNATIVE_OIS_H__
