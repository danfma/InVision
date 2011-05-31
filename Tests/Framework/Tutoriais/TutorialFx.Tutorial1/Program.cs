using System;
using System.IO;
using InVision.GameMath;
using InVision.TutorialFx;

namespace TutorialFx.Tutorial1
{
	public class Program : BaseApplication
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Program"/> class.
		/// </summary>
		public Program()
		{
		}

		/// <summary>
		/// Creates the scene.
		/// </summary>
		protected override void CreateScene()
		{
			//var ogreHead = SceneMgr.CreateEntity("Head", "ogrehead.mesh");

			//var headNode = SceneMgr.RootSceneNode.CreateChildSceneNode();
			//headNode.AttachObject(ogreHead);

			//SceneMgr.AmbientLight = new Color(0.5f, 0.5f, 0.5f);

			//var light = SceneMgr.CreateLight("MainLight");
			//light.Position = new Vector3(20, 80, 50);
		}

		/// <summary>
		/// Mains the specified args.
		/// </summary>
		/// <param name="args">The args.</param>
		private static void Main(string[] args)
		{
			var program = new Program();
			program.Go();
		}
	}
}