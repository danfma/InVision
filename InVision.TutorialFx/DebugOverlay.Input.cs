using InVision.Rendering;

namespace InVision.TutorialFx
{
	public class DebugOverlay
	{
		protected RenderWindow mWindow;
		protected float timeSinceLastDebugUpdate = 1;
		protected OverlayElement mGuiAvg;
		protected OverlayElement mGuiCurr;
		protected OverlayElement mGuiBest;
		protected OverlayElement mGuiWorst;
		protected OverlayElement mGuiTris;
		protected OverlayElement mModesText;
		protected string mAdditionalInfo = "";



		public DebugOverlay(RenderWindow window)
		{
			mWindow = window;

			var debugOverlay = OverlayManager.Instance.GetByName("Core/DebugOverlay");
			debugOverlay.Show();

			mGuiAvg = OverlayManager.Instance.GetOverlayElement("Core/AverageFps");
			mGuiCurr = OverlayManager.Instance.GetOverlayElement("Core/CurrFps");
			mGuiBest = OverlayManager.Instance.GetOverlayElement("Core/BestFps");
			mGuiWorst = OverlayManager.Instance.GetOverlayElement("Core/WorstFps");
			mGuiTris = OverlayManager.Instance.GetOverlayElement("Core/NumTris");
			mModesText = OverlayManager.Instance.GetOverlayElement("Core/NumBatches");
		}

		public string AdditionalInfo
		{
			set { mAdditionalInfo = value; }
			get { return mAdditionalInfo; }
		}

		public void Update(float timeFragment)
		{
			if (timeSinceLastDebugUpdate > 0.5f)
			{
				var stats = mWindow.GetStatistics();

				mGuiAvg.Caption = "Average FPS: " + stats.AvgFPS;
				mGuiCurr.Caption = "Current FPS: " + stats.LastFPS;
				mGuiBest.Caption = "Best FPS: " + stats.BestFPS + " " + stats.BestFrameTime + " ms";
				mGuiWorst.Caption = "Worst FPS: " + stats.WorstFPS + " " + stats.WorstFrameTime + " ms";
				mGuiTris.Caption = "Triangle Count: " + stats.TriangleCount;
				mModesText.Caption = mAdditionalInfo;

				timeSinceLastDebugUpdate = 0;
			}
			else
			{
				timeSinceLastDebugUpdate += timeFragment;
			}
		}
	}
}