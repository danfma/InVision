using System;
using System.Collections.Generic;
using InVision.GameMath;
using InVision.Ogre;

namespace Karel
{
	public class Space : KarelComponent
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Space"/> class.
		/// </summary>
		public Space()
		{
			AllowedBeeperColors = new List<Color>();
		}

		/// <summary>
		/// Gets or sets the position.
		/// </summary>
		/// <value>The position.</value>
		public override Vector3 Position
		{
			get
			{
				if (SceneNode == null)
					return base.Position;

				return SceneNode.Position;
			}
			set
			{
				if (SceneNode == null)
					base.Position = value;
				else
					SceneNode.Position = value;
			}
		}

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="Space"/> is checkpoint.
		/// </summary>
		/// <value><c>true</c> if checkpoint; otherwise, <c>false</c>.</value>
		public bool Checkpoint { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="Space"/> is deposit.
		/// </summary>
		/// <value><c>true</c> if deposit; otherwise, <c>false</c>.</value>
		public bool Deposit { get; set; }

		/// <summary>
		/// Gets or sets the allowed beeper colors.
		/// </summary>
		/// <value>The allowed beeper colors.</value>
		public List<Color> AllowedBeeperColors { get; private set; }

		/// <summary>
		/// Gets or sets a value indicating whether this instance has block.
		/// </summary>
		/// <value><c>true</c> if this instance has block; otherwise, <c>false</c>.</value>
		public bool HasBlock { get; private set; }

		/// <summary>
		/// Gets or sets a value indicating whether this instance has beeper.
		/// </summary>
		/// <value>
		/// 	<c>true</c> if this instance has beeper; otherwise, <c>false</c>.
		/// </value>
		public bool HasBeeper { get; private set; }

		/// <summary>
		/// Tries the add.
		/// </summary>
		/// <param name="childName">Name of the child.</param>
		/// <param name="child">The child.</param>
		/// <returns></returns>
		public bool TryAdd(string childName, KarelComponent child)
		{
			bool added = false;

			if (child is Beeper) {
				if (HasBeeper)
					return false;

				Add(childName, child);
				HasBeeper = true;
				added = true;
			}

			if (child is Block) {
				if (HasBlock)
					return false;

				Add(childName, child);
				HasBlock = true;
				added = true;
			}

			if (!added)
				Add(childName, child);

			return true;
		}

		/// <summary>
		/// Initializes the self.
		/// </summary>
		/// <param name="app">The app.</param>
		protected override void InitializeSelf(InVision.Framework.GameApplication app)
		{
			dynamic ogre = GameApplication.Variables.Ogre;

			var sceneManager = (SceneManager)ogre.SceneManager;
			var worldSceneNode = (SceneNode)StateVariables.WorldSceneNode;

			var plane = sceneManager.CreateEntity("Plane.mesh");
			SceneNode = worldSceneNode.CreateChildSceneNode();
			SceneNode.AttachObject(plane);
			SceneNode.Position = new Vector3(WorldPosition.X, 0, WorldPosition.Y);
			//SceneNode.Scale = new Vector3(0.45f, 1, 0.45f);
		}
	}
}