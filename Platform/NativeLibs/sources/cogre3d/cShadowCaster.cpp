#include "cOgre.h"

/**
 * Method: ShadowCaster::getCastShadows
 */
INV_EXPORT _bool
INV_CALL shadowcaster_get_cast_shadows(InvHandle self)
{
	return toBool(asShadowCaster(self)->getCastShadows());
}

/**
 * Method: ShadowCaster::getEdgeList
 */
INV_EXPORT InvHandle
INV_CALL shadowcaster_get_edge_list(InvHandle self)
{
	Ogre::EdgeData* edgeList = asShadowCaster(self)->getEdgeList();

	return createReference<Ogre::EdgeData>(edgeList);
}

/**
 * Method: ShadowCaster::hasEdgeList
 */
INV_EXPORT _bool
INV_CALL shadowcaster_has_edge_list(InvHandle self)
{
	return toBool(asShadowCaster(self)->hasEdgeList());
}

/**
 * Method: ShadowCaster::getPointExtrusionDistance
 */
INV_EXPORT _float
INV_CALL shadowcaster_get_point_extrusion_distance(InvHandle self, InvHandle light)
{
	return asShadowCaster(self)->getPointExtrusionDistance(asLight(light));
}

