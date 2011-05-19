/*
 * GENERATED CODE
 * DO NOT EDIT THIS
 */

using System;
using System.Reflection;
using InVision.Native.Ext;
using InVision.OIS;
using InVision.OIS.Components;
using InVision.OIS.Native;

namespace InVision.OIS.Native
{
	[CppImplementation(typeof(IMouseState))]
	internal class MouseStateImpl
		: CppInstance, IMouseState
	{
		IMouseState IMouseState.Construct(ref MouseStateDescriptor descriptor)
		{
			Self = NativeMouseState.Construct(ref descriptor);
			return this;
		}
		
		void IMouseState.Destruct()
		{
			NativeMouseState.Destruct(Self);
		}
		
	}
	
	[CppImplementation(typeof(IComponent))]
	internal class ComponentImpl
		: CppInstance, IComponent
	{
		IComponent IComponent.Construct(ref ComponentDescriptor descriptor)
		{
			Self = NativeComponent.Construct(ref descriptor);
			return this;
		}
		
		IComponent IComponent.Construct(ref ComponentDescriptor descriptor, ComponentType ctype)
		{
			Self = NativeComponent.Construct(ref descriptor, ctype);
			return this;
		}
		
		void IComponent.Destruct()
		{
			NativeComponent.Destruct(Self);
		}
		
	}
	
	[CppImplementation(typeof(IVector3))]
	internal class Vector3Impl
		: ComponentImpl, IVector3
	{
		IVector3 IVector3.Construct(ref Vector3Descriptor descriptor)
		{
			Self = NativeVector3.Construct(ref descriptor);
			return this;
		}
		
		IVector3 IVector3.Construct(ref Vector3Descriptor descriptor, float x, float y, float z)
		{
			Self = NativeVector3.Construct(ref descriptor, x, y, z);
			return this;
		}
		
	}
	
	[CppImplementation(typeof(IInterface))]
	internal class InterfaceImpl
		: CppInstance, IInterface
	{
		void IInterface.Destruct()
		{
			NativeInterface.Destruct(Self);
		}
		
	}
	
	[CppImplementation(typeof(IObject))]
	internal class ObjectImpl
		: CppInstance, IObject
	{
		void IObject.Destruct()
		{
			NativeObject.Destruct(Self);
		}
		
		ComponentType IObject.Type()
		{
			var result = NativeObject.Type(Self);
			
			return result;
		}
		
		String IObject.Vendor()
		{
			var result = NativeObject.Vendor(Self);
			
			return result;
		}
		
		bool IObject.Buffered()
		{
			var result = NativeObject.Buffered(Self);
			
			return result;
		}
		
		void IObject.SetBuffered(bool value)
		{
			NativeObject.SetBuffered(Self, value);
		}
		
		Handle IObject.GetCreator()
		{
			var result = NativeObject.GetCreator(Self);
			
			return result;
		}
		
		void IObject.Capture()
		{
			NativeObject.Capture(Self);
		}
		
		int IObject.GetID()
		{
			var result = NativeObject.GetID(Self);
			
			return result;
		}
		
		Handle IObject.QueryInterface(InterfaceType interfaceType)
		{
			var result = NativeObject.QueryInterface(Self, interfaceType);
			
			return result;
		}
		
	}
	
	[CppImplementation(typeof(IButton))]
	internal class ButtonImpl
		: ComponentImpl, IButton
	{
		IButton IButton.Construct(ref ButtonDescriptor descriptor)
		{
			Self = NativeButton.Construct(ref descriptor);
			return this;
		}
		
		IButton IButton.Construct(ref ButtonDescriptor descriptor, bool pushed)
		{
			Self = NativeButton.Construct(ref descriptor, pushed);
			return this;
		}
		
	}
	
	[CppImplementation(typeof(IAxis))]
	internal class AxisImpl
		: ComponentImpl, IAxis
	{
		IAxis IAxis.Construct(ref AxisDescriptor descriptor)
		{
			Self = NativeAxis.Construct(ref descriptor);
			return this;
		}
		
	}
	
	[CppImplementation(typeof(IKeyboard))]
	internal class KeyboardImpl
		: ObjectImpl, IKeyboard
	{
		bool IKeyboard.IsKeyDown(KeyCode keyCode)
		{
			var result = NativeKeyboard.IsKeyDown(Self, keyCode);
			
			return result;
		}
		
		void IKeyboard.SetEventCallback(ICustomKeyListener keyListener)
		{
			NativeKeyboard.SetEventCallback(Self, HandleConvert.ToHandle(keyListener));
		}
		
		ICustomKeyListener IKeyboard.GetEventCallback()
		{
			var result = NativeKeyboard.GetEventCallback(Self);
			
			return HandleConvert.FromHandle<ICustomKeyListener>(result);
		}
		
		void IKeyboard.SetTextTranslation(TextTranslationMode translationMode)
		{
			NativeKeyboard.SetTextTranslation(Self, translationMode);
		}
		
		TextTranslationMode IKeyboard.GetTextTranslation()
		{
			var result = NativeKeyboard.GetTextTranslation(Self);
			
			return result;
		}
		
		String IKeyboard.GetAsString(KeyCode keyCode)
		{
			var result = NativeKeyboard.GetAsString(Self, keyCode);
			
			return result;
		}
		
		bool IKeyboard.IsModifierDown(Modifier modifier)
		{
			var result = NativeKeyboard.IsModifierDown(Self, modifier);
			
			return result;
		}
		
		void IKeyboard.CopyKeyStates(bool[] keys)
		{
			NativeKeyboard.CopyKeyStates(Self, keys);
		}
		
	}
	
	[CppImplementation(typeof(ICustomMouseListener))]
	internal class CustomMouseListenerImpl
		: CppInstance, ICustomMouseListener
	{
		ICustomMouseListener ICustomMouseListener.Construct(MouseMovedHandler mouseMoved, MouseClickHandler mousePressed, MouseClickHandler mouseReleased)
		{
			Self = NativeCustomMouseListener.Construct(mouseMoved, mousePressed, mouseReleased);
			return this;
		}
		
		void ICustomMouseListener.Destruct()
		{
			NativeCustomMouseListener.Destruct(Self);
		}
		
	}
	
	[CppImplementation(typeof(IMouseEvent))]
	internal class MouseEventImpl
		: CppInstance, IMouseEvent
	{
		IMouseEvent IMouseEvent.Construct(ref MouseEventDescriptor descriptor, IObject obj, IMouseState mouseState)
		{
			Self = NativeMouseEvent.Construct(ref descriptor, HandleConvert.ToHandle(obj), HandleConvert.ToHandle(mouseState));
			return this;
		}
		
		void IMouseEvent.Destruct()
		{
			NativeMouseEvent.Destruct(Self);
		}
		
	}
	
	[CppImplementation(typeof(IMouse))]
	internal class MouseImpl
		: ObjectImpl, IMouse
	{
		void IMouse.SetEventCallback(ICustomMouseListener mouseListener)
		{
			NativeMouse.SetEventCallback(Self, HandleConvert.ToHandle(mouseListener));
		}
		
		ICustomMouseListener IMouse.GetEventCallback()
		{
			var result = NativeMouse.GetEventCallback(Self);
			
			return HandleConvert.FromHandle<ICustomMouseListener>(result);
		}
		
		IMouseState IMouse.GetMouseState()
		{
			var result = NativeMouse.GetMouseState(Self);
			
			return HandleConvert.FromHandle<IMouseState>(result);
		}
		
	}
	
	[CppImplementation(typeof(IEventArg))]
	internal class EventArgImpl
		: CppInstance, IEventArg
	{
		IEventArg IEventArg.Construct(IObject device)
		{
			Self = NativeEventArg.Construct(HandleConvert.ToHandle(device));
			return this;
		}
		
		void IEventArg.Destruct()
		{
			NativeEventArg.Destruct(Self);
		}
		
		Handle IEventArg.GetDevice()
		{
			var result = NativeEventArg.GetDevice(Self);
			
			return result;
		}
		
	}
	
	[CppImplementation(typeof(IKeyEvent))]
	internal class KeyEventImpl
		: EventArgImpl, IKeyEvent
	{
		IKeyEvent IKeyEvent.Construct(ref KeyEventDescriptor descriptor, IObject device, KeyCode keyCode, uint text)
		{
			Self = NativeKeyEvent.Construct(ref descriptor, HandleConvert.ToHandle(device), keyCode, text);
			return this;
		}
		
	}
	
	[CppImplementation(typeof(ICustomKeyListener))]
	internal class CustomKeyListenerImpl
		: CppInstance, ICustomKeyListener
	{
		ICustomKeyListener ICustomKeyListener.Construct(KeyEventHandler keyPressed, KeyEventHandler keyReleased)
		{
			Self = NativeCustomKeyListener.Construct(keyPressed, keyReleased);
			return this;
		}
		
		void ICustomKeyListener.Destruct()
		{
			NativeCustomKeyListener.Destruct(Self);
		}
		
	}
	
	[CppImplementation(typeof(IInputManager))]
	internal class InputManagerImpl
		: CppInstance, IInputManager
	{
		uint IInputManager.GetVersionNumber()
		{
			var result = NativeInputManager.GetVersionNumber();
			
			return result;
		}
		
		String IInputManager.GetVersionName()
		{
			var result = NativeInputManager.GetVersionName(Self);
			
			return result;
		}
		
		Handle IInputManager.CreateInputSystem(int winHandle)
		{
			var result = NativeInputManager.CreateInputSystem(winHandle);
			
			return result;
		}
		
		Handle IInputManager.CreateInputSystem(NameValueItem[] parameters, int parametersCount)
		{
			var result = NativeInputManager.CreateInputSystem(parameters, parametersCount);
			
			return result;
		}
		
		void IInputManager.DestroyInputSystem(Handle manager)
		{
			NativeInputManager.DestroyInputSystem(manager);
		}
		
		String IInputManager.InputSystemName()
		{
			var result = NativeInputManager.InputSystemName(Self);
			
			return result;
		}
		
		int IInputManager.GetNumberOfDevices(DeviceType iType)
		{
			var result = NativeInputManager.GetNumberOfDevices(Self, iType);
			
			return result;
		}
		
		IntPtr IInputManager.ListFreeDevices()
		{
			var result = NativeInputManager.ListFreeDevices(Self);
			
			return result;
		}
		
		IObject IInputManager.CreateInputObject(DeviceType iType, bool bufferMode)
		{
			var result = NativeInputManager.CreateInputObject(Self, iType, bufferMode);
			
			return HandleConvert.FromHandle<IObject>(result);
		}
		
		IObject IInputManager.CreateInputObject(DeviceType iType, bool bufferMode, String vendor)
		{
			var result = NativeInputManager.CreateInputObject(Self, iType, bufferMode, vendor);
			
			return HandleConvert.FromHandle<IObject>(result);
		}
		
		void IInputManager.DestroyInputObject(IObject obj)
		{
			NativeInputManager.DestroyInputObject(Self, HandleConvert.ToHandle(obj));
		}
		
		void IInputManager.AddFactoryCreator(IFactoryCreator factory)
		{
			NativeInputManager.AddFactoryCreator(Self, HandleConvert.ToHandle(factory));
		}
		
		void IInputManager.RemoveFactoryCreator(IFactoryCreator factory)
		{
			NativeInputManager.RemoveFactoryCreator(Self, HandleConvert.ToHandle(factory));
		}
		
		void IInputManager.EnableAddOnFactory(AddOnFactory factory)
		{
			NativeInputManager.EnableAddOnFactory(Self, factory);
		}
		
	}
	
	[CppImplementation(typeof(IFactoryCreator))]
	internal class FactoryCreatorImpl
		: CppInstance, IFactoryCreator
	{
	}
	
}
