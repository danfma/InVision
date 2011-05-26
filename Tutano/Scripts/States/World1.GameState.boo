import System
import System.Diagnostics
import InVision
import InVision.GameMath
import InVision.Framework
import Karel

class World1GameState (GameState):
	def constructor():
		super("World1")
	
	def Initialize():
		Console.WriteLine("World1 Initialized")

		world = KarelWorld(4, 4) // 4 x 4 units		
		world.AddBlockAt(3, 1)
		world.AddBlockAt(2, 2)
		world.AddBlockAt(3, 2)
		world.AddBeeperAt(3, 3)
		world.AddDepositAt(0, 3)
		world.SetCheckpointAt(0, 3)
		world.SetKarelAt(3, 0, KarelDirection.East)
		Components.Add(world)
