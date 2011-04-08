#ifndef COLLECTIONS_H
#define COLLECTIONS_H

#include "Common.h"

extern "C"
{
	__export HNameValueCollection __entry namevaluecollection_new();
	__export void __entry namevaluecollection_delete(HNameValueCollection self);
	__export void __entry namevaluecollection_add(HNameValuePairList self,
												  const char *key, const char *value);
	__export void __entry namevaluecollection_remove(HNameValuePairList self,
													 const char *key);
	__export void __entry namevaluecollection_clear(HNameValuePairList self);
	__export Int32 __entry namevaluecollection_count(HNameValuePairList self);
	__export HNameValuePairEnumerator __entry namevaluecollection_get_pairs(HNameValuePairList self);
}

#ifdef __cplusplus
#include "Enumerator.h"
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

		virtual Any convert(iterator& iter)
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
		Any convert(VectorIterator& iter)
		{
			return (Any)*iter;
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
