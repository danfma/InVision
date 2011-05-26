#ifndef __INVISIONNATIVE_OGRE_NAME_VALUE_PAIR_LIST_H__
#define __INVISIONNATIVE_OGRE_NAME_VALUE_PAIR_LIST_H__

#include <InvisionHandle.h>
#include "invisionnative_ogre.h"

extern "C"
{
	/**
	 * Type NameValuePairList
	 */
	struct NameValuePairList
	{
		_uint count;
		NameValuePair* pairs;
	};
	
}

#endif // __INVISIONNATIVE_OGRE_NAME_VALUE_PAIR_LIST_H__

