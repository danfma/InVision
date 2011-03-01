using System;

namespace InVision.Rendering
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