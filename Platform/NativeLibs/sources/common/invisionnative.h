#ifndef __INVISIONNATIVE_H__
#define __INVISIONNATIVE_H__

#include <InvisionHandle.h>

extern "C"
{
	
	/*
	 * Prototypes
	 */
	
	struct BoundingBox;
	
	typedef void (INV_CALL *HandleListenerHandleDestroyedHandler)(InvHandle handle);
	
	#include "invisionnative_bounding_box.h"
	
	
	/*
	 * Function group: InVision.Native.IHandleManager
	 */
	
	/**
	 * Method: HandleManager::registerHandleDestroyed (OK)
	 */
	INV_EXPORT void
	INV_CALL handlemanager_register_handle_destroyed(HandleListenerHandleDestroyedHandler handleDestroyed);
	
	
}


#ifdef __cplusplus

using namespace invision;

inline HandleManager* asHandleManager(InvHandle self) {
	return castHandle< HandleManager >(self);
}

/*
 * Initializer
 */
struct InVisionNative
{
	InVisionNative()
	{
	}
};

static InVisionNative __initInVisionNative;

#endif // __cplusplus
#endif // __INVISIONNATIVE_H__
