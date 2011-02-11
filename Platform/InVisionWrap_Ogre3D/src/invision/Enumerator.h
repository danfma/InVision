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

namespace invision
{
	class IEnumerator
	{
	public:
		virtual ~IEnumerator(){}

		virtual Any getCurrent()  = 0;
		virtual bool moveNext() = 0;
		virtual void reset() = 0;
	};
}

#endif // __cplusplus

#endif // ENUMERATORS_H
