#include "cEnumerator.h"

using namespace invision;

__export void __entry enumerator_delete(HEnumerator self)
{
	delete asEnumerator(self);
}

__export _any __entry enumerator_get_current(HEnumerator self)
{
	return asEnumerator(self)->getCurrent();
}

__export _bool __entry enumerator_move_next(HEnumerator self)
{
	bool result = asEnumerator(self)->moveNext();

	return toBool(result);
}

__export void __entry enumerator_reset(HEnumerator self)
{
	asEnumerator(self)->reset();
}

