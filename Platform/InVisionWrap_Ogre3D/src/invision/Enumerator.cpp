#include "invision/Enumerator.h"
#include "invision/Util.h"

using namespace invision;

__EXPORT void __ENTRY enumerator_delete(HEnumerator self)
{
	delete asEnumerator(self);
}

__EXPORT Any __ENTRY enumerator_get_current(HEnumerator self)
{
	return asEnumerator(self)->getCurrent();
}

__EXPORT Bool __ENTRY enumerator_move_next(HEnumerator self)
{
	bool result = asEnumerator(self)->moveNext();

	return toBool(result);
}

__EXPORT void __ENTRY enumerator_reset(HEnumerator self)
{
	asEnumerator(self)->reset();
}
