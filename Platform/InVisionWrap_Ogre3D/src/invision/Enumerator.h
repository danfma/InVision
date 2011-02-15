#ifndef ENUMERATORS_H
#define ENUMERATORS_H

#include "invision/Common.h"

extern "C"
{
	__EXPORT void __ENTRY enumerator_delete(HEnumerator self);
	__EXPORT Any __ENTRY enumerator_get_current(HEnumerator self);
	__EXPORT Bool __ENTRY enumerator_move_next(HEnumerator self);
	__EXPORT void __ENTRY enumerator_reset(HEnumerator self);
}


#ifdef __cplusplus
#include <Ogre.h>

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
		virtual ~IEnumerator(){ }

		/**
		 * Gets the current element in the collection.
		 */
		virtual Any getCurrent()  = 0;

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
	template <typename TContainer, typename TIterator>
	class IterEnumerator : public IEnumerator
	{
	private:
		bool firstMove;
		TIterator begin, end, it;

	protected:
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

		virtual Any convert(TIterator& iter) = 0;

	public:
		IterEnumerator(TIterator begin, TIterator end)
		{
			this->begin = begin;
			this->end = end;
			it = begin;
		}

		Any getCurrent()
		{
			return convert(it);
		}

		bool moveNext()
		{
			if (firstMove) {
				if (hasMoreItems()) {
					firstMove = false;
					return true;

				} else 
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
}

#endif // __cplusplus

#endif // ENUMERATORS_H
