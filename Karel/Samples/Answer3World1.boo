import Karel;

class MyKarel (KarelRobot):
	def TurnRight():
		this.TurnLeft()
		this.TurnLeft()
		this.TurnLeft()

	def TurnBack():
		TurnLeft()
		TurnLeft()

	def Move(steps):
		for step in range(0, steps):
			Move()

World.SetKarelModel(MyKarel)

karel = World.GetKarel() as MyKarel
karel.TurnOn()
karel.TurnLeft()
karel.Move(2)
karel.TurnRight()
karel.Move(3)
karel.TurnRight()
karel.Move(2)
karel.PickBeeper()
karel.TurnBack()
karel.Move(3)
karel.PutBeeper()
karel.TurnOff()
