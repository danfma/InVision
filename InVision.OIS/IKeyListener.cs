namespace InVision.OIS
{
	public interface IKeyListener
	{
		bool OnKeyPressed(KeyEventArgs e);
		bool OnKeyReleased(KeyEventArgs e);
	}
}