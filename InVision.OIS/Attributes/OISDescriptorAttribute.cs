using System;
using InVision.Native.Ext;

namespace InVision.OIS.Attributes
{
    public class OISDescriptorAttribute : CppDescriptorAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OISDescriptorAttribute"/> class.
        /// </summary>
        public OISDescriptorAttribute()
        {
            Initialize();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OISDescriptorAttribute"/> class.
        /// </summary>
        /// <param name="typename">The typename.</param>
        public OISDescriptorAttribute(string typename)
            : base(typename)
        {
            Initialize();
        }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        private void Initialize()
        {
            Namespace = "OIS";
            DefinitionFile = "OIS.h";
        }
    }
}