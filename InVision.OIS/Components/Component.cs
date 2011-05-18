using System;
using InVision.Native.Ext;
using InVision.OIS.Native;

namespace InVision.OIS.Components
{
    public unsafe class Component : CppWrapper
    {
        private IComponent _native;
        private ComponentType* _ctype;

        /// <summary>
        /// Initializes a new instance of the <see cref="Component"/> class.
        /// </summary>
        /// <param name="cppInstance">The CPP instance.</param>
        protected Component(IComponent cppInstance)
        {
            _native = cppInstance;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Component"/> class.
        /// </summary>
        public Component()
            : this(CreateCppInstance<IComponent>())
        {
            var descriptor = new ComponentDescriptor();
            _native.Component(ref descriptor);

            Initialize(descriptor);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Component"/> class.
        /// </summary>
        /// <param name="ctype">The ctype.</param>
        public Component(ComponentType ctype)
        {
            var descriptor = new ComponentDescriptor();
            _native.Component(ref descriptor, ctype);

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
        /// Gets the native.
        /// </summary>
        /// <value>The native.</value>
        protected IComponent Native
        {
            get { return _native; }
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
            if (disposing && _native != null)
            {
                _native.Dispose();
                _native = null;

                _ctype = null;
            }
        }
    }
}