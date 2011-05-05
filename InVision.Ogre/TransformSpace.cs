namespace InVision.Ogre
{
	/// <summary>
	/// Enumeration denoting the spaces which a transform can be relative to. 
	/// </summary>
	public enum TransformSpace : uint
	{
		/// <summary>
		/// Transform is relative to the local space. 
		/// </summary>
		Local,
		/// <summary>
		/// Transform is relative to the space of the parent node. 
		/// </summary>
		Parent,
		/// <summary>
		/// Transform is relative to world space. 
		/// </summary>
		World
	}
}