/*
 * Utilities for transfering data from a .NET Dictionary<string, string> class 
 * to a NameValuePairList
 */

#ifndef NAMEVALUEPARAMSHANDLE_H
#define NAMEVALUEPARAMSHANDLE_H

#include "cOgre.h"
#include "cEnumerator.h"

extern "C"
{	
	/* NEW ****************************************************************************************/
	
	__export HNameValuePairList __entry namevaluepairlist_convert(const PNameValuePair pairs, _int count);
	__export HNameValuePairList __entry namevaluepairlist_new();
	__export void __entry namevaluepairlist_delete(HNameValuePairList self);
	
	__export void __entry namevaluepairlist_add(HNameValuePairList self, const char *key, const char *value);
	__export void __entry namevaluepairlist_remove(HNameValuePairList self, const char *key);
	__export void __entry namevaluepairlist_clear(HNameValuePairList self);
	__export _int __entry namevaluepairlist_count(HNameValuePairList self);
	__export const HNameValuePairEnumerator __entry namevaluepairlist_get_pairs(HNameValuePairList self);
	__export HNameValuePairList __entry namevaluepairlist_copy(HNameValuePairList self);
}

#ifdef __cplusplus
#	include "cTypeConvert.h"

namespace invision
{
	class NameValuePairEnumerator : IEnumerator
	{
	private:
		bool firstMove;
		const Ogre::NameValuePairList* list;
		Ogre::NameValuePairList::const_iterator it;

	public:
		NameValuePairEnumerator(const Ogre::NameValuePairList *list);
		~NameValuePairEnumerator();

		_any getCurrent();
		bool moveNext();
		void reset();

		static void deletePairData(_any data);
	};
}

#endif

#endif // NAMEVALUEPARAMSHANDLE_H
