using System;
using InVision.Native.Ext;

namespace InVision.OIS.Attributes
{
    [AttributeUsage(AttributeTargets.Enum)]
    public class OISEnumerationAttribute : CppEnumerationAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OISEnumerationAttribute"/> class.
        /// </summary>
        /// <param name="typename">The typename.</param>
        public OISEnumerationAttribute(string typename)
            : base(typename)
        {
        }
    }
}