using System;
using InVision.Extensions;
using InVision.Framework;
using InVision.Framework.Components;
using InVision.GameMath;
using System.Linq;

namespace Karel
{
	public class KarelWorld : GameComponent
	{
		private Type _karelModelType;
		private WorldSpace[,] _spaces;

		#region Construction and Destruction

		/// <summary>
		/// Initializes a new instance of the <see cref="KarelWorld"/> class.
		/// </summary>
		/// <param name="rows">The rows.</param>
		/// <param name="columns">The columns.</param>
		public KarelWorld(int rows, int columns)
		{
			_karelModelType = typeof(KarelRobot);
			_spaces = new WorldSpace[rows, columns];

			for (int i = 0; i < rows; i++)
			{
				for (int j = 0; j < columns; j++)
				{
					string spaceName = string.Format("KarelWorldSpace_{0}x{1}", i, j);

					_spaces[i, j] = new WorldSpace();
					Children.Add(spaceName, _spaces[i, j]);
				}
			}

			Instance = this;
		}

		/// <summary>
		/// Releases unmanaged and - optionally - managed resources
		/// </summary>
		/// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				Instance = null;
				_spaces = null;
				_karelModelType = null;
			}

			base.Dispose(disposing);
		}

		#endregion

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
		/// Gets or sets the instance.
		/// </summary>
		/// <value>The instance.</value>
		public static KarelWorld Instance { get; private set; }

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

			var karel = (KarelRobot)Children.GetOrAdd(karelChildName, key => _karelModelType.CreateInstance<KarelRobot>());
			karel.WorldPosition = new Point(x, y);
			Karel = karel;
		}

		/// <summary>
		/// Sets the karel model.
		/// </summary>
		/// <param name="karelType">Type of the karel.</param>
		public void SetKarelModel(Type karelType)
		{
			if (!typeof(KarelRobot).IsAssignableFrom(karelType))
				throw new InvalidOperationException("You must extends the KarelRobot Type to set the Karel Model");

			_karelModelType = karelType;
		}

		/// <summary>
		/// Updates the self.
		/// </summary>
		/// <param name="elapsedTime">The elapsed time.</param>
		protected override void UpdateSelf(ElapsedTime elapsedTime)
		{
			var remainingBeepers =
				(from child in Children.AsParallel()
				 from beeper in child.Children
				 where beeper is KarelBeeper
				 select beeper).Count();

			bool karelIsOnCheckpoint = this[Karel.WorldPosition.X, Karel.WorldPosition.Y].Checkpoint;

			if (remainingBeepers == 0 && Karel.IsOff && karelIsOnCheckpoint)
			{
				Console.WriteLine("CONGRATULATIONS!! You have won!!");
				GameApplication.Exit();
			}
		}
	}
}