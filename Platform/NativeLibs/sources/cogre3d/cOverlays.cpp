#include "Overlays.h"

using namespace invision::ogre;

INV_EXPORT void INV_CALL ogre_delete_overlaymanager(HOverlayManager self)
{
	delete asOverlayManager(self);
}

INV_EXPORT HOverlay INV_CALL ogre_overlaymanager_create(HOverlayManager self, ConstString name)
{
	return asOverlayManager(self)->create(name);
}

INV_EXPORT HOverlay INV_CALL ogre_overlaymanager_get_by_name(HOverlayManager self, ConstString name)
{
	return asOverlayManager(self)->getByName(name);
}

INV_EXPORT HOverlayElement INV_CALL ogre_overlaymanager_get_overlayelement(HOverlayManager self, ConstString name, _bool isTemplate)
{
	return asOverlayManager(self)->getOverlayElement(name, fromBool(isTemplate));
}

INV_EXPORT HOverlayManager INV_CALL ogre_overlaymanager_get_singleton()
{
	return Ogre::OverlayManager::getSingletonPtr();
}

/*
 * OVERLAY ELEMENT
 */
INV_EXPORT ConstDisplayString INV_CALL ogre_overlayelement_get_caption(HOverlayElement self)
{
	return asOverlayElement(self)->getCaption().c_str();
}

INV_EXPORT void INV_CALL ogre_overlayelement_set_caption(HOverlayElement self, ConstDisplayString value)
{
	asOverlayElement(self)->setCaption(value);
}
