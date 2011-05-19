#ifndef INVISION_HANDLE_H
#define INVISION_HANDLE_H

#include "cWrapper.h"

#ifdef __cplusplus
#include <typeinfo>
#include <boost/unordered_map.hpp>
#endif // __cplusplus

extern "C"
{
	typedef _uint InvHandle;
	typedef _ushort TypeID;

	INV_EXPORT TypeID
	INV_CALL get_registered_typeid_by_name(const char* type);

	INV_EXPORT TypeID
	INV_CALL register_type_by_name(const char* type);

#ifdef __cplusplus

	INV_EXPORT TypeID
	INV_CALL get_registered_typeid(const std::type_info& type);

	INV_EXPORT TypeID
	INV_CALL register_typeid(const std::type_info& type);

#endif // __cplusplus

}

#ifdef __cplusplus

namespace invision
{
	const InvHandle INVALID_HANDLE = 0;
	
	class IHandleData
	{
	public:
		virtual TypeID getTypeId() = 0;
		virtual bool contains(void* data) = 0;
		virtual void deleteData() = 0;
	};

	typedef boost::unordered_map<InvHandle, IHandleData*> HandleRegistry;


	template<typename T>
	class HandleReference : public IHandleData
	{
	public:
		HandleReference(T* data)
			: _data(data)
		{ }

		inline T* data()
		{
			return _data;
		}

		virtual TypeID getTypeId()
		{
			return (TypeID)get_registered_typeid(typeid(T));
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

	protected:
		T* _data;
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
		IHandleGenerator* _generator;
		HandleRegistry _registry;


		template<typename T>
		InvHandle nextHandle()
		{
			return _generator->next() << 16 | get_registered_typeid(typeid(T));
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

			for (HandleRegistry::iterator it = _registry.begin(); it != _registry.end(); it++) {
				IHandleData* hdata = (*it).second;

				hdata->deleteData();
				delete hdata;
				hdata = NULL;
			}
		}

		/**
		 * Creates a new handle for the specified data
		 */
		template<typename T>
		InvHandle createHandle(T* data)
		{
			IHandleData* hdata = new HandleData<T>(data);

			HandleRegistry::value_type entry(nextHandle<T>(), hdata);
			_registry.insert(entry);

			return entry.first;
		}

		/**
		 * Creates a new handle for the specified data
		 */
		template<typename T>
		InvHandle createReference(T* data)
		{
			IHandleData* hdata = new HandleReference<T>(data);

			HandleRegistry::value_type entry(nextHandle<T>(), hdata);
			_registry.insert(entry);

			return entry.first;
		}

		/**
		 * Destroy the specified handle by removing it from this instance and deleting the data it
		 * holds.
		 */
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

				HandleReference<T>* converted = dynamic_cast<HandleReference<T>* >(hdata);

				if (converted == NULL)
					throws_invalid_cast(hdata->getTypeId(), get_registered_typeid(typeid(T)));

				return converted->data();
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

		return HandleManager::getInstance().createHandle<T>(data);
	}

	template<typename T, typename P1>
	inline InvHandle newHandleOf(P1 param1)
	{
		T* data = new T(param1);

		return HandleManager::getInstance().createHandle<T>(data);
	}

	template<typename T, typename P1, typename P2>
	inline InvHandle newHandleOf(P1 param1, P2 param2)
	{
		T* data = new T(param1, param2);

		return HandleManager::getInstance().createHandle<T>(data);
	}

	template<typename T, typename P1, typename P2, typename P3>
	inline InvHandle newHandleOf(P1 param1, P2 param2, P3 param3)
	{
		T* data = new T(param1, param2, param3);

		return HandleManager::getInstance().createHandle<T>(data);
	}

	template<typename T>
	inline T* castHandle(InvHandle handle)
	{
		return HandleManager::getInstance().get<T>(handle);
	}

	inline void destroyHandle(InvHandle handle)
	{
		HandleManager::getInstance().destroyHandle(handle);
	}

	template<typename T>
	inline InvHandle createHandle(T* data)
	{
		if (data == NULL)
			return INVALID_HANDLE;
		
		return HandleManager::getInstance().createHandle<T>(data);
	}

	template<typename T>
	inline InvHandle createReference(T* data)
	{
		if (data == NULL)
			return INVALID_HANDLE;

		return HandleManager::getInstance().createReference<T>(data);
	}

	template<typename T>
	inline InvHandle getOrCreateHandle(T* data)
	{
		if (data == NULL)
			return INVALID_HANDLE;
		
		InvHandle handle = HandleManager::getInstance().find<T>(data);

		if (handle == 0)
			handle = createHandle<T>(data);

		return handle;
	}

	template<typename T>
	inline InvHandle getOrCreateReference(T* data)
	{
		if (data == NULL)
			return INVALID_HANDLE;

		InvHandle handle = HandleManager::getInstance().find<T>(data);

		if (handle == 0)
			handle = createReference<T>(data);

		return handle;
	}


} // namespace invision

#endif // __cplusplus


#endif // INVISION_HANDLE_H
