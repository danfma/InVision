#ifndef COIS_H
#define COIS_H

#include <InvisionHandle.h>
#include "invisionnative_ois.h"

extern "C"
{
	/*
	 * OIS::Type
	 */
	extern _int OIS_TYPE_UNKNONW;
	extern _int OIS_TYPE_KEYBOARD;
	extern _int OIS_TYPE_MOUSE;
	extern _int OIS_TYPE_JOYSTICK;
	extern _int OIS_TYPE_TABLET;
	
	/*
	 * OIS::ComponentType
	 */
	extern _int OIS_COMPONENT_TYPE_UNKNOWN;
	extern _int OIS_COMPONENT_TYPE_BUTTON;
	extern _int OIS_COMPONENT_TYPE_AXIS;
	extern _int OIS_COMPONENT_TYPE_SLIDER;
	extern _int OIS_COMPONENT_TYPE_POV;
	extern _int OIS_COMPONENT_TYPE_VECTOR3;

	/*
	 * OIS::OIS_ERROR
	 */
	extern _int OIS_ERROR_INPUT_DISCONNECTED;
	extern _int OIS_ERROR_INPUT_DEVICE_NON_EXISTENT;
	extern _int OIS_ERROR_INPUT_DEVICE_NOT_SUPPORTED;
	extern _int OIS_ERROR_DEVICE_FULL;
	extern _int OIS_ERROR_NOT_IMPLEMENTED;
	extern _int OIS_ERROR_DUPLICATE;
	extern _int OIS_ERROR_INVALID_PARAM;
	extern _int OIS_ERROR_GENERAL;

	/*
	 * OIS::Interface::IType
	 */
	extern _int OIS_ITYPE_FORCE_FEEDBACK;
	extern _int OIS_ITYPE_RESERVED;


	/*
	 * Descriptors
	 */
	ComponentDescriptor descriptor_of_component(InvHandle handle);
	ButtonDescriptor descriptor_of_button(InvHandle handle);
	AxisDescriptor descriptor_of_axis(InvHandle handle);
	Vector3Descriptor descriptor_of_vector3(InvHandle handle);
}


#ifdef __cplusplus
# include <string>
# include <OIS.h>

namespace invision
{
namespace ois
{
	inline bool ensureNotNull(_any handle)
	{
		bool isNull = handle == NULL;
		
		if (isNull)
			throws_null_reference(__FILE__, __LINE__);
		
		return !isNull;
	}


	class RuntimeTypesChecker
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
		RuntimeTypesChecker()
		{
			SIZE_ASSERT(_int, OIS::ComponentType)
			SIZE_ASSERT(_int*, OIS::ComponentType*)
		}
	};

	extern RuntimeTypesChecker typesChecker;
}
}

#endif

#endif // COIS_H
