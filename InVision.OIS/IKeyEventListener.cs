namespace InVision.OIS
{
	public interface IKeyEventListener
	{
		/// <summary>
		/// Raises the <see cref="E:KeyPressed"/> event.
		/// </summary>
		/// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
		/// <returns></returns>
		bool OnKeyPressed(KeyEventArgs e);

		/// <summary>
		/// Raises the <see cref="E:KeyReleased"/> event.
		/// </summary>
		/// <param name="e">The <see cref="KeyEventArgs"/> instance containing the event data.</param>
		/// <returns></returns>
		bool OnKeyReleased(KeyEventArgs e);
	}
}