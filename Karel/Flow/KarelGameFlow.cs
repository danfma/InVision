using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using InVision.Extensions;
using InVision.Framework;
using InVision.Framework.Components;
using InVision.Framework.Scripting;
using InVision.Framework.States;
using InVision.Ogre;
using InVision.Ogre.Listeners;
using Tutano.Core;

namespace Karel.Flow
{
	public class KarelGameFlow : TutanoGameFlow
	{
		private const string ProblemConfig = "Karel.Problem";
		private const string ResolutionConfig = "Karel.Resolution";

		private IScript _resolutionScript;

		/// <summary>
		/// Initializes a new instance of the <see cref="KarelGameFlow"/> class.
		/// </summary>
		public KarelGameFlow()
		{
			GameLogics = new Dictionary<IScript, IGameLogic[]>();
			ModifiedScripts = new List<IScript>();
		}

		/// <summary>
		/// Gets the world.
		/// </summary>
		/// <value>The world.</value>
		public static World World { get; private set; }

		/// <summary>
		/// Gets or sets the game logics.
		/// </summary>
		/// <value>The game logics.</value>
		private Dictionary<IScript, IGameLogic[]> GameLogics { get; set; }

		/// <summary>
		/// Gets or sets the modified scripts.
		/// </summary>
		/// <value>The modified scripts.</value>
		private List<IScript> ModifiedScripts { get; set; }

		/// <summary>
		/// Initializes the specified app.
		/// </summary>
		/// <param name="app">The app.</param>
		protected override void Initialize(GameApplication app)
		{
			base.Initialize(app);

			string problemPath = app.Configuration.CustomItems.
				Where(x => x.Name == ProblemConfig).
				Select(x => x.Value).SingleOrDefault();
			string resolutionPath = app.Configuration.CustomItems.
				Where(x => x.Name == ResolutionConfig).
				Select(x => x.Value).SingleOrDefault();

			IScript problemScript = FindScriptByPath(problemPath);
			problemScript.LoadOrExecute();

			_resolutionScript = FindScriptByPath(resolutionPath);
		}

		/// <summary>
		/// Finds the script by path.
		/// </summary>
		/// <param name="scriptPath">The script path.</param>
		/// <param name="throwsOnNotFound">if set to <c>true</c> [throws on not found].</param>
		/// <returns></returns>
		private IScript FindScriptByPath(string scriptPath, bool throwsOnNotFound = true)
		{
			IScript script =
				(from s in Tutano.Scripts
				 where s.Path == scriptPath
				 select s).FirstOrDefault();

			if (script == null)
				Tutano.Error(string.Format("No script at path: {0}", scriptPath));

			return script;
		}

		/// <summary>
		/// Games the loop.
		/// </summary>
		/// <param name="app">The app.</param>
		protected override void GameLoop(GameApplication app)
		{
			if (World == null)
				return;

			CreateGameState(app);
			LoadScripts();
			BeginKarelTask();

			Root.Instance.FrameEvent.FrameRenderingQueued += OnFrameRenderingQueued;
			Root.Instance.StartRendering();
		}

		/// <summary>
		/// Loads the scripts.
		/// </summary>
		private void LoadScripts()
		{
			foreach (IScript logicScript in Tutano.GameLogicScripts) {
				logicScript.LoadOrExecute();
				ReloadGameLogics(logicScript);
			}
		}

		/// <summary>
		/// Reloads the game logics.
		/// </summary>
		/// <param name="logicScript">The logic script.</param>
		private void ReloadGameLogics(IScript logicScript)
		{
			GameLogics[logicScript] = logicScript.FindServices<IGameLogic>().ForEach(x => x.Game = Game).ToArray();
		}

		/// <summary>
		/// Called when [frame rendering queued].
		/// </summary>
		/// <param name="e">The e.</param>
		/// <returns></returns>
		private bool OnFrameRenderingQueued(FrameEvent e)
		{
			Game.Timer.UpdateByEvent(e);

			ApplyCustomLogic();

			IGameState currentState = Game.StateMachine.Current;

			if (currentState == null)
				return false;

			currentState.Update(Game.Timer);

			return Game.IsRunning && !Game.Variables.Ogre.RenderWindow.IsClosed;
		}

		private void ApplyCustomLogic()
		{
			foreach (var pair in GameLogics) {
				if (pair.Key.SourceChanged) {
					ModifiedScripts.Add(pair.Key);
					continue;
				}

				foreach (IGameLogic gameLogic in pair.Value) {
					gameLogic.Update(Game.Timer);
				}
			}

			if (ModifiedScripts.Count > 0) {
				foreach (var script in ModifiedScripts) {
					try {
						script.LoadOrExecute();
						ReloadGameLogics(script);

					} catch {
						Console.WriteLine("Failed to load script: {0}", script.Path);
						GameLogics[script] = new IGameLogic[0];
					}
				}

				ModifiedScripts.Clear();
			}
		}

		/// <summary>
		/// Creates the state of the game.
		/// </summary>
		/// <param name="app">The app.</param>
		private void CreateGameState(GameApplication app)
		{
			var state = new KarelGameState("MainState");
			app.StateMachine.Add("MainState", state);

			app.StateMachine.CurrentStateName = "MainState";
			state.Components.Add("KarelWorld", World);

			state.Initialize();
		}

		/// <summary>
		/// Begins the karel task.
		/// </summary>
		private void BeginKarelTask()
		{
			var karelTask = new Task(ExecuteUserScript, TaskCreationOptions.PreferFairness);
			karelTask.Start();
		}

		/// <summary>
		/// Executes the user script.
		/// </summary>
		private void ExecuteUserScript()
		{
			Thread.Sleep(1000);
			Console.WriteLine("Starting user execution");

			_resolutionScript.LoadOrExecute();
			//Game.Exit();
		}

		/// <summary>
		/// Registers the specified world name.
		/// </summary>
		/// <param name="world">The karel world.</param>
		public static void Register(World world)
		{
			World = world;
		}
	}
}