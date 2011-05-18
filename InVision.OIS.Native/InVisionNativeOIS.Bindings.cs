/*
 * GENERATED CODE
 * DO NOT EDIT THIS
 */

using System;
using System.Runtime.InteropServices;
using InVision.Native.Ext;
using InVision.OIS;
using InVision.OIS.Components;
using InVision.OIS.Native;

namespace InVision.OIS.Native
{
	internal sealed class NativeComponent : InVision.Native.PlatformInvoke
	{
		public const string Library = "InVisionNative_OIS.dll";
		
		static NativeComponent()
		{
			Init();
		}
		
		
		[DllImport(Library, EntryPoint = "new_component_by_descriptor")]
		public static extern Handle Component(ref ComponentDescriptor descriptor);
		
		[DllImport(Library, EntryPoint = "new_component_by_descriptor_ctype")]
		public static extern Handle Component(
			ref ComponentDescriptor descriptor, 
			ComponentType ctype);
		
		[DllImport(Library, EntryPoint = "delete_component")]
		public static extern void Dispose(Handle self);
	}
	
	internal sealed class NativeVector3 : InVision.Native.PlatformInvoke
	{
		public const string Library = "InVisionNative_OIS.dll";
		
		static NativeVector3()
		{
			Init();
		}
		
		
		[DllImport(Library, EntryPoint = "new_vector3_by_descriptor")]
		public static extern Handle Vector3(ref Vector3Descriptor descriptor);
		
		[DllImport(Library, EntryPoint = "new_vector3_by_descriptor_x_y_z")]
		public static extern Handle Vector3(
			ref Vector3Descriptor descriptor, 
			float x, 
			float y, 
			float z);
	}
	
	internal sealed class NativeInterface : InVision.Native.PlatformInvoke
	{
		public const string Library = "InVisionNative_OIS.dll";
		
		static NativeInterface()
		{
			Init();
		}
		
		
		[DllImport(Library, EntryPoint = "delete_interface")]
		public static extern void Dispose(Handle self);
	}
	
	internal sealed class NativeObject : InVision.Native.PlatformInvoke
	{
		public const string Library = "InVisionNative_OIS.dll";
		
		static NativeObject()
		{
			Init();
		}
		
		
		[DllImport(Library, EntryPoint = "object_type")]
		public static extern ComponentType Type(Handle self);
		
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
	
	internal sealed class NativeButton : InVision.Native.PlatformInvoke
	{
		public const string Library = "InVisionNative_OIS.dll";
		
		static NativeButton()
		{
			Init();
		}
		
		
		[DllImport(Library, EntryPoint = "new_button_by_descriptor")]
		public static extern Handle Button(ref ButtonDescriptor descriptor);
		
		[DllImport(Library, EntryPoint = "new_button_by_descriptor_pushed")]
		public static extern Handle Button(
			ref ButtonDescriptor descriptor, 
			bool pushed);
	}
	
	internal sealed class NativeAxis : InVision.Native.PlatformInvoke
	{
		public const string Library = "InVisionNative_OIS.dll";
		
		static NativeAxis()
		{
			Init();
		}
		
		
		[DllImport(Library, EntryPoint = "new_axis_by_descriptor")]
		public static extern Handle Axis(ref AxisDescriptor descriptor);
	}
	
	internal sealed class NativeMouseState : InVision.Native.PlatformInvoke
	{
		public const string Library = "InVisionNative_OIS.dll";
		
		static NativeMouseState()
		{
			Init();
		}
		
		
		[DllImport(Library, EntryPoint = "new_mousestate_by_descriptor")]
		public static extern Handle MouseState(ref MouseStateDescriptor descriptor);
		
		[DllImport(Library, EntryPoint = "delete_mousestate")]
		public static extern void Dispose(Handle self);
	}
	
}
