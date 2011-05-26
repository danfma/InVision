using System;
using System.Diagnostics;

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
		/// Gets or sets the frame processing.
		/// </summary>
		/// <value>The frame processing.</value>
		public TimeSpan FrameProcessing { get; private set; }

		/// <summary>
		/// Gets or sets the inter frame processing.
		/// </summary>
		/// <value>The inter frame processing.</value>
		public TimeSpan InterFrameProcessing { get; private set; }

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
			InterFrameProcessing = new TimeSpan(0);
			FrameProcessing = new TimeSpan(0);

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
			InterFrameProcessing = StopWatch.Elapsed - FrameProcessing;

			Restart();
		}

		/// <summary>
		/// Ends the frame.
		/// </summary>
		internal void EndFrame()
		{
			FrameProcessing = StopWatch.Elapsed;
		}
	}
}