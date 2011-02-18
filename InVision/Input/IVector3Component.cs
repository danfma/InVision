namespace InVision.Input
{
	public interface IVector3Component : IComponent
	{
		/// <summary>
		/// 	Gets the X.
		/// </summary>
		/// <value>The X.</value>
		float X { get; }

		/// <summary>
		/// 	Gets the Y.
		/// </summary>
		/// <value>The Y.</value>
		float Y { get; }

		/// <summary>
		/// 	Gets the Z.
		/// </summary>
		/// <value>The Z.</value>
		float Z { get; }
	}
}