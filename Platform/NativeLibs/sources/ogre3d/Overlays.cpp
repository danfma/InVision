#include "Overlays.h"

using namespace invision::ogre;

__export void __entry ogre_delete_overlaymanager(HOverlayManager self)
{
	delete asOverlayManager(self);
}

__export HOverlay __entry ogre_overlaymanager_create(HOverlayManager self, ConstString name)
{
	return asOverlayManager(self)->create(name);
}

__export HOverlay __entry ogre_overlaymanager_get_by_name(HOverlayManager self, ConstString name)
{
	return asOverlayManager(self)->getByName(name);
}

__export HOverlayElement __entry ogre_overlaymanager_get_overlayelement(HOverlayManager self, ConstString name, Bool isTemplate)
{
	return asOverlayManager(self)->getOverlayElement(name, fromBool(isTemplate));
}

__export HOverlayManager __entry ogre_overlaymanager_get_singleton()
{
	return Ogre::OverlayManager::getSingletonPtr();
}

/*
 * OVERLAY ELEMENT
 */
__export ConstDisplayString __entry ogre_overlayelement_get_caption(HOverlayElement self)
{
	return asOverlayElement(self)->getCaption().c_str();
}

__export void __entry ogre_overlayelement_set_caption(HOverlayElement self, ConstDisplayString value)
{
	asOverlayElement(self)->setCaption(value);
}
