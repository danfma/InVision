#ifndef CONFIGFILE_H
#define CONFIGFILE_H

#include "invision/Common.h"

extern "C"
{
	__EXPORT HConfigFile __ENTRY cfgfile_new();

	__EXPORT void __ENTRY cfgfile_delete(HConfigFile configFile);

	__EXPORT void __ENTRY cfgfile_load(
			HConfigFile configFile,
			const char* filename,
			const char* separators,
			Bool trimWhitespace);

	__EXPORT void __ENTRY cfgfile_load_with_resourcegroup(
			HConfigFile configFile,
			const char* filename,
			const char* resourceGroup,
			const char* separators,
			Bool trimWhitespace);

	// __EXPORT void __ENTRY cfgfile_load_with_datastream()

	__EXPORT void __ENTRY cfgfile_load_direct(
			HConfigFile configFile,
			const char* filename,
			const char* separators,
			Bool trimWhitespace);

	__EXPORT void __ENTRY cfgfile_load_from_resource_system(
			HConfigFile configFile,
			const char* filename,
			const char* resourceGroup,
			const char* separators,
			Bool trimWhitespace);

	__EXPORT const char* __ENTRY cfgfile_get_setting(
			HConfigFile configFile,
			const char* key,
			const char* section,
			const char* defaultValue);

	__EXPORT PStringArray __ENTRY cfgfile_multi_setting(
			HConfigFile configFile,
			const char* key,
			const char* section);

	__EXPORT void __ENTRY cfgfile_clear(HConfigFile configFile);

	__EXPORT HSectionEnumerator __ENTRY cfgfile_get_section_iterator(
			HConfigFile configFile);

	__EXPORT HSettingsEnumerator __ENTRY cfgfile_get_settings_iterator(
			HConfigFile configFile,
			const char* section);
}

#ifdef __cplusplus
#include "invision/Enumerator.h"
#include "invision/Util.h"
#include <map>
#include <Ogre.h>

namespace invision
{
	typedef Ogre::ConfigFile::SettingsIterator SettingsIterator;
	typedef Ogre::ConfigFile::SectionIterator SectionIterator;

	class SettingsEnumerator : public IterEnumerator<SettingsIterator, SettingsIterator::iterator>
	{
	private:
		PNameHandlePair parent;

	public:
		typedef IterEnumerator<SettingsIterator, SettingsIterator::iterator> BaseType;
		typedef SettingsIterator::iterator IteratorType;
		typedef std::pair<Ogre::String, Ogre::String> PairType;

		SettingsEnumerator(SettingsIterator iterator)
			: BaseType(iterator.begin(), iterator.end())
		{
			parent = NULL;
		}

		SettingsEnumerator(IteratorType begin, IteratorType end, PNameHandlePair parent)
			: BaseType(begin, end)
		{
			this->parent = parent;
		}

		~SettingsEnumerator()
		{
			// removing the parent reference for this object when this object is
			// released before the parent
			if (parent != NULL)
				parent->value = NULL;
		}

	protected:
		Any convert(IteratorType& data)
		{
			PairType pair = (PairType)*data;

			PNameValuePair result = new NameValuePair();
			result->key = copyString(pair.first);
			result->value = copyString(pair.second);

			return result;
		}
	};

	class SectionEnumerator : public IterEnumerator<SectionIterator, SectionIterator::iterator>
	{
	public:
		typedef IterEnumerator<SectionIterator, SectionIterator::iterator> BaseType;
		typedef SectionIterator::iterator IteratorType;
		typedef SectionIterator::PairType PairType;

		SectionEnumerator(SectionIterator iterator)
			: BaseType(iterator.begin(), iterator.end())
		{ }

	protected:
		Any convert(IteratorType& data)
		{
			PairType pair = (PairType)*data;
			Ogre::String key = pair.first;
			Ogre::ConfigFile::SettingsMultiMap *multiMap = pair.second;

			PNameHandlePair result = new NameHandlePair();
			result->key = copyString(key);
			result->value = new SettingsEnumerator(multiMap->begin(), multiMap->end(), result);

			return result;
		}
	};
}

#endif

#endif // CONFIGFILE_H
