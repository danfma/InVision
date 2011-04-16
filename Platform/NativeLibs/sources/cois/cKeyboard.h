#ifndef CKEYBOARD_H
#define CKEYBOARD_H

#include "cOIS.h"

extern "C"
{

__export _bool __entry ois_keyboard_is_key_down(HKeyboard self, _int keyCode);

__export void __entry ois_keyboard_set_event_callback(HKeyboard self, HKeyListener listener);

__export _int __entry ois_keyboard_get_text_translation_mode(HKeyboard self);

__export void __entry ois_keyboard_set_text_translation_mode(HKeyboard self, _int translationMode);

__export _string __entry ois_keyboard_get_as_string(HKeyboard self, _int keyCode);

__export _bool __entry ois_keyboard_is_modifier_down(HKeyboard self, _int modifier);

__export void __entry ois_keyboard_copy_key_states(HKeyboard self, _byte keys[256]);

}

#ifdef __cplusplus

inline OIS::Keyboard* asKeyboard(HKeyboard handle)
{
	return (OIS::Keyboard*)handle;
}

#endif // __cplusplus

#endif // CKEYBOARD_H
