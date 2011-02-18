namespace InVision.Input
{
	public interface IMouseState
	{
		/// <summary>
		/// 	Gets the width.
		/// </summary>
		/// <value>The width.</value>
		int Width { get; }

		/// <summary>
		/// 	Gets the height.
		/// </summary>
		/// <value>The height.</value>
		int Height { get; }

		/// <summary>
		/// 	Gets the X.
		/// </summary>
		/// <value>The X.</value>
		AxisComponent X { get; }

		/// <summary>
		/// 	Gets the Y.
		/// </summary>
		/// <value>The Y.</value>
		AxisComponent Y { get; }

		/// <summary>
		/// 	Gets the Z.
		/// </summary>
		/// <value>The Z.</value>
		AxisComponent Z { get; }

		/// <summary>
		/// 	Gets the buttons.
		/// </summary>
		/// <value>The buttons.</value>
		int Buttons { get; }

		/// <summary>
		/// 	Determines whether [is button down] [the specified button].
		/// </summary>
		/// <param name = "button">The button.</param>
		/// <returns>
		/// 	<c>true</c> if [is button down] [the specified button]; otherwise, <c>false</c>.
		/// </returns>
		bool IsButtonDown(MouseButton button);
	}
}