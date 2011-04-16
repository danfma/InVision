using System;
using System.Collections.Generic;
using InVision.Native.Collections;

namespace InVision.OIS
{
	public class ParamList : MultiDictionary<string, string>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ParamList"/> class.
		/// </summary>
		public ParamList()
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ParamList"/> class.
		/// </summary>
		/// <param name="collection">The collection.</param>
		public ParamList(IEnumerable<KeyValuePair<string, string>> collection)
			: base(collection)
		{
		}
	}
}