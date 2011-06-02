using System;
using System.Linq;
using InVision.FMod;
using InVision.FMod.Native;
using InVision.Framework;
using InVision.Framework.Components;
using InVision.GameMath;
using InVision.Ogre;
using Karel.Flow;

namespace Karel
{
	public class World : KarelComponent
	{
		private Space[,] _spaces;

		#region Construction and Destruction

		/// <summary>
		/// Initializes a new instance of the <see cref="World"/> class.
		/// </summary>
		/// <param name="rows">The rows.</param>
		/// <param name="columns">The columns.</param>
		public World(int rows, int columns)
		{
			Rows = rows;
			Columns = columns;
			_spaces = new Space[rows, columns];

			for (int row = 0; row < rows; row++) {
				for (int col = 0; col < columns; col++) {
					string spaceName = string.Format("KarelWorldSpace_{0}x{1}", row, col);

					var space = _spaces[row, col] = new Space();
					space.WorldPosition = new Point(row, col);
					Add(spaceName, _spaces[row, col]);
				}
			}
		}

		/// <summary>
		/// Releases unmanaged and - optionally - managed resources
		/// </summary>
		/// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				_spaces = null;
			}

			base.Dispose(disposing);
		}

		#endregion

		/// <summary>
		/// Gets or sets the rows.
		/// </summary>
		/// <value>The rows.</value>
		public int Rows { get; private set; }

		/// <summary>
		/// Gets or sets the columns.
		/// </summary>
		/// <value>The columns.</value>
		public int Columns { get; private set; }

		/// <summary>
		/// Gets or sets the <see cref="Space"/> with the specified x.
		/// </summary>
		/// <value></value>
		public Space this[int x, int y]
		{
			get { return _spaces[x, y]; }
			set { _spaces[x, y] = value; }
		}

		/// <summary>
		/// Gets or sets the karel.
		/// </summary>
		/// <value>The karel.</value>
		public KarelRobot Karel { get; private set; }

		/// <summary>
		/// Adds the child at space.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="x">The x.</param>
		/// <param name="y">The y.</param>
		/// <returns></returns>
		protected bool AddChildAtSpace<T>(int x, int y) where T : KarelComponent, new()
		{
			var child = new T();
			string childName = string.Format("{0}_{1}x{2}", typeof(T).Name, x, y);

			return this[x, y].TryAdd(childName, child);
		}

		/// <summary>
		/// Adds the block at (x, y).
		/// </summary>
		/// <param name="x">The x.</param>
		/// <param name="y">The y.</param>
		public bool AddBlockAt(int x, int y)
		{
			return AddChildAtSpace<Block>(x, y);
		}

		/// <summary>
		/// Adds the beeper at.
		/// </summary>
		/// <param name="x">The x.</param>
		/// <param name="y">The y.</param>
		/// <returns></returns>
		public bool AddBeeperAt(int x, int y)
		{
			return AddChildAtSpace<Beeper>(x, y);
		}

		/// <summary>
		/// Sets the deposit at.
		/// </summary>
		/// <param name="x">The x.</param>
		/// <param name="y">The y.</param>
		public void SetDepositAt(int x, int y)
		{
			SetDepositAt(x, y, Color.Red);
		}

		/// <summary>
		/// Sets the deposit at.
		/// </summary>
		/// <param name="x">The x.</param>
		/// <param name="y">The y.</param>
		/// <param name="allowedBeeperColor">Color of the allowed beeper.</param>
		/// <returns></returns>
		public void SetDepositAt(int x, int y, Color allowedBeeperColor)
		{
			Space space = this[x, y];

			space.Deposit = true;
			space.AllowedBeeperColors.Add(allowedBeeperColor);
		}

		/// <summary>
		/// Sets the checkpoint at.
		/// </summary>
		/// <param name="x">The x.</param>
		/// <param name="y">The y.</param>
		public void SetCheckpointAt(int x, int y)
		{
			Space space = this[x, y];

			space.Checkpoint = true;
		}

		/// <summary>
		/// Sets the karel at.
		/// </summary>
		/// <param name="x">The x.</param>
		/// <param name="y">The y.</param>
		/// <param name="direction">The direction.</param>
		public void SetKarelAt(int x, int y, KarelDirection direction)
		{
			const string karelChildName = "KarelRobot";

			var karel = (KarelRobot)GetOrAdd(karelChildName, key => new KarelRobot());
			karel.WorldPosition = new Point(x, y);
			karel.Direction = direction;
			Karel = karel;
		}

		/// <summary>
		/// Updates the self.
		/// </summary>
		/// <param name="elapsedTime">The elapsed time.</param>
		protected override void UpdateSelf(ElapsedTime elapsedTime)
		{

		}

		/// <summary>
		/// Saves this instance.
		/// </summary>
		public void Save()
		{
			KarelGameFlow.Register(this);
		}

		/// <summary>
		/// Initializes the self.
		/// </summary>
		/// <param name="app">The app.</param>
		protected override void InitializeSelf(GameApplication app)
		{
			SceneNode = SceneManager.RootSceneNode.CreateChildSceneNode("KarelWorld");
			StateVariables.WorldSceneNode = SceneNode;

			InitializeSound();
		}

		/// <summary>
		/// Initializes the sound.
		/// </summary>
		private void InitializeSound()
		{
			var audioSystem = (AudioSystem)GameApplication.Variables.AudioSystem;
			var sound = audioSystem.CreateSound("Content/Sounds/BgSound.mp3",
												MODE.HARDWARE | MODE._2D | MODE.CREATESTREAM | MODE.OPENONLY);
			var channel = sound.PlaySound(CHANNELINDEX.FREE, false);

			GameApplication.Variables.BgSound = sound;
			GameApplication.Variables.Channel = channel;
		}
	}
}