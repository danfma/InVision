import System
import InVision
import InVision.GameMath
import InVision.Framework
import InVision.Framework.Config

class KarelStateConfigurator (ICustomGameStateConfigurator):
	def Configure(states as GameStateMachine):
		Console.WriteLine("Configuring Karel states");

		states.CurrentStateName = "World1"

