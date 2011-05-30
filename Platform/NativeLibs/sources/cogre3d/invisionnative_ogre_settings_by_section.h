#ifndef __INVISIONNATIVE_OGRE_SETTINGS_BY_SECTION_H__
#define __INVISIONNATIVE_OGRE_SETTINGS_BY_SECTION_H__

#include <InvisionHandle.h>
#include "invisionnative_ogre.h"

extern "C"
{
	/**
	 * Type SettingsBySection
	 */
	struct SettingsBySection
	{
		_any section;
		Setting* settings;
		SettingsBySection* next;
	};
	
}

#endif // __INVISIONNATIVE_OGRE_SETTINGS_BY_SECTION_H__

