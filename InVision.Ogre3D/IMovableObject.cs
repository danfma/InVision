namespace InVision.Ogre3D
{
	public interface IMovableObject : IAnimableObject, IShadowCaster
	{
		/// <summary>
		/// 	Gets the name.
		/// </summary>
		/// <value>The name.</value>
		string Name { get; }

		/// <summary>
		/// 	Gets the type of the movable.
		/// </summary>
		/// <value>The type of the movable.</value>
		string MovableType { get; }

		/// <summary>
		/// 	Gets the parent node.
		/// </summary>
		/// <value>The parent node.</value>
		//Node ParentNode { get; }

		/// <summary>
		/// 	Gets the parent scene node.
		/// </summary>
		/// <value>The parent scene node.</value>
		//SceneNode ParentSceneNode { get; }

		/// <summary>
		/// 	Gets a value indicating whether this instance is parent tag point.
		/// </summary>
		/// <value>
		/// 	<c>true</c> if this instance is parent tag point; otherwise, <c>false</c>.
		/// </value>
		bool IsParentTagPoint { get; }

		/// <summary>
		/// 	Gets a value indicating whether this instance is attached.
		/// </summary>
		/// <value>
		/// 	<c>true</c> if this instance is attached; otherwise, <c>false</c>.
		/// </value>
		bool IsAttached { get; }

		/// <summary>
		/// 	Gets a value indicating whether this instance is in scene.
		/// </summary>
		/// <value>
		/// 	<c>true</c> if this instance is in scene; otherwise, <c>false</c>.
		/// </value>
		bool IsInScene { get; }

		/// <summary>
		/// 	Gets the bounding radius.
		/// </summary>
		/// <value>The bounding radius.</value>
		float BoundingRadius { get; }

		/// <summary>
		/// 	Gets or sets a value indicating whether this <see cref = "IMovableObject" /> is visible.
		/// </summary>
		/// <value><c>true</c> if visible; otherwise, <c>false</c>.</value>
		bool Visible { get; set; }

		/// <summary>
		/// 	Gets or sets the rendering distance.
		/// </summary>
		/// <value>The rendering distance.</value>
		float RenderingDistance { get; set; }

		/// <summary>
		/// 	Detaches from parent.
		/// </summary>
		void DetachFromParent();

		/// <summary>
		/// 	Gets the bounding box.
		/// </summary>
		/// <value>The bounding box.</value>
		//AxisAlignedBox GetBoundingBox();

		/// <summary>
		/// 	Gets the world bounding box.
		/// </summary>
		/// <param name = "derive">if set to <c>true</c> [derive].</param>
		/// <returns></returns>
		//AxisAlignedBox GetWorldBoundingBox(bool derive = false);

		/// <summary>
		/// 	Gets the world bounding sphere.
		/// </summary>
		/// <param name = "derive">if set to <c>true</c> [derive].</param>
		/// <returns></returns>
		//Sphere GetWorldBoundingSphere(bool derive = false);
	}
}