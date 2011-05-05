using System;
using System.Runtime.InteropServices;
using InVision.GameMath;

namespace InVision.Ogre.Native
{
	internal sealed class NativeOgreNode : PlatformInvoke
	{
		[DllImport(Library, EntryPoint = "node_get_name")]
		[return: MarshalAs(UnmanagedType.LPStr)]
		public static extern IntPtr _GetName(IntPtr pNode);

		/// <summary>
		/// 	Gets the name.
		/// </summary>
		/// <param name = "pNode">The p node.</param>
		/// <returns></returns>
		public static string GetName(IntPtr pNode)
		{
			return _GetName(pNode).AsConstString();
		}

		[DllImport(Library, EntryPoint = "node_get_parent")]
		public static extern IntPtr GetParent(IntPtr pNode);

		/// <summary>
		/// 	Gets the parent node.
		/// </summary>
		/// <param name = "pNode">The p node.</param>
		/// <returns></returns>
		public static Node GetParentNode(IntPtr pNode)
		{
			return GetParent(pNode).AsHandle(ptr => new Node(ptr, false));
		}

		[DllImport(Library, EntryPoint = "node_get_orientation")]
		public static extern Quaternion GetOrientation(IntPtr pNode);

		[DllImport(Library, EntryPoint = "node_set_orientation")]
		public static extern void SetOrientation(IntPtr pNode, Quaternion orientation);

		[DllImport(Library, EntryPoint = "node_reset_orientation")]
		public static extern void ResetOrientation(IntPtr pNode);

		[DllImport(Library, EntryPoint = "node_get_position")]
		public static extern Vector3 GetPosition(IntPtr pNode);

		[DllImport(Library, EntryPoint = "node_set_position")]
		public static extern void SetPosition(IntPtr pNode, Vector3 position);

		[DllImport(Library, EntryPoint = "node_get_scale")]
		public static extern Vector3 GetScale(IntPtr pNode);

		[DllImport(Library, EntryPoint = "node_set_scale")]
		public static extern void SetScale(IntPtr pNode, Vector3 position);

		[DllImport(Library, EntryPoint = "node_get_inherit_orientation")]
		public static extern bool GetInheritOrientation(IntPtr pNode);

		[DllImport(Library, EntryPoint = "node_set_inherit_orientation")]
		public static extern void SetInheritOrientation(IntPtr pNode, bool value);

		[DllImport(Library, EntryPoint = "node_get_inherit_scale")]
		public static extern bool GetInheritScale(IntPtr pNode);

		[DllImport(Library, EntryPoint = "node_set_inherit_scale")]
		public static extern void SetInheritScale(IntPtr pNode, bool value);

		[DllImport(Library, EntryPoint = "node_scale")]
		public static extern void Scale(IntPtr pNode, Vector3 scale);

		[DllImport(Library, EntryPoint = "node_scale3f")]
		public static extern void Scale(IntPtr pNode, float x, float y, float z);

		[DllImport(Library, EntryPoint = "node_translate")]
		public static extern void Translate(IntPtr pNode, Vector3 direction, TransformSpace relative);

		[DllImport(Library, EntryPoint = "node_translate3f")]
		public static extern void Translate(IntPtr pNode, float x, float y, float z, TransformSpace relative);
	}
}