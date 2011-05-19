namespace InVision.Native.Ext
{
    public class CppDescriptorAttribute : CppValueObjectAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CppDescriptorAttribute"/> class.
        /// </summary>
        public CppDescriptorAttribute()
        {
            IsDescriptor = true;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CppDescriptorAttribute"/> class.
        /// </summary>
        /// <param name="typename">The typename.</param>
        public CppDescriptorAttribute(string typename) : base(typename)
        {
            IsDescriptor = true;
        }
    }
}