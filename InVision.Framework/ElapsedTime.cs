using System;
using System.Diagnostics;
using InVision.Ogre.Listeners;

namespace InVision.Framework
{
	public class ElapsedTime
	{
		private static readonly Stopwatch StopWatch = Stopwatch.StartNew();

		/// <summary>
		/// Gets or sets the elapsed.
		/// </summary>
		/// <value>The elapsed.</value>
		public TimeSpan Elapsed { get; private set; }

		/// <summary>
		/// Gets or sets from last event.
		/// </summary>
		/// <value>From last event.</value>
		public TimeSpan FromLastEvent { get; private set; }

		/// <summary>
		/// Gets a value indicating whether this instance is running.
		/// </summary>
		/// <value>
		/// 	<c>true</c> if this instance is running; otherwise, <c>false</c>.
		/// </value>
		internal bool IsRunning
		{
			get { return StopWatch.IsRunning; }
		}

		/// <summary>
		/// Starts this instance.
		/// </summary>
		internal void Start()
		{
			Elapsed = new TimeSpan(0);
			StopWatch.Start();
		}

		/// <summary>
		/// Stops this instance.
		/// </summary>
		internal void Stop()
		{
			StopWatch.Stop();
		}

		/// <summary>
		/// Starts this instance.
		/// </summary>
		internal void Restart()
		{
			StopWatch.Reset();
			StopWatch.Start();
		}

		/// <summary>
		/// Begins the frame.
		/// </summary>
		internal void BeginFrame()
		{
			Elapsed = StopWatch.Elapsed;
			Restart();
		}

		/// <summary>
		/// Ends the frame.
		/// </summary>
		internal void EndFrame()
		{
		}

		/// <summary>
		/// Updates the by event.
		/// </summary>
		/// <param name="frameEvent">The frame event.</param>
		public void UpdateByEvent(FrameEvent frameEvent)
		{
			Elapsed = TimeSpan.FromSeconds(frameEvent.TimeSinceLastFrame);
			FromLastEvent = TimeSpan.FromSeconds(frameEvent.TimeSinceLastEvent);
		}
	}
}