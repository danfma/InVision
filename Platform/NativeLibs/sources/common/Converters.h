#ifndef CONVERTERS_H
#define CONVERTERS_H

#ifdef __cplusplus

struct IConverter {
	~IConverter() { }
	virtual void* convert(void* data) = 0;
};

template<typename TOut, typename TIn>
struct Converter : public IConverter
{
	virtual void* convert(void* data)
	{
		return (TOut*)((TIn*)data);
	}
};

struct NoAppliedConverter : public IConverter
{
	virtual void* convert(void *data)
	{
		return data;
	}
};

#endif // __cplusplus

#endif // CONVERTERS_H
