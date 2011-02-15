using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using InVision.Ogre3D.Util;

namespace InVision.Ogre3D.Native
{
	internal sealed class NativeConfigFile : PlatformInvoke
	{
		[DllImport(Library, EntryPoint = "cfgfile_new")]
		public static extern IntPtr New();

		[DllImport(Library, EntryPoint = "cfgfile_delete")]
		public static extern void Delete(IntPtr pConfigFile);

		[DllImport(Library, EntryPoint = "cfgfile_load")]
		public static extern void Load(
			IntPtr pConfigFile,
			[MarshalAs(UnmanagedType.LPStr)] string filename,
			[MarshalAs(UnmanagedType.LPStr)] string separators,
			[MarshalAs(UnmanagedType.Bool)] bool trimWhitespace);

		[DllImport(Library, EntryPoint = "cfgfile_load_with_resourcegroup")]
		public static extern void Load(
			IntPtr pConfigFile,
			[MarshalAs(UnmanagedType.LPStr)] string filename,
			[MarshalAs(UnmanagedType.LPStr)] string resourceGroup,
			[MarshalAs(UnmanagedType.LPStr)] string separators,
			[MarshalAs(UnmanagedType.Bool)] bool trimWhitespace);

		[DllImport(Library, EntryPoint = "cfgfile_load_direct")]
		public static extern void LoadDirect(
			IntPtr pConfigFile,
			[MarshalAs(UnmanagedType.LPStr)] string filename,
			[MarshalAs(UnmanagedType.LPStr)] string separators,
			[MarshalAs(UnmanagedType.Bool)] bool trimWhitespace);

		[DllImport(Library, EntryPoint = "cfgfile_load_from_resource_system")]
		public static extern void LoadFromResourceGroup(
			IntPtr pConfigFile,
			[MarshalAs(UnmanagedType.LPStr)] string filename,
			[MarshalAs(UnmanagedType.LPStr)] string resourceGroup,
			[MarshalAs(UnmanagedType.LPStr)] string separators,
			[MarshalAs(UnmanagedType.Bool)] bool trimWhitespace);

		[DllImport(Library, EntryPoint = "cfgfile_get_setting")]
		public static extern IntPtr _GetSetting(
			IntPtr pConfigFile,
			[MarshalAs(UnmanagedType.LPStr)] string key,
			[MarshalAs(UnmanagedType.LPStr)] string section,
			[MarshalAs(UnmanagedType.LPStr)] string defaultValue);

		[DllImport(Library, EntryPoint = "cfgfile_multi_setting")]
		public static extern IntPtr _MultiSetting(
			IntPtr pConfigFile,
			[MarshalAs(UnmanagedType.LPStr)] string key,
			[MarshalAs(UnmanagedType.LPStr)] string section);

		[DllImport(Library, EntryPoint = "cfgfile_clear")]
		public static extern void Clear(IntPtr pConfigFile);

		[DllImport(Library, EntryPoint = "cfgfile_get_section_iterator")]
		public static extern IntPtr GetSectionIterator(IntPtr pConfigFile);

		[DllImport(Library, EntryPoint = "cfgfile_get_settings_iterator")]
		public static extern IntPtr GetSettingsIterator(IntPtr pConfigFile, string section);

		#region Helpers

		/// <summary>
		/// 	Gets the settings.
		/// </summary>
		/// <param name = "pConfigFile">The p config file.</param>
		/// <param name = "section">The section.</param>
		/// <returns></returns>
		public static IEnumerable<KeyValuePair<string, string>> GetSettings(IntPtr pConfigFile, string section)
		{
			return GetSettingsIterator(pConfigFile, section).
				AsAutoEnumeration<NameValuePair>(NativeUtilities.DeleteNameValuePair).
				Select(p => new KeyValuePair<string, string>(p.Key, p.Value));
		}

		/// <summary>
		/// 	Gets the sections.
		/// </summary>
		/// <param name = "pConfigFile">The p config file.</param>
		/// <returns></returns>
		public static IEnumerable<KeyValuePair<string, IEnumerable<KeyValuePair<string, string>>>> GetSections(
			IntPtr pConfigFile)
		{
			var sectionEnumeration = GetSectionIterator(pConfigFile).AsEnumeration<NameHandlePair>();

			foreach (var sectionPair in sectionEnumeration)
			{
				var pNameHandlePair = sectionPair.Key;
				var sectionKey = sectionPair.Value.Key;
				var pSettingsEnumerator = sectionPair.Value.Value;

				try
				{
					var settingEnumeration = pSettingsEnumerator.
						AsAutoEnumeration<NameValuePair>(NativeUtilities.DeleteNameValuePair).
						Select(p => new KeyValuePair<string, string>(p.Key, p.Value));

					yield return new KeyValuePair<string, IEnumerable<KeyValuePair<string, string>>>(sectionKey, settingEnumeration);
				}
				finally
				{
					NativeUtilities.DeleteNameHandlePair(pNameHandlePair);
				}
			}
		}


		public static string GetSetting(IntPtr pConfigFile, string key, string section, string defaultValue)
		{
			return _GetSetting(pConfigFile, key, section, defaultValue).AsString();
		}

		public static string[] MultiSetting(IntPtr pConfigFile, string key, string section)
		{
			IntPtr result = _MultiSetting(pConfigFile, key, section);

			try
			{
				var stringArray = result.AsStructure<StringArray>();
				var array = new string[stringArray.Count];

				for (int i = 0; i < array.Length; i++)
				{
					array[i] = IntPtr.Add(stringArray.PStrings, Marshal.SizeOf(typeof(IntPtr)) * i).AsConstString();
				}

				return array;
			}
			finally
			{
				NativeUtilities.DeleteStringArray(result);
			}
		}

		#endregion
	}
}