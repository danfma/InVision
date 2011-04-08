#include "EventArgs.h"

using namespace invision::ois;

__export HInputObject __entry ois_get_device(HEventArgs e)
{
	OIS::Object *pt = (OIS::Object*)asEventArg(e)->device;

	return pt;
}
