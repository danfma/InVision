using InVision.OIS.Native;

namespace InVision.OIS
{
	public class ButtonComponent : Component, IButtonComponent
	{
		private ButtonExtended nativeRef;

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
		/// <param name="nativeRef">The native ref.</param>
		/// <param name="ownsHandle">if set to <c>true</c> [owns handle].</param>
		internal ButtonComponent(ButtonExtended nativeRef, bool ownsHandle = false) 
			: base(nativeRef.BaseInfo, ownsHandle)
		{
			this.nativeRef = nativeRef;
		}

		#region IButtonComponent Members

		/// <summary>
		/// Gets a value indicating whether this <see cref="ButtonExtended"/> is pushed.
		/// </summary>
		/// <value><c>true</c> if pushed; otherwise, <c>false</c>.</value>
		public bool Pushed
		{
			get { return nativeRef.Pushed; }
		}

		#endregion

		/// <summary>
		/// Releases the valid handle.
		/// </summary>
		protected override void ReleaseValidHandle()
		{
			NativeButton.Delete(handle);
			nativeRef = default(ButtonExtended);
		}
	}
}