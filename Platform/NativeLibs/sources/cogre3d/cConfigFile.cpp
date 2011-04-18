#include "ConfigFile.h"
#include "TypeConvert.h"

using namespace invision;

__export HConfigFile __entry cfgfile_new()
{
	return new Ogre::ConfigFile();
}

__export void __entry cfgfile_delete(HConfigFile configFile)
{
	delete asConfigFile(configFile);
}

__export void __entry cfgfile_load(
		HConfigFile configFile,
		const _string filename,
		const _string separators,
		_bool trimWhitespace)
{
	asConfigFile(configFile)->load(filename, separators, fromBool(trimWhitespace));
}

__export void __entry cfgfile_load_with_resourcegroup(
		HConfigFile configFile,
		const _string filename,
		const _string resourceGroup,
		const _string separators,
		_bool trimWhitespace)
{
	asConfigFile(configFile)->load(filename, resourceGroup, separators, fromBool(trimWhitespace));
}

// __export void __entry cfgfile_load_with_datastream()

__export void __entry cfgfile_load_direct(
		HConfigFile configFile,
		const _string filename,
		const _string separators,
		_bool trimWhitespace)
{
	asConfigFile(configFile)->loadDirect(filename, separators, fromBool(trimWhitespace));
}

__export void __entry cfgfile_load_from_resource_system(
		HConfigFile configFile,
		const _string filename,
		const _string resourceGroup,
		const _string separators,
		_bool trimWhitespace)
{
	asConfigFile(configFile)->loadFromResourceSystem(
				filename, resourceGroup, separators, fromBool(trimWhitespace));
}

__export const _string __entry cfgfile_get_setting(
		HConfigFile configFile,
		const _string key,
		const _string section,
		const _string defaultValue)
{
	Ogre::String str = asConfigFile(configFile)->getSetting(
				key,
				section == NULL ? Ogre::StringUtil::BLANK : section,
				defaultValue == NULL ? Ogre::StringUtil::BLANK : defaultValue);

	return copyString(str);
}

__export PStringArray __entry cfgfile_multi_setting(
		HConfigFile configFile,
		const _string key,
		const _string section)
{
	Ogre::StringVector vstr = asConfigFile(configFile)->getMultiSetting(key, section);


	PStringArray pStrArray = new StringArray();
	pStrArray->count = vstr.size();
	pStrArray->strings = new _string[pStrArray->count];

	_int i = 0;
	Ogre::StringVector::iterator it = vstr.begin();

	while (it != vstr.end()) {
		pStrArray->strings[i++] = copyString(*(it++));
	}

	return pStrArray;
}

__export void __entry cfgfile_clear(HConfigFile configFile)
{
	asConfigFile(configFile)->clear();
}

__export HSectionEnumerator __entry cfgfile_get_section_iterator(
		HConfigFile configFile)
{
	Ogre::ConfigFile::SectionIterator iterator = asConfigFile(configFile)->getSectionIterator();

	return new SectionEnumerator(iterator);
}

__export HSettingsEnumerator __entry cfgfile_get_settings_iterator(
		HConfigFile configFile,
		const _string section)
{
	Ogre::String ssection = section == NULL ? Ogre::StringUtil::BLANK : section;
	Ogre::ConfigFile::SettingsIterator iterator = asConfigFile(configFile)->getSettingsIterator(ssection);

	return new SettingsEnumerator(iterator);
}
