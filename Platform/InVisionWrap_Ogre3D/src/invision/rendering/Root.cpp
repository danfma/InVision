#include "invision/rendering/Root.h"
#include "invision/rendering/CustomFrameListener.h"
#include "invision/rendering/RenderingEnumerators.h"
#include "invision/Util.h"
#include <Ogre.h>

using namespace invision;

/*
 * Creation and destruction
 */

__EXPORT HRoot __ENTRY RootNew(const char* pluginFilename, const char* configFilename)
{
	return new Ogre::Root(pluginFilename, configFilename);
}

__EXPORT HRoot __ENTRY RootNewWithLog(const char* pluginFilename, const char* configFilename, const char* logFilename)
{
	return new Ogre::Root(pluginFilename, configFilename, logFilename);
}

__EXPORT void __ENTRY RootDelete(HRoot self)
{
	delete asRoot(self);
}


/*
 * Methods
 */

__EXPORT void __ENTRY RootSaveConfig(HRoot self)
{
	asRoot(self)->saveConfig();
}

__EXPORT Bool __ENTRY RootRestoreConfig(HRoot self)
{
	return asRoot(self)->restoreConfig() ? TRUE : FALSE;
}

__EXPORT Bool __ENTRY RootShowConfigDialog(HRoot self)
{
	return asRoot(self)->showConfigDialog() ? TRUE : FALSE;
}

__EXPORT HRenderSystem __ENTRY RootGetRenderSystemByName(
	HRoot self,
	const char* name)
{
	return asRoot(self)->getRenderSystemByName(name);
}

__EXPORT HRenderWindow __ENTRY RootInitialiseWithTitleAndCap(
	HRoot self,
	Bool autoCreateWindow,
	const char* title,
	const char* capabilitiesConfig)
{
	return asRoot(self)->initialise(autoCreateWindow == TRUE, title, capabilitiesConfig);
}

__EXPORT HRenderWindow __ENTRY RootInitialiseWithTitle(HRoot self, Bool autoCreateWindow, const char* title)
{
	return asRoot(self)->initialise(autoCreateWindow == TRUE, title);
}

__EXPORT HRenderWindow __ENTRY RootInitialise(HRoot self, Bool autoCreateWindow)
{
	return asRoot(self)->initialise(autoCreateWindow == TRUE);
}

__EXPORT void __ENTRY RootDestroySceneManager(
	HRoot self,
	HSceneManager sceneManager)
{
	asRoot(self)->destroySceneManager((Ogre::SceneManager*)sceneManager);
}

__EXPORT HSceneManager __ENTRY RootGetSceneManager(
	HRoot self,
	const char* instanceName)
{
	return asRoot(self)->getSceneManager(instanceName);
}

__EXPORT Bool __ENTRY RootHasSceneManager(
	HRoot self,
	const char* instanceName)
{
	return toBool(asRoot(self)->hasSceneManager(instanceName));
}

__EXPORT HTextureManager __ENTRY RootGetTextureManager(
	HRoot self)
{
	return asRoot(self)->getTextureManager();
}

__EXPORT HMeshManager __ENTRY RootGetMeshManager(
	HRoot self)
{
	return asRoot(self)->getMeshManager();
}

__EXPORT HRenderWindow __ENTRY RootGetAutoCreatedWindow(HRoot self)
{
	return asRoot(self)->getAutoCreatedWindow();
}

__EXPORT Bool __ENTRY RootIsInitialised(HRoot self)
{
	return asRoot(self)->isInitialised();
}

__EXPORT void __ENTRY RootStartRendering(HRoot self)
{
	asRoot(self)->startRendering();
}

__EXPORT void __ENTRY RootAddFrameListener(HRoot self, HFrameListener listener)
{
	asRoot(self)->addFrameListener(asCustomFrameListener(listener));
}

__EXPORT void __ENTRY RootRemoveFrameListener(HRoot self, HFrameListener listener)
{
	asRoot(self)->removeFrameListener(asCustomFrameListener(listener));
}

__EXPORT void __ENTRY RootLoadPlugin(HRoot self, const char *pluginName)
{
	asRoot(self)->loadPlugin(pluginName);
}

__EXPORT void __ENTRY RootUnloadPlugin(HRoot self, const char *pluginName)
{
	asRoot(self)->unloadPlugin(pluginName);
}

__EXPORT HEnumerator __ENTRY RootGetAvailableRenderers(HRoot self)
{
	Ogre::RenderSystemList list = asRoot(self)->getAvailableRenderers();

	return new RenderSystemEnumerator(list);
}

/* NEW ********************************************************************************************/

__EXPORT Bool __ENTRY RootGetRemoveRenderQueueStructuresOnClear(HRoot self)
{
	bool result = asRoot(self)->getRemoveRenderQueueStructuresOnClear();

	return toBool(result);
}

__EXPORT void __ENTRY RootSetRemoveRenderQueueStructuresOnClear(HRoot self, Bool value)
{
	asRoot(self)->setRemoveRenderQueueStructuresOnClear(fromBool(value));
}

__EXPORT void __ENTRY RootShutdown(HRoot self)
{
	asRoot(self)->shutdown();
}

__EXPORT Bool __ENTRY RootRenderOneFrame(HRoot self)
{
	bool result = asRoot(self)->renderOneFrame();
	
	return toBool(result);
}
__EXPORT Bool __ENTRY RootRenderOneFrameWithTime(HRoot self, float timeSinceLastFrame)
{
	bool result = asRoot(self)->renderOneFrame(timeSinceLastFrame);
	
	return toBool(result);
}

__EXPORT HRenderWindow __ENTRY RootCreateRenderWindow(
	HRoot self,
	const char* name,
	UInt32 width, UInt32 height,
	Bool fullscreen)
{
	return asRoot(self)->createRenderWindow(name, width, height, fromBool(fullscreen));
}

__EXPORT HRenderWindow __ENTRY RootCreateRenderWindow2(
	HRoot self,
	const char* name,
	UInt32 width, UInt32 height,
	Bool fullscreen,
	HNameValuePairList pairList)
{
	return asRoot(self)->createRenderWindow(
		name, 
		width, height, 
		fromBool(fullscreen),
		asNameValuePairList(pairList));
}

__EXPORT UInt64 __ENTRY RootGetNextFrameNumber(HRoot self)
{
	return asRoot(self)->getNextFrameNumber();
}

__EXPORT HSceneManager __ENTRY RootCreateSceneManagerByTypeName(
	HRoot self, 
	const char* typeName)
{
	return asRoot(self)->createSceneManager(typeName);
}

__EXPORT HSceneManager __ENTRY RootCreateSceneManagerByTypeName2(
	HRoot self, 
	const char* typeName, 
	const char* instanceName)
{
	return asRoot(self)->createSceneManager(typeName, instanceName);
}

__EXPORT HSceneManager __ENTRY RootCreateSceneManagerByType(
	HRoot self, 
	UInt32 type)
{
	return asRoot(self)->createSceneManager(type);
}

__EXPORT HSceneManager __ENTRY RootCreateSceneManagerByType2(
	HRoot self, 
	UInt32 type, 
	const char* instanceName)
{
	return asRoot(self)->createSceneManager(type, instanceName);
}

__EXPORT const char* __ENTRY RootGetErrorDescription(HRoot self, Int64 errorNumber)
{
	return asRoot(self)->getErrorDescription((long)errorNumber).c_str();
}

__EXPORT void __ENTRY RootQueueEndRendering(HRoot self)
{
	asRoot(self)->queueEndRendering();
}

__EXPORT void __ENTRY RootClearEventTimes(HRoot self)
{
	asRoot(self)->clearEventTimes();
}

__EXPORT void __ENTRY RootSetFrameSmoothingPeriod(HRoot self, float period)
{
	asRoot(self)->setFrameSmoothingPeriod(period);
}

__EXPORT float __ENTRY RootGetFrameSmoothingPeriod(HRoot self)
{
	return asRoot(self)->getFrameSmoothingPeriod();
}

__EXPORT Bool __ENTRY RootHasMovableObjectFactory(HRoot self, const char* typeName)
{
	bool result = asRoot(self)->hasMovableObjectFactory(typeName);
	
	return toBool(result);
}

__EXPORT UInt32 __ENTRY RootGetDisplayMonitorCount(HRoot self)
{
	return asRoot(self)->getDisplayMonitorCount();
}


/*
 * Static methods
 */

__EXPORT HRoot __ENTRY RootGetSingleton()
{
	return Ogre::Root::getSingletonPtr();
}
