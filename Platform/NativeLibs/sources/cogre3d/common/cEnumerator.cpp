#include "Enumerator.h"

using namespace invision;

__export void __entry enumerator_delete(HEnumerator self)
{
	delete asEnumerator(self);
}

__export Any __entry enumerator_get_current(HEnumerator self)
{
	return asEnumerator(self)->getCurrent();
}

__export Bool __entry enumerator_move_next(HEnumerator self)
{
	bool result = asEnumerator(self)->moveNext();

	return toBool(result);
}

__export void __entry enumerator_reset(HEnumerator self)
{
	asEnumerator(self)->reset();
}

