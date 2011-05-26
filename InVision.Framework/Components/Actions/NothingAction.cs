namespace InVision.Framework.Components.Actions
{
	public class NothingAction : UpdateAction
	{
		/// <summary>
		/// Gets a value indicating whether this <see cref="UpdateAction"/> is done.
		/// </summary>
		/// <value><c>true</c> if done; otherwise, <c>false</c>.</value>
		public override bool Done
		{
			get { return true; }
		}

		/// <summary>
		/// Updates the specified elapsed time.
		/// </summary>
		/// <param name="elapsedTime">The elapsed time.</param>
		public override void Update(ElapsedTime elapsedTime)
		{

		}
	}
}