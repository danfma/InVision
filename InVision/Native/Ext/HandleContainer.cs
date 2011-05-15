using System;

namespace InVision.Native.Ext
{
	public abstract class HandleContainer : IDisposable
	{
		private readonly bool _ownsHandle;

		/// <summary>
		/// Initializes a new instance of the <see cref="HandleContainer"/> class.
		/// </summary>
		protected HandleContainer()
			: this(default(Handle), false)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="HandleContainer"/> class.
		/// </summary>
		/// <param name="handle">The handle.</param>
		/// <param name="ownsHandle">if set to <c>true</c> [owns handle].</param>
		protected HandleContainer(Handle handle, bool ownsHandle)
		{
			SelfHandle = handle;
			_ownsHandle = ownsHandle;
		}

		/// <summary>
		/// Gets the handle.
		/// </summary>
		/// <value></value>
		/// <value>The handle.</value>
		public Handle SelfHandle { get; protected set; }

		#region IDisposable Members

		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		/// <filterpriority>2</filterpriority>
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		#endregion

		/// <summary>
		/// Releases unmanaged resources and performs other cleanup operations before the
		/// <see cref="HandleContainer"/> is reclaimed by garbage collection.
		/// </summary>
		~HandleContainer()
		{
			Dispose(false);
		}

		/// <summary>
		/// Releases unmanaged and - optionally - managed resources
		/// </summary>
		/// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
		protected virtual void Dispose(bool disposing)
		{
			if (SelfHandle.IsValid && _ownsHandle)
				DeleteHandle();
		}

		/// <summary>
		/// Deletes the handle.
		/// </summary>
		protected abstract void DeleteHandle();
	}
}