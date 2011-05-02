#include "cCollections.h"

using namespace std;
using namespace invision;

INV_EXPORT HNameValueCollection INV_CALL namevaluecollection_new()
{
	return new NameValueMap();
}

INV_EXPORT void INV_CALL namevaluecollection_delete(HNameValueCollection self)
{
	delete asNameValueCollection(self);
}

INV_EXPORT void INV_CALL namevaluecollection_add(HNameValuePairList self, const char *key, const char *value)
{
	string skey = key;
	string svalue = value;

	asNameValueCollection(self)->insert(NameValueCollectionPair(skey, svalue));
}

INV_EXPORT void INV_CALL namevaluecollection_remove(HNameValuePairList self, const char *key)
{
	string skey = key;

	asNameValueCollection(self)->erase(skey);
}

INV_EXPORT void INV_CALL namevaluecollection_clear(HNameValuePairList self)
{
	asNameValueCollection(self)->clear();
}

INV_EXPORT _int INV_CALL namevaluecollection_count(HNameValuePairList self)
{
	return asNameValueCollection(self)->size();
}

INV_EXPORT HNameValuePairEnumerator INV_CALL namevaluecollection_get_pairs(HNameValuePairList self)
{
	NameValueMap* list = asNameValueCollection(self);

	return new NameValueCollectionEnumerator(list->begin(), list->end());
}

