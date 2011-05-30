using InVision.Native;
using InVision.Ogre.Native;
using InVision.Extensions;

namespace InVision.Ogre
{
	public abstract class Singleton<TWrapper, TNative> : CppWrapper, ICppWrapper<TNative>
		where TNative : ISingleton<TNative>, ICppInstance
	{
		protected static readonly TNative Static = CreateCppInstance<TNative>();

		/// <summary>
		/// Initializes a new instance of the <see cref="Singleton&lt;T&gt;"/> class.
		/// </summary>
		/// <param name="nativeInstance">The native instance.</param>
		protected Singleton(ICppInstance nativeInstance)
			: base(nativeInstance)
		{
		}

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>The instance.</value>
		public static TWrapper Instance
		{
			get
			{
				TNative result = Static.GetSingleton();

				return GetOrCreateOwner(
					result, 
					native => typeof(TWrapper).CreateInstance<TWrapper>(native));
			}
		}

		#region ICppWrapper<TNative> Members

		/// <summary>
		/// Gets or sets the native instance.
		/// </summary>
		/// <value>The native instance.</value>
		public new TNative Native
		{
			get { return (TNative)base.Native; }
		}

		#endregion
	}
}