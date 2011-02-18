#-------------------------------------------------
#
# Project created by QtCreator 2011-02-15T16:53:30
#
#-------------------------------------------------

QT       -= core gui

TARGET = InVisionWrap
TEMPLATE = lib

SOURCES += \
	invision/Common.cpp \
	invision/Enumerator.cpp \
	invision/ogre3d/NameValueParamsHandle.cpp \
	invision/ogre3d/Root.cpp \
	invision/ogre3d/RenderingEnumerators.cpp \
	invision/ogre3d/RenderSystem.cpp \
	invision/ogre3d/CustomFrameListener.cpp \
	invision/ogre3d/SceneManager.cpp \
	invision/ogre3d/FrameListener.cpp \
	invision/ogre3d/Camera.cpp \
	invision/ogre3d/Math.cpp \
	invision/ogre3d/RenderWindow.cpp \
	invision/ogre3d/AnimableObject.cpp \
	invision/ogre3d/Node.cpp \
	invision/ogre3d/TextureManager.cpp \
	invision/ogre3d/Viewport.cpp \
	invision/ogre3d/ConfigFile.cpp \
	invision/ogre3d/ResourceGroupManager.cpp \
	invision/ogre3d/MaterialManager.cpp \
    invision/Collections.cpp \
    invision/ois/Component.cpp \
    invision/ois/Button.cpp \
    invision/ois/Axis.cpp \
    invision/ois/Vector3.cpp \
    invision/ois/InputObject.cpp \
    invision/ois/MouseState.cpp \
    invision/ois/CustomMouseListener.cpp \
    invision/ois/EventArgs.cpp \
    invision/ois/MouseEvent.cpp \
    invision/ois/InputManager.cpp

HEADERS += \
	invision/Common.h \
	invision/Enumerator.h \
	invision/ogre3d/NameValueParamsHandle.h \
	invision/ogre3d/CustomFrameListener.h \
	invision/ogre3d/RenderSystem.h \
	invision/ogre3d/RenderingEnumerators.h \
	invision/ogre3d/Root.h \
	invision/ogre3d/SceneManager.h \
	invision/ogre3d/FrameListener.h \
	invision/ogre3d/Camera.h \
	invision/ogre3d/Math.h \
	invision/ogre3d/RenderWindow.h \
	invision/ogre3d/AnimableObject.h \
	invision/ogre3d/Node.h \
	invision/ogre3d/TextureManager.h \
	invision/ogre3d/Viewport.h \
	invision/ogre3d/ConfigFile.h \
	invision/ogre3d/ResourceGroupManager.h \
	invision/ogre3d/MaterialManager.h \
    invision/ogre3d/TypeConvert.h \
    invision/Collections.h \
    invision/ois/Component.h \
    invision/ois/Button.h \
    invision/ois/Axis.h \
    invision/ois/Vector3.h \
    invision/ois/InputObject.h \
    invision/ois/Common.h \
    invision/ois/MouseState.h \
    invision/ois/CustomMouseListener.h \
    invision/ois/EventArgs.h \
    invision/ois/MouseEvent.h \
    invision/ois/InputManager.h

Release:DESTDIR = Bin/Release
Release:OBJECTS_DIR = Bin/Release/.obj
Release:MOC_DIR = Bin/Release/.moc
Release:RCC_DIR = Bin/Release/.rcc
Release:UI_DIR = Bin/Release/.ui

Debug:DESTDIR = Bin/Debug
Debug:OBJECTS_DIR = Bin/Debug/.obj
Debug:MOC_DIR = Bin/Debug/.moc
Debug:RCC_DIR = Bin/Debug/.rcc
Debug:UI_DIR = Bin/Debug/.ui
Debug:DEFINES += DEBUG


win32 {
	DEFINES += WIN32 DEBUG

	INCLUDEPATH +=  \
		. \
		$$(OGRE_SDK)include\OGRE \
		$$(OGRE_SDK)include\OIS \
		$$(BOOST_SDK)

	LIBS += \
		-L$$(OGRE_SDK)lib\debug \
		-L$$(OGRE_SDK)lib\debug\opt \
		-L$$(BOOST_SDK)lib \
		-lOgreMain_d -lOIS_d
}
