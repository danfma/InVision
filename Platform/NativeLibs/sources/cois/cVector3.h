#ifndef VECTOR3_H
#define VECTOR3_H

#include "cOIS.h"
#include "cComponent.h"

class Vector3Proxy;

// definição do delegate
typedef void(*Vector3ClearMethod)(Vector3Proxy* self);

// definição da informação
struct Vector3ProxyInfo
{
	ComponentProxyInfo base;

	// fields
	float* x;
	float* y;
	float* z;

	// methods
	Vector3ClearMethod* clear;
};

// definição do proxy
class Vector3Proxy : public OIS::Vector3
{
private:
	Vector3ClearMethod clearMethod;

	static void _clear(Vector3Proxy* self)
	{
		self->Vector3::clear();
	}

	void initialize()
	{
		clearMethod = Vector3Proxy::_clear;
	}

public:
	Vector3Proxy(float x, float y, float z)
		: OIS::Vector3(x, y, z)
	{
		initialize();
	}

	virtual void clear()
	{
		clearMethod(this);
	}

	static Vector3ProxyInfo createInfo(Vector3Proxy* vector)
	{
		Vector3ProxyInfo info;
		info.base.handle = vector;
		info.base.ctype = &vector->cType;
		info.x = &vector->x;
		info.y = &vector->y;
		info.z = &vector->z;
		info.clear = &vector->clearMethod;

		return info;
	}
};

extern "C"
{
	struct Vector3Extended {
		ComponentExtended base;
		_float* x;
		_float* y;
		_float* z;
	};

	/*
	 * OIS::Button
	 */
	__export Vector3Extended __entry ois_vector3_new(float x, float y, float z);
	__export void __entry ois_vector3_delete(HVector3 self);

	__export Vector3ProxyInfo __entry ois_new_vector3(float x, float y, float z);
}

#endif // VECTOR3_H
