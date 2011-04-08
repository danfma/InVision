#ifndef BUTTON_H
#define BUTTON_H

#include "cOIS.h"

extern "C"
{
	__export HInputButton __entry ois_button_new();
	__export void __entry ois_button_delete(HInputButton button);

	__export _bool __entry ois_button_get_pushed(HInputButton button);
	__export void __entry ois_button_set_pushed(HInputButton button, _bool value);
}

#ifdef __cplusplus
#include <OIS.h>

namespace invision
{
	namespace ois
	{
		inline OIS::Button* asButton(HInputButton handle)
		{
			return (OIS::Button*)handle;
		}
	}
}

#endif

#endif // BUTTON_H
