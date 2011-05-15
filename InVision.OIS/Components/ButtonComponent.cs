using System;
using InVision.OIS.Native;

namespace InVision.OIS.Components
{
	public class ButtonComponent : Component
	{
		private ButtonDescriptor _descriptor;

		/// <summary>
		/// Initializes a new instance of the <see cref="ButtonComponent"/> class.
		/// </summary>
		/// <param name="pushed">if set to <c>true</c> [pushed].</param>
		public ButtonComponent(bool pushed)
			: this(NativeButton.New(pushed), true)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ButtonComponent"/> class.
		/// </summary>
		/// <param name="descriptor">The native ref.</param>
		/// <param name="ownsHandle">if set to <c>true</c> [owns handle].</param>
		internal ButtonComponent(ButtonDescriptor descriptor, bool ownsHandle = false)
			: base(descriptor.Base, ownsHandle)
		{
			_descriptor = descriptor;
		}

		/// <summary>
		/// Gets a value indicating whether this <see cref="ButtonDescriptor"/> is pushed.
		/// </summary>
		/// <value><c>true</c> if pushed; otherwise, <c>false</c>.</value>
		public bool Pushed
		{
			get { return _descriptor.Pushed; }
		}

		/// <summary>
		/// Releases the valid handle.
		/// </summary>
		protected override void DeleteHandle()
		{
			NativeButton.Delete(SelfHandle);
			_descriptor = default(ButtonDescriptor);
		}
	}
}