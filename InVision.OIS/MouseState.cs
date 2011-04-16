using InVision.Native;
using InVision.OIS.Native;

namespace InVision.OIS
{
	public class MouseState : ReferenceHandle
	{
		private MouseStateExtended state;

		/// <summary>
		/// Initializes a new instance of the <see cref="MouseState"/> class.
		/// </summary>
		/// <param name="state">The state.</param>
		internal MouseState(MouseStateExtended state)
			: base(state.Self)
		{
			this.state = state;
			X = new AxisComponent(state.X);
			Y = new AxisComponent(state.Y);
			Z = new AxisComponent(state.Z);
		}

		public int Width
		{
			get { return state.Width; }
		}

		public int Height
		{
			get { return state.Height; }
		}

		public AxisComponent X { get; private set; }

		public AxisComponent Y { get; private set; }

		public AxisComponent Z { get; private set; }

		public int Buttons
		{
			get { return state.Buttons; }
		}
	}
}