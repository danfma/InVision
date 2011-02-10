#include "invision/NameValueParamsHandle.h"
#include "invision/Util.h"

using namespace invision;

typedef std::pair<Ogre::String, Ogre::String> OgreNameValuePair;

/*
 * Support functions
 */
void deletePairList(Any data)
{
	PNameValuePairList pairList = (PNameValuePairList)data;

#ifdef DEBUG
	std::cout << "deleting NameValuePairList: " << pairList->count << " pairs" << std::endl;
#endif

	for (int i = 0; i < pairList->count; i++) {
		NameValuePair pair = pairList->pairs[i];

		delete[] pair.key;
		delete[] pair.value;
	}

	delete[] pairList->pairs;
	delete pairList;
}

/*
 * Implementations
 */

__EXPORT HNameValuePairList __ENTRY NvplConvert(
	const PNameValuePair pairs,
	Int32 count)
{
	HNameValuePairList pairList = NvplNew();
	
	for (int i = 0; i < count; i++) {
		NameValuePair& pair = pairs[i];
		
		NvplAdd(pairList, pair.key, pair.value);
	}
	
	return pairList;
}

__EXPORT HNameValuePairList __ENTRY NvplNew()
{
	return new Ogre::NameValuePairList();
}

__EXPORT void __ENTRY NvplDelete(
	HNameValuePairList self)
{
	delete asNameValuePairList(self);
}

__EXPORT void __ENTRY NvplAdd(
	HNameValuePairList self,
	const char *key,
	const char *value)
{
	Ogre::String _key = key;
	Ogre::String _value = value;
	Ogre::NameValuePairList *pairList = asNameValuePairList(self);

	pairList->insert(std::pair<Ogre::String, Ogre::String>(_key, _value));
}

__EXPORT void __ENTRY NvplRemove(
	HNameValuePairList self,
	const char *key)
{
	Ogre::String _key = key;
	Ogre::NameValuePairList *pairList = asNameValuePairList(self);

	pairList->erase(key);
}

__EXPORT void __ENTRY NvplClear(
	HNameValuePairList self)
{
	asNameValuePairList(self)->clear();
}

__EXPORT Int32 __ENTRY NvplCount(
	HNameValuePairList self)
{
	return asNameValuePairList(self)->size();
}

__EXPORT const HNameValuePairEnumerator __ENTRY NvplGetPairs(
	HNameValuePairList self)
{
	Ogre::NameValuePairList *list = asNameValuePairList(self);
	NameValuePairEnumerator *e = new NameValuePairEnumerator(list);

	return e;
}

__EXPORT HNameValuePairList __ENTRY NvplCopy(
	HNameValuePairList self)
{
	Ogre::NameValuePairList *list = asNameValuePairList(self);
	Ogre::NameValuePairList *copy = new Ogre::NameValuePairList(list->begin(), list->end());

	return copy;
}


/*
 * CLASS IMPLEMENTATION
 */
NameValuePairEnumerator::NameValuePairEnumerator(const Ogre::NameValuePairList *list)
{
	this->list = list;
	reset();
}

NameValuePairEnumerator::~NameValuePairEnumerator()
{
#ifdef DEBUG
	std::cout << "Destroying NameValuePairEnumerator" << std::endl;
#endif
}

Any NameValuePairEnumerator::getCurrent()
{
	const Ogre::NameValuePairList::value_type tuple = *it;
	const Ogre::String* key = &(tuple.first);
/*
	Any data;

	if (MemoryMap::tryFind(this, key->c_str(), &data))
		return (PNameValuePair)data;
*/
	const Ogre::String* value = &(tuple.second);

	PNameValuePair pair = new NameValuePair();
	pair->key = copyString(key);
	pair->value = copyString(value);

//	MemoryMap::hook(this, key->c_str(), pair, deletePairData);

	return pair;
}

bool NameValuePairEnumerator::moveNext()
{
	if (firstMove && it != list->end()) {
		firstMove = false;
		return true;
	}

	return ++it != list->end();
}

void NameValuePairEnumerator::reset()
{
	it = list->begin();
	firstMove = true;
}

void NameValuePairEnumerator::deletePairData(Any data)
{
	delete (PNameValuePair)data;
}
