using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace InVision.Ogre.Config
{
	public class PluginsConfig
	{
		private readonly List<PluginConfig> _plugins;

		/// <summary>
		/// Initializes a new instance of the <see cref="PluginsConfig"/> class.
		/// </summary>
		public PluginsConfig()
		{
			_plugins = new List<PluginConfig>();
		}

		/// <summary>
		/// Gets or sets the plugins folder.
		/// </summary>
		/// <value>The plugins folder.</value>
		public string PluginsFolder { get; set; }

		/// <summary>
		/// Gets or sets the plugins.
		/// </summary>
		/// <value>The plugins.</value>
		public IEnumerable<PluginConfig> Plugins { get { return _plugins; } }

		/// <summary>
		/// Adds an object to the end of the <see cref="T:System.Collections.Generic.List`1"/>.
		/// </summary>
		/// <param name="item">The object to be added to the end of the <see cref="T:System.Collections.Generic.List`1"/>. The value can be null for reference types.</param>
		public void Add(PluginConfig item)
		{
			_plugins.Add(item);
		}

		/// <summary>
		/// Adds the elements of the specified collection to the end of the <see cref="T:System.Collections.Generic.List`1"/>.
		/// </summary>
		/// <param name="collection">The collection whose elements should be added to the end of the <see cref="T:System.Collections.Generic.List`1"/>. The collection itself cannot be null, but it can contain elements that are null, if type <paramref name="T"/> is a reference type.</param><exception cref="T:System.ArgumentNullException"><paramref name="collection"/> is null.</exception>
		public void AddRange(IEnumerable<PluginConfig> collection)
		{
			_plugins.AddRange(collection);
		}

		/// <summary>
		/// Removes all elements from the <see cref="T:System.Collections.Generic.List`1"/>.
		/// </summary>
		public void Clear()
		{
			_plugins.Clear();
		}

		/// <summary>
		/// Determines whether an element is in the <see cref="T:System.Collections.Generic.List`1"/>.
		/// </summary>
		/// <returns>
		/// true if <paramref name="item"/> is found in the <see cref="T:System.Collections.Generic.List`1"/>; otherwise, false.
		/// </returns>
		/// <param name="item">The object to locate in the <see cref="T:System.Collections.Generic.List`1"/>. The value can be null for reference types.</param>
		public bool Contains(PluginConfig item)
		{
			return _plugins.Contains(item);
		}

		/// <summary>
		/// Returns an enumerator that iterates through the <see cref="T:System.Collections.Generic.List`1"/>.
		/// </summary>
		/// <returns>
		/// A <see cref="T:System.Collections.Generic.List`1.Enumerator"/> for the <see cref="T:System.Collections.Generic.List`1"/>.
		/// </returns>
		public List<PluginConfig>.Enumerator GetEnumerator()
		{
			return _plugins.GetEnumerator();
		}

		/// <summary>
		/// Creates a shallow copy of a range of elements in the source <see cref="T:System.Collections.Generic.List`1"/>.
		/// </summary>
		/// <returns>
		/// A shallow copy of a range of elements in the source <see cref="T:System.Collections.Generic.List`1"/>.
		/// </returns>
		/// <param name="index">The zero-based <see cref="T:System.Collections.Generic.List`1"/> index at which the range starts.</param><param name="count">The number of elements in the range.</param><exception cref="T:System.ArgumentOutOfRangeException"><paramref name="index"/> is less than 0.-or-<paramref name="count"/> is less than 0.</exception><exception cref="T:System.ArgumentException"><paramref name="index"/> and <paramref name="count"/> do not denote a valid range of elements in the <see cref="T:System.Collections.Generic.List`1"/>.</exception>
		public List<PluginConfig> GetRange(int index, int count)
		{
			return _plugins.GetRange(index, count);
		}

		/// <summary>
		/// Removes the first occurrence of a specific object from the <see cref="T:System.Collections.Generic.List`1"/>.
		/// </summary>
		/// <returns>
		/// true if <paramref name="item"/> is successfully removed; otherwise, false.  This method also returns false if <paramref name="item"/> was not found in the <see cref="T:System.Collections.Generic.List`1"/>.
		/// </returns>
		/// <param name="item">The object to remove from the <see cref="T:System.Collections.Generic.List`1"/>. The value can be null for reference types.</param>
		public bool Remove(PluginConfig item)
		{
			return _plugins.Remove(item);
		}

		/// <summary>
		/// Removes the all the elements that match the conditions defined by the specified predicate.
		/// </summary>
		/// <returns>
		/// The number of elements removed from the <see cref="T:System.Collections.Generic.List`1"/> .
		/// </returns>
		/// <param name="match">The <see cref="T:System.Predicate`1"/> delegate that defines the conditions of the elements to remove.</param><exception cref="T:System.ArgumentNullException"><paramref name="match"/> is null.</exception>
		public int RemoveAll(Predicate<PluginConfig> match)
		{
			return _plugins.RemoveAll(match);
		}

		/// <summary>
		/// Removes the element at the specified index of the <see cref="T:System.Collections.Generic.List`1"/>.
		/// </summary>
		/// <param name="index">The zero-based index of the element to remove.</param><exception cref="T:System.ArgumentOutOfRangeException"><paramref name="index"/> is less than 0.-or-<paramref name="index"/> is equal to or greater than <see cref="P:System.Collections.Generic.List`1.Count"/>.</exception>
		public void RemoveAt(int index)
		{
			_plugins.RemoveAt(index);
		}

		/// <summary>
		/// Removes a range of elements from the <see cref="T:System.Collections.Generic.List`1"/>.
		/// </summary>
		/// <param name="index">The zero-based starting index of the range of elements to remove.</param><param name="count">The number of elements to remove.</param><exception cref="T:System.ArgumentOutOfRangeException"><paramref name="index"/> is less than 0.-or-<paramref name="count"/> is less than 0.</exception><exception cref="T:System.ArgumentException"><paramref name="index"/> and <paramref name="count"/> do not denote a valid range of elements in the <see cref="T:System.Collections.Generic.List`1"/>.</exception>
		public void RemoveRange(int index, int count)
		{
			_plugins.RemoveRange(index, count);
		}

		/// <summary>
		/// Writes the specified writer.
		/// </summary>
		/// <param name="filename">The filename.</param>
		public void Write(string filename)
		{
			using (var writer = new StreamWriter(filename, false, Encoding.UTF8))
			{
				writer.WriteLine("# FILE GENERATED - DO NOT EDIT");
				writer.WriteLine("# PLUGINS FOLDER");
				writer.WriteLine("PluginFolder={0}", Path.GetFullPath(PluginsFolder));
				writer.WriteLine();

				foreach (var pluginFile in Plugins)
				{
					pluginFile.Write(writer);
				}

				writer.Flush();
			}
		}
	}
}