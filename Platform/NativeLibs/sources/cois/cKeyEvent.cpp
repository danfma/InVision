#include "cOIS.h"

KeyEventDescriptor descriptor_of_keyevent(InvHandle handle)
{
	OIS::KeyEvent* keyEvent = asKeyEvent(handle);

	KeyEventDescriptor descriptor;
	descriptor.base = descriptor_of_eventarg(handle);
	descriptor.key = (KEY_CODE*)&keyEvent->key;
	descriptor.text = &keyEvent->text;

	return descriptor;
}

/**
 * Method: KeyEvent::KeyEvent
 */
INV_EXPORT InvHandle
INV_CALL new_keyevent(KeyEventDescriptor* descriptor, InvHandle device, KEY_CODE keyCode, _uint text)
{
	OIS::KeyEvent* keyEvent = new OIS::KeyEvent(asObject(device), (OIS::KeyCode)keyCode, text);

	InvHandle result = createHandle<OIS::KeyEvent>(keyEvent);

	*descriptor = descriptor_of_keyevent(result);

	return result;
}
