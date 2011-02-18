namespace InVision.Input
{
	public interface IButtonComponent : IComponent
	{
		/// <summary>
		/// 	Gets a value indicating whether this instance is pushed.
		/// </summary>
		/// <value><c>true</c> if this instance is pushed; otherwise, <c>false</c>.</value>
		bool IsPushed { get; }
	}
}