using System;
using InVision.Native;

namespace InVision.OIS.Attributes
{
    [AttributeUsage(AttributeTargets.Interface)]
    public class OISClassAttribute : CppClassAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OISClassAttribute"/> class.
        /// </summary>
        /// <param name="typename">The typename.</param>
        public OISClassAttribute(string typename)
            : base(typename)
        {
            Namespace = "OIS";
            DefinitionFile = "OIS.h";
        }
    }
}