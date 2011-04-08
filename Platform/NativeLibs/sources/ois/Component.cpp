#include "Component.h"

using namespace invision::ois;

__export Int32 __entry ois_component_get_ctype(HInputComponent self)
{
	return asComponent(self)->cType;
}
