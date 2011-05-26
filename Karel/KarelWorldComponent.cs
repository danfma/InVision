using InVision.Framework;
using InVision.GameMath;

namespace Karel
{
	public class KarelWorldComponent : GameComponent
	{
		/// <summary>
		/// Gets or sets the world position.
		/// </summary>
		/// <value>The world position.</value>
		public Vector2 WorldPosition { get; set; }

		/// <summary>
		/// Updates the self.
		/// </summary>
		/// <param name="elapsedTime">The elapsed time.</param>
		protected override void UpdateSelf(ElapsedTime elapsedTime)
		{

		}
	}
}