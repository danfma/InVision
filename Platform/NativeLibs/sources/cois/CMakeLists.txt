set (SOURCES 
	../common/cWrapper.cpp
	cOIS.cpp
	cAxis.cpp
	cButton.cpp
	cComponent.cpp
	cCustomMouseListener.cpp
	cEventArgs.cpp
	cInputManager.cpp
	cInputObject.cpp
	cMouseEvent.cpp
	cMouseState.cpp
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
add_library(cOIS SHARED ${SOURCES})
target_link_libraries(cOIS ${LIBRARIES})
