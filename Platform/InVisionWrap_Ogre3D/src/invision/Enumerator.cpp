#include "invision/Enumerator.h"
#include "invision/Util.h"

using namespace invision;

__EXPORT void __ENTRY EnumrDelete(HEnumerator self)
{
	delete asEnumerator(self);
}

__EXPORT Any __ENTRY EnumrGetCurrent(HEnumerator self)
{
	return asEnumerator(self)->getCurrent();
}

__EXPORT Bool __ENTRY EnumrMoveNext(HEnumerator self)
{
	bool result = asEnumerator(self)->moveNext();

	return toBool(result);
}

__EXPORT void __ENTRY EnumrReset(HEnumerator self)
{
	asEnumerator(self)->reset();
}
