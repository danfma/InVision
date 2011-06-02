namespace InVision.Framework.Components
{
	public interface IGameObject : IGameComponent
	{
		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>The name.</value>
		string Name { get; }
	}
}