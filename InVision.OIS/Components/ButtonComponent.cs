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
			: base(descriptor.BaseDescriptor, ownsHandle)
		{
			_descriptor = descriptor;
		}

		#region IButtonComponent Members

		/// <summary>
		/// Gets a value indicating whether this <see cref="ButtonDescriptor"/> is pushed.
		/// </summary>
		/// <value><c>true</c> if pushed; otherwise, <c>false</c>.</value>
		public bool Pushed
		{
			get { return _descriptor.Pushed; }
		}

		#endregion

		/// <summary>
		/// Releases the valid handle.
		/// </summary>
		protected override void ReleaseValidHandle()
		{
			NativeButton.Delete(handle);
			_descriptor = default(ButtonDescriptor);
		}
	}
}