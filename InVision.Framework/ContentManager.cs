using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using InVision.Framework.Config;

namespace InVision.Framework
{
	public class ContentManager : DisposableObject
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ContentManager"/> class.
		/// </summary>
		public ContentManager()
		{
		}

		/// <summary>
		/// Releases unmanaged and - optionally - managed resources
		/// </summary>
		/// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
		protected override void Dispose(bool disposing)
		{
			throw new NotImplementedException();
		}
	}
}