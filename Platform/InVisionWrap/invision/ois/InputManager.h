#ifndef INPUTMANAGER_H
#define INPUTMANAGER_H

#include "invision/Common.h"
#include "Common.h"

extern "C"
{
	//
	// InputManager members
	//
	__export HInputManager __entry ois_inputmanager_new_with_winhandle(Handle winHandle);
	__export HInputManager __entry ois_inputmanager_new_with_paramlist(HNameValueCollection paramList);

	__export void __entry ois_inputmanager_delete(HInputManager self);

	__export ConstString __entry ois_inputmanager_get_inputsystemname(HInputManager self);
	__export Int32 __entry ois_inputmanager_get_number_of_devices(HInputManager self, Int32 type);

	__export HDeviceInfoEnumerator __entry ois_inputmanager_list_free_devices(HInputManager self);

	__export HInputObject __entry ois_inputmanager_create_inputobject(HInputManager self, Int32 type, Bool bufferMode, const char* vendor);
	__export void __entry ois_inputmanager_destroy_inputobject(HInputManager self, HInputObject obj);

	//
	// Utilities
	//
	__export void __entry delete_deviceinfo(DeviceInfo* data);
}

#ifdef __cplusplus
#include <OIS.h>
#include "invision/Enumerator.h"

namespace invision
{
	namespace ois
	{
		inline OIS::InputManager* asInputManager(HInputManager self)
		{
			return (OIS::InputManager*)self;
		}

		class DeviceInfoEnumerator : IterEnumerator<OIS::DeviceList, OIS::DeviceList::iterator>
		{
		private:
			OIS::DeviceList* list;

		protected:
			Any convert(OIS::DeviceList::iterator& iter)
			{
				OIS::DeviceList::value_type pair = (OIS::DeviceList::value_type)*iter;
				DeviceInfo* info = new DeviceInfo(pair.first, pair.second);

				return info;
			}

		public:
			DeviceInfoEnumerator(OIS::DeviceList& deviceList)
				: list(new OIS::DeviceList(deviceList)),
				  IterEnumerator<OIS::DeviceList, OIS::DeviceList::iterator>(list->begin(), list->end())
			{

			}

			~DeviceInfoEnumerator()
			{
				delete list;
			}
		};
	}
}

#endif

#endif // INPUTMANAGER_H
