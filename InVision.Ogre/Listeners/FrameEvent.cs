using System.Runtime.InteropServices;
using InVision.Ogre.Native;

namespace InVision.Ogre.Listeners
{
	[OgreValueObject("FrameEvent")]
	[StructLayout(LayoutKind.Sequential)]
	public struct FrameEvent
	{
		private float timeSinceLastEvent;
		private float timeSinceLastFrame;

		/// <summary>
		/// 	Initializes a new instance of the <see cref = "FrameEvent" /> struct.
		/// </summary>
		/// <param name = "timeSinceLastEvent">The time since last event.</param>
		/// <param name = "timeSinceLastFrame">The time since last frame.</param>
		public FrameEvent(float timeSinceLastEvent, float timeSinceLastFrame)
			: this()
		{
			TimeSinceLastEvent = timeSinceLastEvent;
			TimeSinceLastFrame = timeSinceLastFrame;
		}

		/// <summary>
		/// 	Gets or sets the time since last event.
		/// </summary>
		/// <value>The time since last event.</value>
		public float TimeSinceLastEvent
		{
			get { return timeSinceLastEvent; }
			private set { timeSinceLastEvent = value; }
		}

		/// <summary>
		/// 	Gets or sets the time since last frame.
		/// </summary>
		/// <value>The time since last frame.</value>
		public float TimeSinceLastFrame
		{
			get { return timeSinceLastFrame; }
			private set { timeSinceLastFrame = value; }
		}
	}
}