#ifndef MOUSEEVENT_H
#define MOUSEEVENT_H

#include "invision/Common.h"
#include "Common.h"

extern "C"
{
	__export HMouseState __entry ois_mouseevent_get_mouse_state(HMouseEventArgs self);
}

#ifdef __cplusplus
#include <OIS.h>

namespace invision
{
	namespace ois
	{
		inline OIS::MouseEvent* asMouseEventArgs(HMouseEventArgs self)
		{
			return (OIS::MouseEvent*)self;
		}
	}
}

#endif

#endif // MOUSEEVENT_H
