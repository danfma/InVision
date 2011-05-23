namespace InVision.OIS.Devices
{
	public interface IMouseListener
	{
		bool OnMouseMoved(MouseEventArgs e);
		bool OnMousePressed(MouseEventArgs e, MouseButton button);
		bool OnMouseReleased(MouseEventArgs e, MouseButton button);
	}
}