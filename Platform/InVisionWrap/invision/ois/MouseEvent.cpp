#include "MouseEvent.h"

using namespace invision::ois;

__export HMouseState __entry ois_mouseevent_get_mouse_state(HMouseEventArgs self)
{
	OIS::Object* state = (OIS::Object*)&(asMouseEventArgs(self)->state);

	return (HMouseState)state;
}
