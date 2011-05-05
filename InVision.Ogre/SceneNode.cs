using System;
using InVision.Native;

namespace InVision.Ogre
{
	public class SceneNode : Handle
	{
		/// <summary>
		/// 	Releases the specified pointer to the unmanaged object.
		/// </summary>
		/// <returns></returns>
		protected override void ReleaseValidHandle()
		{
			throw new NotImplementedException();
		}
	}
}