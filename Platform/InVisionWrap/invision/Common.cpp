#include "invision/Common.h"
#include "invision/Enumerator.h"
#include <Ogre.h>

const PolygonModeEnum PME_Points = Ogre::PM_POINTS;
const PolygonModeEnum PME_Wireframe = Ogre::PM_WIREFRAME;
const PolygonModeEnum PME_Solid = Ogre::PM_SOLID;

using namespace invision;


RaiseExceptionHandler exceptionHandler = NULL;

__export void __entry register_exception_raiser(RaiseExceptionHandler exceptionHandler)
{
	::exceptionHandler = exceptionHandler;
}

__export void __entry raise_exception(ConstString message)
{
	if (exceptionHandler != NULL)
		exceptionHandler(message);
}

__export void __entry util_delete_string(const char* data)
{
	if (data == NULL)
		return;

	delete[] data;
}

__export void __entry util_delete_stringarray(PStringArray strArray)
{
	if (strArray == NULL)
		return;

	for (int i = 0; i < strArray->count; i++) {
		delete[] strArray->strings[i];
	}

	delete strArray;
}

__export void __entry util_delete_namevaluepair(PNameValuePair data)
{
	if (data == NULL)
		return;

	delete[] data->key;
	delete[] data->value;
	delete data;
}

__export void __entry util_delete_namehandlepair(PNameHandlePair data)
{
	if (data == NULL)
		return;

	if (data->value != NULL)
		delete asEnumerator(data->value);

	delete[] data->key;
	delete data;
}

