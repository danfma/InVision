using System.Runtime.InteropServices;
using InVision.GameMath;
using InVision.Native;

namespace InVision.Ogre.Native
{
	[OgreClass("SceneNode", BaseType = typeof(INode))]
	public interface ISceneNode : INode
	{
		[Method(Implemented = true)]
		void AttachObject(IMovableObject obj);

		[Method(Implemented = true)]
		ushort NumAttachedObjects();

		[Method(Implemented = true)]
		IMovableObject GetAttachedObject(ushort index);

		[Method(Implemented = true)]
		IMovableObject GetAttachedObject([MarshalAs(UnmanagedType.LPStr)] string name);

		[Method(Implemented = true)]
		IMovableObject DetachObject(ushort index);

		[Method(Implemented = true)]
		void DetachObject(IMovableObject movableObject);

		[Method(Implemented = true)]
		IMovableObject DetachObject([MarshalAs(UnmanagedType.LPStr)] string name);

		[Method(Implemented = true)]
		void DetachAllObjects();

		[Method(Implemented = true)]
		ISceneNode CreateChildSceneNode();

		[Method(Implemented = true)]
		ISceneNode CreateChildSceneNode(Vector3 translate);

		[Method(Implemented = true)]
		ISceneNode CreateChildSceneNode(Vector3 translate, Quaternion rotate);

		[Method(Implemented = true)]
		ISceneNode CreateChildSceneNode([MarshalAs(UnmanagedType.LPStr)] string name);

		[Method(Implemented = true)]
		ISceneNode CreateChildSceneNode([MarshalAs(UnmanagedType.LPStr)] string name, Vector3 translate);

		[Method(Implemented = true)]
		ISceneNode CreateChildSceneNode([MarshalAs(UnmanagedType.LPStr)] string name, Vector3 translate, Quaternion rotate);

		[Method(Implemented = true)]
		void SetPosition(Vector3 value);

		[Method(Implemented = true)]
		Vector3 GetPosition();

		[Method(Implemented = true)]
		void SetScale(Vector3 scale);

		[Method(Implemented = true)]
		Vector3 GetScale();

		[Method(Implemented = true)]
		Quaternion GetOrientation();

		[Method(Implemented = true)]
		void SetOrientation(Quaternion orientation);
	}
}