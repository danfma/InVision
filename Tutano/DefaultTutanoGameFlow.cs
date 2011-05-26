using InVision.Framework;

namespace Tutano
{
	public class DefaultTutanoGameFlow : TutanoGameFlow
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="DefaultTutanoGameFlow"/> class.
		/// </summary>
		/// <param name="tutanoApp">The tutano app.</param>
		public DefaultTutanoGameFlow(TutanoApplication tutanoApp)
			: base(tutanoApp)
		{
		}

		/// <summary>
		/// Runs the specified app.
		/// </summary>
		/// <param name="app">The app.</param>
		public override void Run(GameApplication app)
		{
			TutanoApp.ApplyCustomConfigurators();
			TutanoApp.LoadGameStates();

			app.Configure(TutanoApp.Configuration);

			TutanoApp.InitializeGameStates();

			while (app.IsRunning)
			{
				app.BeginScene();
				{
					var currentState = app.StateMachine.Current;

					if (currentState == null)
						break;

					currentState.Update(app.Timer);
				}
				app.EndScene();
			}
		}
	}
}