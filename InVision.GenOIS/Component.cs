using InVision.Native.Ext;

namespace InVision.GenOIS
{
    public unsafe class Component : CppWrapper
    {
        private IComponent _native;
        private ComponentType* _componentType;

        /// <summary>
        /// Initializes a new instance of the <see cref="Component"/> class.
        /// </summary>
        /// <param name="cppInstance">The CPP instance.</param>
        protected Component(IComponent cppInstance)
        {
            _native = cppInstance;
            InitializeByDescriptor();
        }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        protected virtual void InitializeByDescriptor()
        {
            var descriptor = _native.CreateDescriptor();

            _componentType = descriptor.CType;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Component"/> class.
        /// </summary>
        public Component()
            : this(CreateCppInstance<IComponent>().Component())
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Component"/> class.
        /// </summary>
        /// <param name="componentType">Type of the component.</param>
        public Component(ComponentType componentType)
            : this(CreateCppInstance<IComponent>().Component(componentType))
        { }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            _native.Dispose();
            _native = null;
        }

        /// <summary>
        /// Gets the type of the component.
        /// </summary>
        /// <value>The type of the component.</value>
        public ComponentType ComponentType
        {
            get
            {
                return *_componentType;
            }
        }
    }
}