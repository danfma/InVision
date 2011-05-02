using System;
using InVision;
using Invision.GameMath;
using InVision.Extensions;
using InVision.Framework;
using InVision.Framework.Rendering;
using InVision.OIS;

namespace TicTacToy
{
	public class Table : GameObject
	{
		private const int NumSlots = 3;
		
		private int[,] tablePositions;		
		private bool waitingPlayer;
		private Slot lastPlayClick;
		
		private Plane tablePlane;
		private Plane firstMark;
		private Plane secondMark;
		
		public Table ()
		{
			tablePositions = new int[NumSlots, NumSlots];
		}
		
		public int CurrentPlayer {
			get;
			set;
		}
		
		protected override void Load ()
		{
			var components = GameState.Components;
			components.mouse.ButtonPressed += OnMouseButtonPressed;
			components.keyboard.KeyPressed += OnKeyboardKeyPressed;
			
			var surface = GameState.CreateSurface2D ("surface");
			
			tablePlane = GameState.CreateComponent<Plane> ("table.plane");
			tablePlane.ApplyTexture ("table.png");
			surface.Attach (tablePlane);
			
			firstMark = GameState.CreateComponent<Plane> ("firstMark");
			firstMark.ApplyTexture ("ball.png");
			
			secondMark = GameState.CreateComponent<Plane> ("secondMark");
			secondMark.ApplyTexture("x.png");
		}
		
		protected override void Unload ()
		{
			var components = GameState.Components;
			components.mouse.ButtonPressed -= OnMouseButtonPressed;
			components.keyboard.KeyPressed -= OnKeyboardKeyPressed;
		}
		
		private void OnMouseButtonPressed (MouseEvent e, MouseButton button)
		{
			if (button != MouseButton.Left)
				return;
			
			if (!waitingPlayer)
				return;
			
			lastPlayClick = GetTableSlot (e.X, e.Y);
			RaiseEvent ("playerDone");
		}
		
		private void OnKeyboardKeyPressed (KeyboardEvent e)
		{
			var keyboard = GameState ["keyboard"];
			
			if (keyboard.IsKeyPressed (Keys.Escape))
				GameState.Exit ();
		}
		
		public override IEnumerable<GameAction> Update (GameTime time)
		{
			while (true) {
				waitingPlayer = true;
				
				yield return WaitFor (this, "playerDone");
				
				waitingPlayer = false;
				
				if (!IsValidSlot (lastPlayClick))
					continue;
				
				MarkSlot (lastPlayClick);
				
				if (HasPlayerWon (lastPlayClick)) {
					TraceWinLine ();
					yield return WaitTime (3.Seconds ());
					break;
				}
				
				CurrentPlayer = (CurrentPlayer + 1) % 2;
			}
			
			GameState.Exit ();
		}
		
		private bool IsValidSlot (Slot slot)
		{
			return slot.IsValid && tablePositions [slot.Row, slot.Column] == 0;
		}
		
		private void MarkSlot (Slot slot)
		{
			tablePositions [slot.Row, slot.Column] = CurrentPlayer;
			
			Point slotSpace = new Point (
				GameState.Window.Width / NumSlots,
				GameState.Window.Height / NumSlots);
			
			Point start = new Point (
				slotSpace.X / 2,
				slotSpace.Y / 2);
			
			var mark = CreatePlayerMark ();
			mark.SetPosition (
				start.X + (slot.Row * slotSpace.X), 
				start.Y + (slot.Column * slotSpace.Y));
			
			tablePlane.AddChild (mark);
		}
		
		private Plane CreatePlayerMark()
		{
			Plane plane;
			
			if (CurrentPlayer == 0)
				plane = firstMark;
			else
				plane = secondMark;
				
			return plane.Clone()
		}
		
		private void TraceWinLine()
		{
			// traces the winner line on the table
			throw new NotImplementedException();
		}
		
		private void HasPlayerWon (Slot slot)
		{
			// checks if the player has marked a vertial line, 
			// a horizontal line, a diagonal line or a 
			// counter diagonal line
			throw new NotImplementedException ();
		}
		
		private Slot GetTableSlot (float clickX, float clickY)
		{
			var window = GameState.Window;
			int row = clickX / (int)(window.Width / NumSlots);
			int col = clickY / (int)(window.Height / NumSlots);
			
			return new Slot { Row = row, Column = col };
		}
		
		private struct Slot
		{
			public int Row, Column;
			
			public bool IsValid
			{
				get { return (Row >= 0 && Row < NumSlots) && (Column >= 0 && Column < NumSlots); }
			}
		}
	}
}

