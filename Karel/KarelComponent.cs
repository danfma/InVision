using System;
using InVision.Framework.Components;
using InVision.GameMath;
using InVision.Ogre;

namespace Karel
{
	public class KarelComponent : GameComponent
	{
		/// <summary>
		/// Gets the scene manager.
		/// </summary>
		/// <value>The scene manager.</value>
		protected SceneManager SceneManager
		{
			get
			{
				return (SceneManager)GameApplication.Variables.Ogre.SceneManager;
			}
		}

		/// <summary>
		/// Gets or sets the parent.
		/// </summary>
		/// <value>The parent.</value>
		public KarelComponent Parent { get; set; }

		/// <summary>
		/// Gets or sets the scene node.
		/// </summary>
		/// <value>The scene node.</value>
		public SceneNode SceneNode { get; protected set; }

		/// <summary>
		/// Gets or sets the world position.
		/// </summary>
		/// <value>The world position.</value>
		public Point WorldPosition { get; set; }

		/// <summary>
		/// Adds the specified key and value to the dictionary.
		/// </summary>
		/// <param name="key">The key of the element to add.</param>
		/// <param name="value">The value of the element to add. The value can be null for reference types.</param>
		/// <exception cref="T:System.ArgumentNullException"><paramref name="key"/> is null.</exception>
		/// <exception cref="T:System.ArgumentException">An element with the same key already exists in the <see cref="T:System.Collections.Generic.Dictionary`2"/>.</exception>
		public override void Add(string key, IGameComponent value)
		{
			base.Add(key, value);

			if (value is KarelComponent)
				((KarelComponent)value).Parent = this;
		}

		/// <summary>
		/// Adds a key/value pair to the <see cref="T:System.Collections.Concurrent.ConcurrentDictionary`2"/> if the key does not already exist.
		/// </summary>
		/// <param name="key">The key of the element to add.</param>
		/// <param name="valueFactory">The function used to generate a value for the key</param>
		/// <returns>
		/// The value for the key. This will be either the existing value for the key if the key is already in the dictionary, or the new value for the key as returned by valueFactory if the key was not in the dictionary.
		/// </returns>
		/// <exception cref="T:System.ArgumentNullException"><paramref name="key"/> is a null reference (Nothing in Visual Basic).-or-<paramref name="valueFactory"/> is a null reference (Nothing in Visual Basic).</exception>
		/// <exception cref="T:System.OverflowException">The dictionary contains too many elements.</exception>
		public override IGameComponent GetOrAdd(string key, Func<string, IGameComponent> valueFactory)
		{
			return base.GetOrAdd(key, k => {
				IGameComponent component = valueFactory(k);

				if (component is KarelComponent)
					((KarelComponent)component).Parent = this;

				return component;
			});
		}
	}
}