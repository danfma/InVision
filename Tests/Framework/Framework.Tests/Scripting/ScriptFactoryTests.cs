using System;
using InVision.Framework.Config;
using InVision.Framework.Scripting;
using InVision.Scripting.Boo;
using NUnit.Framework;

namespace Framework.Tests.Scripting
{
	[TestFixture]
	public class ScriptFactoryTests
	{
		private Configuration config;

		#region Setup/Teardown

		[SetUp]
		public void Setup()
		{
			config = new Configuration();
			config.Scripting.ScriptManagers.Add(typeof(BooScriptManager));

			ScriptManagerFactory.Initialize(config);
		}

		#endregion

		[Test]
		public void LoadBooScript()
		{
			const string filename = "Scripting/Boo/HelloWorld.boo";

			var scriptFactory = ScriptManagerFactory.Instance;
			var script = scriptFactory.GetScriptManagerFor(filename).LoadScript(filename);

			Assert.That(script, Is.Not.Null);
			Assert.That(script, Is.InstanceOf(typeof(IBooScript)));
		}
	}
}