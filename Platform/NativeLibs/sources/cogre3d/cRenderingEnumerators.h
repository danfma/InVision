#ifndef RENDERINGENUMERATORS_H
#define RENDERINGENUMERATORS_H

#include "invision/Enumerator.h"

#ifdef __cplusplus
#include "Ogre.h"
#include "vector"

namespace invision
{
	class RenderSystemEnumerator : public IEnumerator
	{
	private:
		bool firstMove;
		Ogre::RenderSystemList list;
		Ogre::RenderSystemList::const_iterator it;

	public:
		RenderSystemEnumerator(const Ogre::RenderSystemList& list)
		{
			this->list = list;
			reset();
		}

		~RenderSystemEnumerator()
		{
#if defined(__cplusplus) && defined(DEBUG)
			std::cout << "Destroying RenderSystemEnumerator" << std::endl;
#endif
		}

		_any getCurrent()
		{
			return *it;
		}

		bool moveNext()
		{
			if (firstMove && it != list.end()) {
				firstMove = false;
				return true;
			}

			return ++it != list.end();
		}

		void reset()
		{
			it = list.begin();
			firstMove = true;
		}
	};
}

#endif

#endif // RENDERINGENUMERATORS_H
