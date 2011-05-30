using InVision.GameMath;

namespace InVision.Ogre
{
	public interface IShadowCaster
	{
		/// <summary>
		/// Gets a value indicating whether [cast shadows].
		/// </summary>
		/// <value><c>true</c> if [cast shadows]; otherwise, <c>false</c>.</value>
		bool CastShadows { get; }

		/// <summary>
		/// Gets the edge list.
		/// </summary>
		/// <value>The edge list.</value>
		EdgeData EdgeList { get; }

		/// <summary>
		/// Gets a value indicating whether this instance has edge list.
		/// </summary>
		/// <value>
		/// 	<c>true</c> if this instance has edge list; otherwise, <c>false</c>.
		/// </value>
		bool HasEdgeList { get; }

		/// <summary>
		/// Gets the world bounding box.
		/// </summary>
		/// <param name="derive">if set to <c>true</c> [derive].</param>
		/// <returns></returns>
		BoundingBox GetWorldBoundingBox(bool derive = false);

		/// <summary>
		/// Gets the light cap bounds.
		/// </summary>
		/// <returns></returns>
		BoundingBox GetLightCapBounds();

		/// <summary>
		/// Gets the dark cap bounds.
		/// </summary>
		/// <param name="light">The light.</param>
		/// <param name="dirLightExtrusionDist">The dir light extrusion dist.</param>
		/// <returns></returns>
		BoundingBox GetDarkCapBounds(Light light, float dirLightExtrusionDist);

		/// <summary>
		/// Gets the point extrusion distance.
		/// </summary>
		/// <param name="light">The light.</param>
		/// <returns></returns>
		float GetPointExtrusionDistance(Light light);
	}
}