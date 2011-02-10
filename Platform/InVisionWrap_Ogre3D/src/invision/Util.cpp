#include "invision/Util.h"
#include <boost/foreach.hpp>
#include <boost/tuple/tuple.hpp>
#include <boost/unordered_map.hpp>

using namespace std;
using namespace invision;


__EXPORT void __ENTRY UDeleteString(const char* data)
{
#ifdef DEBUG
	cout << "Destroying char*" << endl;
#endif

	if (data == NULL)
		return;

	delete[] data;
}

__EXPORT void __ENTRY UDeleteNameValuePair(PNameValuePair data)
{
#ifdef DEBUG
	cout << "Destroying NameValuePair" << endl;
#endif

	if (data == NULL)
		return;

	delete[] data->key;
	delete[] data->value;
	delete data;
}


MemoryMap::MemoryMap()
{

}

MemoryMap::~MemoryMap()
{
	clear();
}

void MemoryMap::hookData(Handle handle, const char* propertyKey, Any data, DataDeleter dataDeleter)
{
#ifdef DEBUG
	cout << "Hook memory (" << propertyKey << ") for handle: " << hex << ((Int64)handle) << endl;
#endif

	HandleKey key = (HandleKey)handle;
	HandleMap::iterator hmit = map.find(key);
	PPropertyMap ppmap;

	if (hmit == map.end())
		map[key] = ppmap = new PropertyMap();
	else
		ppmap = (*hmit).second;

	std::string pkey = propertyKey;
	PropertyMap::iterator pit = ppmap->find(pkey);
	MemoryTuple *tuple;

	if (pit == ppmap->end()) {
		tuple = new MemoryTuple(data, dataDeleter);
		ppmap->insert(PropertyMapPair(pkey, tuple));

	} else {
		tuple = (*pit).second;
		delete tuple;

		ppmap->erase(pit);
		tuple = new MemoryTuple(data, dataDeleter);
		ppmap->insert(PropertyMapPair(pkey, tuple));
	}
}

bool MemoryMap::tryFindData(Handle handle, const char *propertyKey, Any* data)
{
#ifdef DEBUG
	cout << "Retrieve hooked memory (" << propertyKey <<
			") for handle: " << hex << ((Int64)handle) << endl;
#endif

	HandleKey key = (HandleKey)handle;
	HandleMap::iterator hmit = map.find(key);
	PPropertyMap ppmap;

	if (hmit == map.end())
		return false;

	ppmap = (*hmit).second;

	std::string pkey = propertyKey;
	PropertyMap::iterator pit = ppmap->find(pkey);
	MemoryTuple *tuple;

	if (pit == ppmap->end())
		return false;

	tuple = (*pit).second;
	*data = tuple->data;

	return true;
}

void MemoryMap::unhookData(Handle handle)
{
#ifdef DEBUG
	cout << "Unhook memory for handle: " << hex << ((Int64)handle) << endl;
#endif
}

void MemoryMap::clear()
{
	HandleMap::iterator it = map.begin();

	while (it != map.end()) {
		PPropertyMap ppmap = (*it).second;
		PropertyMap::iterator pit = ppmap->begin();

		while (pit != ppmap->end()) {
			PMemoryTuple tuple = (*pit).second;
			delete tuple;
		}

		ppmap->clear();
		delete ppmap;
	}

	map.clear();
}


MemoryMap& MemoryMap::getInstance()
{
	static MemoryMap instance;

	return instance;
}

void MemoryMap::hook(Handle handle, const char *propertyKey, Any data, DataDeleter dataDeleter)
{
	getInstance().hookData(handle, propertyKey, data, dataDeleter);
}

void MemoryMap::unhook(Handle handle)
{
	getInstance().unhookData(handle);
}

bool MemoryMap::tryFind(Handle handle, const char *propertyKey, Any* data)
{
	return getInstance().tryFindData(handle, propertyKey, data);
}
