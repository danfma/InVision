using InVision.GameMath;
using InVision.Native;

namespace InVision.Ogre
{
	public abstract class MovableObject : CppWrapper<Native.IMovableObject>, IShadowCaster, IAnimableObject
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="MovableObject"/> class.
		/// </summary>
		/// <param name="nativeInstance">The native instance.</param>
		protected MovableObject(Native.IMovableObject nativeInstance)
			: base(nativeInstance)
		{
		}

		/// <summary>
		/// Gets a value indicating whether [cast shadows].
		/// </summary>
		/// <value><c>true</c> if [cast shadows]; otherwise, <c>false</c>.</value>
		public bool CastShadows
		{
			get { return Native.GetCastShadows(); }
		}

		/// <summary>
		/// Gets the edge list.
		/// </summary>
		/// <value>The edge list.</value>
		public EdgeData EdgeList
		{
			get { return GetOrCreateOwner(Native.GetEdgeList(), native => new EdgeData(native)); }
		}

		/// <summary>
		/// Gets a value indicating whether this instance has edge list.
		/// </summary>
		/// <value>
		/// 	<c>true</c> if this instance has edge list; otherwise, <c>false</c>.
		/// </value>
		public bool HasEdgeList
		{
			get { return Native.HasEdgeList(); }
		}

		/// <summary>
		/// Gets the world bounding box.
		/// </summary>
		/// <param name="derive">if set to <c>true</c> [derive].</param>
		/// <returns></returns>
		public BoundingBox GetWorldBoundingBox(bool derive)
		{
			return Native.GetWorldBoundingBox(derive);
		}

		/// <summary>
		/// Gets the light cap bounds.
		/// </summary>
		/// <returns></returns>
		public BoundingBox GetLightCapBounds()
		{
			return Native.GetLightCapBounds();
		}

		/// <summary>
		/// Gets the dark cap bounds.
		/// </summary>
		/// <param name="light">The light.</param>
		/// <param name="dirLightExtrusionDist">The dir light extrusion dist.</param>
		/// <returns></returns>
		public BoundingBox GetDarkCapBounds(Light light, float dirLightExtrusionDist)
		{
			return Native.GetDarkCapBounds(light.Native, dirLightExtrusionDist);
		}

		/// <summary>
		/// Gets the point extrusion distance.
		/// </summary>
		/// <param name="light">The light.</param>
		/// <returns></returns>
		public float GetPointExtrusionDistance(Light light)
		{
			return Native.GetPointExtrusionDistance(light.Native);
		}
	}
}