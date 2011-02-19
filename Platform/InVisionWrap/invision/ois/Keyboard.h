#ifndef KEYBOARD_H
#define KEYBOARD_H

#include "Common.h"

extern "C"
{
	typedef Bool (*KeyEventHandler)(KeyEventArgs e);
	
	/*
	 * Keyboard
	 */
	__export void __entry ois_keyboard_set_event_callback(HKeyboard self, HCustomKeyListener listener);
	
	__export Int32 __entry ois_keyboard_get_text_translation_mode(HKeyboard self);
	__export void __entry ois_keyboard_set_text_translation_mode(HKeyboard self, Int32 mode);
	
	__export String __entry ois_keyboard_get_as_string(HKeyboard self, Int32 key);
	__export Bool __entry ois_keyboard_is_modifier_down(HKeyboard self, Int32 modifier);
	__export Bool __entry ois_keyboard_is_key_down(HKeyboard self, Int32 key);
	
	__export void __entry ois_keyboard_copy_key_states(HKeyboard self, const Byte* data);
	
	/*
	 * Utilities
	 */
	__export HCustomKeyListener __entry ois_new_keylistener(KeyEventHandler keyPressed, KeyEventHandler keyReleased);
	__export void __entry ois_delete_keylistener(HCustomKeyListener self);
}

#ifdef __cplusplus
#include <OIS.h>

namespace invision
{
	namespace ois 
	{
		class CustomKeyListener : public OIS::KeyListener
		{
		private:
			KeyEventHandler keyPressedHandler;
			KeyEventHandler keyReleasedHandler;
			
		public:
			CustomKeyListener(KeyEventHandler keyPressedHandler,
							  KeyEventHandler keyReleasedHandler)
				:	keyPressedHandler(keyPressedHandler),
					keyReleasedHandler(keyReleasedHandler)
			{ }
			
			bool keyPressed(const OIS::KeyEvent& arg)
			{
				bool result = true;
				
				if (keyPressedHandler != NULL) {
					OIS::KeyEvent tmp = arg;
					KeyEventArgs e(tmp);
					
					result = fromBool(keyPressedHandler(e));
				}
				
				return result;
			}
			
			virtual bool keyReleased(const OIS::KeyEvent& arg)
			{
				bool result = true;
				
				if (keyReleasedHandler != NULL) {
					OIS::KeyEvent tmp = arg;
					KeyEventArgs e(tmp);
					
					result = fromBool(keyReleasedHandler(e));
				}
				
				return result;
			}
		};
		
		inline OIS::Keyboard* asKeyboard(HKeyboard handle)
		{
			return (OIS::Keyboard*)handle;
		}
		
		inline OIS::KeyListener* asKeyListener(HCustomKeyListener handle)
		{
			return (OIS::KeyListener*)handle;
		}
	}
}

#endif

#endif // KEYBOARD_H
