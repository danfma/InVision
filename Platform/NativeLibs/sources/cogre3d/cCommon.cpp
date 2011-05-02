#include "cOgre.h"
#include "cEnumerator.h"
#include <Ogre.h>

const PolygonModeEnum PME_Points = Ogre::PM_POINTS;
const PolygonModeEnum PME_Wireframe = Ogre::PM_WIREFRAME;
const PolygonModeEnum PME_Solid = Ogre::PM_SOLID;

using namespace invision;

RaiseExceptionHandler exceptionHandler = NULL;

INV_EXPORT void INV_CALL util_delete_string(const _string data)
{
	if (data == NULL)
		return;

	delete[] data;
}

INV_EXPORT void INV_CALL util_delete_stringarray(PStringArray strArray)
{
	if (strArray == NULL)
		return;

	for (_int i = 0; i < strArray->count; i++) {
		delete[] strArray->strings[i];
	}

	delete strArray;
}

INV_EXPORT void INV_CALL util_delete_namevaluepair(PNameValuePair data)
{
	if (data == NULL)
		return;

	delete[] data->key;
	delete[] data->value;
	delete data;
}

INV_EXPORT void INV_CALL util_delete_namehandlepair(PNameHandlePair data)
{
	if (data == NULL)
		return;

	if (data->value != NULL)
		delete asEnumerator(data->value);

	delete[] data->key;
	delete data;
}

INV_EXPORT void INV_CALL register_exception_raise_handler(RaiseExceptionHandler handler)
{
	exceptionHandler = handler;
}

