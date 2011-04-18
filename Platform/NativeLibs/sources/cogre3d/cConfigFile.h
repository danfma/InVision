#ifndef CONFIGFILE_H
#define CONFIGFILE_H

#include "cOgre.h"

extern "C"
{
	__export HConfigFile __entry cfgfile_new();

	__export void __entry cfgfile_delete(HConfigFile configFile);

	__export void __entry cfgfile_load(
			HConfigFile configFile,
			const _string filename,
			const _string separators,
			_bool trimWhitespace);

	__export void __entry cfgfile_load_with_resourcegroup(
			HConfigFile configFile,
			const _string filename,
			const _string resourceGroup,
			const _string separators,
			_bool trimWhitespace);

	// __export void __entry cfgfile_load_with_datastream()

	__export void __entry cfgfile_load_direct(
			HConfigFile configFile,
			const _string filename,
			const _string separators,
			_bool trimWhitespace);

	__export void __entry cfgfile_load_from_resource_system(
			HConfigFile configFile,
			const _string filename,
			const _string resourceGroup,
			const _string separators,
			_bool trimWhitespace);

	__export const _string __entry cfgfile_get_setting(
			HConfigFile configFile,
			const _string key,
			const _string section,
			const _string defaultValue);

	__export PStringArray __entry cfgfile_multi_setting(
			HConfigFile configFile,
			const _string key,
			const _string section);

	__export void __entry cfgfile_clear(HConfigFile configFile);

	__export HSectionEnumerator __entry cfgfile_get_section_iterator(
			HConfigFile configFile);

	__export HSettingsEnumerator __entry cfgfile_get_settings_iterator(
			HConfigFile configFile,
			const _string section);
}

#ifdef __cplusplus
#include "invision/Enumerator.h"
#include "TypeConvert.h"
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
		_any convert(IteratorType& data)
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
		_any convert(IteratorType& data)
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
