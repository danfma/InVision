#ifndef CHANDLE_H
#define CHANDLE_H

#include "cWrapper.h"


extern "C"
{
	typedef _uint InvHandle;
}

#ifdef __cplusplus
#include <boost/unordered_map.hpp>

namespace invision
{

class IHandleData
{
public:
	virtual void deleteData() = 0;
};



template<typename T>
class HandleData : public IHandleData
{
private:
	T _data;
	bool _isPointer;

public:
	HandleData(T data, bool isPointer = true)
		: _data(data), _isPointer(isPointer)
	{ }

	T data()
	{
		return _data;
	}

	void deleteData()
	{
		if (_isPointer)
			delete _data;
	}
};



typedef boost::unordered_map<InvHandle, IHandleData*> HandleRegistry;



class IHandleGenerator
{
public:
	virtual InvHandle next() = 0;
};



class SequentialHandleGenerator : public IHandleGenerator
{
private:
	InvHandle _next;

public:
	SequentialHandleGenerator()
		: _next(1)
	{ }

	InvHandle next()
	{
		return _next++;
	}
};



class HandleManager
{
private:
	IHandleGenerator* _generator;
	HandleRegistry _registry;

public:
	HandleManager(IHandleGenerator* generator = NULL)
	{
		if (generator == NULL)
			generator = new SequentialHandleGenerator();

		_generator = generator;
	}

	~HandleManager()
	{
		if (_generator != NULL)
			delete _generator;

		for (HandleRegistry::iterator it = _registry.begin(); it != _registry.end(); it++) {
			IHandleData* hdata = (*it).second;
			delete hdata;
		}
	}

	template<typename T>
	InvHandle createHandle(T data, bool isPointer = true)
	{
		IHandleData* hdata = new HandleData<T>(data, isPointer);

		HandleRegistry::value_type entry(_generator->next(), hdata);
		_registry.insert(entry);

		return entry.first;
	}

	void removeHandle(InvHandle handle)
	{
		if (handle == 0)
			return;

		HandleRegistry::const_iterator it = _registry.find(handle);

		if (it == _registry.end())
			return;

		IHandleData* hdata = (*it).second;

		_registry.erase_return_void(it);
		delete hdata;
	}

	void destroyHandle(InvHandle handle)
	{
		if (handle == 0)
			return;

		HandleRegistry::const_iterator it = _registry.find(handle);

		if (it == _registry.end())
			return;

		IHandleData* hdata = (*it).second;

		_registry.erase_return_void(it);
		hdata->deleteData();
		delete hdata;
	}

	template<typename T>
	T get(InvHandle handle)
	{
		IHandleData* hdata = _registry.at(handle);
		HandleData<T>* converted = dynamic_cast<HandleData<T>* >(hdata);

		return converted->data();
	}

	static HandleManager& getInstance()
	{
		static HandleManager handleManager;

		return handleManager;
	}
};



template<typename T>
inline InvHandle newHandleOf()
{
	T* data = new T();

	return HandleManager::getInstance().createHandle<T*>(data);
}

template<typename T, typename P1>
inline InvHandle newHandleOf(P1 param1)
{
	T* data = new T(param1);

	return HandleManager::getInstance().createHandle<T*>(data);
}

template<typename T, typename P1, typename P2>
inline InvHandle newHandleOf(P1 param1, P2 param2)
{
	T* data = new T(param1, param2);

	return HandleManager::getInstance().createHandle<T*>(data);
}

template<typename T, typename P1, typename P2, typename P3>
inline InvHandle newHandleOf(P1 param1, P2 param2, P3 param3)
{
	T* data = new T(param1, param2, param3);

	return HandleManager::getInstance().createHandle<T*>(data);
}

template<typename T>
inline T* castHandle(InvHandle handle)
{
	return HandleManager::getInstance().get<T*>(handle);
}

inline void removeHandle(InvHandle handle)
{
	HandleManager::getInstance().removeHandle(handle);
}

inline void destroyHandle(InvHandle handle)
{
	HandleManager::getInstance().destroyHandle(handle);
}

template<typename T>
inline InvHandle getOrAddHandleByObject(T* data)
{
	return 0; // TODO Implement in the right way
}


} // namespace invision

#endif // __cplusplus


#endif // CHANDLE_H
