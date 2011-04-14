using System;

namespace InVision.OIS
{
	public abstract class Device : Handle
	{
		/// <summary>
		/// 	Initializes a new instance of the <see cref = "Device" /> class.
		/// </summary>
		/// <param name = "pSelf">The p self.</param>
		/// <param name = "ownsHandle">if set to <c>true</c> [owns handle].</param>
		protected internal Device(IntPtr pSelf, bool ownsHandle)
			: base(pSelf, ownsHandle)
		{
		}

		/// <summary>
		/// 	Initializes a new instance of the <see cref = "Device" /> class.
		/// </summary>
		/// <param name = "ownsHandle">if set to <c>true</c> [owns handle].</param>
		protected internal Device(bool ownsHandle)
			: base(ownsHandle)
		{
		}

		/// <summary>
		/// 	Gets the type.
		/// </summary>
		/// <value>The type.</value>
		public InputType Type
		{
			get { return NativeObject.GetType(handle); }
		}

		/// <summary>
		/// 	Gets the vendor.
		/// </summary>
		/// <value>The vendor.</value>
		public string Vendor
		{
			get { return NativeObject.GetVendor(handle); }
		}

		/// <summary>
		/// 	Gets or sets a value indicating whether this <see cref = "Device" /> is buffered.
		/// </summary>
		/// <value><c>true</c> if buffered; otherwise, <c>false</c>.</value>
		public bool Buffered
		{
			get { return NativeObject.GetBuffered(handle); }
			set { NativeObject.SetBuffered(handle, value); }
		}

		/// <summary>
		/// 	Gets the creator.
		/// </summary>
		/// <value>The creator.</value>
		public Input.InputManager Creator
		{
			get { return NativeObject.GetCreator(handle); }
		}

		/// <summary>
		/// 	Gets the id.
		/// </summary>
		/// <value>The id.</value>
		public int Id
		{
			get { return NativeObject.GetId(handle); }
		}

		/// <summary>
		/// 	Releases the specified pointer to the unmanaged object.
		/// </summary>
		/// <returns></returns>
		protected override void ReleaseValidHandle()
		{
			if (Creator != null)
				Creator.DestroyInputObject(this);
			else
				NativeObject.Delete(handle);
		}

		/// <summary>
		/// 	Captures the data for this instance.
		/// </summary>
		public void Capture()
		{
			NativeObject.Capture(handle);
		}
	}
}