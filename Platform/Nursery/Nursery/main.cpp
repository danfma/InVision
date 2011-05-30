#include <QtCore/QCoreApplication>

#include <iostream>
#include <typeinfo>
#include <boost/cast.hpp>
#include <boost/unordered_map.hpp>

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

void component(Component* self)
{
	cout << "Component: " << (size_t)self << endl;
}

void vector3_clear(Vector3* self)
{
	component(self);

	cout << "vector3: " << (size_t)self << endl;
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
private:
	Vector3ClearMethod method;

public:
	Other(float x, float y, float z)
		: Vector3(x, y, z)
	{ }

	virtual ~Other() {

	}

	virtual void clear() {

	}
};

void other_clear(Other* self)
{
	cout << "other: " << (size_t)self << endl;
	vector3_clear(self);
}

struct Test
{
	int b;
	bool a;
	char c;
};




typedef uint TypeID;

struct IConverter {
	~IConverter() { }
	virtual void* convert(void* data) = 0;
};

template<typename TOut, typename TIn>
struct Converter : public IConverter
{
	virtual void* convert(void* data)
	{
//		return dynamic_cast<TOut*>(static_cast<TIn*>(data));
		return (TOut*)((TIn*)data);
	}
};

struct NoAppliedConverter : public IConverter
{
	virtual void* convert(void* data)
	{
		return data;
	}
};

class ConverterRegistry
{
private:
	typedef boost::unordered_map<const char*, IConverter*> SecondMap;
	typedef boost::unordered_map<const char*, SecondMap*> FirstMap;

	NoAppliedConverter* _noAppliedConverter;
	FirstMap _firstMap;

private:
	ConverterRegistry()
	{
		_noAppliedConverter = new NoAppliedConverter();
	}

public:
	~ConverterRegistry()
	{
		for (FirstMap::iterator it = _firstMap.begin(); it != _firstMap.end(); it++) {
			SecondMap* map = (*it).second;

			for (SecondMap::iterator it2 = map->begin(); it2 != map->end(); it2++) {
				IConverter* converter = (*it2).second;
				delete converter;
			}

			map->clear();
			delete map;
		}

		_firstMap.clear();

		delete _noAppliedConverter;
	}

	template<typename TOut, typename TIn>
	void registerConverter()
	{
		const std::type_info& typeOut = typeid(TOut*);
		const std::type_info& typeIn = typeid(TIn*);

		registerConverter(typeOut.name(), typeIn.name(), new Converter<TOut, TIn>());
		registerConverter(typeIn.name(), typeOut.name(), new Converter<TIn, TOut>());
	}

	IConverter* getConverter(const std::type_info& typeOut, const std::type_info& typeIn)
	{
		SecondMap* secondMap = getConverterMap(typeOut.name());
		SecondMap::const_iterator it = secondMap->find(typeIn.name());

		if (it != secondMap->end())
			return (*it).second;

		return _noAppliedConverter;
	}

private:
	void registerConverter(const char* typeIn, const char* typeOut, IConverter* converter)
	{
		SecondMap* secondMap = getConverterMap(typeIn);

		if (secondMap->find(typeOut) != secondMap->end())
			return;

		SecondMap::value_type pair(typeOut, converter);
		secondMap->insert(pair);
	}

	SecondMap* getConverterMap(const char* typeIn)
	{
		SecondMap* secondMap;
		FirstMap::const_iterator it = _firstMap.find(typeIn);

		if (it == _firstMap.end()) {
			secondMap = new SecondMap();

			FirstMap::value_type pair(typeIn, secondMap);
			_firstMap.insert(pair);

		} else {
			secondMap = (*it).second;
		}

		return secondMap;
	}

public:
	static ConverterRegistry& getInstance()
	{
		static ConverterRegistry instance;

		return instance;
	}
};

template<typename TExpected, typename TData>
inline void register_converter()
{
	ConverterRegistry::getInstance().registerConverter<TExpected, TData>();
}

inline IConverter* converter_of(const std::type_info& expectedType, const std::type_info& dataType)
{
	return ConverterRegistry::getInstance().getConverter(expectedType, dataType);
}


class IHandleData
{
public:
	virtual void* convertedData(const std::type_info& expectedType) = 0;
	virtual bool contains(void* data) = 0;
	virtual void deleteData() = 0;

	template<typename TOut>
	TOut* convertedData()
	{
		return static_cast<TOut*>(convertedData(typeid(TOut*)));
	}
};


template<typename TIn>
class HandleReference : public IHandleData
{
public:
	HandleReference(TIn* data)
		: _data(data), _typeIn(typeid(TIn*))
	{ }

	virtual void* convertedData(const std::type_info& expectedType)
	{
		IConverter* converter = converter_of(expectedType, _typeIn);

		return converter->convert(_data);
	}

	virtual bool contains(void* data)
	{
		return _data == data;
	}

	virtual void deleteData()
	{
		_data = NULL;
	}

protected:
	TIn* _data;
	const std::type_info& _typeIn;
};


template<typename T>
class HandleData : public HandleReference<T>
{
public:
	HandleData(T* data)
		: HandleReference<T>(data)
	{ }

	void deleteData()
	{
		if (this->_data != NULL) {
			delete this->_data;
			this->_data = NULL;
		}
	}
};


void initialize()
{
	register_converter<Vector3, Component>();

	register_converter<Other, Vector3>();
	register_converter<Other, Component>();
}


int main(int argc, char *argv[])
{
	initialize();

	Other* vector = new Other(1, 2, 3);
	Component* cp2 = vector;

	IHandleData* handle = new HandleData<Other>(vector);
	Component* cp = handle->convertedData<Component>();

	cout << "vector: " << (size_t)vector << endl;
	cout << "component converted: " << (size_t)cp << endl;
	cout << "component direct cast: " << (size_t)cp2 << endl;

	delete handle;

	return 0;
}
