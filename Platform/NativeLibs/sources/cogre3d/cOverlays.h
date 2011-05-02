#ifndef OVERLAYS_H
#define OVERLAYS_H

#include "OgreCommon.h"

extern "C"
{
	/*
	 * OVERLAY MANAGERs
	 */
	INV_EXPORT void INV_CALL ogre_delete_overlaymanager(HOverlayManager self);

	INV_EXPORT HOverlay INV_CALL ogre_overlaymanager_create(HOverlayManager self, ConstString name);
	INV_EXPORT HOverlay INV_CALL ogre_overlaymanager_get_by_name(HOverlayManager self, ConstString name);

	INV_EXPORT HOverlayElement INV_CALL ogre_overlaymanager_get_overlayelement(HOverlayManager self, ConstString name, _bool isTemplate);

	INV_EXPORT HOverlayManager INV_CALL ogre_overlaymanager_get_singleton();


	/*
	 * OVERLAY ELEMENT
	 */
	INV_EXPORT ConstDisplayString INV_CALL ogre_overlayelement_get_caption(HOverlayElement self);
	INV_EXPORT void INV_CALL ogre_overlayelement_set_caption(HOverlayElement self, ConstDisplayString value);
}

#ifdef __cplusplus

namespace invision
{
	namespace ogre
	{
		inline Ogre::OverlayManager* asOverlayManager(HOverlayManager handle)
		{
			return (Ogre::OverlayManager*) handle;
		}

		inline Ogre::OverlayElement* asOverlayElement(HOverlayElement handle)
		{
			return (Ogre::OverlayElement*) handle;
		}
	}
}

#endif // __cplusplus

#endif // OVERLAYS_H
