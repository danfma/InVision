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
	internal static class CppComponent
	{
		public const string Library = "InVisionNative_OIS.dll";
		
		[DllImport(Library, EntryPoint = "new_component")]
		public static extern ComponentDescriptor New();
		
		[DllImport(Library, EntryPoint = "new_component_by_componenttype")]
		public static extern ComponentDescriptor New(ComponentType componentType);
		
		[DllImport(Library, EntryPoint = "delete_component")]
		public static extern void Delete(Handle self);
		
		[DllImport(Library, EntryPoint = "component_create_descriptor")]
		public static extern ComponentDescriptor CreateDescriptor(Handle self);
	}
	
	internal static class CppButton
	{
		public const string Library = "InVisionNative_OIS.dll";
		
		[DllImport(Library, EntryPoint = "new_button")]
		public static extern ButtonDescriptor New();
		
		[DllImport(Library, EntryPoint = "new_button_by_pushed")]
		public static extern ButtonDescriptor New(bool pushed);
		
		[DllImport(Library, EntryPoint = "button_create_descriptor")]
		public static extern ButtonDescriptor CreateDescriptor(Handle self);
	}
	
}
