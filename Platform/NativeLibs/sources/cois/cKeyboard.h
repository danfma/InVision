#ifndef CKEYBOARD_H
#define CKEYBOARD_H

#include "cOIS.h"
#include "cCustomKeyEventListener.h"

extern "C"
{
	INV_EXPORT bool
	INV_CALL ois_keyboard_is_key_down(
		OIS::Keyboard* self,
		OIS::KeyCode keyCode);

	INV_EXPORT void
	INV_CALL ois_keyboard_set_event_callback(
		OIS::Keyboard* self,
		CustomKeyListener* listener);

	INV_EXPORT _string
	INV_CALL ois_keyboard_get_as_string(
		OIS::Keyboard* self,
		OIS::KeyCode keyCode);

	INV_EXPORT bool
	INV_CALL ois_keyboard_is_modifier_down(
		OIS::Keyboard* self,
		OIS::Keyboard::Modifier modifier);

	INV_EXPORT void
	INV_CALL ois_keyboard_copy_key_states(
		OIS::Keyboard* self,
		char keys[256]);

	INV_EXPORT OIS::Keyboard::TextTranslationMode
	INV_CALL ois_keyboard_get_text_translation(
		OIS::Keyboard* self);

	INV_EXPORT void
	INV_CALL ois_keyboard_set_text_translation(
		OIS::Keyboard* self,
		OIS::Keyboard::TextTranslationMode value);
}

#endif // CKEYBOARD_H
