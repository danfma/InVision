cmake_minimum_required(VERSION 2.8)

set (SOURCES 
	cAxis.cpp
	cButton.cpp
	cComponent.cpp
	cVector3.cpp
)

include_directories(.)
include_directories(../common/)

if (WIN32)
  set(CMAKE_USE_RELATIVE_PATHS true)
  set(CMAKE_SUPPRESS_REGENERATION true)

	include_directories(C:/boost_1_46_1/)
	include_directories(C:/OgreSDK_mingw_v1-7-2/include/OIS/)
	link_directories(C:/OgreSDK_mingw_v1-7-2/lib/debug)

elseif (OSX)

else()
	set(INCLUDES . /usr/include/OIS/)
	set(LIBRARIES OIS_d ${InVisionNative})
	set(CMAKE_CXX_FLAGS "-g -Wall")
	
endif (WIN32)

include_directories(${INCLUDES})
add_library(InVisionNative_OIS SHARED ${SOURCES})
target_link_libraries(InVisionNative_OIS ${LIBRARIES})
