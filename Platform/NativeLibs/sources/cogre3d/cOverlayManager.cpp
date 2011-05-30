#include "cOgre.h"

INV_EXPORT InvHandle
INV_CALL overlaymanager_get_overlay_element(InvHandle self, _string name, _bool isTemplate)
{
	return getOrCreateReference<Ogre::OverlayElement>(
				asOverlayManager(self)->getOverlayElement(name, fromBool(isTemplate)));
}

INV_EXPORT InvHandle
INV_CALL overlaymanager_get_singleton()
{
	return getOrCreateReference<Ogre::OverlayManager>(
				Ogre::OverlayManager::getSingletonPtr());
}

INV_EXPORT InvHandle
INV_CALL overlaymanager_get_by_name(InvHandle self, _string name)
{
	return getOrCreateReference<Ogre::Overlay>(
				asOverlayManager(self)->getByName(name));
}
