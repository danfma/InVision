using System;
using System.Runtime.InteropServices;
using InVision.Native.Ext;

namespace InVision.OIS.Native
{
	[StructLayout(LayoutKind.Sequential)]
	internal unsafe struct AxisDescriptor
	{
		private readonly ComponentDescriptor _base;
		private readonly int* _abs;
		private readonly int* _rel;
		private readonly bool* _absOnly;

		/// <summary>
		/// Gets the base info.
		/// </summary>
		/// <value>The base info.</value>
		public ComponentDescriptor Base
		{
			get { return _base; }
		}

		/// <summary>
		/// Gets the abs.
		/// </summary>
		/// <value>The abs.</value>
		public int Abs
		{
			get { return *_abs; }
		}

		/// <summary>
		/// Gets the rel.
		/// </summary>
		/// <value>The rel.</value>
		public int Rel
		{
			get { return *_rel; }
		}

		/// <summary>
		/// Gets a value indicating whether [abs only].
		/// </summary>
		/// <value><c>true</c> if [abs only]; otherwise, <c>false</c>.</value>
		public bool AbsOnly
		{
			get { return *_absOnly; }
		}
	}
}