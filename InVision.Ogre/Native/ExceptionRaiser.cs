using System;

namespace InVision.Ogre.Native
{
	internal sealed class ExceptionRaiser : IDisposable
	{
		private RaiseExceptionHandler raiseException;

		/// <summary>
		/// Initializes a new instance of the <see cref="ExceptionRaiser"/> class.
		/// </summary>
		public ExceptionRaiser()
		{
			raiseException = RaiseException;
			PlatformInvoke.RegisterExceptionHandler(raiseException);
		}

		/// <summary>
		/// Releases unmanaged resources and performs other cleanup operations before the
		/// <see cref="ExceptionRaiser"/> is reclaimed by garbage collection.
		/// </summary>
		~ExceptionRaiser()
		{
			Dispose(false);
		}

		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		/// <summary>
		/// Releases unmanaged and - optionally - managed resources
		/// </summary>
		/// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
		private void Dispose(bool disposing)
		{
			if (raiseException == null)
				return;

			raiseException = null;
			PlatformInvoke.RegisterExceptionHandler(null);
		}

		/// <summary>
		/// Raises the exception.
		/// </summary>
		/// <param name="message">The message.</param>
		private static void RaiseException(string message)
		{
			throw new InVisionException(message);
		}
	}
}