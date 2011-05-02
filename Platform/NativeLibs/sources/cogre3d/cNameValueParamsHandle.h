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
	
	INV_EXPORT HNameValuePairList INV_CALL namevaluepairlist_convert(const PNameValuePair pairs, _int count);
	INV_EXPORT HNameValuePairList INV_CALL namevaluepairlist_new();
	INV_EXPORT void INV_CALL namevaluepairlist_delete(HNameValuePairList self);
	
	INV_EXPORT void INV_CALL namevaluepairlist_add(HNameValuePairList self, const char *key, const char *value);
	INV_EXPORT void INV_CALL namevaluepairlist_remove(HNameValuePairList self, const char *key);
	INV_EXPORT void INV_CALL namevaluepairlist_clear(HNameValuePairList self);
	INV_EXPORT _int INV_CALL namevaluepairlist_count(HNameValuePairList self);
	INV_EXPORT const HNameValuePairEnumerator INV_CALL namevaluepairlist_get_pairs(HNameValuePairList self);
	INV_EXPORT HNameValuePairList INV_CALL namevaluepairlist_copy(HNameValuePairList self);
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
