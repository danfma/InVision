#include "cComponent.h"

using namespace invision::ois;

__export _int __entry ois_component_get_ctype(HInputComponent self)
{
	return asComponent(self)->cType;
}
