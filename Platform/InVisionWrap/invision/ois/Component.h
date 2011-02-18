#ifndef COMPONENT_H
#define COMPONENT_H

#include "invision/Common.h"
#include "Common.h"

extern "C"
{
	__export Int32 __entry ois_component_get_ctype(HInputComponent self);
}

#ifdef __cplusplus
#include <OIS.h>

namespace invision
{
	namespace ois
	{
		inline OIS::Component* asComponent(HInputComponent self)
		{
			return (OIS::Component*)self;
		}
	}
}

#endif

#endif // COMPONENT_H
