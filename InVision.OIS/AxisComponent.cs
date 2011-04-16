using System;
using InVision.OIS.Native;

namespace InVision.OIS
{
	public class AxisComponent : Component, IAxisComponent
	{
		private AxisExtended nativeRef;

		/// <summary>
		/// Initializes a new instance of the <see cref="AxisComponent"/> class.
		/// </summary>
		public AxisComponent()
			: this(NativeAxis.New(), true)
		{
			
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="AxisComponent"/> class.
		/// </summary>
		/// <param name="pSelf">The p self.</param>
		/// <param name="ownsHandle">if set to <c>true</c> [owns handle].</param>
		internal AxisComponent(AxisExtended pSelf, bool ownsHandle = false)
			: base(pSelf.BaseInfo, ownsHandle)
		{
			nativeRef = pSelf;
		}

		/// <summary>
		/// Gets the absolute.
		/// </summary>
		/// <value>The absolute.</value>
		public int Absolute
		{
			get { return nativeRef.Abs; }
		}

		/// <summary>
		/// Gets the relative.
		/// </summary>
		/// <value>The relative.</value>
		public int Relative
		{
			get { return nativeRef.Rel; }
		}

		/// <summary>
		/// Gets a value indicating whether [absolute only].
		/// </summary>
		/// <value><c>true</c> if [absolute only]; otherwise, <c>false</c>.</value>
		public bool AbsoluteOnly
		{
			get { return nativeRef.AbsOnly; }
		}

		/// <summary>
		/// Releases the valid handle.
		/// </summary>
		protected override void ReleaseValidHandle()
		{
			NativeAxis.Delete(handle);
			nativeRef = default(AxisExtended);
		}
	}
}