/*
 * GENERATED CODE
 * DO NOT EDIT THIS
 */

using System;
using System.Reflection;
using InVision.Native;
using InVision.OIS;
using InVision.OIS.Devices;
using InVision.OIS.Native;

namespace InVision.OIS.Native
{
	[CppImplementation(typeof(IMouseState))]
	internal unsafe class MouseStateImpl
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
			Self = default(Handle);
		}
		
	}
	
	[CppImplementation(typeof(IKeyListener))]
	internal unsafe class KeyListenerImpl
		: CppInstance, IKeyListener
	{
		void IKeyListener.Destruct()
		{
			NativeKeyListener.Destruct(Self);
			Self = default(Handle);
		}
		
	}
	
	[CppImplementation(typeof(IObject))]
	internal unsafe class ObjectImpl
		: CppInstance, IObject
	{
		void IObject.Destruct()
		{
			NativeObject.Destruct(Self);
			Self = default(Handle);
		}
		
		DeviceType IObject.Type()
		{
			CheckMemberOnlyCall();
			
			var result = NativeObject.Type(Self);
			
			return result;
		}
		
		String IObject.Vendor()
		{
			CheckMemberOnlyCall();
			
			var result = NativeObject.Vendor(Self);
			
			return result;
		}
		
		bool IObject.Buffered()
		{
			CheckMemberOnlyCall();
			
			var result = NativeObject.Buffered(Self);
			
			return result;
		}
		
		void IObject.SetBuffered(bool value)
		{
			CheckMemberOnlyCall();
			
			NativeObject.SetBuffered(Self, value);
		}
		
		Handle IObject.GetCreator()
		{
			CheckMemberOnlyCall();
			
			var result = NativeObject.GetCreator(Self);
			
			return result;
		}
		
		void IObject.Capture()
		{
			CheckMemberOnlyCall();
			
			NativeObject.Capture(Self);
		}
		
		int IObject.GetID()
		{
			CheckMemberOnlyCall();
			
			var result = NativeObject.GetID(Self);
			
			return result;
		}
		
		Handle IObject.QueryInterface(InterfaceType interfaceType)
		{
			CheckMemberOnlyCall();
			
			var result = NativeObject.QueryInterface(Self, interfaceType);
			
			return result;
		}
		
	}
	
	[CppImplementation(typeof(IKeyboard))]
	internal unsafe class KeyboardImpl
		: ObjectImpl, IKeyboard
	{
		bool IKeyboard.IsKeyDown(KeyCode keyCode)
		{
			CheckMemberOnlyCall();
			
			var result = NativeKeyboard.IsKeyDown(Self, keyCode);
			
			return result;
		}
		
		void IKeyboard.SetEventCallback(ICustomKeyListener keyListener)
		{
			CheckMemberOnlyCall();
			
			NativeKeyboard.SetEventCallback(Self, HandleConvert.ToHandle(keyListener));
		}
		
		ICustomKeyListener IKeyboard.GetEventCallback()
		{
			CheckMemberOnlyCall();
			
			var result = NativeKeyboard.GetEventCallback(Self);
			
			return HandleConvert.FromHandle<ICustomKeyListener>(result);
		}
		
		void IKeyboard.SetTextTranslation(TextTranslationMode translationMode)
		{
			CheckMemberOnlyCall();
			
			NativeKeyboard.SetTextTranslation(Self, translationMode);
		}
		
		TextTranslationMode IKeyboard.GetTextTranslation()
		{
			CheckMemberOnlyCall();
			
			var result = NativeKeyboard.GetTextTranslation(Self);
			
			return result;
		}
		
		String IKeyboard.GetAsString(KeyCode keyCode)
		{
			CheckMemberOnlyCall();
			
			var result = NativeKeyboard.GetAsString(Self, keyCode);
			
			return result;
		}
		
		bool IKeyboard.IsModifierDown(Modifier modifier)
		{
			CheckMemberOnlyCall();
			
			var result = NativeKeyboard.IsModifierDown(Self, modifier);
			
			return result;
		}
		
		void IKeyboard.CopyKeyStates(bool[] keys)
		{
			CheckMemberOnlyCall();
			
			NativeKeyboard.CopyKeyStates(Self, keys);
		}
		
	}
	
	[CppImplementation(typeof(IComponent))]
	internal unsafe class ComponentImpl
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
			Self = default(Handle);
		}
		
	}
	
	[CppImplementation(typeof(IVector3))]
	internal unsafe class Vector3Impl
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
	internal unsafe class InterfaceImpl
		: CppInstance, IInterface
	{
		void IInterface.Destruct()
		{
			NativeInterface.Destruct(Self);
			Self = default(Handle);
		}
		
	}
	
	[CppImplementation(typeof(IEventArg))]
	internal unsafe class EventArgImpl
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
			Self = default(Handle);
		}
		
		IObject IEventArg.GetDevice()
		{
			CheckMemberOnlyCall();
			
			var result = NativeEventArg.GetDevice(Self);
			
			return HandleConvert.FromHandle<IObject>(result);
		}
		
	}
	
	[CppImplementation(typeof(IMouse))]
	internal unsafe class MouseImpl
		: ObjectImpl, IMouse
	{
		void IMouse.SetEventCallback(ICustomMouseListener mouseListener)
		{
			CheckMemberOnlyCall();
			
			NativeMouse.SetEventCallback(Self, HandleConvert.ToHandle(mouseListener));
		}
		
		ICustomMouseListener IMouse.GetEventCallback()
		{
			CheckMemberOnlyCall();
			
			var result = NativeMouse.GetEventCallback(Self);
			
			return HandleConvert.FromHandle<ICustomMouseListener>(result);
		}
		
		IMouseState IMouse.GetMouseState()
		{
			CheckMemberOnlyCall();
			
			var result = NativeMouse.GetMouseState(Self);
			
			return HandleConvert.FromHandle<IMouseState>(result);
		}
		
	}
	
	[CppImplementation(typeof(IMouseListener))]
	internal unsafe class MouseListenerImpl
		: CppInstance, IMouseListener
	{
		void IMouseListener.Destruct()
		{
			NativeMouseListener.Destruct(Self);
			Self = default(Handle);
		}
		
	}
	
	[CppImplementation(typeof(IMouseEvent))]
	internal unsafe class MouseEventImpl
		: EventArgImpl, IMouseEvent
	{
		IMouseEvent IMouseEvent.Construct(ref MouseEventDescriptor descriptor, IObject obj, IMouseState mouseState)
		{
			Self = NativeMouseEvent.Construct(ref descriptor, HandleConvert.ToHandle(obj), HandleConvert.ToHandle(mouseState));
			return this;
		}
		
	}
	
	[CppImplementation(typeof(IInputManager))]
	internal unsafe class InputManagerImpl
		: CppInstance, IInputManager
	{
		uint IInputManager.GetVersionNumber()
		{
			CheckStaticOnlyCall();
			
			var result = NativeInputManager.GetVersionNumber();
			
			return result;
		}
		
		String IInputManager.GetVersionName()
		{
			CheckMemberOnlyCall();
			
			var result = NativeInputManager.GetVersionName(Self);
			
			return result;
		}
		
		IInputManager IInputManager.CreateInputSystem(int winHandle)
		{
			CheckStaticOnlyCall();
			
			var result = NativeInputManager.CreateInputSystem(winHandle);
			
			return HandleConvert.FromHandle<IInputManager>(result);
		}
		
		IInputManager IInputManager.CreateInputSystem(NameValueItem[] parameters, int parametersCount)
		{
			CheckStaticOnlyCall();
			
			var result = NativeInputManager.CreateInputSystem(parameters, parametersCount);
			
			return HandleConvert.FromHandle<IInputManager>(result);
		}
		
		void IInputManager.DestroyInputSystem(IInputManager manager)
		{
			CheckStaticOnlyCall();
			
			NativeInputManager.DestroyInputSystem(HandleConvert.ToHandle(manager));
		}
		
		String IInputManager.InputSystemName()
		{
			CheckMemberOnlyCall();
			
			var result = NativeInputManager.InputSystemName(Self);
			
			return result;
		}
		
		int IInputManager.GetNumberOfDevices(DeviceType iType)
		{
			CheckMemberOnlyCall();
			
			var result = NativeInputManager.GetNumberOfDevices(Self, iType);
			
			return result;
		}
		
		IntPtr IInputManager.ListFreeDevices()
		{
			CheckMemberOnlyCall();
			
			var result = NativeInputManager.ListFreeDevices(Self);
			
			return result;
		}
		
		IObject IInputManager.CreateInputObject(DeviceType iType, bool bufferMode)
		{
			CheckMemberOnlyCall();
			
			var result = NativeInputManager.CreateInputObject(Self, iType, bufferMode);
			
			return HandleConvert.FromHandle<IObject>(result);
		}
		
		IObject IInputManager.CreateInputObject(DeviceType iType, bool bufferMode, String vendor)
		{
			CheckMemberOnlyCall();
			
			var result = NativeInputManager.CreateInputObject(Self, iType, bufferMode, vendor);
			
			return HandleConvert.FromHandle<IObject>(result);
		}
		
		void IInputManager.DestroyInputObject(IObject obj)
		{
			CheckMemberOnlyCall();
			
			NativeInputManager.DestroyInputObject(Self, HandleConvert.ToHandle(obj));
		}
		
		void IInputManager.AddFactoryCreator(IFactoryCreator factory)
		{
			CheckMemberOnlyCall();
			
			NativeInputManager.AddFactoryCreator(Self, HandleConvert.ToHandle(factory));
		}
		
		void IInputManager.RemoveFactoryCreator(IFactoryCreator factory)
		{
			CheckMemberOnlyCall();
			
			NativeInputManager.RemoveFactoryCreator(Self, HandleConvert.ToHandle(factory));
		}
		
		void IInputManager.EnableAddOnFactory(AddOnFactory factory)
		{
			CheckMemberOnlyCall();
			
			NativeInputManager.EnableAddOnFactory(Self, factory);
		}
		
	}
	
	[CppImplementation(typeof(ICustomKeyListener))]
	internal unsafe class CustomKeyListenerImpl
		: KeyListenerImpl, ICustomKeyListener
	{
		ICustomKeyListener ICustomKeyListener.Construct(KeyEventHandler keyPressed, KeyEventHandler keyReleased)
		{
			Self = NativeCustomKeyListener.Construct(keyPressed, keyReleased);
			return this;
		}
		
	}
	
	[CppImplementation(typeof(ICustomMouseListener))]
	internal unsafe class CustomMouseListenerImpl
		: MouseListenerImpl, ICustomMouseListener
	{
		ICustomMouseListener ICustomMouseListener.Construct(MouseMovedHandler mouseMoved, MouseClickHandler mousePressed, MouseClickHandler mouseReleased)
		{
			Self = NativeCustomMouseListener.Construct(mouseMoved, mousePressed, mouseReleased);
			return this;
		}
		
	}
	
	[CppImplementation(typeof(IFactoryCreator))]
	internal unsafe class FactoryCreatorImpl
		: CppInstance, IFactoryCreator
	{
	}
	
	[CppImplementation(typeof(IButton))]
	internal unsafe class ButtonImpl
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
	internal unsafe class AxisImpl
		: ComponentImpl, IAxis
	{
		IAxis IAxis.Construct(ref AxisDescriptor descriptor)
		{
			Self = NativeAxis.Construct(ref descriptor);
			return this;
		}
		
	}
	
	[CppImplementation(typeof(IKeyEvent))]
	internal unsafe class KeyEventImpl
		: EventArgImpl, IKeyEvent
	{
		IKeyEvent IKeyEvent.Construct(ref KeyEventDescriptor descriptor, IObject device, KeyCode keyCode, uint text)
		{
			Self = NativeKeyEvent.Construct(ref descriptor, HandleConvert.ToHandle(device), keyCode, text);
			return this;
		}
		
	}
	
}
