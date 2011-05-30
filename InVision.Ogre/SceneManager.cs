using System;
using InVision.GameMath;
using InVision.Native;
using InVision.Ogre.Native;

namespace InVision.Ogre
{
	public class SceneManager : CppWrapper<ISceneManager>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="SceneManager"/> class.
		/// </summary>
		/// <param name="nativeInstance">The native instance.</param>
		public SceneManager(ISceneManager nativeInstance)
			: base(nativeInstance)
		{
		}

		/// <summary>
		/// Clears the scene.
		/// </summary>
		public void ClearScene()
		{
			Native.ClearScene();
		}

		/// <summary>
		/// Gets or sets the ambient light.
		/// </summary>
		/// <value>The ambient light.</value>
		public Color AmbientLight
		{
			get { return Native.GetAmbientLight(); }
			set { Native.SetAmbientLight(value); }
		}

		/// <summary>
		/// Creates the camera.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <returns></returns>
		public Camera CreateCamera(string name)
		{
			return GetOrCreateOwner(
				Native.CreateCamera(name),
				native => new Camera(native));
		}

		/// <summary>
		/// Creates the entity.
		/// </summary>
		/// <param name="meshName">Name of the mesh.</param>
		/// <returns></returns>
		public Entity CreateEntity(string meshName)
		{
			return GetOrCreateOwner(
				Native.CreateEntity(meshName),
				native => new Entity(native));
		}

		/// <summary>
		/// Creates the entity.
		/// </summary>
		/// <param name="entityName">Name of the entity.</param>
		/// <param name="meshName">Name of the mesh.</param>
		/// <returns></returns>
		public Entity CreateEntity(string entityName, string meshName)
		{
			return GetOrCreateOwner(
				Native.CreateEntity(entityName, meshName),
				native => new Entity(native));
		}

		/// <summary>
		/// Gets the root scene node.
		/// </summary>
		/// <value>The root scene node.</value>
		public SceneNode RootSceneNode
		{
			get
			{
				return GetOrCreateOwner(
					Native.GetRootSceneNode(),
					native => new SceneNode(native));
			}
		}

		/// <summary>
		/// Creates the light.
		/// </summary>
		/// <returns></returns>
		public Light CreateLight()
		{
			return GetOrCreateOwner(
				Native.CreateLight(),
				native => new Light(native));
		}

		/// <summary>
		/// Creates the light.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <returns></returns>
		public Light CreateLight(string name)
		{
			return GetOrCreateOwner(
				Native.CreateLight(name),
				native => new Light(native));
		}
	}
}