using System;

namespace InVision.Native
{
    public class FieldAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FieldAttribute"/> class.
        /// </summary>
        public FieldAttribute() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="FieldAttribute"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public FieldAttribute(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the type of the CPP.
        /// </summary>
        /// <value>The type of the CPP.</value>
        public string CppType { get; set; }

        /// <summary>
        /// Gets or sets the special casting.
        /// </summary>
        /// <value>The special casting.</value>
        public string SpecialCasting { get; set; }
    }
}