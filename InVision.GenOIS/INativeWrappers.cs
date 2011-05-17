using System;
using System.Runtime.InteropServices;
using InVision.Native.Ext;

namespace InVision.GenOIS
{
    [CppInterface]
    public interface IComponent
    {
        [Constructor]
        IComponent Component();

        [Constructor]
        IComponent Component(ComponentType componentType);

        [Destructor]
        void Dispose();

        [Method]
        ComponentDescriptor CreateDescriptor();
    }

    [ValueObject]
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct ComponentDescriptor
    {
        public Handle Self;
        public ComponentType* CType;
    }

    public unsafe class Component : DisposableObject
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
            : this(NativeFactory.Create<IComponent>().Component())
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Component"/> class.
        /// </summary>
        /// <param name="componentType">Type of the component.</param>
        public Component(ComponentType componentType)
            : this(NativeFactory.Create<IComponent>().Component(componentType))
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

    [CppInterface]
    public interface IButton : IComponent
    {
        [Constructor]
        new void New();

        [Constructor]
        void New(bool pushed);

        [Method]
        new ButtonDescriptor CreateDescriptor();
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct ButtonDescriptor
    {
        public ComponentDescriptor Base;
        public bool* Pushed;
    }
}