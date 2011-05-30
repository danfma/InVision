using InVision.GameMath;
using InVision.Native;

namespace InVision.Ogre.Native
{
	[OgreClass("ShadowCaster", Type = ClassType.Interface)]
	public interface IShadowCaster : ICppInstance
	{
		[Method(Implemented = true)]
		bool GetCastShadows();

		[Method(Implemented = true)]
		IEdgeData GetEdgeList();

		[Method(Implemented = true)]
		bool HasEdgeList();

		[Method]
		BoundingBox GetWorldBoundingBox(bool derive = false);

		[Method]
		BoundingBox GetLightCapBounds();

		[Method]
		BoundingBox GetDarkCapBounds(ILight light, float dirLightExtrusionDist);

		[Method]
		float GetPointExtrusionDistance(ILight light);
	}
}