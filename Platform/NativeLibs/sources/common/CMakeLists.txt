set (SOURCES 
  cCollections.cpp
  cEnumerator.cpp
  cWrapper.cpp
)

include_directories(.)

if (WIN32)
  set(CMAKE_USE_RELATIVE_PATHS true)
  set(CMAKE_SUPPRESS_REGENERATION true)

elseif (OSX)

else()
	set(CMAKE_CXX_FLAGS "-g -Wall")
	
endif (WIN32)

include_directories(${INCLUDES})
add_library(InVisionNative SHARED ${SOURCES})
target_link_libraries(InVisionNative ${LIBRARIES})
