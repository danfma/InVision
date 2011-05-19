#include "cOIS.h"

/**
 * Method: DeviceList::delete
 */
INV_EXPORT void
INV_CALL devicelist_delete(_any deviceList)
{
	::DeviceList* pDeviceList = (::DeviceList*)deviceList;

	if (pDeviceList == NULL)
		return;

	DeviceListItem* items = (DeviceListItem*)pDeviceList->items;

	for (int i = 0; i < pDeviceList->count; i++) {
		delete[] items[i].name;
	}

	delete[] pDeviceList->items;
	delete pDeviceList;
}
