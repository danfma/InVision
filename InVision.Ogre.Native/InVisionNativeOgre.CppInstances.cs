/*
 * GENERATED CODE
 * DO NOT EDIT THIS
 */

using System;
using System.Reflection;
using InVision.GameMath;
using InVision.Native;
using InVision.Ogre;
using InVision.Ogre.Native;

namespace InVision.Ogre.Native
{
	[CppImplementation(typeof(IRenderSystemCapabilities))]
	internal class RenderSystemCapabilitiesImpl
		: CppInstance, IRenderSystemCapabilities
	{
	}
	
	[CppImplementation(typeof(ILog))]
	internal class LogImpl
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
	
	[CppImplementation(typeof(IRoot))]
	internal class RootImpl
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
	
	[CppImplementation(typeof(ICamera))]
	internal class CameraImpl
		: CppInstance, ICamera
	{
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
		
		void ICamera.SetNearClipDistance(float distance)
		{
			CheckMemberOnlyCall();
			
			NativeCamera.SetNearClipDistance(Self, distance);
		}
		
		void ICamera.SetAspectRatio(float aspectRatio)
		{
			CheckMemberOnlyCall();
			
			NativeCamera.SetAspectRatio(Self, aspectRatio);
		}
		
	}
	
	[CppImplementation(typeof(ISceneManagerFactory))]
	internal class SceneManagerFactoryImpl
		: CppInstance, ISceneManagerFactory
	{
	}
	
	[CppImplementation(typeof(IRenderSystem))]
	internal class RenderSystemImpl
		: CppInstance, IRenderSystem
	{
	}
	
	[CppImplementation(typeof(ILogManager))]
	internal class LogManagerImpl
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
	
	[CppImplementation(typeof(ICustomLogListener))]
	internal class CustomLogListenerImpl
		: CppInstance, ICustomLogListener
	{
		ICustomLogListener ICustomLogListener.Construct(LogListenerMessageLoggedHandler messageLoggedHandler)
		{
			Self = NativeCustomLogListener.Construct(messageLoggedHandler);
			return this;
		}
		
		void ICustomLogListener.Destruct()
		{
			NativeCustomLogListener.Destruct(Self);
			Self = default(Handle);
		}
		
	}
	
	[CppImplementation(typeof(IViewport))]
	internal class ViewportImpl
		: CppInstance, IViewport
	{
		void IViewport.SetBackgroundColor(Color color)
		{
			CheckMemberOnlyCall();
			
			NativeViewport.SetBackgroundColor(Self, color);
		}
		
	}
	
	[CppImplementation(typeof(ISceneManager))]
	internal class SceneManagerImpl
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
		
	}
	
	[CppImplementation(typeof(IRenderWindow))]
	internal class RenderWindowImpl
		: CppInstance, IRenderWindow
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
		
	}
	
}
