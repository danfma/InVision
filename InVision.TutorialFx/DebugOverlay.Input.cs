using InVision.Ogre;

namespace InVision.TutorialFx
{
	public class DebugOverlay
	{
		protected RenderWindow Window;
		protected float TimeSinceLastDebugUpdate = 1;
		protected OverlayElement GuiAvg;
		protected OverlayElement GuiCurr;
		protected OverlayElement GuiBest;
		protected OverlayElement GuiWorst;
		protected OverlayElement GuiTris;
		protected OverlayElement ModesText;
		private string additionalInfo = "";

		public DebugOverlay(RenderWindow window)
		{
			Window = window;

			Overlay debugOverlay = OverlayManager.Instance.GetByName("Core/DebugOverlay");
			debugOverlay.Show();

			GuiAvg = OverlayManager.Instance.GetOverlayElement("Core/AverageFps");
			GuiCurr = OverlayManager.Instance.GetOverlayElement("Core/CurrFps");
			GuiBest = OverlayManager.Instance.GetOverlayElement("Core/BestFps");
			GuiWorst = OverlayManager.Instance.GetOverlayElement("Core/WorstFps");
			GuiTris = OverlayManager.Instance.GetOverlayElement("Core/NumTris");
			ModesText = OverlayManager.Instance.GetOverlayElement("Core/NumBatches");
		}

		public string AdditionalInfo
		{
			set { additionalInfo = value; }
			get { return additionalInfo; }
		}

		public void Update(float timeFragment)
		{
			if (TimeSinceLastDebugUpdate > 0.5f) {
				var stats = Window.GetStatistics();

				GuiAvg.Caption = "Average FPS: " + stats.AvgFPS;
				GuiCurr.Caption = "Current FPS: " + stats.LastFPS;
				GuiBest.Caption = "Best FPS: " + stats.BestFPS + " " + stats.BestFrameTime + " ms";
				GuiWorst.Caption = "Worst FPS: " + stats.WorstFPS + " " + stats.WorstFrameTime + " ms";
				GuiTris.Caption = "Triangle Count: " + stats.TriangleCount;
				ModesText.Caption = additionalInfo;

				TimeSinceLastDebugUpdate = 0;
			} else {
				TimeSinceLastDebugUpdate += timeFragment;
			}
		}
	}
}