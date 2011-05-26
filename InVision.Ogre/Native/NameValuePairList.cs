using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace InVision.Ogre.Native
{
	[StructLayout(LayoutKind.Sequential)]
	[OgreValueObject]
	public struct NameValuePairList
	{
		public uint Count;

		[MarshalAs(UnmanagedType.LPArray)]
		public NameValuePair[] Pairs;

		/// <summary>
		/// Converts the specified parameters.
		/// </summary>
		/// <param name="parameters">The parameters.</param>
		/// <returns></returns>
		public static NameValuePairList Convert(IDictionary<string, string> parameters)
		{
			return new NameValuePairList {
				Count = (uint)parameters.Count,
				Pairs = parameters.Select(p => new NameValuePair(p.Key, p.Value)).ToArray()
			};
		}
	}
}