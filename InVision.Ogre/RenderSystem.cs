using System;
using InVision.Native;
using InVision.Ogre.Native;

namespace InVision.Ogre
{
	public class RenderSystem : Handle
	{
		private string name;

		/// <summary>
		/// 	Initializes a new instance of the <see cref = "RenderSystem" /> class.
		/// </summary>
		/// <param name = "handle">The handle.</param>
		/// <param name = "ownsHandle">if set to <c>true</c> [owns handle].</param>
		internal RenderSystem(IntPtr handle, bool ownsHandle)
			: base(handle, ownsHandle)
		{
		}


		/// <summary>
		/// 	Gets the name.
		/// </summary>
		/// <value>The name.</value>
		public string Name
		{
			get { return name ?? (name = NativeOgreRenderSystem.GetName(handle)); }
		}

		/// <summary>
		/// 	Releases the specified handle.
		/// </summary>
		/// <returns></returns>
		protected override void ReleaseValidHandle()
		{
		}
	}
}