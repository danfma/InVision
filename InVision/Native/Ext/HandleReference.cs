using System;

namespace InVision.Native.Ext
{
	public abstract class HandleReference : HandleContainer
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="HandleReference"/> class.
		/// </summary>
		protected HandleReference()
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="HandleReference"/> class.
		/// </summary>
		/// <param name="handle">The handle.</param>
		protected HandleReference(Handle handle)
			: base(handle, false)
		{
		}

		/// <summary>
		/// Deletes the handle.
		/// </summary>
		protected override void DeleteHandle()
		{
			
		}
	}
}