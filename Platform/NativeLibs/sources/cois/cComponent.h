#ifndef CCOMPONENT_H
#define CCOMPONENT_H

#include "cOIS.h"

#ifdef __cplusplus

struct ComponentProxyInfo
{
	_handle handle;
	OIS::ComponentType* ctype;
};

class ComponentProxy : public OIS::Component
{
public:
	ComponentProxy(OIS::ComponentType ctype)
		: OIS::Component(ctype)
	{
		std::cout << "ComponentProxy::ctr(" << ctype << ")" << std::endl;
	}

	virtual ~ComponentProxy()
	{
		std::cout << "ComponentWrapper::~ctor()" << std::endl;
	}

	static ComponentProxyInfo createInfo(ComponentProxy* component)
	{
		ComponentProxyInfo info;
		info.handle = component;
		info.ctype = &component->cType;

		return info;
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


	__export ComponentProxyInfo __entry ois_new_component(OIS::ComponentType ctype);
	__export void __entry ois_delete_component(OIS::Component* self);
}

#endif // CCOMPONENT_H
