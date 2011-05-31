import System
import InVision
import InVision.GameMath
import Karel

world = KarelWorld(4, 4) // 4 x 4 units		
world.AddBlockAt(3, 1)
world.AddBlockAt(2, 2)
world.AddBlockAt(3, 2)
world.AddBeeperAt(3, 3)
world.SetDepositAt(0, 3)
world.SetCheckpointAt(0, 3)
world.SetKarelAt(3, 0, KarelDirection.East)
world.Save()
