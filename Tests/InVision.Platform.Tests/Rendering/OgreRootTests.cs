using System;
using NUnit.Framework;

namespace InVision.Ogre3D.Tests.Rendering
{
	[TestFixture]
	public class OgreRootTests
	{
		[Test]
		public void InitializationTest()
		{
			using (var root = new Root("Config/plugins.cfg", "Config/ogre.cfg"))
			{
				if (!root.RestoreConfig())
				{
					if (root.ShowConfigDialog())
						root.SaveConfig();
				}

				var renderSystems = root.AvailableRenderers;

				foreach (var renderSystem in renderSystems)
				{
					Console.WriteLine("RenderSystem: {0}", renderSystem);
				}

				root.Initialise(true);

				root.FrameEvent.FrameStarted += @event =>
													{
														Console.WriteLine("Frame Started");
														return true;
													};
				root.FrameEvent.FrameEnded += @event =>
												{
													Console.WriteLine("Frame ended");
													return false;
												};

				root.StartRendering();
			}
		}
	}
}