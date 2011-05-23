using System;
using InVision.Native;

namespace InVision.OIS.Attributes
{
    [AttributeUsage(AttributeTargets.Interface)]
    public class OISInterfaceAttribute : CppInterfaceAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OISInterfaceAttribute"/> class.
        /// </summary>
        /// <param name="typename">The typename.</param>
        public OISInterfaceAttribute(string typename)
            : base(typename)
        {
            Namespace = "OIS";
            DefinitionFile = "OIS.h";
        }
    }
}