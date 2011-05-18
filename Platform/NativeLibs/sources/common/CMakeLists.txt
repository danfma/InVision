cmake_minimum_required(VERSION 2.8)

set (SOURCES 
  cCollections.cpp
  cEnumerator.cpp
  cWrapper.cpp
  InvisionHandle.cpp
)

include_directories(.)

if (WIN32)
  set(CMAKE_USE_RELATIVE_PATHS true)
  set(CMAKE_SUPPRESS_REGENERATION true)

  include_directories(C:/boost_1_46_1/)

elseif (OSX)

else()
	set(CMAKE_CXX_FLAGS "-g -Wall")
	
endif (WIN32)

include_directories(${INCLUDES})
add_library(InVisionNative SHARED ${SOURCES})
target_link_libraries(InVisionNative ${LIBRARIES})
