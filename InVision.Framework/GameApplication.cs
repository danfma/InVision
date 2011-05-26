using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using InVision.Framework.Config;
using InVision.Ogre;
using InVision.Ogre.Logging;

namespace InVision.Framework
{
	public class GameApplication : DisposableObject
	{
		#region Construction and Destruction

		/// <summary>
		/// Initializes a new instance of the <see cref="GameApplication"/> class.
		/// </summary>
		public GameApplication()
		{
			StateMachine = new GameStateMachine();
			Components = new GameComponentCollection();
			AppVariables = new ExpandoObject();
			Configurators = new List<ICustomConfigurator>();
			Timer = new ElapsedTime();
		}

		/// <summary>
		/// Releases unmanaged and - optionally - managed resources
		/// </summary>
		/// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
		protected override void Dispose(bool disposing)
		{
			if (!Equals(Timer, default(ElapsedTime)))
				Timer.Stop();

			if (Configurators != null)
				Configurators.Clear();

			if (Components != null)
				Components.Clear();

			if (StateMachine != null)
				StateMachine.Dispose();

			if (AppVariables != null)
				DisposeOgre();

			if (disposing)
			{
				Configurators = null;
				StateMachine = null;
				AppVariables = null;
				Configuration = null;
				Timer = default(ElapsedTime);
			}
		}

		#endregion

		/// <summary>
		/// Gets the configurators.
		/// </summary>
		/// <value>The configurators.</value>
		public IList<ICustomConfigurator> Configurators { get; private set; }

		/// <summary>
		/// Gets or sets the component manager.
		/// </summary>
		/// <value>The component manager.</value>
		public GameComponentCollection Components { get; private set; }

		/// <summary>
		/// Gets the state manager.
		/// </summary>
		/// <value>The state manager.</value>
		public GameStateMachine StateMachine { get; private set; }

		/// <summary>
		/// Gets the global vars.
		/// </summary>
		/// <value>The global vars.</value>
		public dynamic AppVariables { get; private set; }

		/// <summary>
		/// Gets or sets the configuration.
		/// </summary>
		/// <value>The configuration.</value>
		public Configuration Configuration { get; private set; }

		/// <summary>
		/// Gets or sets the game flow.
		/// </summary>
		/// <value>The game flow.</value>
		public IGameFlow GameFlow { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether this instance is running.
		/// </summary>
		/// <value>
		/// 	<c>true</c> if this instance is running; otherwise, <c>false</c>.
		/// </value>
		public bool IsRunning { get; private set; }

		/// <summary>
		/// Gets or sets the timer.
		/// </summary>
		/// <value>The timer.</value>
		public ElapsedTime Timer { get; private set; }

		/// <summary>
		/// Configures the specified config.
		/// </summary>
		/// <param name="config">The config.</param>
		public void Configure(Configuration config)
		{
			AppVariables.Config = config;
			AppVariables.StateManager = StateMachine;
			AppVariables.Ogre = new ExpandoObject();
			AppVariables.Components = Components;

			foreach (ICustomConfigurator configurator in Configurators)
			{
				configurator.Configure(config);
			}

			Configuration = config;

			InitializeOgre();

			IsRunning = true;
		}

		/// <summary>
		/// Initializes the ogre.
		/// </summary>
		protected virtual void InitializeOgre()
		{
			Configuration config = Configuration;

			var logManager = new LogManager();
			AppVariables.Ogre.LogManager = logManager;

			Log logger = logManager.CreateLog("OGRE.log", true, false, false);
			AppVariables.Ogre.Logger = logger;

			var root = new Root(config.Ogre.PluginsFilename, config.Ogre.OgreConfigFilename);
			AppVariables.Ogre.Root = root;

			CreateWindow(root);
		}

		/// <summary>
		/// Disposes the ogre.
		/// </summary>
		protected virtual void DisposeOgre()
		{
			dynamic ogre = AppVariables.Ogre;

			if (ogre.RenderWindow != null)
				ogre.RenderWindow.Dispose();

			if (ogre.Root != null)
				ogre.Root.Dispose();

			if (ogre.Logger != null)
				ogre.Logger.Dispose();

			if (ogre.LogManager != null)
				ogre.LogManager.Dispose();
		}

		/// <summary>
		/// Creates the window.
		/// </summary>
		/// <param name="root">The root.</param>
		protected virtual void CreateWindow(Root root)
		{
			Configuration config = Configuration;

			RenderWindow window;

			if (Configuration.Ogre.UseOgreConfig)
			{
				if (!root.RestoreConfig())
				{
					if (!root.ShowConfigDialog())
					{
						Console.WriteLine("Could not show the config dialog for Ogre");
						Exit();
						return;
					}

					root.SaveConfig();
				}

				window = root.Initialize(true, Configuration.Game.Name);
			}
			else
			{
				if (config.Ogre.RenderWindowParameters != null)
				{
					Dictionary<string, string> parameters = config.Ogre.RenderWindowParameters.ToDictionary(
						item => item.Name,
						item => item.Value);

					window = root.CreateRenderWindow(
						"OgreRoot",
						config.Screen.Width,
						config.Screen.Height,
						config.Screen.Fullscreen,
						new RenderWindowParameters(parameters));
				}
				else
				{
					window = root.CreateRenderWindow(
						"OgreRoot",
						config.Screen.Width,
						config.Screen.Height,
						config.Screen.Fullscreen);
				}
			}

			AppVariables.Ogre.RenderWindow = window;
		}

		/// <summary>
		/// Exits this instance.
		/// </summary>
		public void Exit()
		{
			IsRunning = false;
		}

		/// <summary>
		/// Begins the scene.
		/// </summary>
		public void BeginScene()
		{
			if (!Timer.IsRunning)
				Timer.Start();

			Timer.BeginFrame();
		}

		/// <summary>
		/// Ends the scene.
		/// </summary>
		public void EndScene()
		{
			var root = (Root)AppVariables.Ogre.Root;
			var window = (RenderWindow)AppVariables.Ogre.RenderWindow;

			IsRunning = IsRunning && root.RenderOneFrame() && !window.IsClosed;
			Timer.EndFrame();
		}

		/// <summary>
		/// Executes this instance.
		/// </summary>
		public void Execute()
		{
			if (GameFlow == null)
				GameFlow = new DefaultGameFlow();

			GameFlow.Run(this);
		}
	}
}