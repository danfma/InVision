using InVision.Input;

namespace InVision.OIS
{
	public interface IAxisComponent : IComponent
	{
		/// <summary>
		/// 	Gets the absolute.
		/// </summary>
		/// <value>The absolute.</value>
		int Absolute { get; }

		/// <summary>
		/// 	Gets the relative.
		/// </summary>
		/// <value>The relative.</value>
		int Relative { get; }

		/// <summary>
		/// 	Gets a value indicating whether [absolute only].
		/// </summary>
		/// <value><c>true</c> if [absolute only]; otherwise, <c>false</c>.</value>
		bool AbsoluteOnly { get; }
	}
}