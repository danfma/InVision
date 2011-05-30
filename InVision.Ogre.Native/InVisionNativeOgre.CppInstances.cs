/*
 * GENERATED CODE
 * DO NOT EDIT THIS
 */

using System;
using System.Reflection;
using InVision.GameMath;
using InVision.Native;
using InVision.Ogre;
using InVision.Ogre.Listeners;
using InVision.Ogre.Native;

namespace InVision.Ogre.Native
{
	[CppImplementation(typeof(IStringInterface))]
	internal unsafe class StringInterfaceImpl
		: CppInstance, IStringInterface
	{
	}
	
	[CppImplementation(typeof(IRenderable))]
	internal unsafe class RenderableImpl
		: CppInstance, IRenderable
	{
	}
	
	[CppImplementation(typeof(IOverlayElement))]
	internal unsafe class OverlayElementImpl
		: StringInterfaceImpl, IOverlayElement, IRenderable
	{
		String IOverlayElement.GetCaption()
		{
			CheckMemberOnlyCall();
			
			var result = NativeOverlayElement.GetCaption(Self);
			
			return result;
		}
		
		void IOverlayElement.SetCaption(String value)
		{
			CheckMemberOnlyCall();
			
			NativeOverlayElement.SetCaption(Self, value);
		}
		
		void IOverlayElement.Show()
		{
			CheckMemberOnlyCall();
			
			NativeOverlayElement.Show(Self);
		}
		
	}
	
	[CppImplementation(typeof(IOverlay))]
	internal unsafe class OverlayImpl
		: CppInstance, IOverlay
	{
		void IOverlay.Show()
		{
			CheckMemberOnlyCall();
			
			NativeOverlay.Show(Self);
		}
		
	}
	
	[CppImplementation(typeof(IAnimableObject))]
	internal unsafe class AnimableObjectImpl
		: CppInstance, IAnimableObject
	{
	}
	
	[CppImplementation(typeof(IShadowCaster))]
	internal unsafe class ShadowCasterImpl
		: CppInstance, IShadowCaster
	{
		bool IShadowCaster.GetCastShadows()
		{
			CheckMemberOnlyCall();
			
			var result = NativeShadowCaster.GetCastShadows(Self);
			
			return result;
		}
		
		IEdgeData IShadowCaster.GetEdgeList()
		{
			CheckMemberOnlyCall();
			
			var result = NativeShadowCaster.GetEdgeList(Self);
			
			return HandleConvert.FromHandle<IEdgeData>(result);
		}
		
		bool IShadowCaster.HasEdgeList()
		{
			CheckMemberOnlyCall();
			
			var result = NativeShadowCaster.HasEdgeList(Self);
			
			return result;
		}
		
		BoundingBox IShadowCaster.GetWorldBoundingBox(bool derive)
		{
			CheckMemberOnlyCall();
			
			var result = NativeShadowCaster.GetWorldBoundingBox(Self, derive);
			
			return result;
		}
		
		BoundingBox IShadowCaster.GetLightCapBounds()
		{
			CheckMemberOnlyCall();
			
			var result = NativeShadowCaster.GetLightCapBounds(Self);
			
			return result;
		}
		
		BoundingBox IShadowCaster.GetDarkCapBounds(ILight light, float dirLightExtrusionDist)
		{
			CheckMemberOnlyCall();
			
			var result = NativeShadowCaster.GetDarkCapBounds(Self, HandleConvert.ToHandle(light), dirLightExtrusionDist);
			
			return result;
		}
		
		float IShadowCaster.GetPointExtrusionDistance(ILight light)
		{
			CheckMemberOnlyCall();
			
			var result = NativeShadowCaster.GetPointExtrusionDistance(Self, HandleConvert.ToHandle(light));
			
			return result;
		}
		
	}
	
	[CppImplementation(typeof(IMovableObject))]
	internal unsafe class MovableObjectImpl
		: CppInstance, IMovableObject, IAnimableObject, IShadowCaster
	{
		bool IShadowCaster.GetCastShadows()
		{
			CheckMemberOnlyCall();
			
			var result = NativeMovableObject.GetCastShadows(Self);
			
			return result;
		}
		
		IEdgeData IShadowCaster.GetEdgeList()
		{
			CheckMemberOnlyCall();
			
			var result = NativeMovableObject.GetEdgeList(Self);
			
			return HandleConvert.FromHandle<IEdgeData>(result);
		}
		
		bool IShadowCaster.HasEdgeList()
		{
			CheckMemberOnlyCall();
			
			var result = NativeMovableObject.HasEdgeList(Self);
			
			return result;
		}
		
		BoundingBox IShadowCaster.GetWorldBoundingBox(bool derive)
		{
			CheckMemberOnlyCall();
			
			var result = NativeMovableObject.GetWorldBoundingBox(Self, derive);
			
			return result;
		}
		
		BoundingBox IShadowCaster.GetLightCapBounds()
		{
			CheckMemberOnlyCall();
			
			var result = NativeMovableObject.GetLightCapBounds(Self);
			
			return result;
		}
		
		BoundingBox IShadowCaster.GetDarkCapBounds(ILight light, float dirLightExtrusionDist)
		{
			CheckMemberOnlyCall();
			
			var result = NativeMovableObject.GetDarkCapBounds(Self, HandleConvert.ToHandle(light), dirLightExtrusionDist);
			
			return result;
		}
		
		float IShadowCaster.GetPointExtrusionDistance(ILight light)
		{
			CheckMemberOnlyCall();
			
			var result = NativeMovableObject.GetPointExtrusionDistance(Self, HandleConvert.ToHandle(light));
			
			return result;
		}
		
	}
	
	[CppImplementation(typeof(IFrameListener))]
	internal unsafe class FrameListenerImpl
		: CppInstance, IFrameListener
	{
		void IFrameListener.Destruct()
		{
			NativeFrameListener.Destruct(Self);
			Self = default(Handle);
		}
		
		bool IFrameListener.FrameStarted(FrameEvent frameEvent)
		{
			CheckMemberOnlyCall();
			
			var result = NativeFrameListener.FrameStarted(Self, frameEvent);
			
			return result;
		}
		
		bool IFrameListener.FrameRenderingQueued(FrameEvent frameEvent)
		{
			CheckMemberOnlyCall();
			
			var result = NativeFrameListener.FrameRenderingQueued(Self, frameEvent);
			
			return result;
		}
		
		bool IFrameListener.FrameEnded(FrameEvent frameEvent)
		{
			CheckMemberOnlyCall();
			
			var result = NativeFrameListener.FrameEnded(Self, frameEvent);
			
			return result;
		}
		
	}
	
	[CppImplementation(typeof(IRenderSystemCapabilities))]
	internal unsafe class RenderSystemCapabilitiesImpl
		: CppInstance, IRenderSystemCapabilities
	{
	}
	
	[CppImplementation(typeof(ILog))]
	internal unsafe class LogImpl
		: CppInstance, ILog
	{
		void ILog.AddListener(ICustomLogListener listener)
		{
			CheckMemberOnlyCall();
			
			NativeLog.AddListener(Self, HandleConvert.ToHandle(listener));
		}
		
		void ILog.RemoveListener(ICustomLogListener listener)
		{
			CheckMemberOnlyCall();
			
			NativeLog.RemoveListener(Self, HandleConvert.ToHandle(listener));
		}
		
		String ILog.GetName()
		{
			CheckMemberOnlyCall();
			
			var result = NativeLog.GetName(Self);
			
			return result;
		}
		
		bool ILog.IsDebugOutputEnabled()
		{
			CheckMemberOnlyCall();
			
			var result = NativeLog.IsDebugOutputEnabled(Self);
			
			return result;
		}
		
		bool ILog.IsFileOutputSuppressed()
		{
			CheckMemberOnlyCall();
			
			var result = NativeLog.IsFileOutputSuppressed(Self);
			
			return result;
		}
		
		bool ILog.IsTimeStampEnabled()
		{
			CheckMemberOnlyCall();
			
			var result = NativeLog.IsTimeStampEnabled(Self);
			
			return result;
		}
		
		void ILog.LogMessage(String message, LogMessageLevel level, bool maskDebug)
		{
			CheckMemberOnlyCall();
			
			NativeLog.LogMessage(Self, message, level, maskDebug);
		}
		
	}
	
	[CppImplementation(typeof(IResourceGroupManager))]
	internal unsafe class ResourceGroupManagerImpl
		: CppInstance, IResourceGroupManager, ISingleton<IResourceGroupManager>
	{
		void IResourceGroupManager.AddResourceLocation(String name, String locType)
		{
			CheckMemberOnlyCall();
			
			NativeResourceGroupManager.AddResourceLocation(Self, name, locType);
		}
		
		void IResourceGroupManager.AddResourceLocation(String name, String locType, String resGroup)
		{
			CheckMemberOnlyCall();
			
			NativeResourceGroupManager.AddResourceLocation(Self, name, locType, resGroup);
		}
		
		void IResourceGroupManager.AddResourceLocation(String name, String locType, String resGroup, bool recursive)
		{
			CheckMemberOnlyCall();
			
			NativeResourceGroupManager.AddResourceLocation(Self, name, locType, resGroup, recursive);
		}
		
		void IResourceGroupManager.InitializeAllResourceGroups()
		{
			CheckMemberOnlyCall();
			
			NativeResourceGroupManager.InitializeAllResourceGroups(Self);
		}
		
		IResourceGroupManager ISingleton<IResourceGroupManager>.GetSingleton()
		{
			CheckStaticOnlyCall();
			
			var result = NativeResourceGroupManager.GetSingleton();
			
			return HandleConvert.FromHandle<IResourceGroupManager>(result);
		}
		
	}
	
	[CppImplementation(typeof(IRenderTarget))]
	internal unsafe class RenderTargetImpl
		: CppInstance, IRenderTarget
	{
	}
	
	[CppImplementation(typeof(IFrustum))]
	internal unsafe class FrustumImpl
		: MovableObjectImpl, IFrustum, IAnimableObject, IShadowCaster, IRenderable
	{
	}
	
	[CppImplementation(typeof(IRoot))]
	internal unsafe class RootImpl
		: CppInstance, IRoot, ISingleton<IRoot>
	{
		IRoot IRoot.Construct()
		{
			Self = NativeRoot.Construct();
			return this;
		}
		
		IRoot IRoot.Construct(String pluginFilename)
		{
			Self = NativeRoot.Construct(pluginFilename);
			return this;
		}
		
		IRoot IRoot.Construct(String pluginFilename, String configFilename)
		{
			Self = NativeRoot.Construct(pluginFilename, configFilename);
			return this;
		}
		
		IRoot IRoot.Construct(String pluginFilename, String configFilename, String logFilename)
		{
			Self = NativeRoot.Construct(pluginFilename, configFilename, logFilename);
			return this;
		}
		
		void IRoot.Destruct()
		{
			NativeRoot.Destruct(Self);
			Self = default(Handle);
		}
		
		void IRoot.CheckWindowMessages()
		{
			CheckMemberOnlyCall();
			
			NativeRoot.CheckWindowMessages(Self);
		}
		
		void IRoot.StartRendering()
		{
			CheckMemberOnlyCall();
			
			NativeRoot.StartRendering(Self);
		}
		
		void IRoot.AddFrameListener(IFrameListener listener)
		{
			CheckMemberOnlyCall();
			
			NativeRoot.AddFrameListener(Self, HandleConvert.ToHandle(listener));
		}
		
		void IRoot.RemoveFrameListener(IFrameListener listener)
		{
			CheckMemberOnlyCall();
			
			NativeRoot.RemoveFrameListener(Self, HandleConvert.ToHandle(listener));
		}
		
		void IRoot.SaveConfig()
		{
			CheckMemberOnlyCall();
			
			NativeRoot.SaveConfig(Self);
		}
		
		bool IRoot.RestoreConfig()
		{
			CheckMemberOnlyCall();
			
			var result = NativeRoot.RestoreConfig(Self);
			
			return result;
		}
		
		bool IRoot.ShowConfigDialog()
		{
			CheckMemberOnlyCall();
			
			var result = NativeRoot.ShowConfigDialog(Self);
			
			return result;
		}
		
		void IRoot.AddRenderSystem(IRenderSystem renderSystem)
		{
			CheckMemberOnlyCall();
			
			NativeRoot.AddRenderSystem(Self, HandleConvert.ToHandle(renderSystem));
		}
		
		IntPtr IRoot.GetRenderSystemByName(String name)
		{
			CheckMemberOnlyCall();
			
			var result = NativeRoot.GetRenderSystemByName(Self, name);
			
			return result;
		}
		
		void IRoot.SetRenderSystem(IRenderSystem renderSystem)
		{
			CheckMemberOnlyCall();
			
			NativeRoot.SetRenderSystem(Self, HandleConvert.ToHandle(renderSystem));
		}
		
		IRenderSystem IRoot.GetRenderSystem()
		{
			CheckMemberOnlyCall();
			
			var result = NativeRoot.GetRenderSystem(Self);
			
			return HandleConvert.FromHandle<IRenderSystem>(result);
		}
		
		IRenderWindow IRoot.Initialize(bool autoCreateWindow)
		{
			CheckMemberOnlyCall();
			
			var result = NativeRoot.Initialize(Self, autoCreateWindow);
			
			return HandleConvert.FromHandle<IRenderWindow>(result);
		}
		
		IRenderWindow IRoot.Initialize(bool autoCreateWindow, String windowTitle)
		{
			CheckMemberOnlyCall();
			
			var result = NativeRoot.Initialize(Self, autoCreateWindow, windowTitle);
			
			return HandleConvert.FromHandle<IRenderWindow>(result);
		}
		
		IRenderWindow IRoot.Initialize(bool autoCreateWindow, String windowTitle, String customCapabilities)
		{
			CheckMemberOnlyCall();
			
			var result = NativeRoot.Initialize(Self, autoCreateWindow, windowTitle, customCapabilities);
			
			return HandleConvert.FromHandle<IRenderWindow>(result);
		}
		
		bool IRoot.IsInitialized()
		{
			CheckMemberOnlyCall();
			
			var result = NativeRoot.IsInitialized(Self);
			
			return result;
		}
		
		void IRoot.UseCustomRenderSystemCapabilities(IRenderSystemCapabilities capabilities)
		{
			CheckMemberOnlyCall();
			
			NativeRoot.UseCustomRenderSystemCapabilities(Self, HandleConvert.ToHandle(capabilities));
		}
		
		bool IRoot.GetRemoveRenderQueueStructuresOnClear()
		{
			CheckMemberOnlyCall();
			
			var result = NativeRoot.GetRemoveRenderQueueStructuresOnClear(Self);
			
			return result;
		}
		
		void IRoot.SetRemoveRenderQueueStructuresOnClear(bool value)
		{
			CheckMemberOnlyCall();
			
			NativeRoot.SetRemoveRenderQueueStructuresOnClear(Self, value);
		}
		
		void IRoot.AddSceneManagerFactory(ISceneManagerFactory factory)
		{
			CheckMemberOnlyCall();
			
			NativeRoot.AddSceneManagerFactory(Self, HandleConvert.ToHandle(factory));
		}
		
		void IRoot.RemoveSceneManagerFactory(ISceneManagerFactory factory)
		{
			CheckMemberOnlyCall();
			
			NativeRoot.RemoveSceneManagerFactory(Self, HandleConvert.ToHandle(factory));
		}
		
		ISceneManager IRoot.CreateSceneManager(SceneType sceneType)
		{
			CheckMemberOnlyCall();
			
			var result = NativeRoot.CreateSceneManager(Self, sceneType);
			
			return HandleConvert.FromHandle<ISceneManager>(result);
		}
		
		ISceneManager IRoot.CreateSceneManager(SceneType sceneType, String instanceName)
		{
			CheckMemberOnlyCall();
			
			var result = NativeRoot.CreateSceneManager(Self, sceneType, instanceName);
			
			return HandleConvert.FromHandle<ISceneManager>(result);
		}
		
		IRenderWindow IRoot.CreateRenderWindow(String name, uint width, uint height, bool fullscreen)
		{
			CheckMemberOnlyCall();
			
			var result = NativeRoot.CreateRenderWindow(Self, name, width, height, fullscreen);
			
			return HandleConvert.FromHandle<IRenderWindow>(result);
		}
		
		IRenderWindow IRoot.CreateRenderWindow(String name, uint width, uint height, bool fullscreen, NameValuePairList list)
		{
			CheckMemberOnlyCall();
			
			var result = NativeRoot.CreateRenderWindow(Self, name, width, height, fullscreen, list);
			
			return HandleConvert.FromHandle<IRenderWindow>(result);
		}
		
		void IRoot.LoadPlugin(String plugin)
		{
			CheckMemberOnlyCall();
			
			NativeRoot.LoadPlugin(Self, plugin);
		}
		
		void IRoot.UnloadPlugin(String plugin)
		{
			CheckMemberOnlyCall();
			
			NativeRoot.UnloadPlugin(Self, plugin);
		}
		
		bool IRoot.RenderOneFrame(bool clearWindowMessages)
		{
			CheckMemberOnlyCall();
			
			var result = NativeRoot.RenderOneFrame(Self, clearWindowMessages);
			
			return result;
		}
		
		IRoot ISingleton<IRoot>.GetSingleton()
		{
			CheckStaticOnlyCall();
			
			var result = NativeRoot.GetSingleton();
			
			return HandleConvert.FromHandle<IRoot>(result);
		}
		
	}
	
	[CppImplementation(typeof(INode))]
	internal unsafe class NodeImpl
		: CppInstance, INode
	{
	}
	
	[CppImplementation(typeof(ICustomFrameListener))]
	internal unsafe class CustomFrameListenerImpl
		: FrameListenerImpl, ICustomFrameListener
	{
		ICustomFrameListener ICustomFrameListener.Construct(FrameEventHandler frameStarted, FrameEventHandler frameEnded, FrameEventHandler frameRenderingQueued)
		{
			Self = NativeCustomFrameListener.Construct(frameStarted, frameEnded, frameRenderingQueued);
			return this;
		}
		
	}
	
	[CppImplementation(typeof(IAxisAlignedBox))]
	internal unsafe class AxisAlignedBoxImpl
		: CppInstance, IAxisAlignedBox
	{
	}
	
	[CppImplementation(typeof(ICamera))]
	internal unsafe class CameraImpl
		: CppInstance, ICamera, IAnimableObject, IShadowCaster, IRenderable
	{
		Vector3 ICamera.GetPosition()
		{
			CheckMemberOnlyCall();
			
			var result = NativeCamera.GetPosition(Self);
			
			return result;
		}
		
		void ICamera.SetPosition(Vector3 pos)
		{
			CheckMemberOnlyCall();
			
			NativeCamera.SetPosition(Self, pos);
		}
		
		void ICamera.LookAt(Vector3 direction)
		{
			CheckMemberOnlyCall();
			
			NativeCamera.LookAt(Self, direction);
		}
		
		float ICamera.GetNearClipDistance()
		{
			CheckMemberOnlyCall();
			
			var result = NativeCamera.GetNearClipDistance(Self);
			
			return result;
		}
		
		void ICamera.SetNearClipDistance(float distance)
		{
			CheckMemberOnlyCall();
			
			NativeCamera.SetNearClipDistance(Self, distance);
		}
		
		float ICamera.GetAspectRatio()
		{
			CheckMemberOnlyCall();
			
			var result = NativeCamera.GetAspectRatio(Self);
			
			return result;
		}
		
		void ICamera.SetAspectRatio(float aspectRatio)
		{
			CheckMemberOnlyCall();
			
			NativeCamera.SetAspectRatio(Self, aspectRatio);
		}
		
		float ICamera.GetFarClipDistance()
		{
			CheckMemberOnlyCall();
			
			var result = NativeCamera.GetFarClipDistance(Self);
			
			return result;
		}
		
		void ICamera.SetFarClipDistance(float value)
		{
			CheckMemberOnlyCall();
			
			NativeCamera.SetFarClipDistance(Self, value);
		}
		
		void ICamera.SetAutoAspectRatio(bool value)
		{
			CheckMemberOnlyCall();
			
			NativeCamera.SetAutoAspectRatio(Self, value);
		}
		
		PolygonMode ICamera.GetPolygonMode()
		{
			CheckMemberOnlyCall();
			
			var result = NativeCamera.GetPolygonMode(Self);
			
			return result;
		}
		
		void ICamera.SetPolygonMode(PolygonMode value)
		{
			CheckMemberOnlyCall();
			
			NativeCamera.SetPolygonMode(Self, value);
		}
		
		Vector3 ICamera.GetDirection()
		{
			CheckMemberOnlyCall();
			
			var result = NativeCamera.GetDirection(Self);
			
			return result;
		}
		
		Vector3 ICamera.GetRight()
		{
			CheckMemberOnlyCall();
			
			var result = NativeCamera.GetRight(Self);
			
			return result;
		}
		
		Vector3 ICamera.GetUp()
		{
			CheckMemberOnlyCall();
			
			var result = NativeCamera.GetUp(Self);
			
			return result;
		}
		
		void ICamera.Move(Vector3 distance)
		{
			CheckMemberOnlyCall();
			
			NativeCamera.Move(Self, distance);
		}
		
		void ICamera.Yaw(float valueRadians)
		{
			CheckMemberOnlyCall();
			
			NativeCamera.Yaw(Self, valueRadians);
		}
		
		void ICamera.Pitch(float valueRadians)
		{
			CheckMemberOnlyCall();
			
			NativeCamera.Pitch(Self, valueRadians);
		}
		
		bool IShadowCaster.GetCastShadows()
		{
			CheckMemberOnlyCall();
			
			var result = NativeCamera.GetCastShadows(Self);
			
			return result;
		}
		
		IEdgeData IShadowCaster.GetEdgeList()
		{
			CheckMemberOnlyCall();
			
			var result = NativeCamera.GetEdgeList(Self);
			
			return HandleConvert.FromHandle<IEdgeData>(result);
		}
		
		bool IShadowCaster.HasEdgeList()
		{
			CheckMemberOnlyCall();
			
			var result = NativeCamera.HasEdgeList(Self);
			
			return result;
		}
		
		BoundingBox IShadowCaster.GetWorldBoundingBox(bool derive)
		{
			CheckMemberOnlyCall();
			
			var result = NativeCamera.GetWorldBoundingBox(Self, derive);
			
			return result;
		}
		
		BoundingBox IShadowCaster.GetLightCapBounds()
		{
			CheckMemberOnlyCall();
			
			var result = NativeCamera.GetLightCapBounds(Self);
			
			return result;
		}
		
		BoundingBox IShadowCaster.GetDarkCapBounds(ILight light, float dirLightExtrusionDist)
		{
			CheckMemberOnlyCall();
			
			var result = NativeCamera.GetDarkCapBounds(Self, HandleConvert.ToHandle(light), dirLightExtrusionDist);
			
			return result;
		}
		
		float IShadowCaster.GetPointExtrusionDistance(ILight light)
		{
			CheckMemberOnlyCall();
			
			var result = NativeCamera.GetPointExtrusionDistance(Self, HandleConvert.ToHandle(light));
			
			return result;
		}
		
	}
	
	[CppImplementation(typeof(IScriptLoader))]
	internal unsafe class ScriptLoaderImpl
		: CppInstance, IScriptLoader
	{
	}
	
	[CppImplementation(typeof(IEntity))]
	internal unsafe class EntityImpl
		: MovableObjectImpl, IEntity, IAnimableObject, IShadowCaster
	{
	}
	
	[CppImplementation(typeof(IConfigFile))]
	internal unsafe class ConfigFileImpl
		: CppInstance, IConfigFile
	{
		IConfigFile IConfigFile.Construct()
		{
			Self = NativeConfigFile.Construct();
			return this;
		}
		
		void IConfigFile.Destruct()
		{
			NativeConfigFile.Destruct(Self);
			Self = default(Handle);
		}
		
		void IConfigFile.Load(String filename, String separators, bool trimWhitespace)
		{
			CheckMemberOnlyCall();
			
			NativeConfigFile.Load(Self, filename, separators, trimWhitespace);
		}
		
		void IConfigFile.GetSections(out SettingsBySection* settingsBySection)
		{
			CheckMemberOnlyCall();
			
			NativeConfigFile.GetSections(Self, out settingsBySection);
		}
		
		void IConfigFile.DeleteSettingsBySection(SettingsBySection* settingsBySection)
		{
			CheckStaticOnlyCall();
			
			NativeConfigFile.DeleteSettingsBySection(settingsBySection);
		}
		
	}
	
	[CppImplementation(typeof(IResourceManager))]
	internal unsafe class ResourceManagerImpl
		: ScriptLoaderImpl, IResourceManager
	{
	}
	
	[CppImplementation(typeof(IMaterialManager))]
	internal unsafe class MaterialManagerImpl
		: CppInstance, IMaterialManager, ISingleton<IMaterialManager>
	{
		void IMaterialManager.SetDefaultTextureFiltering(TextureFilterOption option)
		{
			CheckMemberOnlyCall();
			
			NativeMaterialManager.SetDefaultTextureFiltering(Self, option);
		}
		
		void IMaterialManager.SetDefaultAnisotropy(uint max)
		{
			CheckMemberOnlyCall();
			
			NativeMaterialManager.SetDefaultAnisotropy(Self, max);
		}
		
		uint IMaterialManager.GetDefaultAnisotropy()
		{
			CheckMemberOnlyCall();
			
			var result = NativeMaterialManager.GetDefaultAnisotropy(Self);
			
			return result;
		}
		
		IMaterialManager ISingleton<IMaterialManager>.GetSingleton()
		{
			CheckStaticOnlyCall();
			
			var result = NativeMaterialManager.GetSingleton();
			
			return HandleConvert.FromHandle<IMaterialManager>(result);
		}
		
	}
	
	[CppImplementation(typeof(ILogListener))]
	internal unsafe class LogListenerImpl
		: CppInstance, ILogListener
	{
		void ILogListener.Destruct()
		{
			NativeLogListener.Destruct(Self);
			Self = default(Handle);
		}
		
	}
	
	[CppImplementation(typeof(IEdgeData))]
	internal unsafe class EdgeDataImpl
		: CppInstance, IEdgeData
	{
	}
	
	[CppImplementation(typeof(ISceneManagerFactory))]
	internal unsafe class SceneManagerFactoryImpl
		: CppInstance, ISceneManagerFactory
	{
	}
	
	[CppImplementation(typeof(IRenderSystem))]
	internal unsafe class RenderSystemImpl
		: CppInstance, IRenderSystem
	{
	}
	
	[CppImplementation(typeof(ISceneNode))]
	internal unsafe class SceneNodeImpl
		: NodeImpl, ISceneNode
	{
		void ISceneNode.AttachObject(IMovableObject obj)
		{
			CheckMemberOnlyCall();
			
			NativeSceneNode.AttachObject(Self, HandleConvert.ToHandle(obj));
		}
		
		ushort ISceneNode.NumAttachedObjects()
		{
			CheckMemberOnlyCall();
			
			var result = NativeSceneNode.NumAttachedObjects(Self);
			
			return result;
		}
		
		IMovableObject ISceneNode.GetAttachedObject(ushort index)
		{
			CheckMemberOnlyCall();
			
			var result = NativeSceneNode.GetAttachedObject(Self, index);
			
			return HandleConvert.FromHandle<IMovableObject>(result);
		}
		
		IMovableObject ISceneNode.GetAttachedObject(String name)
		{
			CheckMemberOnlyCall();
			
			var result = NativeSceneNode.GetAttachedObject(Self, name);
			
			return HandleConvert.FromHandle<IMovableObject>(result);
		}
		
		IMovableObject ISceneNode.DetachObject(ushort index)
		{
			CheckMemberOnlyCall();
			
			var result = NativeSceneNode.DetachObject(Self, index);
			
			return HandleConvert.FromHandle<IMovableObject>(result);
		}
		
		void ISceneNode.DetachObject(IMovableObject movableObject)
		{
			CheckMemberOnlyCall();
			
			NativeSceneNode.DetachObject(Self, HandleConvert.ToHandle(movableObject));
		}
		
		IMovableObject ISceneNode.DetachObject(String name)
		{
			CheckMemberOnlyCall();
			
			var result = NativeSceneNode.DetachObject(Self, name);
			
			return HandleConvert.FromHandle<IMovableObject>(result);
		}
		
		void ISceneNode.DetachAllObjects()
		{
			CheckMemberOnlyCall();
			
			NativeSceneNode.DetachAllObjects(Self);
		}
		
		ISceneNode ISceneNode.CreateChildSceneNode()
		{
			CheckMemberOnlyCall();
			
			var result = NativeSceneNode.CreateChildSceneNode(Self);
			
			return HandleConvert.FromHandle<ISceneNode>(result);
		}
		
		ISceneNode ISceneNode.CreateChildSceneNode(Vector3 translate)
		{
			CheckMemberOnlyCall();
			
			var result = NativeSceneNode.CreateChildSceneNode(Self, translate);
			
			return HandleConvert.FromHandle<ISceneNode>(result);
		}
		
		ISceneNode ISceneNode.CreateChildSceneNode(Vector3 translate, Quaternion rotate)
		{
			CheckMemberOnlyCall();
			
			var result = NativeSceneNode.CreateChildSceneNode(Self, translate, rotate);
			
			return HandleConvert.FromHandle<ISceneNode>(result);
		}
		
		ISceneNode ISceneNode.CreateChildSceneNode(String name)
		{
			CheckMemberOnlyCall();
			
			var result = NativeSceneNode.CreateChildSceneNode(Self, name);
			
			return HandleConvert.FromHandle<ISceneNode>(result);
		}
		
		ISceneNode ISceneNode.CreateChildSceneNode(String name, Vector3 translate)
		{
			CheckMemberOnlyCall();
			
			var result = NativeSceneNode.CreateChildSceneNode(Self, name, translate);
			
			return HandleConvert.FromHandle<ISceneNode>(result);
		}
		
		ISceneNode ISceneNode.CreateChildSceneNode(String name, Vector3 translate, Quaternion rotate)
		{
			CheckMemberOnlyCall();
			
			var result = NativeSceneNode.CreateChildSceneNode(Self, name, translate, rotate);
			
			return HandleConvert.FromHandle<ISceneNode>(result);
		}
		
	}
	
	[CppImplementation(typeof(IOverlayManager))]
	internal unsafe class OverlayManagerImpl
		: ScriptLoaderImpl, IOverlayManager, ISingleton<IOverlayManager>
	{
		IOverlayElement IOverlayManager.GetOverlayElement(String name, bool isTemplate)
		{
			CheckMemberOnlyCall();
			
			var result = NativeOverlayManager.GetOverlayElement(Self, name, isTemplate);
			
			return HandleConvert.FromHandle<IOverlayElement>(result);
		}
		
		IOverlay IOverlayManager.GetByName(String name)
		{
			CheckMemberOnlyCall();
			
			var result = NativeOverlayManager.GetByName(Self, name);
			
			return HandleConvert.FromHandle<IOverlay>(result);
		}
		
		IOverlayManager ISingleton<IOverlayManager>.GetSingleton()
		{
			CheckStaticOnlyCall();
			
			var result = NativeOverlayManager.GetSingleton();
			
			return HandleConvert.FromHandle<IOverlayManager>(result);
		}
		
	}
	
	[CppImplementation(typeof(ILogManager))]
	internal unsafe class LogManagerImpl
		: CppInstance, ILogManager, ISingleton<ILogManager>
	{
		ILogManager ILogManager.Construct()
		{
			Self = NativeLogManager.Construct();
			return this;
		}
		
		void ILogManager.Destruct()
		{
			NativeLogManager.Destruct(Self);
			Self = default(Handle);
		}
		
		ILog ILogManager.CreateLog(String name, bool defaultLog, bool debuggerOutput, bool suppressFileOutput)
		{
			CheckMemberOnlyCall();
			
			var result = NativeLogManager.CreateLog(Self, name, defaultLog, debuggerOutput, suppressFileOutput);
			
			return HandleConvert.FromHandle<ILog>(result);
		}
		
		ILog ILogManager.GetLog(String name)
		{
			CheckMemberOnlyCall();
			
			var result = NativeLogManager.GetLog(Self, name);
			
			return HandleConvert.FromHandle<ILog>(result);
		}
		
		ILog ILogManager.GetDefaultLog()
		{
			CheckMemberOnlyCall();
			
			var result = NativeLogManager.GetDefaultLog(Self);
			
			return HandleConvert.FromHandle<ILog>(result);
		}
		
		void ILogManager.DestroyLog(String name)
		{
			CheckMemberOnlyCall();
			
			NativeLogManager.DestroyLog(Self, name);
		}
		
		void ILogManager.DestroyLog(ILog log)
		{
			CheckMemberOnlyCall();
			
			NativeLogManager.DestroyLog(Self, HandleConvert.ToHandle(log));
		}
		
		ILog ILogManager.SetDefaultLog(ILog log)
		{
			CheckMemberOnlyCall();
			
			var result = NativeLogManager.SetDefaultLog(Self, HandleConvert.ToHandle(log));
			
			return HandleConvert.FromHandle<ILog>(result);
		}
		
		void ILogManager.LogMessage(String message, LogMessageLevel logLevel, bool maskDebug)
		{
			CheckMemberOnlyCall();
			
			NativeLogManager.LogMessage(Self, message, logLevel, maskDebug);
		}
		
		void ILogManager.SetLogDetail(LoggingLevel level)
		{
			CheckMemberOnlyCall();
			
			NativeLogManager.SetLogDetail(Self, level);
		}
		
		ILogManager ISingleton<ILogManager>.GetSingleton()
		{
			CheckStaticOnlyCall();
			
			var result = NativeLogManager.GetSingleton();
			
			return HandleConvert.FromHandle<ILogManager>(result);
		}
		
	}
	
	[CppImplementation(typeof(ILight))]
	internal unsafe class LightImpl
		: MovableObjectImpl, ILight, IAnimableObject, IShadowCaster
	{
		void ILight.SetPosition(float x, float y, float z)
		{
			CheckMemberOnlyCall();
			
			NativeLight.SetPosition(Self, x, y, z);
		}
		
		void ILight.SetPosition(Vector3 pos)
		{
			CheckMemberOnlyCall();
			
			NativeLight.SetPosition(Self, pos);
		}
		
		Vector3 ILight.GetPosition()
		{
			CheckMemberOnlyCall();
			
			var result = NativeLight.GetPosition(Self);
			
			return result;
		}
		
	}
	
	[CppImplementation(typeof(ICustomLogListener))]
	internal unsafe class CustomLogListenerImpl
		: LogListenerImpl, ICustomLogListener
	{
		ICustomLogListener ICustomLogListener.Construct(LogListenerMessageLoggedHandler messageLoggedHandler)
		{
			Self = NativeCustomLogListener.Construct(messageLoggedHandler);
			return this;
		}
		
	}
	
	[CppImplementation(typeof(IViewport))]
	internal unsafe class ViewportImpl
		: CppInstance, IViewport
	{
		IViewport IViewport.Construct(ICamera camera, IRenderTarget renderTarget, float left, float top, float width, float height, int zOrder)
		{
			Self = NativeViewport.Construct(HandleConvert.ToHandle(camera), HandleConvert.ToHandle(renderTarget), left, top, width, height, zOrder);
			return this;
		}
		
		void IViewport.Destruct()
		{
			NativeViewport.Destruct(Self);
			Self = default(Handle);
		}
		
		void IViewport.SetBackgroundColor(Color color)
		{
			CheckMemberOnlyCall();
			
			NativeViewport.SetBackgroundColor(Self, color);
		}
		
		Color IViewport.GetBackgroundColor()
		{
			CheckMemberOnlyCall();
			
			var result = NativeViewport.GetBackgroundColor(Self);
			
			return result;
		}
		
		void IViewport.Update()
		{
			CheckMemberOnlyCall();
			
			NativeViewport.Update(Self);
		}
		
		void IViewport.Clear()
		{
			CheckMemberOnlyCall();
			
			NativeViewport.Clear(Self);
		}
		
		ICamera IViewport.GetCamera()
		{
			CheckMemberOnlyCall();
			
			var result = NativeViewport.GetCamera(Self);
			
			return HandleConvert.FromHandle<ICamera>(result);
		}
		
		void IViewport.SetCamera(ICamera camera)
		{
			CheckMemberOnlyCall();
			
			NativeViewport.SetCamera(Self, HandleConvert.ToHandle(camera));
		}
		
		float IViewport.GetLeft()
		{
			CheckMemberOnlyCall();
			
			var result = NativeViewport.GetLeft(Self);
			
			return result;
		}
		
		float IViewport.GetTop()
		{
			CheckMemberOnlyCall();
			
			var result = NativeViewport.GetTop(Self);
			
			return result;
		}
		
		float IViewport.GetWidth()
		{
			CheckMemberOnlyCall();
			
			var result = NativeViewport.GetWidth(Self);
			
			return result;
		}
		
		float IViewport.GetHeight()
		{
			CheckMemberOnlyCall();
			
			var result = NativeViewport.GetHeight(Self);
			
			return result;
		}
		
		int IViewport.GetActualLeft()
		{
			CheckMemberOnlyCall();
			
			var result = NativeViewport.GetActualLeft(Self);
			
			return result;
		}
		
		int IViewport.GetActualTop()
		{
			CheckMemberOnlyCall();
			
			var result = NativeViewport.GetActualTop(Self);
			
			return result;
		}
		
		int IViewport.GetActualWidth()
		{
			CheckMemberOnlyCall();
			
			var result = NativeViewport.GetActualWidth(Self);
			
			return result;
		}
		
		int IViewport.GetActualHeight()
		{
			CheckMemberOnlyCall();
			
			var result = NativeViewport.GetActualHeight(Self);
			
			return result;
		}
		
	}
	
	[CppImplementation(typeof(ISceneManager))]
	internal unsafe class SceneManagerImpl
		: CppInstance, ISceneManager
	{
		void ISceneManager.ClearScene()
		{
			CheckMemberOnlyCall();
			
			NativeSceneManager.ClearScene(Self);
		}
		
		void ISceneManager.SetAmbientLight(Color color)
		{
			CheckMemberOnlyCall();
			
			NativeSceneManager.SetAmbientLight(Self, color);
		}
		
		Color ISceneManager.GetAmbientLight()
		{
			CheckMemberOnlyCall();
			
			var result = NativeSceneManager.GetAmbientLight(Self);
			
			return result;
		}
		
		ICamera ISceneManager.CreateCamera(String name)
		{
			CheckMemberOnlyCall();
			
			var result = NativeSceneManager.CreateCamera(Self, name);
			
			return HandleConvert.FromHandle<ICamera>(result);
		}
		
		IEntity ISceneManager.CreateEntity(String meshName)
		{
			CheckMemberOnlyCall();
			
			var result = NativeSceneManager.CreateEntity(Self, meshName);
			
			return HandleConvert.FromHandle<IEntity>(result);
		}
		
		IEntity ISceneManager.CreateEntity(String entityName, String meshName)
		{
			CheckMemberOnlyCall();
			
			var result = NativeSceneManager.CreateEntity(Self, entityName, meshName);
			
			return HandleConvert.FromHandle<IEntity>(result);
		}
		
		ISceneNode ISceneManager.GetRootSceneNode()
		{
			CheckMemberOnlyCall();
			
			var result = NativeSceneManager.GetRootSceneNode(Self);
			
			return HandleConvert.FromHandle<ISceneNode>(result);
		}
		
		ILight ISceneManager.CreateLight()
		{
			CheckMemberOnlyCall();
			
			var result = NativeSceneManager.CreateLight(Self);
			
			return HandleConvert.FromHandle<ILight>(result);
		}
		
		ILight ISceneManager.CreateLight(String name)
		{
			CheckMemberOnlyCall();
			
			var result = NativeSceneManager.CreateLight(Self, name);
			
			return HandleConvert.FromHandle<ILight>(result);
		}
		
	}
	
	[CppImplementation(typeof(IRenderWindow))]
	internal unsafe class RenderWindowImpl
		: RenderTargetImpl, IRenderWindow
	{
		void IRenderWindow.GetCustomAttribute(String name, out IntPtr data)
		{
			CheckMemberOnlyCall();
			
			NativeRenderWindow.GetCustomAttribute(Self, name, out data);
		}
		
		IViewport IRenderWindow.AddViewport(ICamera camera, int zOrder, float left, float top, float width, float height)
		{
			CheckMemberOnlyCall();
			
			var result = NativeRenderWindow.AddViewport(Self, HandleConvert.ToHandle(camera), zOrder, left, top, width, height);
			
			return HandleConvert.FromHandle<IViewport>(result);
		}
		
		bool IRenderWindow.IsClosed()
		{
			CheckMemberOnlyCall();
			
			var result = NativeRenderWindow.IsClosed(Self);
			
			return result;
		}
		
		String IRenderWindow.WriteContentsToTimestampedFile(String filenamePrefix, String filenameSuffix)
		{
			CheckMemberOnlyCall();
			
			var result = NativeRenderWindow.WriteContentsToTimestampedFile(Self, filenamePrefix, filenameSuffix);
			
			return result;
		}
		
		FrameStats IRenderWindow.GetStatistics()
		{
			CheckMemberOnlyCall();
			
			var result = NativeRenderWindow.GetStatistics(Self);
			
			return result;
		}
		
	}
	
	[CppImplementation(typeof(ITextureManager))]
	internal unsafe class TextureManagerImpl
		: CppInstance, ITextureManager, ISingleton<ITextureManager>
	{
		void ITextureManager.SetDefaultNumMipmaps(int num)
		{
			CheckMemberOnlyCall();
			
			NativeTextureManager.SetDefaultNumMipmaps(Self, num);
		}
		
		int ITextureManager.GetDefaultNumMipmaps()
		{
			CheckMemberOnlyCall();
			
			var result = NativeTextureManager.GetDefaultNumMipmaps(Self);
			
			return result;
		}
		
		void ITextureManager.ReloadAll(bool reloadableOnly)
		{
			CheckMemberOnlyCall();
			
			NativeTextureManager.ReloadAll(Self, reloadableOnly);
		}
		
		ITextureManager ISingleton<ITextureManager>.GetSingleton()
		{
			CheckStaticOnlyCall();
			
			var result = NativeTextureManager.GetSingleton();
			
			return HandleConvert.FromHandle<ITextureManager>(result);
		}
		
	}
	
}
