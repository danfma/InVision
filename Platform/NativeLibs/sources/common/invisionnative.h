#ifndef __INVISIONNATIVE_H__
#define __INVISIONNATIVE_H__

#include <InvisionHandle.h>

extern "C"
{
	
	/*
	 * Prototypes
	 */
	
	
	typedef void (INV_CALL *HandleListenerHandleDestroyedHandler)(InvHandle handle);
	
	
	
	/*
	 * Function group: InVision.Native.IHandleManager
	 */
	
	/**
	 * Method: HandleManager::registerHandleDestroyed
	 */
	INV_EXPORT void
	INV_CALL handlemanager_register_handle_destroyed(HandleListenerHandleDestroyedHandler handleDestroyed);
	
	
}


#ifdef __cplusplus

using namespace invision;

inline HandleManager* asHandleManager(InvHandle self) {
	return castHandle< HandleManager >(self);
}

#endif // __cplusplus
#endif // __INVISIONNATIVE_H__
