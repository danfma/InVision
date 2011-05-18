using System;
using System.Runtime.InteropServices;
using InVision.Native.Ext;

namespace InVision.OIS.Native
{
    [CppValueObject]
	[StructLayout(LayoutKind.Sequential)]
    public struct EventArgDescriptor
	{
		private readonly Handle _self;

		/// <summary>
		/// Gets the self.
		/// </summary>
		/// <value>The self.</value>
		public Handle Self
		{
			get { return _self; }
		}
	}
}