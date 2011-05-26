import Karel;

class MyKarel (KarelRobot):
	def TurnRight():
		this.TurnLeft()
		this.TurnLeft()
		this.TurnLeft()

	def TurnBack():
		TurnLeft()
		TurnLeft()

World.SetKarelModel(MyKarel)

karel = World.GetKarel() as MyKarel
karel.TurnOn()
karel.TurnLeft()
karel.Move()
karel.Move()
karel.TurnRight()
karel.Move()
karel.Move()
karel.Move()
karel.TurnRight()
karel.Move()
karel.Move()
karel.PickBeeper()
karel.TurnBack()
karel.Move()
karel.Move()
karel.Move()
karel.PutBeeper()
karel.TurnOff()
