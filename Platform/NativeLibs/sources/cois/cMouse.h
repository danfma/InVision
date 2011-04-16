#ifndef CMOUSE_H
#define CMOUSE_H

#include "cOIS.h"
#include "cMouseState.h"

extern "C"
{

__export void __entry ois_mouse_set_event_callback(HMouse self, HMouseListener listener);

}

#endif // CMOUSE_H
