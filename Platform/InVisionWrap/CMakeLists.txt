cmake_minimum_required(VERSION 2.8)

project(InVisionWrap)

set (SOURCES 
  invision/Collections.cpp
  invision/Common.cpp
  invision/Enumerator.cpp
  invision/ogre3d/AnimableObject.cpp
  invision/ogre3d/Camera.cpp
  invision/ogre3d/ConfigFile.cpp
  invision/ogre3d/CustomFrameListener.cpp
  invision/ogre3d/FrameListener.cpp
  invision/ogre3d/MaterialManager.cpp
  invision/ogre3d/Math.cpp
  invision/ogre3d/NameValueParamsHandle.cpp
  invision/ogre3d/Node.cpp
  invision/ogre3d/RenderingEnumerators.cpp
  invision/ogre3d/RenderSystem.cpp
  invision/ogre3d/RenderWindow.cpp
  invision/ogre3d/ResourceGroupManager.cpp
  invision/ogre3d/Root.cpp
  invision/ogre3d/SceneManager.cpp
  invision/ogre3d/TextureManager.cpp
  invision/ogre3d/Viewport.cpp
  invision/ois/Axis.cpp
  invision/ois/Button.cpp
  invision/ois/Component.cpp
  invision/ois/CustomMouseListener.cpp
  invision/ois/EventArgs.cpp
  invision/ois/InputManager.cpp
  invision/ois/InputObject.cpp
  invision/ois/MouseEvent.cpp
  invision/ois/MouseState.cpp
  invision/ois/Vector3.cpp)

include_directories(.)

if (WIN32)
  set(CMAKE_USE_RELATIVE_PATHS true)
  set(CMAKE_SUPPRESS_REGENERATION true)

elseif (OSX)

else()
  set(INCLUDES . /usr/include/OGRE /usr/include/OIS)
  set(LIBRARIES OgreMain OIS)

endif (WIN32)


include_directories(${INCLUDES})
add_library(InVisionWrap SHARED ${SOURCES})
target_link_libraries(InVisionWrap ${LIBRARIES})
