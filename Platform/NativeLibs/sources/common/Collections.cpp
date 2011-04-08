#include "Collections.h"

using namespace std;
using namespace invision;

__export HNameValueCollection __entry namevaluecollection_new()
{
	return new NameValueMap();
}

__export void __entry namevaluecollection_delete(HNameValueCollection self)
{
	delete asNameValueCollection(self);
}

__export void __entry namevaluecollection_add(HNameValuePairList self, const char *key, const char *value)
{
	string skey = key;
	string svalue = value;

	asNameValueCollection(self)->insert(NameValueCollectionPair(skey, svalue));
}

__export void __entry namevaluecollection_remove(HNameValuePairList self, const char *key)
{
	string skey = key;

	asNameValueCollection(self)->erase(skey);
}

__export void __entry namevaluecollection_clear(HNameValuePairList self)
{
	asNameValueCollection(self)->clear();
}

__export Int32 __entry namevaluecollection_count(HNameValuePairList self)
{
	return asNameValueCollection(self)->size();
}

__export HNameValuePairEnumerator __entry namevaluecollection_get_pairs(HNameValuePairList self)
{
	NameValueMap* list = asNameValueCollection(self);

	return new NameValueCollectionEnumerator(list->begin(), list->end());
}

