using System;
using System.Dynamic;
using InVision.Framework.Config;
using InVision.Ogre;
using InVision.Ogre.Logging;

namespace InVision.Framework
{
	public class GameApplication
	{
		private readonly GameStateManager _stateManager;
		private ExpandoObject _appVariables;

		/// <summary>
		/// Initializes a new instance of the <see cref="GameApplication"/> class.
		/// </summary>
		public GameApplication()
		{
			_stateManager = new GameStateManager();
			_appVariables = new ExpandoObject();
		}

		/// <summary>
		/// Gets or sets the ogre root.
		/// </summary>
		/// <value>The ogre root.</value>
		public Root OgreRoot { get; private set; }

		/// <summary>
		/// Gets the state manager.
		/// </summary>
		/// <value>The state manager.</value>
		public GameStateManager StateManager
		{
			get { return _stateManager; }
		}

		/// <summary>
		/// Gets the global vars.
		/// </summary>
		/// <value>The global vars.</value>
		public dynamic AppVariables
		{
			get { return _appVariables; }
			private set { _appVariables = value; }
		}

		/// <summary>
		/// Initializes the specified config.
		/// </summary>
		/// <param name="config">The config.</param>
		public void Initialize(FxConfiguration config)
		{
			AppVariables.config = config;
			AppVariables.stateManager = _stateManager;
			AppVariables.ogre = new ExpandoObject();
		}

		/// <summary>
		/// Executes this instance.
		/// </summary>
		public void Execute()
		{
			IGameFlow gameFlow = FxConfiguration.Instance.GameFlow;

			if (gameFlow == null)
				throw new InvalidOperationException("No gameflow was defined");

			FxConfiguration config = FxConfiguration.Instance;
			OgreConfiguration ogreConfig = config.Ogre;

			try
			{
				ServiceManager.CreateInstance();
				InitializeLogging();

				using (var root = new Root(ogreConfig.PluginsFilename, ogreConfig.OgreConfigFilename))
				{
					AppVariables.ServiceManager = ServiceManager.Instance;

					if (ogreConfig.UseOgreConfig)
					{
						if (!root.RestoreConfig())
						{
							if (!root.ShowConfigDialog())
								return;

							root.SaveConfig();
						}


					}

					gameFlow.Run(this);
				}
			}
			finally
			{
				TerminateLogging();
				ServiceManager.DisposeInstance();

				AppVariables = null;

			}

			GC.Collect();
			GC.WaitForFullGCComplete();
		}

		/// <summary>
		/// Initializes the logging.
		/// </summary>
		private void InitializeLogging()
		{
			var logManager = new LogManager();
			Log log = logManager.CreateLog("OGRE.log", true, false, false);

			log.ActivateListener();
			//log.MessageLogged += (message, level, debug, name) => output.WriteLine("{0}: '{1}'", level, message);

			AppVariables.ogre.logManager = logManager;
			AppVariables.ogre.log = log;
		}

		/// <summary>
		/// Terminates the logging.
		/// </summary>
		private void TerminateLogging()
		{
			var log = (Log)AppVariables.ogre.log;

			if (log != null)
			{
				log.Dispose();
				AppVariables.ogre.log = null;
			}

			var logManager = (LogManager)AppVariables.ogre.logManager;

			if (logManager != null)
			{
				logManager.Dispose();
				AppVariables.ogre.logManager = null;
			}
		}
	}
}