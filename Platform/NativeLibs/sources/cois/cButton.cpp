#include "cButton.h"

using namespace invision::ois;

__export HInputButton __entry ois_button_new()
{
	return new OIS::Button();
}

__export void __entry ois_button_delete(HInputButton button)
{
	delete asButton(button);
}

__export _bool __entry ois_button_get_pushed(HInputButton button)
{
	bool pushed = asButton(button)->pushed;

	return toBool(pushed);
}

__export void __entry ois_button_set_pushed(HInputButton button, _bool value)
{
	asButton(button)->pushed = fromBool(value);
}
