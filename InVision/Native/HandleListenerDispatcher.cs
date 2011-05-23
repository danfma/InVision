namespace InVision.Native
{
	public sealed class HandleListenerDispatcher : DisposableObject
	{
		#region Delegates

		/// <summary>
		/// 
		/// </summary>
		public delegate void HandleDestroyedHandler(Handle handle);

		#endregion

		private static readonly IHandleManager HandleManager = NativeFactory.Create<IHandleManager>();
		private HandleListenerHandleDestroyedHandler _handleDestroyed;

		#region Construction and Destruction

		/// <summary>
		/// Initializes a new instance of the <see cref="HandleListenerDispatcher"/> class.
		/// </summary>
		internal HandleListenerDispatcher()
		{
			_handleDestroyed = OnHandleDestroyed;
			HandleManager.RegisterHandleDestroyed(_handleDestroyed);
		}

		/// <summary>
		/// Releases unmanaged and - optionally - managed resources
		/// </summary>
		/// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
		protected override void Dispose(bool disposing)
		{
			HandleManager.RegisterHandleDestroyed(null);

			if (disposing)
			{
				_handleDestroyed = null;
				HandleDestroyed = null;
			}
		}

		#endregion

		/// <summary>
		/// Occurs when [handle destroyed].
		/// </summary>
		public event HandleDestroyedHandler HandleDestroyed;

		/// <summary>
		/// Called when [handle destroyed].
		/// </summary>
		/// <param name="handle">The handle.</param>
		private void OnHandleDestroyed(Handle handle)
		{
			if (HandleDestroyed != null)
				HandleDestroyed(handle);
		}
	}
}