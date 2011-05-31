using System;
using InVision.Framework;
using InVision.Framework.States;
using InVision.Ogre;

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
			Tutano.LoadGameStates();
			app.Configure(Tutano.Configuration);
			Tutano.InitializeGameStates();
			ConfigFile.LoadResources("Config/Ogre/resources.cfg");
		}

		/// <summary>
		/// Games the loop.
		/// </summary>
		/// <param name="app">The app.</param>
		protected virtual void GameLoop(GameApplication app)
		{
			while (app.IsRunning) {
				app.BeginScene();
				{
					IGameState currentState = app.StateMachine.Current;

					if (currentState == null)
						break;

					currentState.Update(app.Timer);
				}
				app.EndScene();
			}
		}
	}
}