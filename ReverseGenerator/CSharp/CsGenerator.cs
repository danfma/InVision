﻿using System;
using System.Collections.Generic;

namespace CodeGenerator.CSharp
{
    public class CsGenerator : IGenerator
    {
        private SourceWriter _writer;

        #region IGenerator Members

        /// <summary>
        /// Generates the specified options.
        /// </summary>
        /// <param name="configOptions">The options.</param>
        /// <param name="types">The types.</param>
        public void Generate(ConfigOptions configOptions, IEnumerable<Type> types)
        {
            new CSharpBindingsGenerator(configOptions).Generate(types, ".Bindings");
        }

        #endregion
    }
}