using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using InVision.Framework;
using InVision.Framework.Scripting;
using Tutano.Core;

namespace Karel.Flow
{
	public class KarelGameFlow : TutanoGameFlow
	{
		private const string ProblemConfig = "Karel.Problem";
		private const string ResolutionConfig = "Karel.Resolution";

		private IScript _resolutionScript;

		/// <summary>
		/// Gets the world.
		/// </summary>
		/// <value>The world.</value>
		public static KarelWorld World { get; private set; }

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
			BeginKarelTask();
			base.GameLoop(app);
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
			var karelTask = new Task(ExecuteUserScript, TaskCreationOptions.AttachedToParent);
			karelTask.Start();
		}

		/// <summary>
		/// Executes the user script.
		/// </summary>
		private void ExecuteUserScript()
		{
			Thread.Sleep(1000);
			Console.WriteLine("Starting execution");

			_resolutionScript.LoadOrExecute();
			Tutano.App.Exit();
		}

		/// <summary>
		/// Registers the specified world name.
		/// </summary>
		/// <param name="karelWorld">The karel world.</param>
		public static void Register(KarelWorld karelWorld)
		{
			World = karelWorld;
		}
	}
}