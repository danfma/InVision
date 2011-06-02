using System;
using System.Collections.Generic;
using System.Linq;
using InVision.Framework.Components.Actions;
using InVision.GameMath;

namespace InVision.Framework.Components
{
	public abstract class GameComponent : DisposableObject, IGameComponent
	{
		private GameComponentCollection _children;

		#region Construction and Destruction

		/// <summary>
		/// Initializes a new instance of the <see cref="GameComponent"/> class.
		/// </summary>
		protected GameComponent()
		{
			_children = new GameComponentCollection();
		}

		/// <summary>
		/// Gets or sets the action processor.
		/// </summary>
		/// <value>The action processor.</value>
		protected ActionProcessor ActionProcessor { get; private set; }

		/// <summary>
		/// Releases unmanaged and - optionally - managed resources
		/// </summary>
		/// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
		protected override void Dispose(bool disposing)
		{
			if (_children != null) {
				foreach (IGameComponent child in Children) {
					child.Dispose();
				}

				_children.Clear();
			}

			if (disposing) {
				_children = null;
				ActionProcessor = null;
			}
		}

		#endregion

		/// <summary>
		/// Gets or sets the elapsed time.
		/// </summary>
		/// <value>The elapsed time.</value>
		protected ElapsedTime ElapsedTime { get; private set; }

		#region IGameComponent Members

		/// <summary>
		/// Gets or sets the value associated with the specified key.
		/// </summary>
		/// <returns>
		/// The value associated with the specified key. If the specified key is not found, a get operation throws a <see cref="T:System.Collections.Generic.KeyNotFoundException"/>, and a set operation creates a new element with the specified key.
		/// </returns>
		/// <param name="key">The key of the value to get or set.</param><exception cref="T:System.ArgumentNullException"><paramref name="key"/> is null.</exception><exception cref="T:System.Collections.Generic.KeyNotFoundException">The property is retrieved and <paramref name="key"/> does not exist in the collection.</exception>
		public IGameComponent this[string key]
		{
			get { return _children[key]; }
			set { _children[key] = value; }
		}

		/// <summary>
		/// Gets a collection containing the keys in the <see cref="T:System.Collections.Generic.Dictionary`2"/>.
		/// </summary>
		/// <returns>
		/// A <see cref="T:System.Collections.Generic.Dictionary`2.KeyCollection"/> containing the keys in the <see cref="T:System.Collections.Generic.Dictionary`2"/>.
		/// </returns>
		public IEnumerable<string> ChildrenKeys
		{
			get { return _children.Keys; }
		}

		/// <summary>
		/// Gets a collection containing the values in the <see cref="T:System.Collections.Generic.Dictionary`2"/>.
		/// </summary>
		/// <returns>
		/// A <see cref="T:System.Collections.Generic.Dictionary`2.ValueCollection"/> containing the values in the <see cref="T:System.Collections.Generic.Dictionary`2"/>.
		/// </returns>
		public IEnumerable<IGameComponent> ChildrenValues
		{
			get { return _children.Values; }
		}

		/// <summary>
		/// Gets the number of key/value pairs contained in the <see cref="T:System.Collections.Generic.Dictionary`2"/>.
		/// </summary>
		/// <returns>
		/// The number of key/value pairs contained in the <see cref="T:System.Collections.Generic.Dictionary`2"/>.
		/// </returns>
		public int ChildrenCount
		{
			get { return _children.Count; }
		}

		/// <summary>
		/// Creates a new object that is a copy of the current instance.
		/// </summary>
		/// <returns>
		/// A new object that is a copy of this instance.
		/// </returns>
		/// <filterpriority>2</filterpriority>
		public virtual object Clone()
		{
			return MemberwiseClone();
		}

		/// <summary>
		/// Gets or sets the position.
		/// </summary>
		/// <value>The position.</value>
		public virtual Vector3 Position { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether [repeat update steps].
		/// </summary>
		/// <value><c>true</c> if [repeat update steps]; otherwise, <c>false</c>.</value>
		public bool RepeatUpdateSteps { get; set; }

		/// <summary>
		/// Gets the children.
		/// </summary>
		/// <value>The children.</value>
		public IEnumerable<IGameComponent> Children
		{
			get { return _children; }
		}

		/// <summary>
		/// Gets a value indicating whether this <see cref="IGameComponent"/> is initialized.
		/// </summary>
		/// <value><c>true</c> if initialized; otherwise, <c>false</c>.</value>
		public bool Initialized { get; private set; }

		/// <summary>
		/// Gets a value indicating whether this instance is dead.
		/// </summary>
		/// <value><c>true</c> if this instance is dead; otherwise, <c>false</c>.</value>
		public bool IsDead
		{
			get { return ActionProcessor != null && !ActionProcessor.IsProcessing && !RepeatUpdateSteps; }
		}

		/// <summary>
		/// Gets or sets the game application.
		/// </summary>
		/// <value>The game application.</value>
		public GameApplication GameApplication { get; set; }

		/// <summary>
		/// Gets or sets the game variables.
		/// </summary>
		/// <value>The game variables.</value>
		public dynamic GameVariables { get; set; }

		/// <summary>
		/// Gets or sets the state variables.
		/// </summary>
		/// <value>The state variables.</value>
		public dynamic StateVariables { get; set; }

		/// <summary>
		/// Initializes the specified app.
		/// </summary>
		/// <param name="app">The app.</param>
		public virtual void Initialize(GameApplication app)
		{
			InitializeSelf(app);
			InitializeChildren(app);

			Initialized = true;
		}

		/// <summary>
		/// Updates the specified game time.
		/// </summary>
		/// <param name="elapsedTime">The game time.</param>
		public virtual void Update(ElapsedTime elapsedTime)
		{
			UpdateSelf(elapsedTime);
			UpdateChildren(elapsedTime);
		}

		/// <summary>
		/// Updates the by steps.
		/// </summary>
		/// <returns></returns>
		public virtual IEnumerable<UpdateAction> UpdateBySteps()
		{
			return Enumerable.Empty<UpdateAction>();
		}

		/// <summary>
		/// Waits the by.
		/// </summary>
		/// <param name="milliseconds">The milliseconds.</param>
		/// <returns></returns>
		public UpdateAction WaitBy(long milliseconds)
		{
			return new WaitTimeUpdateAction(milliseconds);
		}

		/// <summary>
		/// Waits the by.
		/// </summary>
		/// <param name="time">The time.</param>
		/// <returns></returns>
		public UpdateAction WaitBy(TimeSpan time)
		{
			return new WaitTimeUpdateAction((long)time.TotalMilliseconds);
		}

		/// <summary>
		/// Actions the specified work.
		/// </summary>
		/// <param name="work">The work.</param>
		/// <returns></returns>
		public UpdateAction DelayedWork(Action work)
		{
			return new DelayedWorkUpdateAction(work);
		}

		/// <summary>
		/// Adds the specified key and value to the dictionary.
		/// </summary>
		/// <param name="key">The key of the element to add.</param><param name="value">The value of the element to add. The value can be null for reference types.</param><exception cref="T:System.ArgumentNullException"><paramref name="key"/> is null.</exception><exception cref="T:System.ArgumentException">An element with the same key already exists in the <see cref="T:System.Collections.Generic.Dictionary`2"/>.</exception>
		public virtual void Add(string key, IGameComponent value)
		{
			_children.Add(key, value);
		}

		/// <summary>
		/// Determines whether the <see cref="T:System.Collections.Generic.Dictionary`2"/> contains the specified key.
		/// </summary>
		/// <returns>
		/// true if the <see cref="T:System.Collections.Generic.Dictionary`2"/> contains an element with the specified key; otherwise, false.
		/// </returns>
		/// <param name="key">The key to locate in the <see cref="T:System.Collections.Generic.Dictionary`2"/>.</param><exception cref="T:System.ArgumentNullException"><paramref name="key"/> is null.</exception>
		public bool ContainsKey(string key)
		{
			return _children.ContainsKey(key);
		}

		/// <summary>
		/// Removes all keys and values from the <see cref="T:System.Collections.Generic.Dictionary`2"/>.
		/// </summary>
		public virtual void Clear()
		{
			_children.Clear();
		}

		/// <summary>
		/// Removes the value with the specified key from the <see cref="T:System.Collections.Generic.Dictionary`2"/>.
		/// </summary>
		/// <returns>
		/// true if the element is successfully found and removed; otherwise, false.  This method returns false if <paramref name="key"/> is not found in the <see cref="T:System.Collections.Generic.Dictionary`2"/>.
		/// </returns>
		/// <param name="key">The key of the element to remove.</param><exception cref="T:System.ArgumentNullException"><paramref name="key"/> is null.</exception>
		public virtual bool Remove(string key)
		{
			return _children.Remove(key);
		}

		/// <summary>
		/// Gets the value associated with the specified key.
		/// </summary>
		/// <returns>
		/// true if the <see cref="T:System.Collections.Generic.Dictionary`2"/> contains an element with the specified key; otherwise, false.
		/// </returns>
		/// <param name="key">The key of the value to get.</param><param name="value">When this method returns, contains the value associated with the specified key, if the key is found; otherwise, the default value for the type of the <paramref name="value"/> parameter. This parameter is passed uninitialized.</param><exception cref="T:System.ArgumentNullException"><paramref name="key"/> is null.</exception>
		public bool TryGetValue(string key, out IGameComponent value)
		{
			return _children.TryGetValue(key, out value);
		}

		/// <summary>
		/// Adds a key/value pair to the <see cref="T:System.Collections.Concurrent.ConcurrentDictionary`2"/> if the key does not already exist.
		/// </summary>
		/// <returns>
		/// The value for the key. This will be either the existing value for the key if the key is already in the dictionary, or the new value for the key as returned by valueFactory if the key was not in the dictionary.
		/// </returns>
		/// <param name="key">The key of the element to add.</param><param name="valueFactory">The function used to generate a value for the key</param><exception cref="T:System.ArgumentNullException"><paramref name="key"/> is a null reference (Nothing in Visual Basic).-or-<paramref name="valueFactory"/> is a null reference (Nothing in Visual Basic).</exception><exception cref="T:System.OverflowException">The dictionary contains too many elements.</exception>
		public virtual IGameComponent GetOrAdd(string key, Func<string, IGameComponent> valueFactory)
		{
			return _children.GetOrAdd(key, valueFactory);
		}

		/// <summary>
		/// Adds a key/value pair to the <see cref="T:System.Collections.Concurrent.ConcurrentDictionary`2"/> if the key does not already exist.
		/// </summary>
		/// <returns>
		/// The value for the key. This will be either the existing value for the key if the key is already in the dictionary, or the new value if the key was not in the dictionary.
		/// </returns>
		/// <param name="key">The key of the element to add.</param><param name="value">the value to be added, if the key does not already exist</param><exception cref="T:System.ArgumentNullException"><paramref name="key"/> is a null reference (Nothing in Visual Basic).</exception><exception cref="T:System.OverflowException">The dictionary contains too many elements.</exception>
		public virtual IGameComponent GetOrAdd(string key, IGameComponent value)
		{
			return _children.GetOrAdd(key, value);
		}

		/// <summary>
		/// Adds a key/value pair to the <see cref="T:System.Collections.Concurrent.ConcurrentDictionary`2"/> if the key does not already exist, or updates a key/value pair in the <see cref="T:System.Collections.Concurrent.ConcurrentDictionary`2"/> if the key already exists.
		/// </summary>
		/// <returns>
		/// The new value for the key. This will be either be the result of addValueFactory (if the key was absent) or the result of updateValueFactory (if the key was present).
		/// </returns>
		/// <param name="key">The key to be added or whose value should be updated</param><param name="addValueFactory">The function used to generate a value for an absent key</param><param name="updateValueFactory">The function used to generate a new value for an existing key based on the key's existing value</param><exception cref="T:System.ArgumentNullException"><paramref name="key"/> is a null reference (Nothing in Visual Basic).-or-<paramref name="addValueFactory"/> is a null reference (Nothing in Visual Basic).-or-<paramref name="updateValueFactory"/> is a null reference (Nothing in Visual Basic).</exception><exception cref="T:System.OverflowException">The dictionary contains too many elements.</exception>
		public virtual IGameComponent AddOrUpdate(string key, Func<string, IGameComponent> addValueFactory,
												  Func<string, IGameComponent, IGameComponent> updateValueFactory)
		{
			return _children.AddOrUpdate(key, addValueFactory, updateValueFactory);
		}

		/// <summary>
		/// Adds a key/value pair to the <see cref="T:System.Collections.Concurrent.ConcurrentDictionary`2"/> if the key does not already exist, or updates a key/value pair in the <see cref="T:System.Collections.Concurrent.ConcurrentDictionary`2"/> if the key already exists.
		/// </summary>
		/// <returns>
		/// The new value for the key. This will be either be addValue (if the key was absent) or the result of updateValueFactory (if the key was present).
		/// </returns>
		/// <param name="key">The key to be added or whose value should be updated</param><param name="addValue">The value to be added for an absent key</param><param name="updateValueFactory">The function used to generate a new value for an existing key based on the key's existing value</param><exception cref="T:System.ArgumentNullException"><paramref name="key"/> is a null reference (Nothing in Visual Basic).-or-<paramref name="updateValueFactory"/> is a null reference (Nothing in Visual Basic).</exception><exception cref="T:System.OverflowException">The dictionary contains too many elements.</exception>
		public virtual IGameComponent AddOrUpdate(string key, IGameComponent addValue,
												  Func<string, IGameComponent, IGameComponent> updateValueFactory)
		{
			return _children.AddOrUpdate(key, addValue, updateValueFactory);
		}

		#endregion

		/// <summary>
		/// Initializes the self.
		/// </summary>
		/// <param name="app">The app.</param>
		protected virtual void InitializeSelf(GameApplication app)
		{
		}

		/// <summary>
		/// Initializes the children.
		/// </summary>
		/// <param name="app">The app.</param>
		protected virtual void InitializeChildren(GameApplication app)
		{
			foreach (IGameComponent child in Children) {
				child.GameApplication = GameApplication;
				child.GameVariables = GameVariables;
				child.StateVariables = StateVariables;
				child.Initialize(app);
			}
		}

		/// <summary>
		/// Updates the self.
		/// </summary>
		/// <param name="elapsedTime">The elapsed time.</param>
		protected virtual void UpdateSelf(ElapsedTime elapsedTime)
		{
			if (ActionProcessor == null)
				ActionProcessor = new ActionProcessor(UpdateBySteps());

			ElapsedTime = elapsedTime;
			ActionProcessor.Step(elapsedTime);

			if (ActionProcessor.IsProcessing)
				return;

			if (RepeatUpdateSteps)
				ActionProcessor.Reset();
		}

		/// <summary>
		/// Updates the children.
		/// </summary>
		/// <param name="elapsedTime">The elapsed time.</param>
		protected virtual void UpdateChildren(ElapsedTime elapsedTime)
		{
			foreach (IGameComponent child in Children) {
				child.Update(elapsedTime);
			}
		}
	}
}