namespace InVision.OIS.Devices
{
	public interface IKeyListener
	{
		bool OnKeyPressed(KeyEventArgs e);
		bool OnKeyReleased(KeyEventArgs e);
	}
}