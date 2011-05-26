using System.IO;
using System.Linq;
using InVision.Framework.Config;
using InVision.Framework.Scripting;
using InVision.GameMath;
using InVision.Scripting.IronRuby;
using NUnit.Framework;

namespace Framework.Tests.Scripting.Ruby
{
	[TestFixture]
	public class RubyScriptTests
	{
		#region Setup/Teardown

		[SetUp]
		public void Setup()
		{
			_scriptManager = new RubyScriptManager();
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
			IScript script = _scriptManager.LoadScript("Scripting/Ruby/HelloWorld.rb");

			Assert.That(script, Is.Not.Null);
			script.LoadOrExecute();
		}

		[Test]
		public void ScriptableConfigure()
		{
			var script = _scriptManager.LoadScript("Scripting/Ruby/Configurer.rb");
			script.AddReference(typeof(Color).Assembly);
			script.AddReference(typeof(Configuration).Assembly);
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