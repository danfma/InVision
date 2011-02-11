#ifndef INVISION_UTIL_H
#define INVISION_UTIL_H

#include "invision/Common.h"
#include "invision/NameValueParamsHandle.h"
#include "invision/rendering/CustomFrameListener.h"

extern "C"
{
	__EXPORT void __ENTRY util_delete_string(const char* data);
	__EXPORT void __ENTRY util_delete_namevaluepair(PNameValuePair data);
}

#ifdef __cplusplus
#include <Ogre.h>

namespace invision
{
	/*
	 * Handle convertion
	 */

	inline Bool toBool(bool value)
	{
		return value ? TRUE : FALSE;
	}

	inline bool fromBool(Bool value)
	{
		return value == TRUE;
	}

	inline Vector3f toVector3f(Ogre::Vector3& v)
	{
		Vector3f r;
#if USE_SIMD
		r.vdata.x = v.x;
		r.vdata.y = v.y;
		r.vdata.z = v.z;
#else
		r.x = v.x;
		r.y = v.y;
		r.z = v.z;
#endif

		return r;
	}

	inline Ogre::Vector3 fromVector3f(Vector3f& v)
	{
#if USE_SIMD
		return Ogre::Vector3(v.vdata.x, v.vdata.y, v.vdata.z);
#else
		return Ogre::Vector3(v.x, v.y, v.z);
#endif
	}

	inline Quaternion toQuaternion(Ogre::Quaternion& v)
	{
		Quaternion q;
		q.w = v.w;
		q.x = v.x;
		q.y = v.y;
		q.z = v.z;

		return q;
	}

	inline Ogre::Quaternion fromQuaternion(Quaternion& q)
	{
		return Ogre::Quaternion(q.w, q.x, q.y, q.z);
	}


	inline Ogre::Root* asRoot(HRoot handle)
	{
		return (Ogre::Root*)handle;
	}

	inline CustomFrameListener* asCustomFrameListener(HFrameListener handle)
	{
		return (CustomFrameListener*)handle;
	}

	inline Ogre::RenderSystem* asRenderSystem(HRenderSystem handle)
	{
		return (Ogre::RenderSystem*)handle;
	}

	inline Ogre::RenderWindow* asRenderWindow(HRenderWindow handle)
	{
		return (Ogre::RenderWindow*)handle;
	}

	inline Ogre::NameValuePairList* asNameValuePairList(HNameValuePairList handle)
	{
		return (Ogre::NameValuePairList*)handle;
	}

	inline Ogre::SceneManager* asSceneManager(HSceneManager handle)
	{
		return (Ogre::SceneManager*)handle;
	}

	inline Ogre::SceneNode* asSceneNode(HSceneNode handle)
	{
		return (Ogre::SceneNode*)handle;
	}

	inline Ogre::Camera* asCamera(HCamera handle)
	{
		return (Ogre::Camera*)handle;
	}

	inline IEnumerator* asEnumerator(HEnumerator self)
	{
		return (IEnumerator*)self;
	}

	/*
	 * Utilities
	 */
	inline char* copyString(const Ogre::String* str)
	{
		int length = str->size();
		char* data = new char[length + 1];

		strcpy(data, str->c_str());
		data[length] = NULL;

		return data;
	}

	inline char* copyString(Ogre::String& str)
	{
		int length = str.size();
		char* data = new char[length + 1];

		strcpy(data, str.c_str());
		data[length] = NULL;

		return data;
	}

	typedef Int64 HandleKey;
	typedef void (*DataDeleter)(Any);

	/*
	 * Classes
	 */

	struct MemoryTuple
	{
		Any data;
		DataDeleter deleter;

		MemoryTuple(Any data, DataDeleter deleter)
		{
			this->data = data;
			this->deleter = deleter;
		}

		~MemoryTuple()
		{
			if (deleter != NULL)
				deleter(data);
		}
	};

	typedef MemoryTuple* PMemoryTuple;

	typedef std::map<std::string, PMemoryTuple> PropertyMap, *PPropertyMap;
	typedef std::pair<std::string, PMemoryTuple> PropertyMapPair;
	typedef std::map<HandleKey, PPropertyMap> HandleMap;

	class MemoryMap
	{
	private:
		HandleMap map;

		void hookData(Handle handle, const char* propertyKey, Any data, DataDeleter dataDeleter);
		void unhookData(Handle handle);
		bool tryFindData(Handle handle, const char* propertyKey, Any* data);
		void clear();

		static MemoryMap& getInstance();

	public:
		MemoryMap();
		~MemoryMap();

		static void hook(Handle handle, const char* propertyKey, Any data, DataDeleter dataDeleter);
		static void unhook(Handle handle);
		static bool tryFind(Handle handle, const char* propertyKey, Any* data);
	};

	template<typename T>
	class Deleter
	{
	public:
		static void deleteData(Any data)
		{
			delete ((T)data);
		}

		static void deleteArray(Any data)
		{
			delete[] ((T)data);
		}

	};
}

#endif // __cplusplus

#endif // INVISION_UTIL_H
