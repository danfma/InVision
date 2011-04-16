#ifndef ENUMERATORS_H
#define ENUMERATORS_H

#include "cWrapper.h"

extern "C"
{
	__export void __entry enumerator_delete(HEnumerator self);
	__export _any __entry enumerator_get_current(HEnumerator self);
	__export _bool __entry enumerator_move_next(HEnumerator self);
	__export void __entry enumerator_reset(HEnumerator self);
}

#ifdef __cplusplus

using namespace std;

namespace invision
{
/**
 * Abstract class for enumerators;
 */
class IEnumerator
{
public:
	/**
	 * Destructor
	 */
	virtual ~IEnumerator()
	{
	}

	/**
	 * Gets the current element in the collection.
	 */
	virtual _any getCurrent() = 0;

	/**
	 * Advances the enumerator to the next element of the collection.
	 * @remarks
	 *		After an enumerator is created or after the Reset method is called, an enumerator is positioned before the first element of the collection, and the first call to the MoveNext method moves the enumerator over the first element of the collection.
	 *		If MoveNext passes the end of the collection, the enumerator is positioned after the last element in the collection and MoveNext returns false. When the enumerator is at this position, subsequent calls to MoveNext also return false until Reset is called.
	 */
	virtual bool moveNext() = 0;

	/**
	 * Sets the enumerator to its initial position, which is before the first element in the collection.
	 */
	virtual void reset() = 0;
};

/**
 * An abstract class for the IEnumerator
 */
template<typename TContainer, typename TIterator>
class IterEnumerator: public IEnumerator
{
private:
	bool firstMove;
	TIterator begin, end, it;

protected:
	typedef TIterator iterator;

	TIterator& getCurrentIterator()
	{
		return it;
	}

	TIterator& getBegin()
	{
		return begin;
	}

	TIterator& getEnd()
	{
		return end;
	}

	bool hasMoreItems()
	{
		return it != end;
	}

	virtual _any convert(TIterator& iter) = 0;

public:
	IterEnumerator(TIterator begin, TIterator end)
	{
		this->begin = begin;
		this->end = end;
		it = begin;
	}

	_any getCurrent()
	{
		return convert(it);
	}

	bool moveNext()
	{
		if (firstMove)
		{
			if (hasMoreItems())
			{
				firstMove = false;
				return true;

			}
			else
				return false;
		}

		return ++it != end;
	}

	void reset()
	{
		it = begin;
		firstMove = true;
	}
};

inline IEnumerator* asEnumerator(HEnumerator self)
{
	return (IEnumerator*) self;
}
}

#endif // __cplusplus
#endif // ENUMERATORS_H
