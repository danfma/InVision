using System.Collections.Generic;
using System.Runtime.InteropServices;
using InVision.GameMath;
using InVision.Native;

namespace InVision.Ogre.Native
{
	[OgreClass("Viewport")]
	public interface IViewport : ICppInstance
	{
		[Constructor(Implemented = true)]
		IViewport Construct(
			ICamera camera,
			IRenderTarget renderTarget,
			float left,
			float top,
			float width,
			float height,
			int zOrder);

		[Destructor(Implemented = true)]
		void Destruct();

		[Method(Implemented = true)]
		void SetBackgroundColor(Color color);

		[Method(Implemented = true)]
		Color GetBackgroundColor();

		[Method(Implemented = true)]
		void Update();

		[Method(Implemented = true)]
		void Clear();

		[Method(Implemented = true)]
		ICamera GetCamera();

		[Method(Implemented = true)]
		void SetCamera(ICamera camera);

		[Method(Implemented = true)]
		float GetLeft();

		[Method(Implemented = true)]
		float GetTop();

		[Method(Implemented = true)]
		float GetWidth();

		[Method(Implemented = true)]
		float GetHeight();

		[Method(Implemented = true)]
		int GetActualLeft();

		[Method(Implemented = true)]
		int GetActualTop();

		[Method(Implemented = true)]
		int GetActualWidth();

		[Method(Implemented = true)]
		int GetActualHeight();
	}
}