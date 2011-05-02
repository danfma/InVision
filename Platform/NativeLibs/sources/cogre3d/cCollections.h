#ifndef COLLECTIONS_H
#define COLLECTIONS_H

#include "cOgre.h"

extern "C"
{
	INV_EXPORT HNameValueCollection INV_CALL namevaluecollection_new();
	INV_EXPORT void INV_CALL namevaluecollection_delete(HNameValueCollection self);
	INV_EXPORT void INV_CALL namevaluecollection_add(HNameValuePairList self,
												  const char *key, const char *value);
	INV_EXPORT void INV_CALL namevaluecollection_remove(HNameValuePairList self,
													 const char *key);
	INV_EXPORT void INV_CALL namevaluecollection_clear(HNameValuePairList self);
	INV_EXPORT _int INV_CALL namevaluecollection_count(HNameValuePairList self);
	INV_EXPORT HNameValuePairEnumerator INV_CALL namevaluecollection_get_pairs(HNameValuePairList self);
}

#ifdef __cplusplus
#include "cEnumerator.h"
#include <map>
#include <iostream>

namespace invision
{
	typedef std::multimap<std::string, std::string> NameValueMap;
	typedef std::multimap<std::string, std::string>::iterator NameValueMapIter;
	typedef NameValueMap::value_type NameValueCollectionPair;

	class NameValueCollectionEnumerator: IterEnumerator<NameValueMap,
			NameValueMapIter>
	{
	public:
		typedef IterEnumerator<NameValueMap, NameValueMapIter> BaseType;

		NameValueCollectionEnumerator(NameValueMapIter begin, NameValueMapIter end) :
			BaseType(begin, end)
		{
		}

		virtual _any convert(iterator& iter)
		{
			NameValueCollectionPair p = (NameValueCollectionPair) *iter;

			std::string key = p.first;
			std::string value = p.second;

			NameValuePair* copy = new NameValuePair();
			copy->key = copyString(key);
			copy->value = copyString(value);

			return copy;
		}
	};

	template<typename T>
	class VectorEnumerator : public IterEnumerator<std::vector<T>, typename std::vector<T>::iterator>
	{
	private:
		typedef std::vector<T> VectorList;
		typedef typename std::vector<T>::iterator VectorIterator;
		typedef IterEnumerator<VectorList, VectorIterator> BaseType;

	protected:
		_any convert(VectorIterator& iter)
		{
			return (_any)*iter;
		}

	public:
		VectorEnumerator(VectorIterator begin, VectorIterator end)
			: BaseType(begin, end)
		{
			std::cout << "[NATIVE] vector enumerator created" << std::endl;
		}

		~VectorEnumerator()
		{
			std::cout << "[NATIVE] vector enumerator destroyed" << std::endl;
		}
	};

	inline NameValueMap* asNameValueCollection(HNameValueCollection handle)
	{
		return (NameValueMap*) handle;
	}
}

#endif // __cplusplus

#endif // COLLECTIONS_H
