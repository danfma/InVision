using System;
using InVision.Native;
using InVision.OIS.Native;

namespace InVision.OIS
{
	public class Component : Handle, IComponent
	{
		private ComponentExtended nativeRef;

		/// <summary>
		/// Initializes a new instance of the <see cref="Component"/> class.
		/// </summary>
		/// <param name="componentType">Type of the component.</param>
		public Component(ComponentType componentType)
			: this(NativeComponent.New(componentType), true)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Component"/> class.
		/// </summary>
		/// <param name="extended">The extended.</param>
		/// <param name="ownsHandle">if set to <c>true</c> [owns handle].</param>
		internal Component(ComponentExtended extended, bool ownsHandle = false)
			: base(extended.Self, ownsHandle)
		{
			nativeRef = extended;
		}

		#region IComponent Members

		/// <summary>
		/// Gets the type of the component.
		/// </summary>
		/// <value>The type of the component.</value>
		public ComponentType ComponentType
		{
			get { return nativeRef.ComponentType; }
		}

		#endregion

		/// <summary>
		/// Releases the valid handle.
		/// </summary>
		protected override void ReleaseValidHandle()
		{
			NativeComponent.Delete(handle);
			nativeRef = default(ComponentExtended);
		}
	}

	public class ComponentProxy : Handle
	{
		private ComponentProxyInfo proxyInfo;

		/// <summary>
		/// Initializes a new instance of the <see cref="ComponentProxy"/> class.
		/// </summary>
		/// <param name="componentType">Type of the component.</param>
		public ComponentProxy(ComponentType componentType)
		{
			proxyInfo = NativeComponent.NewProxy(componentType);

			SetHandle(proxyInfo.Handle);
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ComponentProxy"/> class.
		/// </summary>
		/// <param name="pSelf">The p self.</param>
		/// <param name="ownsHandle">if set to <c>true</c> [owns handle].</param>
		protected ComponentProxy(IntPtr pSelf, bool ownsHandle)
			: base(pSelf, ownsHandle)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ComponentProxy"/> class.
		/// </summary>
		/// <param name="ownsHandle">if set to <c>true</c> [owns handle].</param>
		protected ComponentProxy(bool ownsHandle)
			: base(ownsHandle)
		{
		}

		/// <summary>
		/// Gets the type.
		/// </summary>
		/// <value>The type.</value>
		public ComponentType Type
		{
			get { return proxyInfo.Type; }
		}

		/// <summary>
		/// Releases the valid handle.
		/// </summary>
		protected override void ReleaseValidHandle()
		{
			NativeComponent.DeleteProxy(handle);
		}

		/// <summary>
		/// Releases the unmanaged resources used by the <see cref="T:System.Runtime.InteropServices.SafeHandle"/> class specifying whether to perform a normal dispose operation.
		/// </summary>
		/// <param name="disposing">true for a normal dispose operation; false to finalize the handle.</param>
		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);

			if (disposing)
				proxyInfo = default(ComponentProxyInfo);
		}
	}
}