/*
 * GENERATED CODE
 * DO NOT EDIT THIS
 */

using System;
using System.Runtime.InteropServices;
using InVision.Native;
using InVision.OIS;
using InVision.OIS.Devices;
using InVision.OIS.Native;

namespace InVision.OIS.Native
{
	internal sealed class NativeMouseState : InVision.Native.PlatformInvoke
	{
		public const string Library = "InVisionNative.dll";
		
		static NativeMouseState()
		{
			Init();
		}
		
		
		[DllImport(Library, EntryPoint = "new_mousestate")]
		public static extern Handle Construct(ref MouseStateDescriptor descriptor);
		
		[DllImport(Library, EntryPoint = "delete_mousestate")]
		public static extern void Destruct(Handle self);
	}
	
	internal sealed class NativeObject : InVision.Native.PlatformInvoke
	{
		public const string Library = "InVisionNative.dll";
		
		static NativeObject()
		{
			Init();
		}
		
		
		[DllImport(Library, EntryPoint = "delete_object")]
		public static extern void Destruct(Handle self);
		
		[DllImport(Library, EntryPoint = "object_type")]
		public static extern DeviceType Type(Handle self);
		
		[DllImport(Library, EntryPoint = "object_vendor")]
		[return: MarshalAs(UnmanagedType.LPStr)]
		public static extern String Vendor(Handle self);
		
		[DllImport(Library, EntryPoint = "object_buffered")]
		[return: MarshalAs(UnmanagedType.I1)]
		public static extern bool Buffered(Handle self);
		
		[DllImport(Library, EntryPoint = "object_set_buffered")]
		public static extern void SetBuffered(
			Handle self, 
			[MarshalAs(UnmanagedType.I1)] bool value);
		
		[DllImport(Library, EntryPoint = "object_get_creator")]
		public static extern Handle GetCreator(Handle self);
		
		[DllImport(Library, EntryPoint = "object_capture")]
		public static extern void Capture(Handle self);
		
		[DllImport(Library, EntryPoint = "object_get_id")]
		public static extern int GetID(Handle self);
		
		[DllImport(Library, EntryPoint = "object_query_interface")]
		public static extern Handle QueryInterface(
			Handle self, 
			InterfaceType interfaceType);
	}
	
	internal sealed class NativeKeyboard : InVision.Native.PlatformInvoke
	{
		public const string Library = "InVisionNative.dll";
		
		static NativeKeyboard()
		{
			Init();
		}
		
		
		[DllImport(Library, EntryPoint = "keyboard_is_key_down")]
		public static extern bool IsKeyDown(
			Handle self, 
			KeyCode keyCode);
		
		[DllImport(Library, EntryPoint = "keyboard_set_event_callback")]
		public static extern void SetEventCallback(
			Handle self, 
			Handle keyListener);
		
		[DllImport(Library, EntryPoint = "keyboard_get_event_callback")]
		public static extern Handle GetEventCallback(Handle self);
		
		[DllImport(Library, EntryPoint = "keyboard_set_text_translation")]
		public static extern void SetTextTranslation(
			Handle self, 
			TextTranslationMode translationMode);
		
		[DllImport(Library, EntryPoint = "keyboard_get_text_translation")]
		public static extern TextTranslationMode GetTextTranslation(Handle self);
		
		[DllImport(Library, EntryPoint = "keyboard_get_as_string")]
		[return: MarshalAs(UnmanagedType.LPStr)]
		public static extern String GetAsString(
			Handle self, 
			KeyCode keyCode);
		
		[DllImport(Library, EntryPoint = "keyboard_is_modifier_down")]
		public static extern bool IsModifierDown(
			Handle self, 
			Modifier modifier);
		
		[DllImport(Library, EntryPoint = "keyboard_copy_key_states")]
		public static extern void CopyKeyStates(
			Handle self, 
			[MarshalAs(UnmanagedType.LPArray, SizeConst = 256, ArraySubType = UnmanagedType.I1)] bool[] keys);
	}
	
	internal sealed class NativeComponent : InVision.Native.PlatformInvoke
	{
		public const string Library = "InVisionNative.dll";
		
		static NativeComponent()
		{
			Init();
		}
		
		
		[DllImport(Library, EntryPoint = "new_component_m1")]
		public static extern Handle Construct(ref ComponentDescriptor descriptor);
		
		[DllImport(Library, EntryPoint = "new_component_m2")]
		public static extern Handle Construct(
			ref ComponentDescriptor descriptor, 
			ComponentType ctype);
		
		[DllImport(Library, EntryPoint = "delete_component")]
		public static extern void Destruct(Handle self);
	}
	
	internal sealed class NativeVector3 : InVision.Native.PlatformInvoke
	{
		public const string Library = "InVisionNative.dll";
		
		static NativeVector3()
		{
			Init();
		}
		
		
		[DllImport(Library, EntryPoint = "new_vector3_m1")]
		public static extern Handle Construct(ref Vector3Descriptor descriptor);
		
		[DllImport(Library, EntryPoint = "new_vector3_m2")]
		public static extern Handle Construct(
			ref Vector3Descriptor descriptor, 
			float x, 
			float y, 
			float z);
	}
	
	internal sealed class NativeInterface : InVision.Native.PlatformInvoke
	{
		public const string Library = "InVisionNative.dll";
		
		static NativeInterface()
		{
			Init();
		}
		
		
		[DllImport(Library, EntryPoint = "delete_interface")]
		public static extern void Destruct(Handle self);
	}
	
	internal sealed class NativeEventArg : InVision.Native.PlatformInvoke
	{
		public const string Library = "InVisionNative.dll";
		
		static NativeEventArg()
		{
			Init();
		}
		
		
		[DllImport(Library, EntryPoint = "new_eventarg")]
		public static extern Handle Construct(Handle device);
		
		[DllImport(Library, EntryPoint = "delete_eventarg")]
		public static extern void Destruct(Handle self);
		
		[DllImport(Library, EntryPoint = "eventarg_get_device")]
		public static extern Handle GetDevice(Handle self);
	}
	
	internal sealed class NativeMouse : InVision.Native.PlatformInvoke
	{
		public const string Library = "InVisionNative.dll";
		
		static NativeMouse()
		{
			Init();
		}
		
		
		[DllImport(Library, EntryPoint = "mouse_set_event_callback")]
		public static extern void SetEventCallback(
			Handle self, 
			Handle mouseListener);
		
		[DllImport(Library, EntryPoint = "mouse_get_event_callback")]
		public static extern Handle GetEventCallback(Handle self);
		
		[DllImport(Library, EntryPoint = "mouse_get_mouse_state")]
		public static extern Handle GetMouseState(Handle self);
	}
	
	internal sealed class NativeMouseEvent : InVision.Native.PlatformInvoke
	{
		public const string Library = "InVisionNative.dll";
		
		static NativeMouseEvent()
		{
			Init();
		}
		
		
		[DllImport(Library, EntryPoint = "new_mouseevent")]
		public static extern Handle Construct(
			ref MouseEventDescriptor descriptor, 
			Handle obj, 
			Handle mouseState);
	}
	
	internal sealed class NativeInputManager : InVision.Native.PlatformInvoke
	{
		public const string Library = "InVisionNative.dll";
		
		static NativeInputManager()
		{
			Init();
		}
		
		
		[DllImport(Library, EntryPoint = "inputmanager_get_version_number")]
		public static extern uint GetVersionNumber();
		
		[DllImport(Library, EntryPoint = "inputmanager_get_version_name")]
		[return: MarshalAs(UnmanagedType.LPStr)]
		public static extern String GetVersionName(Handle self);
		
		[DllImport(Library, EntryPoint = "inputmanager_create_input_system1_m1")]
		public static extern Handle CreateInputSystem(int winHandle);
		
		[DllImport(Library, EntryPoint = "inputmanager_create_input_system2_m2")]
		public static extern Handle CreateInputSystem(
			NameValueItem[] parameters, 
			int parametersCount);
		
		[DllImport(Library, EntryPoint = "inputmanager_destroy_input_system")]
		public static extern void DestroyInputSystem(Handle manager);
		
		[DllImport(Library, EntryPoint = "inputmanager_input_system_name")]
		[return: MarshalAs(UnmanagedType.LPStr)]
		public static extern String InputSystemName(Handle self);
		
		[DllImport(Library, EntryPoint = "inputmanager_get_number_of_devices")]
		public static extern int GetNumberOfDevices(
			Handle self, 
			DeviceType iType);
		
		[DllImport(Library, EntryPoint = "inputmanager_list_free_devices")]
		public static extern IntPtr ListFreeDevices(Handle self);
		
		[DllImport(Library, EntryPoint = "inputmanager_create_input_object1_m1")]
		public static extern Handle CreateInputObject(
			Handle self, 
			DeviceType iType, 
			[MarshalAs(UnmanagedType.I1)] bool bufferMode);
		
		[DllImport(Library, EntryPoint = "inputmanager_create_input_object2_m2")]
		public static extern Handle CreateInputObject(
			Handle self, 
			DeviceType iType, 
			[MarshalAs(UnmanagedType.I1)] bool bufferMode, 
			[MarshalAs(UnmanagedType.LPStr)] String vendor);
		
		[DllImport(Library, EntryPoint = "inputmanager_destroy_input_object")]
		public static extern void DestroyInputObject(
			Handle self, 
			Handle obj);
		
		[DllImport(Library, EntryPoint = "inputmanager_add_factory_creator")]
		public static extern void AddFactoryCreator(
			Handle self, 
			Handle factory);
		
		[DllImport(Library, EntryPoint = "inputmanager_remove_factory_creator")]
		public static extern void RemoveFactoryCreator(
			Handle self, 
			Handle factory);
		
		[DllImport(Library, EntryPoint = "inputmanager_enable_add_on_factory")]
		public static extern void EnableAddOnFactory(
			Handle self, 
			AddOnFactory factory);
	}
	
	internal sealed class NativeFactoryCreator : InVision.Native.PlatformInvoke
	{
		public const string Library = "InVisionNative.dll";
		
		static NativeFactoryCreator()
		{
			Init();
		}
		
	}
	
	internal sealed class NativeCustomKeyListener : InVision.Native.PlatformInvoke
	{
		public const string Library = "InVisionNative.dll";
		
		static NativeCustomKeyListener()
		{
			Init();
		}
		
		
		[DllImport(Library, EntryPoint = "new_customkeylistener")]
		public static extern Handle Construct(
			KeyEventHandler keyPressed, 
			KeyEventHandler keyReleased);
		
		[DllImport(Library, EntryPoint = "delete_customkeylistener")]
		public static extern void Destruct(Handle self);
	}
	
	internal sealed class NativeCustomMouseListener : InVision.Native.PlatformInvoke
	{
		public const string Library = "InVisionNative.dll";
		
		static NativeCustomMouseListener()
		{
			Init();
		}
		
		
		[DllImport(Library, EntryPoint = "new_custommouselistener")]
		public static extern Handle Construct(
			MouseMovedHandler mouseMoved, 
			MouseClickHandler mousePressed, 
			MouseClickHandler mouseReleased);
		
		[DllImport(Library, EntryPoint = "delete_custommouselistener")]
		public static extern void Destruct(Handle self);
	}
	
	internal sealed class NativeButton : InVision.Native.PlatformInvoke
	{
		public const string Library = "InVisionNative.dll";
		
		static NativeButton()
		{
			Init();
		}
		
		
		[DllImport(Library, EntryPoint = "new_button_m1")]
		public static extern Handle Construct(ref ButtonDescriptor descriptor);
		
		[DllImport(Library, EntryPoint = "new_button_m2")]
		public static extern Handle Construct(
			ref ButtonDescriptor descriptor, 
			bool pushed);
	}
	
	internal sealed class NativeAxis : InVision.Native.PlatformInvoke
	{
		public const string Library = "InVisionNative.dll";
		
		static NativeAxis()
		{
			Init();
		}
		
		
		[DllImport(Library, EntryPoint = "new_axis")]
		public static extern Handle Construct(ref AxisDescriptor descriptor);
	}
	
	internal sealed class NativeKeyEvent : InVision.Native.PlatformInvoke
	{
		public const string Library = "InVisionNative.dll";
		
		static NativeKeyEvent()
		{
			Init();
		}
		
		
		[DllImport(Library, EntryPoint = "new_keyevent")]
		public static extern Handle Construct(
			ref KeyEventDescriptor descriptor, 
			Handle device, 
			KeyCode keyCode, 
			uint text);
	}
	
}
