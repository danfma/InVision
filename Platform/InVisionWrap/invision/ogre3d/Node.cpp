#include "Node.h"
#include "TypeConvert.h"

using namespace invision;

__export const char* __entry node_get_name(HNode node)
{
	return asNode(node)->getName().c_str();
}

