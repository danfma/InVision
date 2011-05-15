set (SOURCES 
	cAxis.cpp
	cButton.cpp
	cComponent.cpp
	cCustomKeyEventListener.cpp
	cCustomMouseListener.cpp
	cEventArgs.cpp
	cInputManager.cpp
	cJoystick.cpp
	cKeyboard.cpp
	cKeyEvent.cpp
	cMouse.cpp
	cMouseEvent.cpp
	cMouseState.cpp
	cObject.cpp
	cOIS.cpp
	cVector3.cpp
)

include_directories(.)

if (WIN32)
  set(CMAKE_USE_RELATIVE_PATHS true)
  set(CMAKE_SUPPRESS_REGENERATION true)

elseif (OSX)

else()
	set(INCLUDES . /usr/include/OIS)
	set(LIBRARIES OIS)
	set(CMAKE_CXX_FLAGS "-g -Wall")
	
endif (WIN32)

include_directories(${INCLUDES})
add_library(InVisionNative_OIS SHARED ${SOURCES})
target_link_libraries(InVisionNative_OIS ${LIBRARIES})
