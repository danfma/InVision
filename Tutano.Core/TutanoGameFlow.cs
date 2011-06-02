using System;
using InVision.Framework;
using InVision.Framework.Components;
using InVision.Framework.States;
using InVision.Ogre;
using System.Linq;

namespace Tutano.Core
{
	public class TutanoGameFlow : GameFlow
	{
		/// <summary>
		/// Gets or sets the tutano app.
		/// </summary>
		/// <value>The tutano app.</value>
		public Tutano Tutano { get; set; }

		/// <summary>
		/// Gets the game.
		/// </summary>
		/// <value>The game.</value>
		public GameApplication Game
		{
			get { return Tutano.App; }
		}

		/// <summary>
		/// Runs the specified app.
		/// </summary>
		/// <param name="app">The app.</param>
		public override void Run(GameApplication app)
		{
			Initialize(app);
			GameLoop(app);
		}

		/// <summary>
		/// Initializes the specified app.
		/// </summary>
		/// <param name="app">The app.</param>
		protected virtual void Initialize(GameApplication app)
		{
			Tutano.ApplyCustomConfigurators();
			app.Configure(Tutano.Configuration);
			Tutano.InitializeGameStates();
		}

		/// <summary>
		/// Games the loop.
		/// </summary>
		/// <param name="app">The app.</param>
		protected virtual void GameLoop(GameApplication app)
		{
			LoadScripts();

			while (app.IsRunning) {
				app.BeginScene();
				{
					foreach (var gameLogic in GameLogics) {
						gameLogic.Update(app.Timer);
					}

					IGameState currentState = app.StateMachine.Current;

					if (currentState == null)
						break;

					foreach (var gameObject in GameObjects) {
						gameObject.Update(app.Timer);
					}

					currentState.Update(app.Timer);
				}
				app.EndScene();
			}
		}

		/// <summary>
		/// Loads the scripts.
		/// </summary>
		private void LoadScripts()
		{
			var loadableScripts = Tutano.GameLogicScripts.Union(Tutano.GameObjectScripts).AsParallel();

			foreach (var loadableScript in loadableScripts) {
				loadableScript.LoadOrExecute();
			}

			GameLogics = Tutano.GameLogicScripts.SelectMany(x => x.FindServices<IGameLogic>()).ToArray();
			GameObjects = Tutano.GameObjectScripts.SelectMany(x => x.FindServices<IGameObject>()).ToArray();
		}

		/// <summary>
		/// Gets or sets the game objects.
		/// </summary>
		/// <value>The game objects.</value>
		private IGameObject[] GameObjects { get; set; }

		/// <summary>
		/// Gets or sets the game logics.
		/// </summary>
		/// <value>The game logics.</value>
		private IGameLogic[] GameLogics { get;  set; }
	}
}