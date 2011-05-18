using InVision.OIS.Native;

namespace InVision.OIS.Components
{
    /// <summary>
    /// 
    /// </summary>
    public unsafe class Vector3 : Component
    {
        private float* _x;
        private float* _y;
        private float* _z;

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector3"/> class.
        /// </summary>
        /// <param name="cppInstance">The CPP instance.</param>
        protected Vector3(IComponent cppInstance)
            : base(cppInstance)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector3"/> class.
        /// </summary>
        public Vector3()
            : this(CreateCppInstance<IVector3>())
        {
            var descriptor = new Vector3Descriptor();
            Native.Vector3(ref descriptor);

            Initialize(descriptor);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Vector3"/> class.
        /// </summary>
        public Vector3(float x, float y, float z)
            : this(CreateCppInstance<IVector3>())
        {
            var descriptor = new Vector3Descriptor();
            Native.Vector3(ref descriptor, x, y, z);

            Initialize(descriptor);
        }

        /// <summary>
        /// Initializes the specified descriptor.
        /// </summary>
        /// <param name="descriptor">The descriptor.</param>
        protected void Initialize(Vector3Descriptor descriptor)
        {
            Initialize(descriptor.Base);

            _x = descriptor.X;
            _y = descriptor.Y;
            _z = descriptor.Z;
        }

        /// <summary>
        /// Gets the native.
        /// </summary>
        /// <value>The native.</value>
        new protected IVector3 Native
        {
            get { return (IVector3)base.Native; }
        }

        /// <summary>
        /// Gets the X.
        /// </summary>
        /// <value>The X.</value>
        public float X
        {
            get { return *_x; }
        }

        /// <summary>
        /// Gets the Y.
        /// </summary>
        /// <value>The Y.</value>
        public float Y
        {
            get { return *_y; }
        }

        /// <summary>
        /// Gets the Z.
        /// </summary>
        /// <value>The Z.</value>
        public float Z
        {
            get { return *_z; }
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (disposing)
            {
                _x = _y = _z = null;
            }
        }
    }
}