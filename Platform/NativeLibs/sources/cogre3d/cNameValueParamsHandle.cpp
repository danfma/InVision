#include "NameValueParamsHandle.h"
#include "TypeConvert.h"

using namespace invision;

typedef std::pair<Ogre::String, Ogre::String> OgreNameValuePair;

/*
 * Support functions
 */
void deletePairList(_any data)
{
	PNameValuePairList pairList = (PNameValuePairList)data;

#ifdef DEBUG
	std::cout << "deleting NameValuePairList: " << pairList->count << " pairs" << std::endl;
#endif

	for (_int i = 0; i < pairList->count; i++) {
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

INV_EXPORT HNameValuePairList INV_CALL namevaluepairlist_convert(
	const PNameValuePair pairs,
	_int count)
{
	HNameValuePairList pairList = namevaluepairlist_new();
	
	for (_int i = 0; i < count; i++) {
		NameValuePair& pair = pairs[i];
		
		namevaluepairlist_add(pairList, pair.key, pair.value);
	}
	
	return pairList;
}

INV_EXPORT HNameValuePairList INV_CALL namevaluepairlist_new()
{
	return new Ogre::NameValuePairList();
}

INV_EXPORT void INV_CALL namevaluepairlist_delete(
	HNameValuePairList self)
{
	delete asNameValuePairList(self);
}

INV_EXPORT void INV_CALL namevaluepairlist_add(
	HNameValuePairList self,
	const char *key,
	const char *value)
{
	Ogre::String _key = key;
	Ogre::String _value = value;
	Ogre::NameValuePairList *pairList = asNameValuePairList(self);

	pairList->insert(std::pair<Ogre::String, Ogre::String>(_key, _value));
}

INV_EXPORT void INV_CALL namevaluepairlist_remove(
	HNameValuePairList self,
	const char *key)
{
	Ogre::String _key = key;
	Ogre::NameValuePairList *pairList = asNameValuePairList(self);

	pairList->erase(key);
}

INV_EXPORT void INV_CALL namevaluepairlist_clear(
	HNameValuePairList self)
{
	asNameValuePairList(self)->clear();
}

INV_EXPORT _int INV_CALL namevaluepairlist_count(
	HNameValuePairList self)
{
	return asNameValuePairList(self)->size();
}

INV_EXPORT const HNameValuePairEnumerator INV_CALL namevaluepairlist_get_pairs(
	HNameValuePairList self)
{
	Ogre::NameValuePairList *list = asNameValuePairList(self);
	NameValuePairEnumerator *e = new NameValuePairEnumerator(list);

	return e;
}

INV_EXPORT HNameValuePairList INV_CALL namevaluepairlist_copy(
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

_any NameValuePairEnumerator::getCurrent()
{
	const Ogre::NameValuePairList::value_type tuple = *it;
	const Ogre::String* key = &(tuple.first);
/*
	_any data;

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

void NameValuePairEnumerator::deletePairData(_any data)
{
	delete (PNameValuePair)data;
}
