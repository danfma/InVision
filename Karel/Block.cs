using System;
using InVision.Framework;
using InVision.GameMath;
using InVision.Ogre;

namespace Karel
{
	public class Block : KarelComponent
	{
		/// <summary>
		/// Initializes the specified app.
		/// </summary>
		/// <param name="app">The app.</param>
		public override void Initialize(GameApplication app)
		{
			Entity block = SceneManager.CreateEntity("Block.mesh");

			SceneNode = Parent.SceneNode.CreateChildSceneNode();
			//SceneNode.Position = new Vector3(0.5f, 0.5f, 0.5f);
			SceneNode.AttachObject(block);
		}
	}
}