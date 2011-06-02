namespace InVision.Framework.Components.Actions
{
	public abstract class UpdateAction
	{
		/// <summary>
		/// Gets a value indicating whether this <see cref="UpdateAction"/> is done.
		/// </summary>
		/// <value><c>true</c> if done; otherwise, <c>false</c>.</value>
		public abstract bool Done { get; }

		/// <summary>
		/// Updates the specified elapsed time.
		/// </summary>
		/// <param name="elapsedTime">The elapsed time.</param>
		public abstract void Update(ElapsedTime elapsedTime);
	}
}