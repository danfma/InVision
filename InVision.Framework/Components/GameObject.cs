namespace InVision.Framework.Components
{
	public class GameObject : GameComponent, IGameObject
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="GameObject"/> class.
		/// </summary>
		/// <param name="name">The name.</param>
		public GameObject(string name)
		{
			Name = name;
		}

		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>The name.</value>
		public string Name { get; private set; }
	}
}