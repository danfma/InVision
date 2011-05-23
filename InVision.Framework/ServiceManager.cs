using System;
using System.Collections.Concurrent;
using System.Linq;
using InVision.Framework.Util;

namespace InVision.Framework
{
	public sealed class ServiceManager : DisposableObject, IServiceManager
	{
		private static ServiceManager _instace;
		private ConcurrentDictionary<string, ServiceInfo> _services;

		/// <summary>
		/// Initializes a new instance of the <see cref="ServiceManager"/> class.
		/// </summary>
		private ServiceManager()
		{
			_services = new ConcurrentDictionary<string, ServiceInfo>();
		}

		/// <summary>
		/// Adds the service.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <param name="service">The service.</param>
		/// <param name="priority">The priority.</param>
		public void AddService(string name, object service, int priority = 0)
		{
			if (name == null) throw new ArgumentNullException("name");
			if (service == null) throw new ArgumentNullException("service");

			_services.TryAdd(name, new ServiceInfo(service, priority));
		}

		/// <summary>
		/// Adds the service.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="name">The name.</param>
		/// <param name="service">The service.</param>
		/// <param name="priority">The priority.</param>
		public void AddService<T>(string name, T service, int priority = 0)
		{
			if (name == null) throw new ArgumentNullException("name");

			_services.TryAdd(name, new ServiceInfo(service, priority));
		}

		/// <summary>
		/// Removes the service.
		/// </summary>
		/// <param name="name">The name.</param>
		public void RemoveService(string name)
		{
			if (name == null) throw new ArgumentNullException("name");

			ServiceInfo serviceInfo;

			_services.TryRemove(name, out serviceInfo);
		}

		/// <summary>
		/// Gets the service.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <returns></returns>
		public object GetService(string name)
		{
			if (name == null) throw new ArgumentNullException("name");

			ServiceInfo serviceInfo;

			_services.TryGetValue(name, out serviceInfo);

			return serviceInfo.Service;
		}

		/// <summary>
		/// Gets the service.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="name">The name.</param>
		/// <returns></returns>
		public T GetService<T>(string name)
		{
			if (name == null) throw new ArgumentNullException("name");

			return (T)GetService(name);
		}

		/// <summary>
		/// Releases unmanaged and - optionally - managed resources
		/// </summary>
		/// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
		protected override void Dispose(bool disposing)
		{
			if (_services != null)
			{
				var orderedPairs = _services.OrderBy(pair => pair.Value.Priority);

				foreach (var orderedPair in orderedPairs)
				{
					try
					{
						var service = orderedPair.Value.Service;

						if (service is IDisposable)
							((IDisposable)service).Dispose();
					}
					catch (Exception ex)
					{
						using (new ConsoleColorRestore())
						{
							Console.ForegroundColor = ConsoleColor.Red;
							Console.WriteLine("Failed to dispose service {0}: {1}", orderedPair.Key, ex);
						}
					}
				}

				_services.Clear();
			}

			if (disposing)
				_services = null;
		}

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>The instance.</value>
		public static IServiceManager Instance
		{
			get { return _instace; }
		}

		/// <summary>
		/// Creates the instance.
		/// </summary>
		internal static void CreateInstance()
		{
			_instace = new ServiceManager();
		}

		/// <summary>
		/// Disposes the instance.
		/// </summary>
		internal static void DisposeInstance()
		{
			if (_instace == null)
				return;

			_instace.Dispose();
			_instace = null;
		}
	}
}