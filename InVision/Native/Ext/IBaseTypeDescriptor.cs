namespace InVision.Native.Ext
{
    public interface IBaseTypeDescriptor : IDescriptor
    {
        /// <summary>
        /// Gets the self.
        /// </summary>
        /// <value>The self.</value>
        Handle Self { get; }
    }
}