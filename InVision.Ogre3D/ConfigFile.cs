using System;
using System.Collections.Generic;
using System.Linq;
using InVision.Ogre3D.Native;

namespace InVision.Ogre3D
{
	public class ConfigFile : Handle
	{
		/// <summary>
		/// 	Initializes a new instance of the <see cref = "ConfigFile" /> class.
		/// </summary>
		/// <param name = "pSelf">The p self.</param>
		/// <param name = "ownsHandle">if set to <c>true</c> [owns handle].</param>
		internal ConfigFile(IntPtr pSelf, bool ownsHandle)
			: base(pSelf, ownsHandle)
		{
		}

		/// <summary>
		/// 	Initializes a new instance of the <see cref = "ConfigFile" /> class.
		/// </summary>
		/// <param name = "ownsHandle">if set to <c>true</c> [owns handle].</param>
		internal ConfigFile(bool ownsHandle)
			: base(ownsHandle)
		{
		}

		/// <summary>
		/// 	Initializes a new instance of the <see cref = "ConfigFile" /> class.
		/// </summary>
		public ConfigFile()
			: this(NativeConfigFile.New(), true)
		{
		}

		/// <summary>
		/// 	Releases the specified pointer to the unmanaged object.
		/// </summary>
		/// <param name = "pSelf">The pointer to the unmanaged object.</param>
		/// <returns></returns>
		protected override bool Release(IntPtr pSelf)
		{
			NativeConfigFile.Delete(pSelf);
			return true;
		}

		/// <summary>
		/// 	Load from a filename (not using resource group locations)
		/// </summary>
		/// <param name = "filename">The filename.</param>
		/// <param name = "separators">The separators.</param>
		/// <param name = "trimWhitespace">if set to <c>true</c> [trim whitespace].</param>
		public void Load(string filename, string separators = "\t:=", bool trimWhitespace = true)
		{
			NativeConfigFile.Load(handle, filename, separators, trimWhitespace);
		}

		/// <summary>
		/// 	Load from a filename (using resource group locations)
		/// </summary>
		/// <param name = "filename">The filename.</param>
		/// <param name = "resourceGroup">The resource group.</param>
		/// <param name = "separators">The separators.</param>
		/// <param name = "trimWhitespace">if set to <c>true</c> [trim whitespace].</param>
		public void Load(string filename, string resourceGroup, string separators = "\t:=", bool trimWhitespace = true)
		{
			NativeConfigFile.Load(handle, filename, resourceGroup, separators, trimWhitespace);
		}

		/// <summary>
		/// 	Load from a filename (not using resource group locations)
		/// </summary>
		/// <param name = "filename">The filename.</param>
		/// <param name = "separators">The separators.</param>
		/// <param name = "trimWhitespace">if set to <c>true</c> [trim whitespace].</param>
		public void LoadDirect(string filename, string separators = "\t:=", bool trimWhitespace = true)
		{
			NativeConfigFile.LoadDirect(handle, filename, separators, trimWhitespace);
		}

		/// <summary>
		/// 	Load from a filename (using resource group locations)
		/// </summary>
		/// <param name = "filename">The filename.</param>
		/// <param name = "resourceGroup">The resource group.</param>
		/// <param name = "separators">The separators.</param>
		/// <param name = "trimWhitespace">if set to <c>true</c> [trim whitespace].</param>
		public void LoadFromResourceSystem(string filename, string resourceGroup, string separators = "\t:=",
										   bool trimWhitespace = true)
		{
			NativeConfigFile.LoadFromResourceGroup(handle, filename, resourceGroup, separators, trimWhitespace);
		}

		/// <summary>
		/// 	Gets the first setting from the file with the named key.
		/// </summary>
		/// <param name = "key">The key.</param>
		/// <param name = "section">The section.</param>
		/// <param name = "defaultValue">The default value.</param>
		/// <returns></returns>
		public string GetSetting(string key, string section = null, string defaultValue = null)
		{
			return NativeConfigFile.GetSetting(handle, key, section, defaultValue);
		}

		/// <summary>
		/// 	Gets all settings from the file with the named key.
		/// </summary>
		/// <param name = "key">The key.</param>
		/// <param name = "section">The section.</param>
		/// <returns></returns>
		public string[] GetMultiSetting(string key, string section = null)
		{
			return NativeConfigFile.MultiSetting(handle, key, section);
		}

		/// <summary>
		/// 	Get an enumeration over all the available settings in a section.
		/// </summary>
		/// <param name = "section">The section.</param>
		/// <returns></returns>
		public IEnumerable<KeyValuePair<string, string>> GetSettings(string section = null)
		{
			if (string.IsNullOrEmpty(section))
				section = null;

			return NativeConfigFile.GetSettings(handle, section).
				Select(pair => new KeyValuePair<string, string>(pair.Key, pair.Value));
		}

		/// <summary>
		/// 	Gets the settings iterator.
		/// </summary>
		/// <param name = "section">The section.</param>
		/// <returns></returns>
		public IEnumerator<KeyValuePair<string, string>> GetSettingsIterator(string section = null)
		{
			return GetSettings(section).GetEnumerator();
		}

		/// <summary>
		/// 	Gets the sections.
		/// </summary>
		/// <returns></returns>
		public IEnumerable<KeyValuePair<string, IEnumerable<KeyValuePair<string, string>>>> GetSections()
		{
			return NativeConfigFile.GetSections(handle);
		}

		/// <summary>
		/// 	Gets the section iterator.
		/// </summary>
		/// <returns></returns>
		public IEnumerator<KeyValuePair<string, IEnumerable<KeyValuePair<string, string>>>> GetSectionIterator()
		{
			return GetSections().GetEnumerator();
		}
	}
}