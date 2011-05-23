namespace InVision.Native
{
	/// <summary>
	/// 
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public interface ICppWrapper<out T>
	{
		/// <summary>
		/// Gets the native.
		/// </summary>
		/// <value>The native.</value>
		T Native { get; }
	}
}