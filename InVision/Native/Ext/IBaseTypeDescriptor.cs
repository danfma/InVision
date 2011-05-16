namespace InVision.Native.Ext
{
    public interface IDescriptor
    {

    }

    public interface IBaseTypeDescriptor : IDescriptor
    {
        /// <summary>
        /// Gets the self.
        /// </summary>
        /// <value>The self.</value>
        Handle Self { get; }
    }

    public interface IDerivedDescriptor<out T> : IDescriptor
        where T : IDescriptor
    {
        /// <summary>
        /// Gets the type of the base.
        /// </summary>
        /// <value>The type of the base.</value>
        T BaseType { get; }
    }
}