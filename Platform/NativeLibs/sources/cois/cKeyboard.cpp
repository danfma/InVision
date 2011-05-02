#include "cKeyboard.h"

INV_EXPORT bool
INV_CALL ois_keyboard_is_key_down(
	OIS::Keyboard* self,
	OIS::KeyCode keyCode)
{
	return self->isKeyDown(keyCode);
}

INV_EXPORT void
INV_CALL ois_keyboard_set_event_callback(
	OIS::Keyboard* self,
	CustomKeyListener* listener)
{
	self->setEventCallback(listener);
}

INV_EXPORT _string
INV_CALL ois_keyboard_get_as_string(
	OIS::Keyboard* self,
	OIS::KeyCode keyCode)
{
	return copyString(self->getAsString(keyCode));
}

INV_EXPORT bool
INV_CALL ois_keyboard_is_modifier_down(
	OIS::Keyboard* self,
	OIS::Keyboard::Modifier modifier)
{
	return self->isModifierDown(modifier);
}

INV_EXPORT void
INV_CALL ois_keyboard_copy_key_states(
	OIS::Keyboard* self,
	char keys[256])
{
	self->copyKeyStates(keys);
}

INV_EXPORT OIS::Keyboard::TextTranslationMode
INV_CALL ois_keyboard_get_text_translation(
	OIS::Keyboard* self)
{
	return self->getTextTranslation();
}

INV_EXPORT void
INV_CALL ois_keyboard_set_text_translation(
	OIS::Keyboard* self,
	OIS::Keyboard::TextTranslationMode value)
{
	self->setTextTranslation(value);
}
