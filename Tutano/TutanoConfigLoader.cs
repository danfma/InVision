using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using InVision.Framework.Config;

namespace Tutano
{
	public class TutanoConfigLoader
	{
		/// <summary>
		/// Gets the native directory.
		/// </summary>
		/// <value></value>
		public static string NativeDirectory
		{
			get
			{
				return string.Format("Bin/Native/{0}-{1}", Platform.PlatformIdentity,
									 Platform.Is32Bits ? "32bit" : "64bit");
			}
		}

		/// <summary>
		/// Loads this instance.
		/// </summary>
		/// <param name="tutanoApplication">The tutano.</param>
		/// <returns></returns>
		public Configuration Load(TutanoApplication tutanoApplication)
		{
			CreateDefaultDirectories();
			SetNativeDirectoriesToPath();

			var config = Configuration.LoadOrCreate<Configuration>("Config/Tutano.config.xml");

			LoadLibraries();

			return config;
		}

		/// <summary>
		/// Creates the default directories.
		/// </summary>
		private void CreateDefaultDirectories()
		{
			Console.WriteLine("Checking for default directories");

			var directories = new[] {
				"Config/",
				"Libraries/",
				"Scripts/",
				"Content/"
			};

			foreach (string directory in directories.OrderBy(s => s))
			{
				if (!Directory.Exists(directory))
				{
					Console.WriteLine("=> Creating directory '{0}'", directory);
					Directory.CreateDirectory(directory);
				}
				else
					Console.WriteLine("=> Directory '{0}': OK", directory);
			}
		}

		/// <summary>
		/// Loads the libraries.
		/// </summary>
		private void LoadLibraries()
		{
			Console.WriteLine("Loading custom libraries");

			foreach (string directory in GetDirectories("Libraries"))
			{
				foreach (string assemblyFile in Directory.GetFiles(directory, "*.dll"))
				{
					Assembly assembly = Assembly.LoadFrom(assemblyFile);

					Console.WriteLine("=> Loading library: {0}", assembly.GetName().Name);
				}
			}
		}

		/// <summary>
		/// Sets the native directories to path.
		/// </summary>
		private void SetNativeDirectoriesToPath()
		{
			string nativeDirectory = NativeDirectory;

			Console.WriteLine("Setting directories for searching native libraries");

			IEnumerable<string> directories = GetDirectories(nativeDirectory);

			foreach (string directory in directories)
			{
				Console.WriteLine("=> {0}", directory);
				Platform.AddLibraryPath(directory);
			}
		}

		/// <summary>
		/// Gets the directories.
		/// </summary>
		/// <param name="rootDirectory">The root directory.</param>
		/// <param name="recursive">if set to <c>true</c> [recursive].</param>
		/// <returns></returns>
		private static IEnumerable<string> GetDirectories(string rootDirectory, bool recursive = true)
		{
			yield return rootDirectory;

			foreach (string directory in Directory.GetDirectories(rootDirectory))
			{
				yield return directory;

				if (!recursive)
					continue;

				foreach (string innerDirectory in GetDirectories(directory))
				{
					yield return innerDirectory;
				}
			}
		}
	}
}