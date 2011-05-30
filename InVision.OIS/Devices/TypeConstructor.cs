using System;
using System.Globalization;
using System.Reflection;
using System.Runtime.CompilerServices;
using InVision.Native;
using InVision.Native.Collections;
using InVision.OIS.Native;
using InVision.Extensions;

namespace InVision.OIS.Devices
{
	internal abstract class TypeConstructor : ITypeConstructor
	{
		private static Dictionary<DeviceType, ITypeConstructor> DeviceTypes;

		/// <summary>
		/// Initializes the <see cref="DeviceObject"/> class.
		/// </summary>
		static TypeConstructor()
		{
			DeviceTypes = new Dictionary<DeviceType, ITypeConstructor> {
				{ DeviceType.Mouse, new TypeConstructor<Mouse, IMouse>() },
				{ DeviceType.Keyboard, new TypeConstructor<Keyboard, IKeyboard>() }
			};
		}

		/// <summary>
		/// Gets the constructor.
		/// </summary>
		/// <param name="deviceType">Type of the device.</param>
		/// <returns></returns>
		public static ITypeConstructor GetConstructor(DeviceType deviceType)
		{
			return DeviceTypes[deviceType];
		}

		/// <summary>
		/// Creates the instance.
		/// </summary>
		/// <param name="device">The device.</param>
		/// <returns></returns>
		public abstract object CreateInstance(IObject device);
	}

	internal class TypeConstructor<TDevice, TNativeDevice> : TypeConstructor where TNativeDevice : IObject
	{
		#region ITypeConstructor Members

		/// <summary>
		/// Creates the instance.
		/// </summary>
		/// <param name="device">The device.</param>
		/// <returns></returns>
		[MethodImpl(MethodImplOptions.Synchronized)]
		public override object CreateInstance(IObject device)
		{
			if (!(device is TNativeDevice)) {
				Handle handle = device.Self;

				device = NativeFactory.Create<TNativeDevice>();
				device.Self = handle;
			}

			return typeof(TDevice).CreateInstance<TDevice>(device);
		}

		#endregion
	}
}