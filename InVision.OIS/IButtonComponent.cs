namespace InVision.OIS
{
	public interface IButtonComponent : IComponent
	{
		/// <summary>
		/// Gets a value indicating whether this <see cref="IButtonComponent"/> is pushed.
		/// </summary>
		/// <value><c>true</c> if pushed; otherwise, <c>false</c>.</value>
		bool Pushed { get; }
	}
}