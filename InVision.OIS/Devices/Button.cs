using InVision.OIS.Native;

namespace InVision.OIS.Devices
{
    public unsafe class Button : Component
    {
        private bool* _pushed;

        /// <summary>
        /// Initializes a new instance of the <see cref="Button"/> class.
        /// </summary>
        /// <param name="cppInstance">The CPP instance.</param>
        protected Button(IButton cppInstance)
            : base(cppInstance)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Button"/> class.
        /// </summary>
        public Button()
            : base(CreateCppInstance<IButton>())
        {
            var descriptor = new ButtonDescriptor();
            Native.Construct(ref descriptor);

            Initialize(descriptor);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Button"/> class.
        /// </summary>
        /// <param name="pushed">if set to <c>true</c> [pushed].</param>
        public Button(bool pushed)
            : this(CreateCppInstance<IButton>())
        {
            var descriptor = new ButtonDescriptor();
            Native.Construct(ref descriptor, pushed);

            Initialize(descriptor);
        }

        /// <summary>
        /// Initializes the specified descriptor.
        /// </summary>
        /// <param name="descriptor">The descriptor.</param>
        protected void Initialize(ButtonDescriptor descriptor)
        {
            Initialize(descriptor.Base);
            _pushed = descriptor.Pushed;
        }

        /// <summary>
        /// Gets the native.
        /// </summary>
        /// <value>The native.</value>
        public new IButton Native
        {
            get { return (IButton)base.Native; }
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="ButtonDescriptor"/> is pushed.
        /// </summary>
        /// <value><c>true</c> if pushed; otherwise, <c>false</c>.</value>
        public bool Pushed
        {
            get { return *_pushed; }
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (disposing)
                _pushed = null;
        }
    }
}