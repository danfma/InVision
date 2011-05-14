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
		#region Setup/Teardown

		[SetUp]
		public void Setup()
		{
			var config = FxConfiguration.Create();
			config.Scripting.ScriptManagers = new[] { typeof(BooScriptManager) };
		}

		#endregion

		[Test]
		public void CheckConfiguration()
		{
			Assert.That(FxConfiguration.Instance, Is.Not.Null);
		}

		[Test]
		public void LoadBooScript()
		{
			const string filename = "Scripting/Boo/HelloWorld.boo";

			var scriptFactory = new ScriptManagerFactory();
			var script = scriptFactory.GetScriptManagerFor(filename).LoadScript(filename);

			Assert.That(script, Is.Not.Null);
			Assert.That(script, Is.InstanceOf(typeof(IBooScript)));
		}
	}
}