#ifndef EVENTARGS_H
#define EVENTARGS_H

#include "invision/Common.h"
#include "Common.h"

extern "C"
{
	__export HInputObject __entry ois_get_device(HEventArgs e);
}

#ifdef __cplusplus
#include <OIS.h>

namespace invision
{
	namespace ois
	{
		inline OIS::EventArg* asEventArg(HEventArgs handle)
		{
			return (OIS::EventArg*)handle;
		}
	}
}

#endif

#endif // EVENTARGS_H
