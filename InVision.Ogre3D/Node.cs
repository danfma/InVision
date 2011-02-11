using System;
using InVision.Ogre3D.Native;
using Mono.GameMath;

namespace InVision.Ogre3D
{
	public class Node : Handle
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Node"/> class.
		/// </summary>
		/// <param name="pSelf">The p self.</param>
		/// <param name="ownsHandle">if set to <c>true</c> [owns handle].</param>
		public Node(IntPtr pSelf, bool ownsHandle)
			: base(pSelf, ownsHandle)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Node"/> class.
		/// </summary>
		/// <param name="ownsHandle">if set to <c>true</c> [owns handle].</param>
		public Node(bool ownsHandle)
			: base(ownsHandle)
		{
		}

		/// <summary>
		/// 	Releases the specified pointer to the unmanaged object.
		/// </summary>
		/// <param name = "pSelf">The pointer to the unmanaged object.</param>
		/// <returns></returns>
		protected override bool Release(IntPtr pSelf)
		{
			return true;
		}

		/// <summary>
		/// Gets the name of the node. 
		/// </summary>
		/// <value>The name.</value>
		public string Name
		{
			get { return NativeNode.GetName(handle); }
		}

		/// <summary>
		/// Gets this node's parent (NULL if this is the root). 
		/// </summary>
		/// <value>The parent.</value>
		public Node Parent
		{
			get { return NativeNode.GetParent(handle); }
		}

		/// <summary>
		/// Gets or sets the orientation of this node via a quaternion..
		/// </summary>
		/// <value>The orientation.</value>
		public Quaternion Orientation
		{
			get { return NativeNode.GetOrientation(handle); }
			set { NativeNode.SetOrientation(handle, value); }
		}

		/// <summary>
		/// Resets the nodes orientation (local axes as world axes, no rotation).
		/// </summary>
		public void ResetOrientation()
		{
			NativeNode.ResetOrientation(handle);
		}

		/// <summary>
		/// Gets or sets the position of the node relative to it's parent.
		/// </summary>
		/// <value>The position.</value>
		public Vector3 Position
		{
			get { return NativeNode.GetPosition(handle); }
			set { NativeNode.SetPosition(handle); }
		}

		/// <summary>
		/// Gets or sets the scale the scaling factor applied to this node. .
		/// </summary>
		/// <value>The scale.</value>
		public Vector3 Scale
		{
			get { return NativeNode.GetScale(handle); }
			set { NativeNode.SetScale(handle, value); }
		}
	}
}