using InVision.Input;

namespace InVision.OIS
{
	public interface IMouseListener
	{
		bool OnMouseMoved(MouseEventArgs e);
		bool OnMousePressed(MouseEventArgs e, Input.MouseButton button);
		bool OnMouseReleased(MouseEventArgs e, Input.MouseButton button);
	}
}