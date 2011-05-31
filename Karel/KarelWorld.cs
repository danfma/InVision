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
	public class KarelWorld : GameComponent
	{
		private WorldSpace[,] _spaces;
		private SceneNode _sceneNode;

		#region Construction and Destruction

		/// <summary>
		/// Initializes a new instance of the <see cref="KarelWorld"/> class.
		/// </summary>
		/// <param name="rows">The rows.</param>
		/// <param name="columns">The columns.</param>
		public KarelWorld(int rows, int columns)
		{
			Rows = rows;
			Columns = columns;
			_spaces = new WorldSpace[rows, columns];

			for (int i = 0; i < rows; i++) {
				for (int j = 0; j < columns; j++) {
					string spaceName = string.Format("KarelWorldSpace_{0}x{1}", i, j);

					var space = _spaces[i, j] = new WorldSpace();
					space.WorldPosition = new Point(i, j);
					Children.Add(spaceName, _spaces[i, j]);
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
		/// Gets or sets the <see cref="WorldSpace"/> with the specified x.
		/// </summary>
		/// <value></value>
		public WorldSpace this[int x, int y]
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
		protected bool AddChildAtSpace<T>(int x, int y) where T : KarelWorldComponent, new()
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
			return AddChildAtSpace<KarelBlock>(x, y);
		}

		/// <summary>
		/// Adds the beeper at.
		/// </summary>
		/// <param name="x">The x.</param>
		/// <param name="y">The y.</param>
		/// <returns></returns>
		public bool AddBeeperAt(int x, int y)
		{
			return AddChildAtSpace<KarelBeeper>(x, y);
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
			WorldSpace space = this[x, y];

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
			WorldSpace space = this[x, y];

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

			var karel = (KarelRobot)Children.GetOrAdd(karelChildName, key => new KarelRobot());
			karel.WorldPosition = new Point(x, y);
			Karel = karel;
		}

		/// <summary>
		/// Updates the self.
		/// </summary>
		/// <param name="elapsedTime">The elapsed time.</param>
		protected override void UpdateSelf(ElapsedTime elapsedTime)
		{
			int remainingBeepers =
				(from child in Children.AsParallel()
				 from beeper in child.Children
				 where beeper is KarelBeeper
				 select beeper).Count();

			bool karelIsOnCheckpoint = this[Karel.WorldPosition.X, Karel.WorldPosition.Y].Checkpoint;

			if (remainingBeepers == 0 && Karel.IsOff && karelIsOnCheckpoint) {
				Console.WriteLine("CONGRATULATIONS!! You have won!!");
				GameApplication.Exit();
			}
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
			dynamic ogre = GameApplication.GlobalVariables.Ogre;

			var sceneManager = (SceneManager)ogre.SceneManager;
			_sceneNode = sceneManager.RootSceneNode.CreateChildSceneNode("KarelWorld");
			StateVariables.WorldSceneNode = _sceneNode;

			InitializeSound();
		}

		/// <summary>
		/// Initializes the sound.
		/// </summary>
		private void InitializeSound()
		{
			var audioSystem = (AudioSystem)GameApplication.GlobalVariables.AudioSystem;
			var sound = audioSystem.CreateSound("Content/Sounds/BgSound.mp3",
			                                    MODE.HARDWARE | MODE._2D | MODE.CREATESTREAM | MODE.OPENONLY);
			var channel = sound.PlaySound(CHANNELINDEX.FREE, false);

			GameApplication.GlobalVariables.BgSound = sound;
			GameApplication.GlobalVariables.Channel = channel;
		}
	}
}