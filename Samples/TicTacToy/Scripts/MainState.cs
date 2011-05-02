using InVision;
using InVision.Framework;

namespace TicTacToy
{
	public class MainState : GameState
	{
		public override void Initialize ()
		{
			base.Initialize ();
			
			EnableDevice ("mouse", DeviceType.Mouse);
			EnableDevice ("keyboard", DeviceType.Keyboard);
			
			CreateComponent<Table> ("table");
		}

		public override void Terminate()
		{
			DisableDevice("mouse");
			DisableDevice("keyboard");
			
			base.Terminate();
		}
	}
}

