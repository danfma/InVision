import InVision.OIS;

class Slot(System.ValueType):
	public Row as int
	public Column as int
	public IsValid as bool:
		get:
			return Row >= 0 and Row < Table.NumSlots and Column >= 0 and Column < Table.NumSlots

class Table (GameObject):
	public const NumSlots as int = 3
	
	private currentPlayer as int	
	private tablePositions as matrix
	private waitingPlayer as bool
	private lastPlayClick as Slot
	
	private tablePlane as Plane
	private firstMark as Plane
	private secondMark as Plane
	
	def constructor():
		tablePositions = matrix(int, NumSlots, NumSlots);
		
	protected override def Load():
		components as duck = GameState.Components
		components.mouse.ButtonPressed += OnMouseButtonPressed
		components.keyboard.KeyPressed += OnKeyboardKeyPressed
		
		surface = GameState.CreateSurface2D("surface")
		
		tablePlane = GameState.CreateComponent(typeof(Plane), "table.plane")
		tablePlane.ApplyTexture("table.png")
		surface.Attach(tablePlane)
		
		firstMark = GameState.CreateComponent(typeof(Plane), "firstMark")
		firstMark.ApplyTexture("ball.png")
		
		secondMark = GameState.CreateComponent(typeof(Plane), "secondMark")
		secondMark.ApplyTexture("x.png")
		
	protected override def Unload():
		components as duck = GameState.Components
		components.mouse.ButtonPressed -= OnMouseButtonPressed
		components.keyboard.KeyPressed -= OnKeyboardKeyPressed
		
	private def OnMouseButtonPressed(e, button):
		if button == MouseButton.Left:
			return
			
		if not waitingPlayer:
			return
			
		lastPlayClick = GetTableSlot(e.X, e.Y)
		RaiseEvent("playerDone")
		
	private def OnKeyboardKeyPressed(e):
		keyboard = GameState.Components.keyboard
		
		if keyboard.IsKeyPressed(Keys.Escape):
			GameState.Exit()
			
	override def Update(time):
		while true:
			waitingPlayer = true			
			yield WaitFor(this, "playerDone")
			waitingPlayer = false
			
			if not IsValidSlot(lastPlayClick):
				continue
				
			MarkSlot(lastPlayClick)
			
			if HasPlayerWon(lastPlayClick):
				TraceWinLine()
				yield WaitForSeconds(3)
				break
				
			currentPlayer = (currentPlayer + 1) % 2
			
		GameState.Exit()

		
	private def IsValidSlot(slot):
		return slot.IsValid and tablePositions[slot.Row, slot.Column] == 0
		
	private def MarkSlot(slot):
		tablePositions[slot.Row, slot.Column] = currentPlayer
		
		slotSpace = Point(GameState.Window.Width / NumSlots, GameState.Window.Height / NumSlots)
		start = Point(slotSpace.X / 2, slotSpace.Y / 2)
		
		mark = CreatePlayerMark()
		mark.SetPosition(
			start.X + (slot.Row * slotSpace.X),
			start.Y + (slot.Column * slotSpace.Y))
			
		tablePlane.AddChild(mark)
		
	private def TraceWinLine():
		throw NotImplementedException()
		
	private def HasPlayerWon(slot):
		throw NotImplementedException()
		
	private def GetTableSlot(clickX, clickY):
		window = GameState.Window
		row = clickX / (window.Width / NumSlots)
		col = clickY / (window.Height / NumSlots)
		
		return Slot(Row = row, Column = column)

