#ifndef CCUSTOMLOGLISTENER_H
#define CCUSTOMLOGLISTENER_H

#include "cOgre.h"

class CustomLogListener : public Ogre::LogListener
{
private:
	LogListenerMessageLoggedHandler _messageLogged;

public:
	CustomLogListener(LogListenerMessageLoggedHandler messageLoggedHandler)
		: _messageLogged(messageLoggedHandler)
	{ }

	void messageLogged( const Ogre::String& message, Ogre::LogMessageLevel lml, bool maskDebug, const Ogre::String &logName )
	{
		_messageLogged(
					const_cast<char*>(message.c_str()),
					(LOG_MESSAGE_LEVEL)lml,
					toBool(maskDebug),
					const_cast<char*>(logName.c_str()));
	}
};

#endif // CCUSTOMLOGLISTENER_H
