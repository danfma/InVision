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
		
		[DllImport(Library, EntryPoint = "new_componentcppinstance")]
		public static extern Handle Component();
		
		[DllImport(Library, EntryPoint = "new_componentcppinstance_by_ctype")]
		public static extern Handle Component(ComponentType ctype);
		
		[DllImport(Library, EntryPoint = "delete_componentcppinstance")]
		public static extern void Dispose(Handle self);
		
		[DllImport(Library, EntryPoint = "componentcppinstance_create_descriptor")]
		public static extern ComponentDescriptor CreateDescriptor(Handle self);
	}
	
	internal static class NativeButton
	{
		public const string Library = "InVisionNative_OIS.dll";
		
		[DllImport(Library, EntryPoint = "new_buttoncppinstance")]
		public static extern Handle Button();
		
		[DllImport(Library, EntryPoint = "new_buttoncppinstance_by_pushed")]
		public static extern Handle Button(bool pushed);
		
		[DllImport(Library, EntryPoint = "buttoncppinstance_create_descriptor")]
		public static extern ButtonDescriptor CreateDescriptor(Handle self);
	}
	
}
