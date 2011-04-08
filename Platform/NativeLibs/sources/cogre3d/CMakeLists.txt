set (SOURCES 
	common/Collections.cpp
	common/Common.cpp
	common/Enumerator.cpp
	invision/ois/Keyboard.cpp 
	cLogManager.cpp 
	cCollections.cpp
	cCommon.cpp
	cEnumerator.cpp
	cAnimableObject.cpp
	cCamera.cpp
	cConfigFile.cpp
	cCustomFrameListener.cpp
	cFrameListener.cpp
	cMaterialManager.cpp
	cMath.cpp
	cNameValueParamsHandle.cpp
	cNode.cpp
	cRenderingEnumerators.cpp
	cRenderSystem.cpp
	cRenderWindow.cpp
	cResourceGroupManager.cpp
	cRoot.cpp
	cSceneManager.cpp
	cTextureManager.cpp
	cViewport.cpp
)

include_directories(.)

if (WIN32)
  set(CMAKE_USE_RELATIVE_PATHS true)
  set(CMAKE_SUPPRESS_REGENERATION true)

elseif (OSX)

else()
	set(INCLUDES . /usr/include/OGRE)
	set(LIBRARIES OgreMain OIS)
	set(CMAKE_CXX_FLAGS "-g -Wall")	
endif (WIN32)

include_directories(${INCLUDES})
add_library(cOgre SHARED ${SOURCES})
target_link_libraries(cOgre ${LIBRARIES})
