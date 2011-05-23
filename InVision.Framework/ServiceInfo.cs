using System;

namespace InVision.Framework
{
	public struct ServiceInfo
	{
		private readonly object _service;
		private readonly int _priority;

		/// <summary>
		/// Initializes a new instance of the <see cref="ServiceInfo"/> struct.
		/// </summary>
		/// <param name="service">The service.</param>
		/// <param name="priority">The priority.</param>
		public ServiceInfo(object service, int priority = 0)
		{
			_service = service;
			_priority = priority;
		}

		/// <summary>
		/// Gets the service.
		/// </summary>
		/// <value>The service.</value>
		public object Service
		{
			get { return _service; }
		}

		/// <summary>
		/// Gets the priority.
		/// </summary>
		/// <value>The priority.</value>
		public int Priority
		{
			get { return _priority; }
		}
	}
}