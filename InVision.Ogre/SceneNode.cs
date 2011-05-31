using System;
using InVision.GameMath;
using InVision.Ogre.Native;

namespace InVision.Ogre
{
	public class SceneNode : Node
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="SceneNode"/> class.
		/// </summary>
		/// <param name="nativeInstance">The native instance.</param>
		public SceneNode(ISceneNode nativeInstance)
			: base(nativeInstance)
		{
		}

		/// <summary>
		/// Gets the native.
		/// </summary>
		/// <value>The native.</value>
		public new ISceneNode Native
		{
			get { return (ISceneNode)base.Native; }
		}

		/// <summary>
		/// Nums the attached objects.
		/// </summary>
		/// <value></value>
		public ushort NumAttachedObjects
		{
			get { return Native.NumAttachedObjects(); }
		}

		/// <summary>
		/// Gets or sets the position.
		/// </summary>
		/// <value>The position.</value>
		public Vector3 Position
		{
			get { return Native.GetPosition(); }
			set { Native.SetPosition(value); }
		}

		/// <summary>
		/// Gets or sets the scale.
		/// </summary>
		/// <value>The scale.</value>
		public Vector3 Scale
		{
			get { return Native.GetScale(); }
			set { Native.SetScale(value); }
		}

		/// <summary>
		/// Gets or sets the orientation.
		/// </summary>
		/// <value>The orientation.</value>
		public Quaternion Orientation
		{
			get { return Native.GetOrientation(); }
			set { Native.SetOrientation(value); }
		}

		/// <summary>
		/// Creates the child scene node.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <param name="translate">The translate.</param>
		/// <param name="rotate">The rotate.</param>
		/// <returns></returns>
		public SceneNode CreateChildSceneNode(string name, Vector3 translate, Quaternion rotate)
		{
			return GetOrCreateOwner(
				Native.CreateChildSceneNode(name, translate, rotate),
				native => new SceneNode(native));
		}

		/// <summary>
		/// Creates the child scene node.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <param name="translate">The translate.</param>
		/// <returns></returns>
		public SceneNode CreateChildSceneNode(string name, Vector3 translate)
		{
			return GetOrCreateOwner(
				Native.CreateChildSceneNode(name, translate),
				native => new SceneNode(native));
		}

		/// <summary>
		/// Creates the child scene node.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <returns></returns>
		public SceneNode CreateChildSceneNode(string name)
		{
			return GetOrCreateOwner(
				Native.CreateChildSceneNode(name),
				native => new SceneNode(native));
		}

		/// <summary>
		/// Creates the child scene node.
		/// </summary>
		/// <param name="translate">The translate.</param>
		/// <param name="rotate">The rotate.</param>
		/// <returns></returns>
		public SceneNode CreateChildSceneNode(Vector3 translate, Quaternion rotate)
		{
			return GetOrCreateOwner(
				Native.CreateChildSceneNode(translate, rotate),
				native => new SceneNode(native));
		}

		/// <summary>
		/// Creates the child scene node.
		/// </summary>
		/// <param name="translate">The translate.</param>
		/// <returns></returns>
		public SceneNode CreateChildSceneNode(Vector3 translate)
		{
			return GetOrCreateOwner(
				Native.CreateChildSceneNode(translate),
				native => new SceneNode(native));
		}

		/// <summary>
		/// Creates the child scene node.
		/// </summary>
		/// <returns></returns>
		public SceneNode CreateChildSceneNode()
		{
			return GetOrCreateOwner(
				Native.CreateChildSceneNode(),
				native => new SceneNode(native));
		}

		/// <summary>
		/// Detaches all objects.
		/// </summary>
		public void DetachAllObjects()
		{
			Native.DetachAllObjects();
		}

		/// <summary>
		/// Detaches the object.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <returns></returns>
		public MovableObject DetachObject(string name)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Detaches the object.
		/// </summary>
		/// <param name="movableObject">The movable object.</param>
		public void DetachObject(MovableObject movableObject)
		{
			Native.DetachObject(movableObject.Native);
		}

		/// <summary>
		/// Detaches the object.
		/// </summary>
		/// <param name="index">The index.</param>
		/// <returns></returns>
		public MovableObject DetachObject(ushort index)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Gets the attached object.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <returns></returns>
		public MovableObject GetAttachedObject(string name)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Gets the attached object.
		/// </summary>
		/// <param name="index">The index.</param>
		/// <returns></returns>
		public MovableObject GetAttachedObject(ushort index)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Attaches the object.
		/// </summary>
		/// <param name="obj">The obj.</param>
		public void AttachObject(MovableObject obj)
		{
			Native.AttachObject(obj.Native);
		}
	}
}