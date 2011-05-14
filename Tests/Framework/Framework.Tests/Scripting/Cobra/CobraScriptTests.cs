using System;
using System.Linq;
using InVision.Framework.Config;
using InVision.Framework.Scripting;
using InVision.GameMath;
using InVision.Scripting.Cobra;
using NUnit.Framework;

namespace Framework.Tests.Scripting.Cobra
{
	/// <summary>
	/// Description of MyClass.
	/// </summary>
	[TestFixture]
	public class CobraScriptTests
	{
		#region Setup/Teardown

		[SetUp]
		public void Setup()
		{
			_scriptManager = new CobraScriptManager();
		}

		#endregion

		private IScriptManager _scriptManager;

		[Test]
		public void CheckManagerCapabilities()
		{
			Assert.That(_scriptManager, Is.Not.Null);
		}

		[Test]
		public void HelloWorldCompiled()
		{
			var script = _scriptManager.LoadScript("Scripting/Cobra/HelloWorld.cobra");

			Assert.That(script, Is.Not.Null);
			script.LoadOrExecute();
		}

		[Test]
		public void ScriptableConfigure()
		{
			var script = _scriptManager.LoadScript("Scripting/Cobra/Configurer.cobra");
			script.AddReference(typeof(Color).Assembly);
			script.AddReference(typeof(FxConfiguration).Assembly);
			script.LoadOrExecute();

			var configurator = script.FindServices<IConfigurator>().Single();

			FxConfiguration config = FxConfiguration.Create();
			config.Screen.Width = 1;
			config.Screen.Height = 1;
			config.Screen.BackgroundColor = Color.AliceBlue;

			Assert.That(configurator, Is.Not.Null);

			configurator.Configure(config);

			Assert.That(config.Screen.Width, Is.EqualTo(640));
			Assert.That(config.Screen.Height, Is.EqualTo(480));
			Assert.That(config.Screen.BackgroundColor, Is.EqualTo(Color.Black));
		}
	}
}