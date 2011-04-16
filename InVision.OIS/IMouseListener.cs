namespace InVision.OIS
{
	public interface IMouseListener
	{
		bool OnMouseMoved(MouseEventArgs e);
		bool OnMousePressed(MouseEventArgs e, MouseButton button);
		bool OnMouseReleased(MouseEventArgs e, MouseButton button);
	}
}