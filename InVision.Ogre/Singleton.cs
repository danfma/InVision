using InVision.Native;
using InVision.Ogre.Native;

namespace InVision.Ogre
{
	public abstract class Singleton<TWrapper, TNative> : CppWrapper, ICppWrapper<TNative>
		where TNative : ISingleton<TNative>, ICppInterface
	{
		protected static readonly TNative Static = CreateCppInstance<TNative>();

		/// <summary>
		/// Initializes a new instance of the <see cref="Singleton&lt;T&gt;"/> class.
		/// </summary>
		/// <param name="nativeInstance">The native instance.</param>
		protected Singleton(ICppInterface nativeInstance)
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

				return GetOwner<TWrapper>(result);
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