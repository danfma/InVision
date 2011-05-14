#ifndef CHANDLE_H
#define CHANDLE_H

#include "cWrapper.h"
#include <boost/unordered_map.hpp>

class IHandleData
{
};

template<typename T>
class HandleData : public IHandleData
{
public:
	T data;
};

typedef _uint Handle;
typedef boost::unordered_map<Handle, IHandleData> HandleRegistry;

/**
 * Handle Generator
 */
class IHandleGenerator
{
public:
	virtual Handle next() = 0;
};


class SequentialHandleGenerator : public IHandleGenerator
{
private:
	Handle _next;

public:
	SequentialHandleGenerator();

	Handle next();
};

SequentialHandleGenerator::SequentialHandleGenerator()
	: _next(1)
{ }

Handle SequentialHandleGenerator::next()
{
	return _next++;
}


class HandleManager
{
private:
	IHandleGenerator _generator;
	HandleRegistry _registry;

public:
	HandleManager(IHandleGenerator generator = NULL);
	~HandleManager();

	Handle createHandle<T>(T data);
	void removeHandle(Handle handle);
	void destroyHandle(Handle handle);

	T restoreByHandle<T>(Handle handle);
};


HandleManager::HandleManager(IHandleGenerator generator)
{
	if (generator == NULL)
		generator = new SequentialHandleGenerator();

	_generator = generator;
}


Handle HandleManager::createHandle<T>(T data)
{
	HandleData<T> hdata;
	hdata.data = data;

	HandleRegistry::value_type entry;
	entry.first = _generator.next();
	entry.second = hdata;

	registry.insert(entry);
}


#endif // CHANDLE_H
