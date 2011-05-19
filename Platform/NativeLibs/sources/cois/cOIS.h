#ifndef COIS_H
#define COIS_H

#include <InvisionHandle.h>
#include "invisionnative_ois.h"

#ifdef __cplusplus
# include <string>
# include <OIS.h>

using namespace OIS;

class OISRuntimeTypesChecker
{
private:
	static void raiseException(std::string typeX, int sizeX, std::string typeY, int sizeY)
	{
		std::string error = "Different size for types: ";
		error += typeX;
		error += "(";
		error += sizeX;
		error += ") ";
		error += typeY;
		error += "(";
		error += sizeY;
		error += ")";

		raise_exception(error);
	}

#define SIZE_ASSERT(X, Y) if (sizeof(X) != sizeof(Y)) raiseException(#X, sizeof(X), #Y, sizeof(Y));

public:
	OISRuntimeTypesChecker()
	{
		SIZE_ASSERT(_int, OIS::ComponentType)
		SIZE_ASSERT(_int*, OIS::ComponentType*)
	}
};

extern OISRuntimeTypesChecker oisTypesChecker;

#endif

#endif // COIS_H
