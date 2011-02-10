#ifndef OGREROOT_H
#define OGREROOT_H

#include "invision/Common.h"
#include "invision/NameValueParamsHandle.h"

extern "C"
{
	//
	// Ogre::RootHandle prefix = Root
	//

	/*
	 * Creation and destruction
	 */

	__EXPORT HRoot __ENTRY RootNew(
		const char* pluginFilename,
		const char* configFilename);

	__EXPORT HRoot __ENTRY RootNewWithLog(
		const char* pluginFilename,
		const char* configFilename,
		const char* logFilename);

	__EXPORT void __ENTRY RootDelete(
		HRoot self);

	/*
	 * Methods
	 */

	__EXPORT void __ENTRY RootSaveConfig(
		HRoot self);

	__EXPORT Bool __ENTRY RootRestoreConfig(
		HRoot self);

	__EXPORT Bool __ENTRY RootShowConfigDialog(
		HRoot self);

	// TODO addRenderSystem

	__EXPORT HEnumerator __ENTRY RootGetAvailableRenderers(
		HRoot self);

	/** NEW */
	__EXPORT HRenderSystem __ENTRY RootGetRenderSystemByName(
		HRoot self,
		const char* name);

	__EXPORT HRenderWindow __ENTRY RootInitialiseWithTitleAndCap(
		HRoot self,
		Bool autoCreateWindow,
		const char* title,
		const char* capabilitiesConfig);

	__EXPORT HRenderWindow __ENTRY RootInitialiseWithTitle(
		HRoot self,
		Bool autoCreateWindow,
		const char* title);

	__EXPORT HRenderWindow __ENTRY RootInitialise(
		HRoot self,
		Bool autoCreateWindow);

	__EXPORT Bool __ENTRY RootIsInitialised(
		HRoot self);

	// TODO useCustomRenderSystemCapabilities

	/** NEW */
	__EXPORT Bool __ENTRY RootGetRemoveRenderQueueStructuresOnClear(
		HRoot self);

	/** NEW */
	__EXPORT void __ENTRY RootSetRemoveRenderQueueStructuresOnClear(
		HRoot self,
		Bool value);

	// TODO addSceneManagerFactory
	// TODO removeSceneManagerFactory
	// TODO getSceneManagerMetaData
	// TODO getSceneManagerMetaDataIterator

	__EXPORT HSceneManager __ENTRY RootCreateSceneManagerByTypeName(
		HRoot self,
		const char* typeName);

	__EXPORT HSceneManager __ENTRY RootCreateSceneManagerByTypeName2(
		HRoot self,
		const char* typeName,
		const char* instanceName);

	__EXPORT HSceneManager __ENTRY RootCreateSceneManagerByType(
		HRoot self,
		UInt32 type);

	__EXPORT HSceneManager __ENTRY RootCreateSceneManagerByType2(
		HRoot self,
		UInt32 type,
		const char* instanceName);

	/** NEW */
	__EXPORT void __ENTRY RootDestroySceneManager(
		HRoot self,
		HSceneManager sceneManager);

	/** NEW */
	__EXPORT HSceneManager __ENTRY RootGetSceneManager(
		HRoot self,
		const char* instanceName);

	/** NEW */
	__EXPORT Bool __ENTRY RootHasSceneManager(
		HRoot self,
		const char* instanceName);

	// TODO getSceneManagerIterator

	/** NEW */
	__EXPORT HTextureManager __ENTRY RootGetTextureManager(
		HRoot self);

	/** NEW */
	__EXPORT HMeshManager __ENTRY RootGetMeshManager(
		HRoot self);

	/** NEW */
	__EXPORT const char* __ENTRY RootGetErrorDescription(
		HRoot self,
		Int64 errorNumber);

	__EXPORT void __ENTRY RootAddFrameListener(
		HRoot self,
		HFrameListener listener);

	__EXPORT void __ENTRY RootRemoveFrameListener(
		HRoot self,
		HFrameListener listener);

	/** NEW */
	__EXPORT void __ENTRY RootQueueEndRendering(
		HRoot self);

	__EXPORT void __ENTRY RootStartRendering(
		HRoot self);

	/** NEW */
	__EXPORT Bool __ENTRY RootRenderOneFrame(
		HRoot self);

	/** NEW */
	__EXPORT Bool __ENTRY RootRenderOneFrameWithTime(
		HRoot self,
		float timeSinceLastFrame);

	/** NEW */
	__EXPORT void __ENTRY RootShutdown(
		HRoot self);

	// TODO addResourceLocation
	// TODO removeResourceLocation
	// TODO createFileStream
	// TODO openFileStream
	// TODO convertColourValue
	
	__EXPORT HRenderWindow __ENTRY RootGetAutoCreatedWindow(
		HRoot self);

	__EXPORT HRenderWindow __ENTRY RootCreateRenderWindow(
		HRoot self,
		const char* name,
		UInt32 width, UInt32 height,
		Bool fullscreen);

	__EXPORT HRenderWindow __ENTRY RootCreateRenderWindow2(
		HRoot self,
		const char* name,
		UInt32 width, UInt32 height,
		Bool fullscreen,
		HNameValuePairList pairList);

	// TODO createRenderWindows
	// TODO detachRenderTarget
	// TODO getRenderTarget

	__EXPORT void __ENTRY RootLoadPlugin(
		HRoot self,
		const char *pluginName);

	__EXPORT void __ENTRY RootUnloadPlugin(
		HRoot self,
		const char *pluginName);

	// TODO installPlugin
	// TODO uninstallPlugin
	// TODO getInstalledPlugins
	// TODO getTimer

	// RAISING METHODS
	// TODO _fireFrameStarted(FrameEvent)
	// TODO _fireFrameRenderingQueued(FrameEvent)
	// TODO _fireFrameEnded(FrameEvent)
	// TODO _fireFrameStarted
	// TODO _fireFrameRenderingQueued()
	// TODO _fireFrameEnded()

	/** NEW */
	__EXPORT UInt64 __ENTRY RootGetNextFrameNumber(
		HRoot self);

	/** NEW */
	__EXPORT HSceneManager RootGetCurrentSceneManager(
		HRoot self);

	// TODO _getCurrentSceneManager
	// TODO _pushCurrentSceneManager
	// TODO _popCurrentSceneManager
	// TODO _updateAllRenderTargets()
	// TODO _updateAllRenderTargets(FrameEvent)

	// TODO createRenderQueueInvocationSequence
	// TODO getRenderQueueInvocationSequence
	// TODO destroyRenderQueueInvocationSequence

	/** NEW */
	__EXPORT void __ENTRY RootClearEventTimes(
		HRoot self);

	/** NEW */
	__EXPORT void __ENTRY RootSetFrameSmoothingPeriod(
		HRoot self,
		float period);

	/** NEW */
	__EXPORT float __ENTRY RootGetFrameSmoothingPeriod(
		HRoot self);

	// TODO addMovableObjectFactory
	// TODO removeMovableObjectFactory

	/** NEW */
	__EXPORT Bool __ENTRY RootHasMovableObjectFactory(
		HRoot self,
		const char* typeName);

	// TODO getMovableObjectFactory
	// TODO _allocateNextMovableObjectTypeFlag
	// TODO getMovableObjectFactoryIterator

	/** NEW */
	__EXPORT UInt32 __ENTRY RootGetDisplayMonitorCount(
		HRoot self);

	// TODO getWorkQueue
	// TODO setWorkQueue


	/*
	 * Static methods
	 */

	__EXPORT HRoot __ENTRY RootGetSingleton();

}


#endif // OGREROOT_H
