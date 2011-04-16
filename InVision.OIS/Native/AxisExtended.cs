using System.Runtime.InteropServices;

namespace InVision.OIS.Native
{
	[StructLayout(LayoutKind.Sequential)]
	internal unsafe struct AxisExtended
	{
		private ComponentExtended baseInfo;
		private int* abs;
		private int* rel;
		private bool* absOnly;

		/// <summary>
		/// Gets the base info.
		/// </summary>
		/// <value>The base info.</value>
		public ComponentExtended BaseInfo
		{
			get { return baseInfo; }
		}

		/// <summary>
		/// Gets the abs.
		/// </summary>
		/// <value>The abs.</value>
		public int Abs
		{
			get { return *abs; }
		}

		/// <summary>
		/// Gets the rel.
		/// </summary>
		/// <value>The rel.</value>
		public int Rel
		{
			get { return *rel; }
		}

		/// <summary>
		/// Gets a value indicating whether [abs only].
		/// </summary>
		/// <value><c>true</c> if [abs only]; otherwise, <c>false</c>.</value>
		public bool AbsOnly
		{
			get { return *absOnly; }
		}
	}
}