using System;

namespace InVision.Native
{
    public class CppImplementationAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CppImplementationAttribute"/> class.
        /// </summary>
        /// <param name="targetInterface">The target interface.</param>
        public CppImplementationAttribute(Type targetInterface)
        {
            TargetInterface = targetInterface;
        }

        /// <summary>
        /// Gets or sets the target interface.
        /// </summary>
        /// <value>The target interface.</value>
        public Type TargetInterface { get; private set; }
    }
}