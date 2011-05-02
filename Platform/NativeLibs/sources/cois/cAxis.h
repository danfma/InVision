#ifndef CAXIS_H
#define CAXIS_H

#include "cOIS.h"
#include "cComponent.h"

extern "C"
{
	struct AxisDescriptor
	{
		ComponentDescriptor base;	// 8 bytes
		int* abs;					// 12
		int* rel;					// 16
		bool* absOnly;				// 20
	};

	AxisDescriptor
	ois_descriptor_of_axis(_any handle, OIS::Axis* axis);

	/*
	 * OIS::Button
	 */
	INV_EXPORT AxisDescriptor
	INV_CALL ois_new_axis();

	INV_EXPORT void
	INV_CALL ois_delete_axis(OIS::Axis* self);
}

#endif // CAXIS_H
