/*
 * GENERATED CODE
 * DO NOT EDIT THIS
 */

using System;
using System.Runtime.InteropServices;
using InVision.GenOIS;
using InVision.Native.Ext;

namespace InVision.GenOIS
{
	internal static class NativeComponent
	{
		public const string Library = "InVisionNative_OIS.dll";
		
		[DllImport(Library, EntryPoint = "new_component")]
		public static extern Handle Component();
		
		[DllImport(Library, EntryPoint = "new_component_by_componenttype")]
		public static extern Handle Component(ComponentType componentType);
		
		[DllImport(Library, EntryPoint = "delete_component")]
		public static extern void Dispose(Handle self);
		
		[DllImport(Library, EntryPoint = "componentcppinstance_create_descriptor")]
		public static extern ComponentDescriptor CreateDescriptor(Handle self);
	}
	
	internal static class NativeButton
	{
		public const string Library = "InVisionNative_OIS.dll";
		
		[DllImport(Library, EntryPoint = "new_button")]
		public static extern Handle Button();
		
		[DllImport(Library, EntryPoint = "new_button_by_pushed")]
		public static extern Handle Button(bool pushed);
		
		[DllImport(Library, EntryPoint = "buttoncppinstance_create_descriptor")]
		public static extern ButtonDescriptor CreateDescriptor(Handle self);
	}
	
}
