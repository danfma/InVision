using System;
using System.Collections.Concurrent;

namespace InVision.Native
{
	/// <summary>
	/// 
	/// </summary>
	public abstract class CppWrapper : DisposableObject, ICppWrapper<ICppInterface>
	{
		private static readonly HandleListenerDispatcher HandleListener = new HandleListenerDispatcher();

		private static readonly ConcurrentDictionary<Handle, WeakReference> References =
			new ConcurrentDictionary<Handle, WeakReference>();

		/// <summary>
		/// Initializes the <see cref="CppWrapper"/> class.
		/// </summary>
		static CppWrapper()
		{
			HandleListener.HandleDestroyed += OnHandleDestroyed;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="CppWrapper"/> class.
		/// </summary>
		/// <param name="nativeInstance">The native instance.</param>
		protected CppWrapper(ICppInterface nativeInstance)
		{
			Native = nativeInstance;
		}

		/// <summary>
		/// Determines whether the specified <see cref="System.Object"/> is equal to this instance.
		/// </summary>
		/// <param name="obj">The <see cref="System.Object"/> to compare with this instance.</param>
		/// <returns>
		/// 	<c>true</c> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <c>false</c>.
		/// </returns>
		public override bool Equals(object obj)
		{
			if (obj == null)
				return false;

			if (!GetType().IsAssignableFrom(obj.GetType()))
				return false;

			var other = (CppWrapper)obj;

			if (Native == null && other.Native == null)
				return true;

			if (Native == null || other.Native == null)
				return false;

			return Native.Self == other.Native.Self;
		}

		/// <summary>
		/// Returns a hash code for this instance.
		/// </summary>
		/// <returns>
		/// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
		/// </returns>
		public override int GetHashCode()
		{
			return (int)(Native != null ? Native.Self.Value : 0);
		}

		#region ICppWrapper<ICppInterface> Members

		/// <summary>
		/// Gets or sets the native instance.
		/// </summary>
		/// <value>The native instance.</value>
		public ICppInterface Native { get; private set; }

		#endregion

		/// <summary>
		/// Releases unmanaged and - optionally - managed resources
		/// </summary>
		/// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
		protected override void Dispose(bool disposing)
		{
			if (Native.Self.IsValid)
				RemoveOwnership(Native);

			Native = null;
		}

		/// <summary>
		/// Called when [handle destroyed].
		/// </summary>
		/// <param name="handle">The handle.</param>
		private static void OnHandleDestroyed(Handle handle)
		{
			WeakReference reference;

			References.TryRemove(handle, out reference);
		}

		/// <summary>
		/// Creates the instance of the native object for wrap.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		protected static T CreateCppInstance<T>()
		{
			return NativeFactory.Create<T>();
		}

		/// <summary>
		/// Registers the ownership.
		/// </summary>
		/// <param name="interface">The @interface.</param>
		/// <param name="owner">The owner.</param>
		protected internal static void RegisterOwnership(ICppInterface @interface, object owner)
		{
			References.TryAdd(@interface.Self, new WeakReference(owner));
		}

		/// <summary>
		/// Removes the ownership.
		/// </summary>
		/// <param name="nativeInstance">The native instance.</param>
		protected internal static void RemoveOwnership(ICppInterface nativeInstance)
		{
			WeakReference reference;

			References.TryRemove(nativeInstance.Self, out reference);
		}

		/// <summary>
		/// Gets the or create owner.
		/// </summary>
		/// <typeparam name="TOwner">The type of the owner.</typeparam>
		/// <typeparam name="TNative">The type of the native.</typeparam>
		/// <param name="native">The native.</param>
		/// <param name="creator">The creator.</param>
		/// <returns></returns>
		protected static TOwner GetOrCreateOwner<TOwner, TNative>(TNative @native, Func<TNative, TOwner> creator)
			where TNative : ICppInterface
		{
			if (Equals(@native, null) || !@native.Self.IsValid)
				return default(TOwner);

			var owner = GetOwner<TOwner>(@native);

			if (Equals(owner, default(TOwner)))
			{
				owner = creator(@native);
				References.TryAdd(@native.Self, new WeakReference(owner));
			}

			return owner;
		}

		/// <summary>
		/// Gets the owner.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="interface">The @interface.</param>
		/// <returns></returns>
		protected static T GetOwner<T>(ICppInterface @interface)
		{
			if (@interface == null)
				return default(T);

			WeakReference reference;

			if (References.TryGetValue(@interface.Self, out reference))
			{
				if (reference.IsAlive)
					return (T)reference.Target;

				References.TryRemove(@interface.Self, out reference);
			}

			return default(T);
		}
	}

	public abstract class CppWrapper<T> : CppWrapper, ICppWrapper<T>
		where T : ICppInterface
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="CppWrapper&lt;T&gt;"/> class.
		/// </summary>
		/// <param name="nativeInstance">The native instance.</param>
		protected CppWrapper(T nativeInstance)
			: base(nativeInstance)
		{
		}

		#region ICppWrapper<T> Members

		/// <summary>
		/// Gets the native.
		/// </summary>
		/// <value>The native.</value>
		public new T Native
		{
			get { return (T)base.Native; }
		}

		#endregion
	}
}