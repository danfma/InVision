/*
 * Utilities for transfering data from a .NET Dictionary<string, string> class 
 * to a NameValuePairList
 */

#ifndef NAMEVALUEPARAMSHANDLE_H
#define NAMEVALUEPARAMSHANDLE_H

#include "invision/Common.h"
#include "invision/Enumerator.h"

extern "C"
{	
	/* NEW ****************************************************************************************/
	
	__EXPORT HNameValuePairList __ENTRY namevaluepairlist_convert(const PNameValuePair pairs, Int32 count);
	__EXPORT HNameValuePairList __ENTRY namevaluepairlist_new();
	__EXPORT void __ENTRY namevaluepairlist_delete(HNameValuePairList self);
	
	__EXPORT void __ENTRY namevaluepairlist_add(HNameValuePairList self, const char *key, const char *value);
	__EXPORT void __ENTRY namevaluepairlist_remove(HNameValuePairList self, const char *key);
	__EXPORT void __ENTRY namevaluepairlist_clear(HNameValuePairList self);
	__EXPORT Int32 __ENTRY namevaluepairlist_count(HNameValuePairList self);
	__EXPORT const HNameValuePairEnumerator __ENTRY namevaluepairlist_get_pairs(HNameValuePairList self);
	__EXPORT HNameValuePairList __ENTRY namevaluepairlist_copy(HNameValuePairList self);
}

#ifdef __cplusplus
#	include "invision/Util.h"
#	include "Ogre.h"

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

		Any getCurrent();
		bool moveNext();
		void reset();

		static void deletePairData(Any data);
	};
}

#endif

#endif // NAMEVALUEPARAMSHANDLE_H
