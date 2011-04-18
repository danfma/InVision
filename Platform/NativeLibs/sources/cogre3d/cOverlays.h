#ifndef OVERLAYS_H
#define OVERLAYS_H

#include "OgreCommon.h"

extern "C"
{
	/*
	 * OVERLAY MANAGERs
	 */
	__export void __entry ogre_delete_overlaymanager(HOverlayManager self);

	__export HOverlay __entry ogre_overlaymanager_create(HOverlayManager self, ConstString name);
	__export HOverlay __entry ogre_overlaymanager_get_by_name(HOverlayManager self, ConstString name);

	__export HOverlayElement __entry ogre_overlaymanager_get_overlayelement(HOverlayManager self, ConstString name, _bool isTemplate);

	__export HOverlayManager __entry ogre_overlaymanager_get_singleton();


	/*
	 * OVERLAY ELEMENT
	 */
	__export ConstDisplayString __entry ogre_overlayelement_get_caption(HOverlayElement self);
	__export void __entry ogre_overlayelement_set_caption(HOverlayElement self, ConstDisplayString value);
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
