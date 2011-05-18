#include "InvisionHandle.h"

using namespace invision;

typedef boost::unordered_map<const char*, TypeID> TypeRegistry;

//
// GLOBALS
//
TypeID nextTypeIndex = 0;
TypeRegistry typeRegistry;

INV_EXPORT TypeID
INV_CALL get_registered_typeid_by_name(const char* type)
{
	try
	{
		return typeRegistry.at(type);
	}
	catch (std::exception& ex)
	{
		return register_type_by_name(type);
	}
}


INV_EXPORT TypeID
INV_CALL register_type_by_name(const char* type)
{
	_ushort typeId;

	typeRegistry[type] = typeId = ++nextTypeIndex;

	return typeId;
}

INV_EXPORT TypeID
INV_CALL get_registered_typeid(const std::type_info& type)
{
	return get_registered_typeid_by_name(type.name());
}

INV_EXPORT TypeID
INV_CALL register_typeid(const std::type_info& type)
{
	return register_type_by_name(type.name());
}

