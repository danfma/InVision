#ifndef COIS_H
#define COIS_H

#include <InvisionHandle.h>
#include "invisionnative_ois.h"
#include "cCustomKeyEventListener.h"
#include "cCustomMouseListener.h"

#ifdef __cplusplus
# include <string>
# include <OIS.h>


extern "C"
{
	struct RegisteredTypeItem
	{
		OIS_TYPE_ID oisTypeID;
		TypeID registeredTypeId;
	};

	INV_EXPORT RegisteredTypeItem*
	INV_CALL register_ois_types(int* count);
}


using namespace OIS;

class OISStartUp
{
private:
	int itemsCount;
	RegisteredTypeItem* items;

	template<typename T>
	RegisteredTypeItem registerType(OIS_TYPE_ID typeId)
	{
		RegisteredTypeItem item;
		item.oisTypeID = typeId;
		item.registeredTypeId = register_typeid(typeid(T));

		return item;
	}

	void registerTypes()
	{
		itemsCount = 15;
		items = new RegisteredTypeItem[itemsCount];
		items[0] = registerType<OIS::Axis>(OIS_TYPE_ID_AXIS);
		items[1] = registerType<OIS::Button>(OIS_TYPE_ID_BUTTON);
		items[2] = registerType<OIS::Component>(OIS_TYPE_ID_COMPONENT);
		items[3] = registerType<CustomKeyListener>(OIS_TYPE_ID_CUSTOM_KEY_LISTENER);
		items[4] = registerType<CustomMouseListener>(OIS_TYPE_ID_CUSTOM_MOUSE_LISTENER);
		items[5] = registerType<OIS::EventArg>(OIS_TYPE_ID_EVENT_ARG);
		items[6] = registerType<OIS::InputManager>(OIS_TYPE_ID_INPUT_MANAGER);
		items[7] = registerType<OIS::Interface>(OIS_TYPE_ID_INTERFACE);
		items[8] = registerType<OIS::Keyboard>(OIS_TYPE_ID_KEYBOARD);
		items[9] = registerType<OIS::KeyEvent>(OIS_TYPE_ID_KEY_EVENT);
		items[10] = registerType<OIS::Mouse>(OIS_TYPE_ID_MOUSE);
		items[11] = registerType<OIS::MouseEvent>(OIS_TYPE_ID_MOUSE_EVENT);
		items[12] = registerType<OIS::MouseState>(OIS_TYPE_ID_MOUSE_STATE);
		items[13] = registerType<OIS::Object>(OIS_TYPE_ID_OBJECT);
		items[14] = registerType<OIS::Vector3>(OIS_TYPE_ID_VECTOR3);
	}

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

#define SIZE_ASSERT(X, Y) if (sizeof(X) != sizeof(Y)) raiseException(#X, sizeof(X), #Y, sizeof(Y))

public:
	OISStartUp()
	{
		SIZE_ASSERT(_int, OIS::ComponentType);
		SIZE_ASSERT(_int*, OIS::ComponentType*);

		registerTypes();
	}

	~OISStartUp()
	{
		delete[] items;
	}

	RegisteredTypeItem* getRegisteredTypes(int* count)
	{
		*count = itemsCount;

		return items;
	}
};

extern OISStartUp startup;

#endif

#endif // COIS_H
