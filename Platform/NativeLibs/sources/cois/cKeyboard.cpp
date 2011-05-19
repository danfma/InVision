#include "cOIS.h"

/**
 * Method: Keyboard::isKeyDown
 */
INV_EXPORT _bool
INV_CALL keyboard_is_key_down(InvHandle self, KEY_CODE keyCode)
{
	return toBool(asKeyboard(self)->isKeyDown((OIS::KeyCode)keyCode));
}

/**
 * Method: Keyboard::setEventCallback
 */
INV_EXPORT void
INV_CALL keyboard_set_event_callback(InvHandle self, InvHandle keyListener)
{
	asKeyboard(self)->setEventCallback(asKeyListener(keyListener));
}

/**
 * Method: Keyboard::getEventCallback
 */
INV_EXPORT InvHandle
INV_CALL keyboard_get_event_callback(InvHandle self)
{
	return getOrCreateReference<OIS::KeyListener>( asKeyboard(self)->getEventCallback() );
}

/**
 * Method: Keyboard::setTextTranslation
 */
INV_EXPORT void
INV_CALL keyboard_set_text_translation(InvHandle self, TEXT_TRANSLATION_MODE translationMode)
{
	asKeyboard(self)->setTextTranslation(
				(OIS::Keyboard::TextTranslationMode)translationMode);
}

/**
 * Method: Keyboard::getTextTranslation
 */
INV_EXPORT TEXT_TRANSLATION_MODE
INV_CALL keyboard_get_text_translation(InvHandle self)
{
	return asKeyboard(self)->getTextTranslation();
}

/**
 * Method: Keyboard::getAsString
 */
INV_EXPORT _string
INV_CALL keyboard_get_as_string(InvHandle self, KEY_CODE keyCode)
{
	const std::string& text = asKeyboard(self)->getAsString((OIS::KeyCode)keyCode);

	return copyString(text);
}

/**
 * Method: Keyboard::isModifierDown
 */
INV_EXPORT _bool
INV_CALL keyboard_is_modifier_down(InvHandle self, MODIFIER modifier)
{
	bool result = asKeyboard(self)->isModifierDown((OIS::Keyboard::Modifier)modifier);

	return fromBool(result);
}

/**
 * Method: Keyboard::copyKeyStates
 */
INV_EXPORT void
INV_CALL keyboard_copy_key_states(InvHandle self, _bool* keys)
{
	asKeyboard(self)->copyKeyStates((char*)keys);
}
