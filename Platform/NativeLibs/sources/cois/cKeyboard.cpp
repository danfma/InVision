#include "cKeyboard.h"
#include "cCustomKeyEventListener.h"

__export _bool __entry ois_keyboard_is_key_down(HKeyboard self, _int keyCode)
{
	return toBool(asKeyboard(self)->isKeyDown((OIS::KeyCode)keyCode));
}

__export void __entry ois_keyboard_set_event_callback(HKeyboard self, HKeyListener listener)
{
	asKeyboard(self)->setEventCallback(asKeyListener(listener));
}

__export _int __entry ois_keyboard_get_text_translation_mode(HKeyboard self)
{
	return (_int)asKeyboard(self)->getTextTranslation();
}

__export void __entry ois_keyboard_set_text_translation_mode(HKeyboard self, _int translationMode)
{
	asKeyboard(self)->setTextTranslation((OIS::Keyboard::TextTranslationMode)translationMode);
}

__export _string __entry ois_keyboard_get_as_string(HKeyboard self, _int keyCode)
{
	std::string keyString = asKeyboard(self)->getAsString((OIS::KeyCode)keyCode);

	return copyString(keyString);
}

__export _bool __entry ois_keyboard_is_modifier_down(HKeyboard self, _int modifier)
{
	return toBool(asKeyboard(self)->isModifierDown((OIS::Keyboard::Modifier)modifier));
}

__export void __entry ois_keyboard_copy_key_states(HKeyboard self, _byte keys[256])
{
	asKeyboard(self)->copyKeyStates((char*)keys);
}
