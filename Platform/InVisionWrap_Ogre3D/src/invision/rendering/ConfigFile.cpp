#include "ConfigFile.h"
#include "invision/Util.h"

using namespace invision;

__EXPORT HConfigFile __ENTRY cfgfile_new()
{
	return new Ogre::ConfigFile();
}

__EXPORT void __ENTRY cfgfile_delete(HConfigFile configFile)
{
	delete asConfigFile(configFile);
}

__EXPORT void __ENTRY cfgfile_load(
		HConfigFile configFile,
		const char* filename,
		const char* separators,
		Bool trimWhitespace)
{
	asConfigFile(configFile)->load(filename, separators, fromBool(trimWhitespace));
}

__EXPORT void __ENTRY cfgfile_load_with_resourcegroup(
		HConfigFile configFile,
		const char* filename,
		const char* resourceGroup,
		const char* separators,
		Bool trimWhitespace)
{
	asConfigFile(configFile)->load(filename, resourceGroup, separators, fromBool(trimWhitespace));
}

// __EXPORT void __ENTRY cfgfile_load_with_datastream()

__EXPORT void __ENTRY cfgfile_load_direct(
		HConfigFile configFile,
		const char* filename,
		const char* separators,
		Bool trimWhitespace)
{
	asConfigFile(configFile)->loadDirect(filename, separators, fromBool(trimWhitespace));
}

__EXPORT void __ENTRY cfgfile_load_from_resource_system(
		HConfigFile configFile,
		const char* filename,
		const char* resourceGroup,
		const char* separators,
		Bool trimWhitespace)
{
	asConfigFile(configFile)->loadFromResourceSystem(
				filename, resourceGroup, separators, fromBool(trimWhitespace));
}

__EXPORT const char* __ENTRY cfgfile_get_setting(
		HConfigFile configFile,
		const char* key,
		const char* section,
		const char* defaultValue)
{
	Ogre::String str = asConfigFile(configFile)->getSetting(
				key,
				section == NULL ? Ogre::StringUtil::BLANK : section,
				defaultValue == NULL ? Ogre::StringUtil::BLANK : defaultValue);

	return copyString(str);
}

__EXPORT PStringArray __ENTRY cfgfile_multi_setting(
		HConfigFile configFile,
		const char* key,
		const char* section)
{
	Ogre::StringVector vstr = asConfigFile(configFile)->getMultiSetting(key, section);


	PStringArray pStrArray = new StringArray();
	pStrArray->count = vstr.size();
	pStrArray->strings = new char*[pStrArray->count];

	int i = 0;
	Ogre::StringVector::iterator it = vstr.begin();

	while (it != vstr.end()) {
		pStrArray->strings[i++] = copyString(*(it++));
	}

	return pStrArray;
}

__EXPORT void __ENTRY cfgfile_clear(HConfigFile configFile)
{
	asConfigFile(configFile)->clear();
}

__EXPORT HSectionEnumerator __ENTRY cfgfile_get_section_iterator(
		HConfigFile configFile)
{
	Ogre::ConfigFile::SectionIterator iterator = asConfigFile(configFile)->getSectionIterator();

	return new SectionEnumerator(iterator);
}

__EXPORT HSettingsEnumerator __ENTRY cfgfile_get_settings_iterator(
		HConfigFile configFile,
		const char* section)
{
	Ogre::String ssection = section == NULL ? Ogre::StringUtil::BLANK : section;
	Ogre::ConfigFile::SettingsIterator iterator = asConfigFile(configFile)->getSettingsIterator(ssection);

	return new SettingsEnumerator(iterator);
}
