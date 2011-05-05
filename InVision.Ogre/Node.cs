using System;
using InVision.GameMath;
using InVision.Native;
using InVision.Ogre.Native;

namespace InVision.Ogre
{
	/// <summary>
	/// 	Class representing a general-purpose node an articulated scene graph.
	/// </summary>
	/// <remarks>
	/// 	A node in the scene graph is a node in a structured tree. A node contains information about the transformation which 
	/// 	will apply to it and all of it's children. Child nodes can have transforms of their own, which are combined with their parent's transformations. 
	/// 	This is an abstract class - concrete classes are based on this for specific purposes, e.g. <see cref = "SceneNode" />, <see cref = "Bone" />
	/// </remarks>
	public class Node : Handle
	{
		/// <summary>
		/// 	Initializes a new instance of the <see cref = "Node" /> class.
		/// </summary>
		/// <param name = "pSelf">The p self.</param>
		/// <param name = "ownsHandle">if set to <c>true</c> [owns handle].</param>
		public Node(IntPtr pSelf, bool ownsHandle)
			: base(pSelf, ownsHandle)
		{
		}

		/// <summary>
		/// 	Initializes a new instance of the <see cref = "Node" /> class.
		/// </summary>
		/// <param name = "ownsHandle">if set to <c>true</c> [owns handle].</param>
		public Node(bool ownsHandle)
			: base(ownsHandle)
		{
		}

		/// <summary>
		/// 	Gets the name of the node.
		/// </summary>
		/// <value>The name.</value>
		public string Name
		{
			get { return NativeOgreNode.GetName(handle); }
		}

		/// <summary>
		/// 	Gets this node's parent (NULL if this is the root).
		/// </summary>
		/// <value>The parent.</value>
		public Node Parent
		{
			get { return NativeOgreNode.GetParentNode(handle); }
		}

		/// <summary>
		/// 	Gets or sets the orientation of this node via a quaternion..
		/// </summary>
		/// <value>The orientation.</value>
		public Quaternion Orientation
		{
			get { return NativeOgreNode.GetOrientation(handle); }
			set { NativeOgreNode.SetOrientation(handle, value); }
		}

		/// <summary>
		/// 	Gets or sets the position of the node relative to it's parent.
		/// </summary>
		/// <value>The position.</value>
		public Vector3 Position
		{
			get { return NativeOgreNode.GetPosition(handle); }
			set { NativeOgreNode.SetPosition(handle, value); }
		}

		/// <summary>
		/// 	Gets or sets the scale the scaling factor applied to this node. .
		/// </summary>
		/// <value>The scale.</value>
		public Vector3 Scale
		{
			get { return NativeOgreNode.GetScale(handle); }
			set { NativeOgreNode.SetScale(handle, value); }
		}

		/// <summary>
		/// 	Tells the node whether it should inherit orientation from it's parent node.
		/// </summary>
		/// <remarks>
		/// 	Orientations, unlike other transforms, are not always inherited by child nodes. Whether or
		/// 	not orientations affect the orientation of the child nodes depends on the setInheritOrientation option of the child. 
		/// 	In some cases you want a orientating of a parent node to apply to a child node 
		/// 	(e.g. where the child node is a part of the same object, so you want it to be the same relative orientation based on 
		/// 	the parent's orientation), but not in other cases (e.g. where the child node is just for positioning another object, 
		/// 	you want it to maintain it's own orientation). The default is to inherit as with other transforms
		/// </remarks>
		/// <value>if set to <c>true</c> this node's orientation will be affected by its parent's orientation. If <c>false</c>, it will not be affected.</value>
		public bool InheritOrientation
		{
			set { NativeOgreNode.SetInheritOrientation(handle, value); }
			get { return NativeOgreNode.GetInheritOrientation(handle); }
		}

		/// <summary>
		/// 	Gets or sets a value indicating whether [inherit scale].
		/// </summary>
		/// <value><c>true</c> if [inherit scale]; otherwise, <c>false</c>.</value>
		public bool InheritScale
		{
			get { return NativeOgreNode.GetInheritScale(handle); }
			set { NativeOgreNode.SetInheritScale(handle, value); }
		}

		/// <summary>
		/// 	Releases the specified pointer to the unmanaged object.
		/// </summary>
		/// <returns></returns>
		protected override void ReleaseValidHandle()
		{
		}

		/// <summary>
		/// 	Resets the nodes orientation (local axes as world axes, no rotation).
		/// </summary>
		public void ResetOrientation()
		{
			NativeOgreNode.ResetOrientation(handle);
		}

		/// <summary>
		/// 	Scales the node, combining it's current scale with the passed in scaling factor.
		/// </summary>
		/// <param name = "scale">The scale.</param>
		/// <remarks>
		/// 	This method applies an extra scaling factor to the node's existing scale,
		/// 	(unlike setScale which overwrites it) combining it's current scale with the new one. E.g. calling this method twice with Vector3(2,2,2)
		/// 	would have the same effect as setScale(Vector3(4,4,4)) if the existing scale was 1.
		/// 	Note that like rotations, scalings are oriented around the node's origin.
		/// </remarks>
		public void ScaleBy(Vector3 scale)
		{
			NativeOgreNode.Scale(handle, scale);
		}

		/// <summary>
		/// 	Scales the node, combining it's current scale with the passed in scaling factor.
		/// </summary>
		/// <param name = "x">The x.</param>
		/// <param name = "y">The y.</param>
		/// <param name = "z">The z.</param>
		/// <remarks>
		/// 	This method applies an extra scaling factor to the node's existing scale, (unlike setScale which overwrites it)
		/// 	combining it's current scale with the new one. E.g. calling this method twice with Vector3(2,2,2) would have the same
		/// 	effect as setScale(Vector3(4,4,4)) if the existing scale was 1.
		/// 	Note that like rotations, scalings are oriented around the node's origin.
		/// </remarks>
		public void ScaleBy(float x, float y, float z)
		{
			NativeOgreNode.Scale(handle, x, y, z);
		}

		/// <summary>
		/// 	Moves the node along the Cartesian axes. This method moves the node by the supplied vector along the world Cartesian axes, i.e. along world x,y,z
		/// </summary>
		/// <param name = "direction">The direction.</param>
		/// <param name = "relativeTo">The space which this transform is relative to. .</param>
		public void Translate(Vector3 direction, TransformSpace relativeTo = TransformSpace.Parent)
		{
			NativeOgreNode.Translate(handle, direction, relativeTo);
		}

		/// <summary>
		/// 	Moves the node along the Cartesian axes. This method moves the node by the supplied vector along the world Cartesian axes, i.e. along world x,y,z
		/// </summary>
		/// <param name = "x">The x.</param>
		/// <param name = "y">The y.</param>
		/// <param name = "z">The z.</param>
		/// <param name = "relativeTo">The relative to.</param>
		public void Translate(float x, float y, float z, TransformSpace relativeTo = TransformSpace.Parent)
		{
			NativeOgreNode.Translate(handle, x, y, z, relativeTo);
		}
	}
}