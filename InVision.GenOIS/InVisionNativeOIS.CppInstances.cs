/*
 * GENERATED CODE
 * DO NOT EDIT THIS
 */

using System;
using InVision.GenOIS;
using InVision.Native.Ext;

namespace InVision.GenOIS
{
	[CppImplementation(typeof(IComponent))]
	internal class ComponentImpl
		: CppInstance, IComponent
	{
		IComponent IComponent.Component()
		{
			Self = NativeComponent.Component();
			return this;
		}
		
		IComponent IComponent.Component(ComponentType componentType)
		{
			Self = NativeComponent.Component(componentType);
			return this;
		}
		
		void IComponent.Dispose()
		{
			NativeComponent.Dispose(Self);
		}
		
		ComponentDescriptor IComponent.CreateDescriptor()
		{
			return NativeComponent.CreateDescriptor(Self);
		}
		
	}
	
	[CppImplementation(typeof(IButton))]
	internal class ButtonImpl
		: ComponentImpl, IButton
	{
		IButton IButton.Button()
		{
			Self = NativeButton.Button();
			return this;
		}
		
		IButton IButton.Button(bool pushed)
		{
			Self = NativeButton.Button(pushed);
			return this;
		}
		
		ButtonDescriptor IButton.CreateDescriptor()
		{
			return NativeButton.CreateDescriptor(Self);
		}
		
	}
	
}
