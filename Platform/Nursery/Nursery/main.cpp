#include <QtCore/QCoreApplication>

#include <iostream>
#include <boost/function.hpp>

using namespace std;
using namespace boost;

typedef void* ANY;

//! Base type for all device components (button, axis, etc)
enum ComponentType
{
	OIS_Unknown = 0,
	OIS_Button  = 1, //ie. Key, mouse button, joy button, etc
	OIS_Axis    = 2, //ie. A joystick or mouse axis
	OIS_Slider  = 3, //
	OIS_POV     = 4, //ie. Arrow direction keys
	OIS_Vector3 = 5  //ie. WiiMote orientation
};

//! Base of all device components (button, axis, etc)
class Component
{
public:
	Component() : cType(OIS_Unknown) {}
	Component(ComponentType type) : cType(type) {}
	//! Indicates what type of coponent this is
	ComponentType cType;
};

//! A 3D Vector component (perhaps an orientation, as in the WiiMote)
class Vector3 : public Component
{
public:
	Vector3() {}
	Vector3(float _x, float _y, float _z) : Component(OIS_Vector3), x(_x), y(_y), z(_z) {}

	~Vector3() {
		cout << "Vector::~ctr()" << endl;
	}

	//! X component of vector
	float x;

	//! Y component of vector
	float y;

	//! Z component of vector
	float z;

	void clear()
	{
		x = y = z = 0.0f;
	}
};

void vector3_clear(Vector3* self)
{
	cout << "vector3: " << (int)self << endl;
	self->clear();
}

// definição do delegate
typedef void(*Vector3ClearMethod)(ANY self);

// definição da informação
struct Vector3Descriptor
{
	// fields
	float* x;
	float* y;
	float* z;

	// methods
	Vector3ClearMethod* clear;
};

class Other : public Vector3
{
public:
	Other(float x, float y, float z)
		: Vector3(x, y, z)
	{ }
};

void other_clear(Other* self)
{
	cout << "other: " << (int)self << endl;
	vector3_clear(self);
}

struct Test
{
	int b;
	bool a;
	char c;
};

int main(int argc, char *argv[])
{
	Other* other = new Other(1, 2, 3);

	other_clear(other);

	cout << "bool size: " << sizeof(bool) << endl;
	cout << "int size: " << sizeof(int) << endl;
	cout << "test size: " << sizeof(Test) << endl;

	return 0;
}
