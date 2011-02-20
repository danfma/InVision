#ifndef COLLECTIONS_H
#define COLLECTIONS_H

#include "Common.h"

extern "C"
{
	/*
	 * NameValueCollection
	 */	
	__export HNameValueCollection __entry namevaluecollection_new();
	__export void __entry namevaluecollection_delete(HNameValueCollection self);
	__export void __entry namevaluecollection_add(HNameValuePairList self, const char *key, const char *value);
	__export void __entry namevaluecollection_remove(HNameValuePairList self, const char *key);
	__export void __entry namevaluecollection_clear(HNameValuePairList self);
	__export Int32 __entry namevaluecollection_count(HNameValuePairList self);
	__export const HNameValuePairEnumerator __entry namevaluecollection_get_pairs(HNameValuePairList self);
	
	/*
	 * VectorList
	 */
	__export HVectorList __entry vectorlist_new();
}

#ifdef __cplusplus
#include "Enumerator.h"
#include <map>

namespace invision
{
	typedef std::multimap<std::string, std::string> NameValueMap;
	typedef std::multimap<std::string, std::string>::iterator NameValueMapIter;
	typedef NameValueMap::value_type NameValueCollectionPair;

	class NameValueCollectionEnumerator : IterEnumerator<NameValueMap, NameValueMapIter>
	{
	public:
		typedef IterEnumerator<NameValueMap, NameValueMapIter> BaseType;

		NameValueCollectionEnumerator(NameValueMapIter begin, NameValueMapIter end)
			: BaseType(begin, end)
		{ }

		virtual Any convert(iterator& iter)
		{
			NameValueCollectionPair p = (NameValueCollectionPair)*iter;

			std::string key = p.first;
			std::string value = p.second;

			NameValuePair* copy = new NameValuePair();
			copy->key = copyString(key);
			copy->value = copyString(value);

			return copy;
		}
	};

	inline NameValueMap* asNameValueCollection(HNameValueCollection handle)
	{
		return (NameValueMap*)handle;
	}
}

#endif

#endif // COLLECTIONS_H
