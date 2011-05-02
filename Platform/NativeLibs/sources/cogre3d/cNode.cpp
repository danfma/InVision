#include "Node.h"
#include "TypeConvert.h"

using namespace invision;

INV_EXPORT const _string INV_CALL node_get_name(HNode node)
{
	return asNode(node)->getName().c_str();
}

