#include "invision/rendering/Node.h"
#include "invision/Util.h"

using namespace invision;

__EXPORT const char* __ENTRY node_get_name(HNode node)
{
	return asNode(node)->getName().c_str();
}

