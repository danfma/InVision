#ifndef __INVISIONNATIVE_OIS_DEVICE_TYPE_ITEM_H__
#define __INVISIONNATIVE_OIS_DEVICE_TYPE_ITEM_H__

#include <InvisionHandle.h>
#include "invisionnative_ois.h"

extern "C"
{
	/**
	 * Type DeviceTypeItem
	 */
	struct DeviceTypeItem
	{
		DEVICE_TYPE deviceType;
		_string name;
	};
	
}

#endif // __INVISIONNATIVE_OIS_DEVICE_TYPE_ITEM_H__

