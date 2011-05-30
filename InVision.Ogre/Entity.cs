using InVision.Ogre.Native;

namespace InVision.Ogre
{
	public class Entity : MovableObject
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Entity"/> class.
		/// </summary>
		/// <param name="nativeInstance">The native instance.</param>
		public Entity(IEntity nativeInstance)
			: base(nativeInstance)
		{
		}
	}
}