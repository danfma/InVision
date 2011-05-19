using System;
using InVision.Native.Ext;
using InVision.OIS.Components;
using InVision.OIS.Native;

namespace InVision.OIS
{
    public unsafe class MouseState : CppWrapper
    {
        private readonly IMouseState _native;
        private int* _buttons;
        private int* _height;
        private int* _width;

        /// <summary>
        /// Initializes a new instance of the <see cref="MouseState"/> class.
        /// </summary>
        /// <param name="native">The native.</param>
        protected MouseState(IMouseState native)
        {
            _native = native;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MouseState"/> class.
        /// </summary>
        public MouseState()
            : this(CreateCppInstance<IMouseState>())
        {
            var descriptor = new MouseStateDescriptor();
            _native.Construct(ref descriptor);

            Initialize(descriptor);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MouseState"/> class.
        /// </summary>
        /// <param name="descriptor">The descriptor.</param>
        internal MouseState(MouseStateDescriptor descriptor)
            : this(CreateCppInstance<IMouseState>())
        {
            Native.Self = descriptor.Self;

            Initialize(descriptor);
        }

        /// <summary>
        /// Gets the native.
        /// </summary>
        /// <value>The native.</value>
        protected IMouseState Native
        {
            get { return _native; }
        }

        /// <summary>
        /// Gets the width.
        /// </summary>
        /// <value>The width.</value>
        public int Width
        {
            get { return *_width; }
            set { *_width = value; }
        }

        /// <summary>
        /// Gets the height.
        /// </summary>
        /// <value>The height.</value>
        public int Height
        {
            get { return *_height; }
            set { *_height = value; }
        }

        /// <summary>
        /// Gets or sets the X.
        /// </summary>
        /// <value>The X.</value>
        public Axis X { get; private set; }

        /// <summary>
        /// Gets or sets the Y.
        /// </summary>
        /// <value>The Y.</value>
        public Axis Y { get; private set; }

        /// <summary>
        /// Gets or sets the Z.
        /// </summary>
        /// <value>The Z.</value>
        public Axis Z { get; private set; }

        /// <summary>
        /// Gets the buttons.
        /// </summary>
        /// <value>The buttons.</value>
        public int Buttons
        {
            get { return *_buttons; }
        }

        /// <summary>
        /// Initializes the specified descriptor.
        /// </summary>
        /// <param name="descriptor">The descriptor.</param>
        protected void Initialize(MouseStateDescriptor descriptor)
        {
            _width = descriptor.Width;
            _height = descriptor.Height;
            _buttons = descriptor.Buttons;

            X = new Axis(descriptor.X);
            Y = new Axis(descriptor.Y);
            Z = new Axis(descriptor.Z);
        }

        /// <summary>
        /// Determines whether [is button down] [the specified button].
        /// </summary>
        /// <param name="button">The button.</param>
        /// <returns>
        /// 	<c>true</c> if [is button down] [the specified button]; otherwise, <c>false</c>.
        /// </returns>
        public bool IsButtonDown(MouseButton button)
        {
            return (Buttons & (1L << (int)button)) != 0;
        }
    }
}