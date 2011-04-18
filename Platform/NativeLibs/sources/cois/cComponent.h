#ifndef CCOMPONENT_H
#define CCOMPONENT_H

#include "cOIS.h"

#ifdef __cplusplus
#include <iostream>

class COMInterface
{
private:
	int refCount;

public:
	COMInterface() {
		std::cout << "COMInterface::ctr()" << std::endl;
		refCount = 0;
	}

	virtual ~COMInterface() {
		std::cout << "COMInterface::~ctr()" << std::endl;
	}

	virtual int QueryInterface(void* id, void** result)
	{
		*result = this;

		std::cout << "COMInterface::QueryInterface(id, result) " << std::endl;

		return 0;
	}

	virtual int AddRef() {
		int ret = ++refCount;

		std::cout << "COMInterface::AddRef() -> " << ret << std::endl;

		return ret;
	}

	virtual int Release() {
		int ret = --refCount;

		std::cout << "COMInterface::Release() -> " << ret << std::endl;

		if (ret == 0)
			delete this;

		return ret;
	}

	virtual void Dispose() {
		delete this;
	}
};

class ComponentWrapper : public COMInterface
{
private:
	OIS::Component* target;
	bool ownsHandle;

public:
	ComponentWrapper(OIS::Component* target, bool ownsHandle = false)
		: COMInterface(), target(target), ownsHandle(ownsHandle)
	{ }

	ComponentWrapper(OIS::ComponentType ctype)
		: COMInterface(), target(new OIS::Component(ctype)), ownsHandle(true)
	{ }

	virtual ~ComponentWrapper()
	{
		std::cout << "ComponentWrapper::~ctor()" << std::endl;

		if (ownsHandle)
			delete target;
	}

	virtual OIS::ComponentType GetType()
	{
		return target->cType;
	}
};

#endif // __cplusplus

extern "C"
{
	struct ComponentExtended {
		HComponent handle;
		_int* componentType;
	};

	/*
	 * OIS::Component
	 */
	__export ComponentExtended __entry ois_component_new(_int ctype);
	__export void __entry ois_component_delete(HComponent self);

	__export ComponentWrapper* __entry ois_create_component_wrapper(OIS::ComponentType ctype);
}

#endif // CCOMPONENT_H
