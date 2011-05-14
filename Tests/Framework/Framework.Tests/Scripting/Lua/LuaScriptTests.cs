using System;
using InVision.Framework.Config;
using InVision.Framework.Scripting;
using InVision.GameMath;
using InVision.Scripting.Lua;
using NUnit.Framework;
using System.Linq;

namespace Framework.Tests.Scripting.Lua
{
	[TestFixture]
	public class LuaScriptTests
	{
		#region Setup/Teardown

		[SetUp]
		public void Setup()
		{
			_scriptManager = new LuaScriptManager();
		}

		#endregion

		private IScriptManager _scriptManager;

		/// <summary>
		/// Checks the manager capabilities.
		/// </summary>
		[Test]
		public void CheckManagerCapabilities()
		{
			Assert.That(_scriptManager, Is.Not.Null);
		}

		[Test]
		public void HelloWorld()
		{
			IScript script = _scriptManager.LoadScript("Scripting/Lua/HelloWorld.lua");

			Assert.That(script, Is.Not.Null);
			script.LoadOrExecute();
		}

		[Test]
		public void ScriptableConfigure()
		{
			var script = _scriptManager.LoadScript("Scripting/Lua/Configurer.lua");
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