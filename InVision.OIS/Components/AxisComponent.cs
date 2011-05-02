using InVision.OIS.Native;

namespace InVision.OIS.Components
{
	public class AxisComponent : Component
	{
		private AxisDescriptor _descriptor;

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
		internal AxisComponent(AxisDescriptor pSelf, bool ownsHandle = false)
			: base(pSelf.BaseDescriptor, ownsHandle)
		{
			_descriptor = pSelf;
		}

		/// <summary>
		/// Gets the absolute.
		/// </summary>
		/// <value>The absolute.</value>
		public int Absolute
		{
			get { return _descriptor.Abs; }
		}

		/// <summary>
		/// Gets the relative.
		/// </summary>
		/// <value>The relative.</value>
		public int Relative
		{
			get { return _descriptor.Rel; }
		}

		/// <summary>
		/// Gets a value indicating whether [absolute only].
		/// </summary>
		/// <value><c>true</c> if [absolute only]; otherwise, <c>false</c>.</value>
		public bool AbsoluteOnly
		{
			get { return _descriptor.AbsOnly; }
		}

		/// <summary>
		/// Releases the valid handle.
		/// </summary>
		protected override void ReleaseValidHandle()
		{
			NativeAxis.Delete(handle);
			_descriptor = default(AxisDescriptor);
		}
	}
}