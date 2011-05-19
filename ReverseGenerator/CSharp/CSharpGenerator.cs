using System;
using System.Collections.Generic;

namespace ReverseGenerator.CSharp
{
    public class CSharpGenerator : IGenerator
    {
        #region IGenerator Members

        /// <summary>
        /// Generates the specified options.
        /// </summary>
        /// <param name="configOptions">The options.</param>
        /// <param name="types">The types.</param>
        public void Generate(ConfigOptions configOptions, IEnumerable<Type> types)
        {
            new CSharpBindingGenerator(configOptions).Generate(types, ".Bindings");
			new CSharpCppInstanceGenerator(configOptions).Generate(types, ".CppInstances");
            new CSharpCppInstanceGenerator(configOptions).Generate(types, ".CppInstances");
        }

        #endregion
    }
}