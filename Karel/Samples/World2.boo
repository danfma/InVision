import Karel
import InVision.GameMath

class WorldCreator1 (IKarelWorldCreator):
	def KarelWorld Create() as KarelWorld:
		world = KarelWorld(4, 4) // 4 x 4 units
		
		world.AddBlockAt(3, 1)
		world.AddBlockAt(2, 2)
		world.AddBlockAt(3, 2)

		world.AddBeeperAt(3, 3, Color.Red)
		wolrd.AddBeeperAt(0, 0, Color.Blue)

		world.AddDepositAt(0, 2, Color.Blue)
		world.AddDepositAt(1, 3, Color.Red)

		world.AddCheckpointAt(0, 3)

		world.SetKarelAt(3, 0, KarelDirection.East)

		return world
