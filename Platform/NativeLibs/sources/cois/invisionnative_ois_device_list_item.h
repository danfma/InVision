#ifndef __INVISIONNATIVE_OIS_DEVICE_LIST_ITEM_H__
#define __INVISIONNATIVE_OIS_DEVICE_LIST_ITEM_H__

#include <InvisionHandle.h>
#include "invisionnative_ois.h"

extern "C"
{
	/**
	 * Type DeviceListItem
	 */
	struct DeviceListItem
	{
		DEVICE_TYPE type;
		_string name;
	};
	
}

#endif // __INVISIONNATIVE_OIS_DEVICE_LIST_ITEM_H__

