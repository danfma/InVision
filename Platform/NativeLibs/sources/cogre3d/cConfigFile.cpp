#include "cOgre.h"

INV_EXPORT InvHandle
INV_CALL new_configfile()
{
	return createHandle<Ogre::ConfigFile>(
				new Ogre::ConfigFile());
}

INV_EXPORT void
INV_CALL delete_configfile(InvHandle self)
{
	destroyHandle(self);
}

INV_EXPORT void
INV_CALL configfile_load(InvHandle self, _string filename, _string separators, _bool trimWhitespace)
{
	asConfigFile(self)->load(filename, separators, fromBool(trimWhitespace));
}

INV_EXPORT void
INV_CALL configfile_get_sections(InvHandle self, SettingsBySection** settingsBySection)
{
	Ogre::ConfigFile::SectionIterator iterator = asConfigFile(self)->getSectionIterator();
	SettingsBySection** parent = settingsBySection;

	iterator.moveNext();

	while (iterator.hasMoreElements()) {
		Ogre::ConfigFile::SectionIterator::PairType pair = *(iterator.current());

		SettingsBySection* pSettingsBySection = new SettingsBySection();
		pSettingsBySection->section = copyString(pair.first);
		pSettingsBySection->next = NULL;
		pSettingsBySection->settings = NULL;

		Setting** parentSetting = &pSettingsBySection->settings;

		Ogre::ConfigFile::SettingsMultiMap* multimap = pair.second;

		for (Ogre::ConfigFile::SettingsMultiMap::iterator it = multimap->begin();
			 it != multimap->end();
			 it++) {
			Ogre::ConfigFile::SettingsMultiMap::value_type settingPair = *it;

			Setting* setting = new Setting();
			setting->name = copyString(settingPair.first);
			setting->value = copyString(settingPair.second);
			setting->next = NULL;
			*parentSetting = setting;
			parentSetting = &setting->next;
		}

		*parent = pSettingsBySection;
		parent = &pSettingsBySection->next;

		iterator.moveNext();
	}
}

INV_EXPORT void
INV_CALL configfile_delete_settings_by_section(SettingsBySection* settingsBySection)
{
	while (settingsBySection != NULL) {
		Setting* setting = settingsBySection->settings;

		while (setting != NULL) {
			Setting* next = setting->next;

			delete[] (_string)setting->name;
			delete[] (_string)setting->value;
			delete setting;

			setting = next;
		}

		SettingsBySection* next = settingsBySection->next;

		delete[] (_string)settingsBySection->section;
		delete settingsBySection;

		settingsBySection = next;
	}
}
