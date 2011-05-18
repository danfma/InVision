using InVision.Native;
using InVision.OIS.Components;
using InVision.OIS.Native;

namespace InVision.OIS
{
	public class MouseState : ReferenceSafeHandle
	{
		private MouseStateDescriptor _descriptor;

		/// <summary>
		/// Initializes a new instance of the <see cref="MouseState"/> class.
		/// </summary>
		/// <param name="descriptor">The descriptor.</param>
		internal MouseState(MouseStateDescriptor descriptor)
			: base(descriptor.Self)
		{
            //_descriptor = descriptor;
            //X = new Axis(descriptor.X);
            //Y = new Axis(descriptor.Y);
            //Z = new Axis(descriptor.Z);
		}

		/// <summary>
		/// Gets the width.
		/// </summary>
		/// <value>The width.</value>
		public int Width
		{
			get { return _descriptor.Width; }
			set { _descriptor.Width = value; }
		}

		/// <summary>
		/// Gets the height.
		/// </summary>
		/// <value>The height.</value>
		public int Height
		{
			get { return _descriptor.Height; }
			set { _descriptor.Height = value; }
		}

		/// <summary>
		/// Gets or sets the X.
		/// </summary>
		/// <value>The X.</value>
		public Axis X { get; private set; }

		/// <summary>
		/// Gets or sets the Y.
		/// </summary>
		/// <value>The Y.</value>
		public Axis Y { get; private set; }

		/// <summary>
		/// Gets or sets the Z.
		/// </summary>
		/// <value>The Z.</value>
		public Axis Z { get; private set; }

		/// <summary>
		/// Gets the buttons.
		/// </summary>
		/// <value>The buttons.</value>
		public int Buttons
		{
			get { return _descriptor.Buttons; }
		}

		/// <summary>
		/// Determines whether [is button down] [the specified button].
		/// </summary>
		/// <param name="button">The button.</param>
		/// <returns>
		/// 	<c>true</c> if [is button down] [the specified button]; otherwise, <c>false</c>.
		/// </returns>
		public bool IsButtonDown(MouseButton button)
		{
			return (Buttons & (1L << (int)button)) != 0;
		}
	}
}