using System.Collections.Generic;
using System.Runtime.InteropServices;
using InVision.Native.Ext;

namespace InVision.OIS.Native
{
	[GeneratorModel, CppValueObject]
	[StructLayout(LayoutKind.Sequential)]
	public struct NameValueItem
	{
		[MarshalAs(UnmanagedType.LPStr)]
		public string Name;

		[MarshalAs(UnmanagedType.LPStr)]
		public string Value;

		/// <summary>
		/// Initializes a new instance of the <see cref="NameValueItem"/> struct.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <param name="value">The value.</param>
		public NameValueItem(string name, string value)
		{
			Name = name;
			Value = value;
		}

		/// <summary>
		/// Toes the array.
		/// </summary>
		/// <param name="parameters">The parameters.</param>
		/// <param name="count">The count.</param>
		/// <returns></returns>
		public static NameValueItem[] ToArray(IDictionary<string, string> parameters, out int count)
		{
			count = parameters.Count;

			int i = 0;
			var items = new NameValueItem[count];

			foreach (var parameter in parameters)
			{
				items[i++] = new NameValueItem(parameter.Key, parameter.Value);
			}

			return items;
		}
	}
}