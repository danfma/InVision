using System;
using System.IO;
using System.Linq;
using InVision.Framework.Config;
using InVision.Framework.Scripting;
using InVision.GameMath;
using InVision.Scripting.Boo;
using NUnit.Framework;

namespace Framework.Tests.Scripting.Boo
{
	/// <summary>
	/// Description of MyClass.
	/// </summary>
	[TestFixture]
	public class BooScriptTests
	{
		#region Setup/Teardown

		[SetUp]
		public void Setup()
		{
			_scriptManager = new BooScriptManager();
		}

		#endregion

		private IScriptManager _scriptManager;

		[Test]
		public void CheckManagerCapabilities()
		{
			Assert.That(_scriptManager, Is.Not.Null);
		}

		[Test]
		public void HelloWorld()
		{
			_scriptManager.PreferredExecution = ExecutionMode.Interpreted;

			var script = _scriptManager.LoadScript("Scripting/Boo/HelloWorld.boo");
			Assert.That(script, Is.Not.Null);
			Assert.That(script.ExecutionMode, Is.EqualTo(ExecutionMode.Interpreted));
			script.LoadOrExecute();
		}

		[Test]
		public void HelloWorldCompiled()
		{
			_scriptManager.PreferredExecution = ExecutionMode.Compiled;

			var script = _scriptManager.LoadScript("Scripting/Boo/HelloWorld.boo");
			Assert.That(script, Is.Not.Null);
			Assert.That(script.ExecutionMode, Is.EqualTo(ExecutionMode.Compiled));
			script.LoadOrExecute();
		}

		[Test]
		public void GetConfigureServiceOnCompiledScript()
		{
			_scriptManager.PreferredExecution = ExecutionMode.Compiled;

			var script = _scriptManager.LoadScript("Scripting/Boo/Configurer.boo");
			script.LoadOrExecute();

			var configurator = script.FindServices<ICustomConfigurator>().Single();

			var config = new Configuration();
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