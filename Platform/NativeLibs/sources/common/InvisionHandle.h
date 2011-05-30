#ifndef __INVISION_HANDLE_H__
#define __INVISION_HANDLE_H__

#include "cWrapper.h"

extern "C"
{
	typedef _uint InvHandle;
}

#ifdef __cplusplus
#include <typeinfo>
#include <boost/unordered_map.hpp>
#include "ConverterRegistry.h"

namespace invision
{
	const InvHandle INVALID_HANDLE = 0;

	class IHandleData
	{
	public:
		virtual bool contains(void* data) = 0;
		virtual void deleteData() = 0;
		virtual void* convertedData(const std::type_info& expectedType) = 0;

		template<typename TOut>
		TOut* convertedData()
		{
			return static_cast<TOut*>(convertedData(typeid(TOut*)));
		}
	};

	typedef boost::unordered_map<InvHandle, IHandleData*> HandleRegistry;


	template<typename T>
	class HandleReference : public IHandleData
	{
	public:
		HandleReference(T* data)
			: _data(data), _dataType(typeid(T*))
		{ }

		inline T* data()
		{
			return _data;
		}

		virtual bool contains(void* data)
		{
			return _data == data;
		}

		void deleteData()
		{
			if (_data != NULL)
				_data = NULL;
		}

		virtual void* convertedData(const std::type_info& expectedType)
		{
			IConverter* converter = converter_of(expectedType, _dataType);

			return converter->convert(_data);
		}

	protected:
		T* _data;
		const std::type_info& _dataType;
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




	class IHandleGenerator
	{
	public:
		virtual _ushort next() = 0;
	};



	class SequentialHandleGenerator : public IHandleGenerator
	{
	private:
		_ushort _next;

	public:
		SequentialHandleGenerator()
			: _next(1)
		{ }

		_ushort next()
		{
			return _next++;
		}
	};

	class HandleManager
	{
	private:
		typedef void (INV_CALL *HandleDestroyedHandler)(InvHandle handle);
		IHandleGenerator* _generator;
		HandleRegistry _registry;
		HandleDestroyedHandler _handleDestroyed;


		InvHandle nextHandle()
		{
			return _generator->next();
		}

		InvHandle registerHandle(IHandleData* hdata)
		{
			HandleRegistry::value_type entry(nextHandle(), hdata);
			_registry.insert(entry);

			return entry.first;
		}

	public:
		HandleManager(IHandleGenerator* generator = NULL)
		{
			if (generator == NULL)
				generator = new SequentialHandleGenerator();

			_generator = generator;
		}

		~HandleManager()
		{
			if (_generator != NULL) {
				delete _generator;
				_generator = NULL;
			}

			_handleDestroyed = NULL;

			for (HandleRegistry::iterator it = _registry.begin(); it != _registry.end(); it++) {
				IHandleData* hdata = (*it).second;

				hdata->deleteData();
				delete hdata;
				hdata = NULL;
			}
		}

		void setHandleDestroyedListener(HandleDestroyedHandler handleDestroyed)
		{
			_handleDestroyed = handleDestroyed;
		}

		void destroyHandle(InvHandle handle)
		{
			if (handle == 0)
				return;

			HandleRegistry::const_iterator it = _registry.find(handle);

			if (it == _registry.end())
				return;

			IHandleData* hdata = (*it).second;

			_registry.erase(handle);
			hdata->deleteData();
			delete hdata;

			if (_handleDestroyed != NULL)
				_handleDestroyed(handle);
		}

		/**
		 * Creates a new handle for the specified data
		 */
		template<typename T>
		InvHandle createHandle(T* data)
		{
			IHandleData* hdata = new HandleData<T>(data);

			return registerHandle(hdata);
		}

		/**
		 * Creates a new handle for the specified data
		 */
		template<typename T>
		InvHandle createReference(T* data)
		{
			IHandleData* hdata = new HandleReference<T>(data);

			return registerHandle(hdata);
		}

		/**
		 * Gets the data holded by the specified handle
		 */
		template<typename T>
		T* get(InvHandle handle)
		{
			try
			{
				IHandleData* hdata = _registry.at(handle);

				if (hdata == NULL)
					throws_key_not_found("" + handle);

				return hdata->convertedData<T>();
			}
			catch (std::bad_cast& e)
			{
				raise_exception(e.what(), INVALID_CAST_ERROR);
			}

			return NULL;
		}

		template<typename T>
		InvHandle find(T* data)
		{
			HandleRegistry::iterator it;

			for (it = _registry.begin(); it != _registry.end(); it++) {
				IHandleData* hdata = (*it).second;

				if (hdata->contains(data))
					return (*it).first;
			}

			return 0;
		}

		static HandleManager* getInstance()
		{
			static HandleManager instance;

			return &instance;
		}
	};


	template<typename T>
	inline InvHandle newHandleOf()
	{
		T* data = new T();

		return HandleManager::getInstance()->createHandle<T>(data);
	}

	template<typename T, typename P1>
	inline InvHandle newHandleOf(P1 param1)
	{
		T* data = new T(param1);

		return HandleManager::getInstance()->createHandle<T>(data);
	}

	template<typename T, typename P1, typename P2>
	inline InvHandle newHandleOf(P1 param1, P2 param2)
	{
		T* data = new T(param1, param2);

		return HandleManager::getInstance()->createHandle<T>(data);
	}

	template<typename T, typename P1, typename P2, typename P3>
	inline InvHandle newHandleOf(P1 param1, P2 param2, P3 param3)
	{
		T* data = new T(param1, param2, param3);

		return HandleManager::getInstance()->createHandle<T>(data);
	}

	template<typename T>
	inline T* castHandle(InvHandle handle)
	{
		return HandleManager::getInstance()->get<T>(handle);
	}

	inline void destroyHandle(InvHandle handle)
	{
		HandleManager::getInstance()->destroyHandle(handle);
	}

	template<typename T>
	inline InvHandle createHandle(T* data)
	{
		if (data == NULL)
			return INVALID_HANDLE;

		return HandleManager::getInstance()->createHandle<T>(data);
	}

	template<typename T>
	inline InvHandle createReference(T* data)
	{
		if (data == NULL)
			return INVALID_HANDLE;

		return HandleManager::getInstance()->createReference<T>(data);
	}

	template<typename T>
	inline InvHandle getOrCreateHandle(T* data)
	{
		if (data == NULL)
			return INVALID_HANDLE;

		InvHandle handle = HandleManager::getInstance()->find<T>(data);

		if (handle == 0)
			handle = createHandle<T>(data);

		return handle;
	}

	template<typename T>
	inline InvHandle getOrCreateReference(T* data)
	{
		if (data == NULL)
			return INVALID_HANDLE;

		InvHandle handle = HandleManager::getInstance()->find<T>(data);

		if (handle == 0)
			handle = createReference<T>(data);

		return handle;
	}

} // namespace invision

#endif // __cplusplus
#endif // __INVISION_HANDLE_H__
