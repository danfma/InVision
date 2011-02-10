#ifndef COLLECTIONS_H
#define COLLECTIONS_H

#ifdef __cplusplus
#include "invision/Enumerator.h"
#include <boost/unordered_map.hpp>
#include <boost/foreach.hpp>

namespace invision
{
	/* NON GENERIC TYPES **************************************************************************/

	class ICollection
	{
	public:
		virtual IEnumerator* getEnumerator() = 0;
		virtual void copyTo(Any* targetArray, int count, int start = 0) = 0;
		virtual int count() = 0;
		virtual void add(Any item) = 0;
		virtual bool remove(Any item) = 0;
		virtual void clear() = 0;
		virtual bool contains(Any item) = 0;
	};

	class IList : public ICollection
	{
	protected:
		virtual void copy(const IEnumerator* e) = 0;

	public:
		IList();
		IList(const IEnumerator* e);
		virtual ~IList();

		virtual void removeAt(int index) = 0;
		virtual int indexOf(Any item) = 0;
		virtual void insert(int index, Any item) = 0;
	};

	typedef struct KeyValue
	{
		Any key;
		Any value;
	} *PKeyValue;

	class IDictionary : public ICollection
	{
	public:
		//+ ICollection overrides
		virtual IEnumerator* getEnumerator() = 0;
		virtual void copyTo(Any* targetArray, int count, int start = 0) = 0;
		//- ICollection overrides

		virtual void add(Any key, Any value) = 0;
		virtual bool remove(Any key) = 0;
		virtual void clear() = 0;
		virtual bool contains(Any value) = 0;
		virtual bool containsKey(Any key) = 0;
		virtual bool tryGetValue(Any key, Any* value) = 0;
	};
}

#endif // __cplusplus


#endif // COLLECTIONS_H
