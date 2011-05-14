using System;
using InVision.Framework.Scripting;

namespace Tutano
{
	public class Tutano : IDisposable
	{
		public static readonly ScriptManagerFactory ScriptManagerFactory;

		/// <summary>
		/// Initializes the <see cref="Tutano"/> class.
		/// </summary>
		static Tutano()
		{
			ScriptManagerFactory = new ScriptManagerFactory("Scripts/");			
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Tutano"/> class.
		/// </summary>
		public Tutano()
		{
		}

		/// <summary>
		/// Releases unmanaged resources and performs other cleanup operations before the
		/// <see cref="Tutano"/> is reclaimed by garbage collection.
		/// </summary>
		~Tutano()
		{
			Dispose(false);
		}

		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		/// <filterpriority>2</filterpriority>
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

		}

		/// <summary>
		/// Runs this instance.
		/// </summary>
		public void Run()
		{
			LoadConfiguration();
		}

		/// <summary>
		/// Loads the configuration.
		/// </summary>
		private void LoadConfiguration()
		{
			
		}
	}
}