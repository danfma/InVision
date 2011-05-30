#include "cOgre.h"

INV_EXPORT void
INV_CALL light_set_position_m1(InvHandle self, _float x, _float y, _float z)
{
	asLight(self)->setPosition(x, y, z);
}

INV_EXPORT void
INV_CALL light_set_position_m2(InvHandle self, Vector3 pos)
{
	asLight(self)->setPosition(vector3_convert_to_ogre(pos));
}

INV_EXPORT Vector3
INV_CALL light_get_position(InvHandle self)
{
	return vector3_convert_from_ogre(
				asLight(self)->getPosition());
}
