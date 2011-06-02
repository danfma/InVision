using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using InVision;
using InVision.Framework;
using InVision.Framework.Config;
using InVision.Framework.Scripting;
using InVision.Framework.States;
using Tutano.Core.Config;

namespace Tutano.Core
{
	public class Tutano : DisposableObject
	{
		private GameApplication _app;

		#region Construction and Destruction

		/// <summary>
		/// Initializes a new instance of the <see cref="Tutano"/> class.
		/// </summary>
		public Tutano()
		{
			_app = new GameApplication();
		}

		/// <summary>
		/// Releases unmanaged and - optionally - managed resources
		/// </summary>
		/// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
		protected override void Dispose(bool disposing)
		{
			if (_app != null)
				_app.Dispose();

			if (disposing)
				_app = null;
		}

		#endregion

		/// <summary>
		/// Gets the app.
		/// </summary>
		/// <value>The app.</value>
		public GameApplication App
		{
			get { return _app; }
		}

		/// <summary>
		/// Gets or sets the configuration.
		/// </summary>
		/// <value>The configuration.</value>
		public TutanoConfiguration Configuration { get; set; }

		/// <summary>
		/// Gets the native directory.
		/// </summary>
		/// <value></value>
		public static string NativeDirectory
		{
			get
			{
				return string.Format("Bin/Native/{0}-{1}", Platform.PlatformIdentity,
									 Platform.Is32Bits ? "32bit" : "64bit");
			}
		}

		/// <summary>
		/// Gets or sets the scripts.
		/// </summary>
		/// <value>The scripts.</value>
		public List<IScript> Scripts { get; protected set; }

		/// <summary>
		/// Gets the game logic scripts.
		/// </summary>
		/// <value>The game logic scripts.</value>
		public IEnumerable<IScript> GameLogicScripts
		{
			get { return Scripts.Where(x => x.Path.EndsWith(".Logic")); }
		}

		/// <summary>
		/// Gets the game state scripts.
		/// </summary>
		/// <value>The game state scripts.</value>
		public IEnumerable<IScript> GameStateScripts
		{
			get { return Scripts.Where(x => x.Path.EndsWith(".State")); }
		}

		/// <summary>
		/// Gets the game object scripts.
		/// </summary>
		/// <value>The game object scripts.</value>
		public IEnumerable<IScript> GameObjectScripts
		{
			get { return Scripts.Where(x => x.Path.EndsWith(".Object")); }
		}

		/// <summary>
		/// Runs this instance.
		/// </summary>
		public void Run()
		{
			try {
				Initialize();

				var gameFlow = Configuration.GameFlow as TutanoGameFlow;

				if (gameFlow == null) {
					Console.WriteLine("No TutanoGameFlow instance for the game flow was defined");
					return;
				}

				gameFlow.Tutano = this;
				_app.GameFlow = gameFlow;
				_app.Execute();

			} catch (TutanoException ex) {
				Console.WriteLine(ex.Message);
			}
		}

		/// <summary>
		/// Loads this instance.
		/// </summary>
		/// <returns></returns>
		public void Initialize()
		{
			CreateDefaultDirectories();
			SetNativeDirectoriesToPath();

			Configuration = InVision.Framework.Config.Configuration.LoadOrCreate<TutanoConfiguration>("Config/Tutano.config.xml");

			LoadCustomLibraries();
			ScriptManagerFactory.Initialize(
				Configuration,
				Path.GetFullPath("Bin/CompiledScripts"),
				Configuration.Scripting.ExecutionMode);

			LoadScripts();
		}

		/// <summary>
		/// Creates the default directories.
		/// </summary>
		private static void CreateDefaultDirectories()
		{
			Console.WriteLine("Checking for default directories");

			var directories = new[] {
				"Config/",
				"Libraries/",
				"Scripts/",
				"Content/"
			};

			foreach (string directory in directories.OrderBy(s => s)) {
				if (!Directory.Exists(directory)) {
					Console.WriteLine("=> Creating directory '{0}'", directory);
					Directory.CreateDirectory(directory);
				} else
					Console.WriteLine("=> Directory '{0}': OK", directory);
			}
		}

		/// <summary>
		/// Loads the custom libraries.
		/// </summary>
		private static void LoadCustomLibraries()
		{
			Console.WriteLine("Loading custom libraries");

			foreach (string assemblyFile in FindFiles("Libraries", "*.dll")) {
				Assembly assembly = Assembly.LoadFrom(assemblyFile);
				Console.WriteLine("=> Loading library: {0}", assembly.GetName().Name);
			}
		}

		/// <summary>
		/// Sets the native directories to path.
		/// </summary>
		private static void SetNativeDirectoriesToPath()
		{
			string nativeDirectory = NativeDirectory;

			Console.WriteLine("Setting directories for searching native libraries");

			IEnumerable<string> directories = FindDirectories(nativeDirectory);

			foreach (string directory in directories) {
				Console.WriteLine("=> {0}", directory);
				Platform.AddLibraryPath(directory);
			}
		}

		/// <summary>
		/// Gets the directories.
		/// </summary>
		/// <param name="rootDirectory">The root directory.</param>
		/// <param name="recursive">if set to <c>true</c> [recursive].</param>
		/// <returns></returns>
		private static IEnumerable<string> FindDirectories(string rootDirectory, bool recursive = true)
		{
			yield return rootDirectory;

			foreach (string directory in Directory.GetDirectories(rootDirectory)) {
				yield return directory;

				if (!recursive)
					continue;

				foreach (string innerDirectory in FindDirectories(directory)) {
					yield return innerDirectory;
				}
			}
		}

		/// <summary>
		/// Finds the files.
		/// </summary>
		/// <param name="directory">The directory.</param>
		/// <param name="match">The match.</param>
		/// <param name="recursive">if set to <c>true</c> [recursive].</param>
		/// <returns></returns>
		private static IEnumerable<string> FindFiles(string directory, string match, bool recursive = true)
		{
			directory = Path.GetFullPath(directory);

			return FindDirectories(directory, recursive).SelectMany(foundDir => Directory.GetFiles(foundDir, match));
		}

		/// <summary>
		/// Finds the configurators.
		/// </summary>
		private void LoadScripts()
		{
			Scripts = new List<IScript>();

			foreach (string allowedScriptExtension in ScriptManagerFactory.Instance.AllowedScriptExtensions) {
				Console.WriteLine("Searching for '{0}' scripts...", allowedScriptExtension);

				string fileMatch = string.Format("*{0}", allowedScriptExtension);

				IEnumerable<string> files = FindFiles("Config", fileMatch);
				files = files.Union(FindFiles("Scripts", fileMatch));

				foreach (string configFile in files) {
					LoadScript(configFile);
				}
			}
		}

		private void LoadScript(string configFile)
		{
			IScriptManager scriptManager = ScriptManagerFactory.Instance.GetScriptManagerFor(configFile);

			if (scriptManager != null) {
				Console.WriteLine("=> Found script: {0}", Path.GetFileName(configFile));

				IScript script = scriptManager.LoadScript(configFile);

				script.AddReferences(AppDomain.CurrentDomain.GetAssemblies());
				script.AssemblyPrefix =
					Path.GetDirectoryName(configFile).Substring(Environment.CurrentDirectory.Length + 1).Replace(
						Path.DirectorySeparatorChar, '_') + "_";
				Scripts.Add(script);
			}
		}

		/// <summary>
		/// Applies the custom configurators.
		/// </summary>
		public void ApplyCustomConfigurators()
		{
			foreach (var script in Scripts) {
				if (script.Path.StartsWith("Config") && script.Path.EndsWith(".Config")) {
					script.LoadOrExecute();

					foreach (ICustomConfigurator configurator in script.FindServices<ICustomConfigurator>()) {
						configurator.Configure(Configuration);
					}
				}
			}
		}

		/// <summary>
		/// Initializes the game states.
		/// </summary>
		public void InitializeGameStates()
		{
			foreach (IGameState gameState in _app.StateMachine.Values) {
				gameState.Initialize();
			}
		}

		/// <summary>
		/// Errors the specified message.
		/// </summary>
		/// <param name="message">The message.</param>
		public void Error(string message)
		{
			Console.WriteLine(message);
			throw new TutanoException(message);
		}
	}
}