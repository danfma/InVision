using InVision.Native;
using InVision.OIS.Native;

namespace InVision.OIS.Devices
{
	public unsafe class Component : CppWrapper
	{
		private ComponentType* _ctype;

		/// <summary>
		/// Initializes a new instance of the <see cref="Component"/> class.
		/// </summary>
		/// <param name="cppInstance">The CPP instance.</param>
		protected Component(IComponent cppInstance)
			: base(cppInstance)
		{ }

		/// <summary>
		/// Initializes a new instance of the <see cref="Component"/> class.
		/// </summary>
		public Component()
			: this(CreateCppInstance<IComponent>())
		{
			var descriptor = new ComponentDescriptor();
			Native.Construct(ref descriptor);

			Initialize(descriptor);
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Component"/> class.
		/// </summary>
		/// <param name="ctype">The ctype.</param>
		public Component(ComponentType ctype)
			: this(CreateCppInstance<IComponent>())
		{
			var descriptor = new ComponentDescriptor();
			Native.Construct(ref descriptor, ctype);

			Initialize(descriptor);
		}

		/// <summary>
		/// Initializes the specified descriptor.
		/// </summary>
		/// <param name="descriptor">The descriptor.</param>
		protected void Initialize(ComponentDescriptor descriptor)
		{
			_ctype = descriptor.Ctype;
		}

		/// <summary>
		/// Gets or sets the native instance.
		/// </summary>
		/// <value>The native instance.</value>
		public new IComponent Native
		{
			get { return (IComponent) base.Native; }
		}

		/// <summary>
		/// Gets the type of the C.
		/// </summary>
		/// <value>The type of the C.</value>
		public ComponentType CType
		{
			get { return *_ctype; }
		}

		/// <summary>
		/// Releases unmanaged and - optionally - managed resources
		/// </summary>
		/// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && Native != null)
			{
				Native.Destruct();
				_ctype = null;
			}

			base.Dispose(disposing);
		}
	}
}