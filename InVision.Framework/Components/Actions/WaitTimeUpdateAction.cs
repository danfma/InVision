namespace InVision.Framework.Components.Actions
{
	public class WaitTimeUpdateAction : UpdateAction
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="WaitTimeUpdateAction"/> class.
		/// </summary>
		/// <param name="milliseconds">The milliseconds.</param>
		public WaitTimeUpdateAction(long milliseconds)
		{
			Counter = 0;
			WaitingMilliseconds = milliseconds;
		}

		/// <summary>
		/// Gets or sets the counter.
		/// </summary>
		/// <value>The counter.</value>
		public double Counter { get; private set; }

		/// <summary>
		/// Gets or sets the waiting milliseconds.
		/// </summary>
		/// <value>The waiting milliseconds.</value>
		public double WaitingMilliseconds { get; private set; }

		/// <summary>
		/// Gets a value indicating whether this <see cref="UpdateAction"/> is done.
		/// </summary>
		/// <value><c>true</c> if done; otherwise, <c>false</c>.</value>
		public override bool Done
		{
			get { return Counter >= WaitingMilliseconds; }
		}

		/// <summary>
		/// Updates the specified elapsed time.
		/// </summary>
		/// <param name="elapsedTime">The elapsed time.</param>
		public override void Update(ElapsedTime elapsedTime)
		{
			Counter += elapsedTime.Elapsed.TotalMilliseconds;
		}
	}
}