#-------------------------------------------------
#
# Project created by QtCreator 2011-02-15T16:53:30
#
#-------------------------------------------------

QT       -= core gui

TARGET = InVisionNative_OIS
TEMPLATE = lib

SOURCES += $$files(sources/cois/*.cpp)
HEADERS += $$files(sources/cois/*.h)

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

INCLUDEPATH += sources/common sources/cois

win32 {
	DEFINES += WIN32 DEBUG

	INCLUDEPATH += \
		$$(OGRE_SDK)include\OIS \
		$$(BOOST_SDK)

	LIBS += \
		-L$$(OGRE_SDK)lib\debug \
		-L$$(OGRE_SDK)lib\debug\opt \
		-lOIS_d
}

macx {
	DEFINES += MACOSX DEBUG
	INCLUDEPATH += /Users/danfma/Developer/libraries/OgreSDK/include/OIS
	LIBS += -L/Users/danfma/Developer/libraries/OgreSDK/lib/release/ -lOIS
}
