using System;
using System.Collections.Generic;
using InVision.Framework.Components.Actions;
using InVision.GameMath;

namespace InVision.Framework.Components
{
	public interface IGameComponent : ICloneable, IDisposable, IUpdateActionCreator
	{
		/// <summary>
		/// Gets or sets the position.
		/// </summary>
		/// <value>The position.</value>
		Vector3 Position { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether [repeat update steps].
		/// </summary>
		/// <value><c>true</c> if [repeat update steps]; otherwise, <c>false</c>.</value>
		bool RepeatUpdateSteps { get; set; }

		/// <summary>
		/// Gets the children.
		/// </summary>
		/// <value>The children.</value>
		IEnumerable<IGameComponent> Children { get; }

		/// <summary>
		/// Gets a value indicating whether this <see cref="IGameComponent"/> is initialized.
		/// </summary>
		/// <value><c>true</c> if initialized; otherwise, <c>false</c>.</value>
		bool Initialized { get; }

		/// <summary>
		/// Gets a value indicating whether this instance is dead.
		/// </summary>
		/// <value><c>true</c> if this instance is dead; otherwise, <c>false</c>.</value>
		bool IsDead { get; }

		/// <summary>
		/// Gets or sets the game application.
		/// </summary>
		/// <value>The game application.</value>
		GameApplication GameApplication { get; set; }

		/// <summary>
		/// Gets or sets the game variables.
		/// </summary>
		/// <value>The game variables.</value>
		dynamic GameVariables { get; set; }

		/// <summary>
		/// Gets or sets the state variables.
		/// </summary>
		/// <value>The state variables.</value>
		dynamic StateVariables { get; set; }

		/// <summary>
		/// Gets a collection containing the keys in the <see cref="T:System.Collections.Generic.Dictionary`2"/>.
		/// </summary>
		/// <returns>
		/// A <see cref="T:System.Collections.Generic.Dictionary`2.KeyCollection"/> containing the keys in the <see cref="T:System.Collections.Generic.Dictionary`2"/>.
		/// </returns>
		IEnumerable<string> ChildrenKeys { get; }

		/// <summary>
		/// Gets a collection containing the values in the <see cref="T:System.Collections.Generic.Dictionary`2"/>.
		/// </summary>
		/// <returns>
		/// A <see cref="T:System.Collections.Generic.Dictionary`2.ValueCollection"/> containing the values in the <see cref="T:System.Collections.Generic.Dictionary`2"/>.
		/// </returns>
		IEnumerable<IGameComponent> ChildrenValues { get; }

		/// <summary>
		/// Gets the number of key/value pairs contained in the <see cref="T:System.Collections.Generic.Dictionary`2"/>.
		/// </summary>
		/// <returns>
		/// The number of key/value pairs contained in the <see cref="T:System.Collections.Generic.Dictionary`2"/>.
		/// </returns>
		int ChildrenCount { get; }

		/// <summary>
		/// Gets or sets the value associated with the specified key.
		/// </summary>
		/// <returns>
		/// The value associated with the specified key. If the specified key is not found, a get operation throws a <see cref="T:System.Collections.Generic.KeyNotFoundException"/>, and a set operation creates a new element with the specified key.
		/// </returns>
		/// <param name="key">The key of the value to get or set.</param><exception cref="T:System.ArgumentNullException"><paramref name="key"/> is null.</exception><exception cref="T:System.Collections.Generic.KeyNotFoundException">The property is retrieved and <paramref name="key"/> does not exist in the collection.</exception>
		IGameComponent this[string key] { get; set; }

		/// <summary>
		/// Initializes the specified app.
		/// </summary>
		/// <param name="app">The app.</param>
		void Initialize(GameApplication app);

		/// <summary>
		/// Updates the specified time.
		/// </summary>
		/// <param name="time">The time.</param>
		void Update(ElapsedTime time);

		/// <summary>
		/// Updates the by steps.
		/// </summary>
		/// <returns></returns>
		IEnumerable<UpdateAction> UpdateBySteps();

		/// <summary>
		/// Adds the specified key and value to the dictionary.
		/// </summary>
		/// <param name="key">The key of the element to add.</param><param name="value">The value of the element to add. The value can be null for reference types.</param><exception cref="T:System.ArgumentNullException"><paramref name="key"/> is null.</exception><exception cref="T:System.ArgumentException">An element with the same key already exists in the <see cref="T:System.Collections.Generic.Dictionary`2"/>.</exception>
		void Add(string key, IGameComponent value);

		/// <summary>
		/// Determines whether the <see cref="T:System.Collections.Generic.Dictionary`2"/> contains the specified key.
		/// </summary>
		/// <returns>
		/// true if the <see cref="T:System.Collections.Generic.Dictionary`2"/> contains an element with the specified key; otherwise, false.
		/// </returns>
		/// <param name="key">The key to locate in the <see cref="T:System.Collections.Generic.Dictionary`2"/>.</param><exception cref="T:System.ArgumentNullException"><paramref name="key"/> is null.</exception>
		bool ContainsKey(string key);

		/// <summary>
		/// Removes all keys and values from the <see cref="T:System.Collections.Generic.Dictionary`2"/>.
		/// </summary>
		void Clear();

		/// <summary>
		/// Removes the value with the specified key from the <see cref="T:System.Collections.Generic.Dictionary`2"/>.
		/// </summary>
		/// <returns>
		/// true if the element is successfully found and removed; otherwise, false.  This method returns false if <paramref name="key"/> is not found in the <see cref="T:System.Collections.Generic.Dictionary`2"/>.
		/// </returns>
		/// <param name="key">The key of the element to remove.</param><exception cref="T:System.ArgumentNullException"><paramref name="key"/> is null.</exception>
		bool Remove(string key);

		/// <summary>
		/// Gets the value associated with the specified key.
		/// </summary>
		/// <returns>
		/// true if the <see cref="T:System.Collections.Generic.Dictionary`2"/> contains an element with the specified key; otherwise, false.
		/// </returns>
		/// <param name="key">The key of the value to get.</param><param name="value">When this method returns, contains the value associated with the specified key, if the key is found; otherwise, the default value for the type of the <paramref name="value"/> parameter. This parameter is passed uninitialized.</param><exception cref="T:System.ArgumentNullException"><paramref name="key"/> is null.</exception>
		bool TryGetValue(string key, out IGameComponent value);

		/// <summary>
		/// Adds a key/value pair to the <see cref="T:System.Collections.Concurrent.ConcurrentDictionary`2"/> if the key does not already exist.
		/// </summary>
		/// <returns>
		/// The value for the key. This will be either the existing value for the key if the key is already in the dictionary, or the new value for the key as returned by valueFactory if the key was not in the dictionary.
		/// </returns>
		/// <param name="key">The key of the element to add.</param><param name="valueFactory">The function used to generate a value for the key</param><exception cref="T:System.ArgumentNullException"><paramref name="key"/> is a null reference (Nothing in Visual Basic).-or-<paramref name="valueFactory"/> is a null reference (Nothing in Visual Basic).</exception><exception cref="T:System.OverflowException">The dictionary contains too many elements.</exception>
		IGameComponent GetOrAdd(string key, Func<string, IGameComponent> valueFactory);

		/// <summary>
		/// Adds a key/value pair to the <see cref="T:System.Collections.Concurrent.ConcurrentDictionary`2"/> if the key does not already exist.
		/// </summary>
		/// <returns>
		/// The value for the key. This will be either the existing value for the key if the key is already in the dictionary, or the new value if the key was not in the dictionary.
		/// </returns>
		/// <param name="key">The key of the element to add.</param><param name="value">the value to be added, if the key does not already exist</param><exception cref="T:System.ArgumentNullException"><paramref name="key"/> is a null reference (Nothing in Visual Basic).</exception><exception cref="T:System.OverflowException">The dictionary contains too many elements.</exception>
		IGameComponent GetOrAdd(string key, IGameComponent value);

		/// <summary>
		/// Adds a key/value pair to the <see cref="T:System.Collections.Concurrent.ConcurrentDictionary`2"/> if the key does not already exist, or updates a key/value pair in the <see cref="T:System.Collections.Concurrent.ConcurrentDictionary`2"/> if the key already exists.
		/// </summary>
		/// <returns>
		/// The new value for the key. This will be either be the result of addValueFactory (if the key was absent) or the result of updateValueFactory (if the key was present).
		/// </returns>
		/// <param name="key">The key to be added or whose value should be updated</param><param name="addValueFactory">The function used to generate a value for an absent key</param><param name="updateValueFactory">The function used to generate a new value for an existing key based on the key's existing value</param><exception cref="T:System.ArgumentNullException"><paramref name="key"/> is a null reference (Nothing in Visual Basic).-or-<paramref name="addValueFactory"/> is a null reference (Nothing in Visual Basic).-or-<paramref name="updateValueFactory"/> is a null reference (Nothing in Visual Basic).</exception><exception cref="T:System.OverflowException">The dictionary contains too many elements.</exception>
		IGameComponent AddOrUpdate(string key, Func<string, IGameComponent> addValueFactory,
								   Func<string, IGameComponent, IGameComponent> updateValueFactory);

		/// <summary>
		/// Adds a key/value pair to the <see cref="T:System.Collections.Concurrent.ConcurrentDictionary`2"/> if the key does not already exist, or updates a key/value pair in the <see cref="T:System.Collections.Concurrent.ConcurrentDictionary`2"/> if the key already exists.
		/// </summary>
		/// <returns>
		/// The new value for the key. This will be either be addValue (if the key was absent) or the result of updateValueFactory (if the key was present).
		/// </returns>
		/// <param name="key">The key to be added or whose value should be updated</param><param name="addValue">The value to be added for an absent key</param><param name="updateValueFactory">The function used to generate a new value for an existing key based on the key's existing value</param><exception cref="T:System.ArgumentNullException"><paramref name="key"/> is a null reference (Nothing in Visual Basic).-or-<paramref name="updateValueFactory"/> is a null reference (Nothing in Visual Basic).</exception><exception cref="T:System.OverflowException">The dictionary contains too many elements.</exception>
		IGameComponent AddOrUpdate(string key, IGameComponent addValue,
								   Func<string, IGameComponent, IGameComponent> updateValueFactory);
	}
}