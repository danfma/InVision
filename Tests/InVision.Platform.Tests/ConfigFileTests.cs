using System;
using InVision.Ogre3D;
using NUnit.Framework;

namespace InVision.Platform.Tests
{
	[TestFixture]
	public class ConfigFileTests
	{
		[Test]
		public void Settings()
		{
			var configFile = new ConfigFile();
			configFile.Load("Config/resources.cfg");

			var sections = configFile.GetSections();

			foreach (var sectionPair in sections)
			{
				Console.WriteLine("Section Key: {0}", sectionPair.Key);

				foreach (var settingPair in sectionPair.Value)
				{
					Console.WriteLine("\tSetting Key: {0} Value: {1}",
						settingPair.Key, settingPair.Value);
				}
			}
		}
	}
}