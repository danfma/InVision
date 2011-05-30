#ifndef __INVISIONNATIVE_OGRE_SETTING_H__
#define __INVISIONNATIVE_OGRE_SETTING_H__

#include <InvisionHandle.h>
#include "invisionnative_ogre.h"

extern "C"
{
	/**
	 * Type Setting
	 */
	struct Setting
	{
		_any name;
		_any value;
		Setting* next;
	};
	
}

#endif // __INVISIONNATIVE_OGRE_SETTING_H__

