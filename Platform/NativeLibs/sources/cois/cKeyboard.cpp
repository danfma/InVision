#include "cKeyboard.h"

using namespace invision::ois;

__export void __entry ois_keyboard_set_event_callback(HKeyboard self, HCustomKeyListener listener)
{
	asKeyboard(self)->setEventCallback(asKeyListener(listener));
}

__export Int32 __entry ois_keyboard_get_text_translation_mode(HKeyboard self)
{
	return asKeyboard(self)->getTextTranslation();
}

__export void __entry ois_keyboard_set_text_translation_mode(HKeyboard self, Int32 mode)
{
	asKeyboard(self)->setTextTranslation((OIS::Keyboard::TextTranslationMode)mode);
}

__export String __entry ois_keyboard_get_as_string(HKeyboard self, Int32 key)
{
	std::string result = asKeyboard(self)->getAsString((OIS::KeyCode)key);
	
	return copyString(result);
}

__export Bool __entry ois_keyboard_is_modifier_down(HKeyboard self, Int32 modifier)
{
	return toBool(asKeyboard(self)->isModifierDown((OIS::Keyboard::Modifier)modifier));
}

__export Bool __entry ois_keyboard_is_key_down(HKeyboard self, Int32 key)
{
	return toBool(asKeyboard(self)->isKeyDown((OIS::KeyCode)key));
}

__export void __entry ois_keyboard_copy_key_states(HKeyboard self, const Byte* data)
{
	char* keys = (char*)data;
	
	asKeyboard(self)->copyKeyStates(keys);
}
	

__export HCustomKeyListener __entry ois_new_keylistener(KeyEventHandler keyPressed, KeyEventHandler keyReleased)
{
	return new CustomKeyListener(keyPressed, keyReleased);
}

__export void __entry ois_delete_keylistener(HCustomKeyListener self)
{
	delete asKeyListener(self);
}
	