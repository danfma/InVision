using System;
using System.Linq;
using InVision.Native;
using InVision.Native.Collections;
using InVision.Ogre.Native;

namespace InVision.Ogre
{
	public class ConfigFile : CppWrapper<IConfigFile>
	{
		public static readonly IConfigFile NativeStatic = CreateCppInstance<IConfigFile>();

		/// <summary>
		/// Initializes a new instance of the <see cref="ConfigFile"/> class.
		/// </summary>
		/// <param name="nativeInstance">The native instance.</param>
		public ConfigFile(IConfigFile nativeInstance)
			: base(nativeInstance)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ConfigFile"/> class.
		/// </summary>
		public ConfigFile()
			: this(CreateCppInstance<IConfigFile>())
		{
			Native.Construct().SetOwner(this);
		}

		/// <summary>
		/// Releases unmanaged and - optionally - managed resources
		/// </summary>
		/// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
		protected override void Dispose(bool disposing)
		{
			if (Native != null) {
				Native.Destruct();
			}

			base.Dispose(disposing);
		}

		/// <summary>
		/// Loads the specified filename.
		/// </summary>
		/// <param name="filename">The filename.</param>
		/// <param name="separators">The separators.</param>
		/// <param name="trimWhitespace">if set to <c>true</c> [trim whitespace].</param>
		public void Load(string filename, string separators = "\t:=", bool trimWhitespace = true)
		{
			Native.Load(filename, separators, trimWhitespace);
		}

		/// <summary>
		/// Gets the sections.
		/// </summary>
		/// <returns></returns>
		public SettingsBySection GetSections()
		{
			var settingsBySection = new SettingsBySection();

			unsafe {
				Native.SettingsBySection* sections = null;

				try {
					Native.GetSections(out sections);

					Native.SettingsBySection* currentSection = sections;

					while (currentSection != null) {
						var settings = new Settings();
						settingsBySection.Add(currentSection->SectionName, settings);

						Setting* currentSetting = currentSection->Settings;

						while (currentSetting != null) {
							settings[currentSetting->NameString] = currentSetting->ValueString;
							currentSetting = currentSetting->Next;
						}

						currentSection = currentSection->Next;
					}
				} finally {
					NativeStatic.DeleteSettingsBySection(sections);
				}
			}

			return settingsBySection;
		}

		#region Nested type: Settings

		public sealed class Settings : MultiDictionary<string, string>
		{
		}

		#endregion

		#region Nested type: SettingsBySection

		public sealed class SettingsBySection : MultiDictionary<string, Settings>
		{
		}

		#endregion

		/// <summary>
		/// Loads the resources.
		/// </summary>
		/// <param name="resourceFile">The resource file.</param>
		public static void LoadResources(string resourceFile = "resources.cfg")
		{
			// Load resource paths from config file
			using (var cf = new ConfigFile()) {
				cf.Load(resourceFile);

				// Go through all sections & settings in the file
				var settings =
					from section in cf.GetSections()
					from setting in section.Value
					select new {
						Section = section.Key,
						Setting = setting.Key,
						setting.Value
					};

				foreach (var setting in settings) {
					ResourceGroupManager.Instance.AddResourceLocation(
						setting.Value, setting.Setting, setting.Section);
				}

				ResourceGroupManager.Instance.InitializeAllResourceGroups();
			}
		}
	}
}