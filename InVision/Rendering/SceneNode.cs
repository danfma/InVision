using System;

namespace InVision.Rendering
{
	public class SceneNode : Handle
	{
		/// <summary>
		/// 	Releases the specified pointer to the unmanaged object.
		/// </summary>
		/// <param name = "pSelf">The pointer to the unmanaged object.</param>
		/// <returns></returns>
		protected override bool Release(IntPtr pSelf)
		{
			throw new NotImplementedException();
		}
	}
}