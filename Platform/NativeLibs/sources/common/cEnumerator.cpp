#include "cEnumerator.h"

using namespace invision;

INV_EXPORT void INV_CALL enumerator_delete(HEnumerator self)
{
	delete asEnumerator(self);
}

INV_EXPORT _any INV_CALL enumerator_get_current(HEnumerator self)
{
	return asEnumerator(self)->getCurrent();
}

INV_EXPORT _bool INV_CALL enumerator_move_next(HEnumerator self)
{
	bool result = asEnumerator(self)->moveNext();

	return toBool(result);
}

INV_EXPORT void INV_CALL enumerator_reset(HEnumerator self)
{
	asEnumerator(self)->reset();
}

