namespace InVision.Framework
{
	public interface IServiceManager
	{
		/// <summary>
		/// Adds the service.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <param name="service">The service.</param>
		/// <param name="priority">The priority.</param>
		void AddService(string name, object service, int priority = 0);

		/// <summary>
		/// Adds the service.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="name">The name.</param>
		/// <param name="service">The service.</param>
		/// <param name="priority">The priority.</param>
		void AddService<T>(string name, T service, int priority = 0);

		/// <summary>
		/// Removes the service.
		/// </summary>
		/// <param name="name">The name.</param>
		void RemoveService(string name);

		/// <summary>
		/// Gets the service.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <returns></returns>
		object GetService(string name);

		/// <summary>
		/// Gets the service.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="name">The name.</param>
		/// <returns></returns>
		T GetService<T>(string name);
	}
}