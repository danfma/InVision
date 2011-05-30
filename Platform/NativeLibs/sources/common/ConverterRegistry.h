#ifndef CONVERTERREGISTRY_H
#define CONVERTERREGISTRY_H

#ifdef __cplusplus
#include "Converters.h"
#include <boost/unordered_map.hpp>
#include <typeinfo>

class ConverterRegistry
{
private:
	typedef boost::unordered_map<const char*, IConverter*> SecondMap;
	typedef boost::unordered_map<const char*, SecondMap*> FirstMap;

	NoAppliedConverter* _defaultConverter;
	FirstMap _firstMap;

private:
	ConverterRegistry()
	{
		_defaultConverter = new NoAppliedConverter();
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

		delete _defaultConverter;
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

		return _defaultConverter;
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

#endif // __cplusplus

#endif // CONVERTERREGISTRY_H
