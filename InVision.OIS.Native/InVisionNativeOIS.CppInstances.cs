/*
 * GENERATED CODE
 * DO NOT EDIT THIS
 */

using System;
using InVision.Native.Ext;
using InVision.OIS;
using InVision.OIS.Components;
using InVision.OIS.Native;

namespace InVision.OIS.Native
{
	[CppImplementation(typeof(IComponent))]
	internal class ComponentImpl
		: CppInstance, IComponent
	{
		IComponent IComponent.Component(ref ComponentDescriptor descriptor)
		{
			Self = NativeComponent.Component(ref descriptor);
			return this;
		}
		
		IComponent IComponent.Component(ref ComponentDescriptor descriptor, ComponentType ctype)
		{
			Self = NativeComponent.Component(ref descriptor, ctype);
			return this;
		}
		
		void IComponent.Dispose()
		{
			NativeComponent.Dispose(Self);
		}
		
	}
	
	[CppImplementation(typeof(IVector3))]
	internal class Vector3Impl
		: ComponentImpl, IVector3
	{
		IVector3 IVector3.Vector3(ref Vector3Descriptor descriptor)
		{
			Self = NativeVector3.Vector3(ref descriptor);
			return this;
		}
		
		IVector3 IVector3.Vector3(ref Vector3Descriptor descriptor, float x, float y, float z)
		{
			Self = NativeVector3.Vector3(ref descriptor, x, y, z);
			return this;
		}
		
	}
	
	[CppImplementation(typeof(IInterface))]
	internal class InterfaceImpl
		: CppInstance, IInterface
	{
		void IInterface.Dispose()
		{
			NativeInterface.Dispose(Self);
		}
		
	}
	
	[CppImplementation(typeof(IObject))]
	internal class ObjectImpl
		: InterfaceImpl, IObject
	{
		ComponentType IObject.Type()
		{
			return NativeObject.Type(Self);
		}
		
		String IObject.Vendor()
		{
			return NativeObject.Vendor(Self);
		}
		
		bool IObject.Buffered()
		{
			return NativeObject.Buffered(Self);
		}
		
		void IObject.SetBuffered(bool value)
		{
			NativeObject.SetBuffered(Self, value);
		}
		
		Handle IObject.GetCreator()
		{
			return NativeObject.GetCreator(Self);
		}
		
		void IObject.Capture()
		{
			NativeObject.Capture(Self);
		}
		
		int IObject.GetID()
		{
			return NativeObject.GetID(Self);
		}
		
		Handle IObject.QueryInterface(InterfaceType interfaceType)
		{
			return NativeObject.QueryInterface(Self, interfaceType);
		}
		
	}
	
	[CppImplementation(typeof(IButton))]
	internal class ButtonImpl
		: ComponentImpl, IButton
	{
		IButton IButton.Button(ref ButtonDescriptor descriptor)
		{
			Self = NativeButton.Button(ref descriptor);
			return this;
		}
		
		IButton IButton.Button(ref ButtonDescriptor descriptor, bool pushed)
		{
			Self = NativeButton.Button(ref descriptor, pushed);
			return this;
		}
		
	}
	
	[CppImplementation(typeof(IAxis))]
	internal class AxisImpl
		: ComponentImpl, IAxis
	{
		IAxis IAxis.Axis(ref AxisDescriptor descriptor)
		{
			Self = NativeAxis.Axis(ref descriptor);
			return this;
		}
		
	}
	
	[CppImplementation(typeof(IMouseState))]
	internal class MouseStateImpl
		: CppInstance, IMouseState
	{
		IMouseState IMouseState.MouseState(ref MouseStateDescriptor descriptor)
		{
			Self = NativeMouseState.MouseState(ref descriptor);
			return this;
		}
		
		void IMouseState.Dispose()
		{
			NativeMouseState.Dispose(Self);
		}
		
	}
	
}
