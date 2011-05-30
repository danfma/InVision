#-------------------------------------------------
#
# Project created by QtCreator 2011-02-15T16:53:30
#
#-------------------------------------------------

QT       -= core gui

Debug:TARGET = InVisionNative_d
Release:TARGET = InVisionNative

TEMPLATE = lib

SOURCES += $$files(sources/common/*.cpp)
SOURCES += $$files(sources/cois/*.cpp)
SOURCES += $$files(sources/cogre3d/*.cpp)

HEADERS += $$files(sources/common/*.h)
HEADERS += $$files(sources/cois/*.h)
HEADERS += $$files(sources/cogre3d/*.h)

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

INCLUDEPATH += sources/common
INCLUDEPATH += sources/cois
INCLUDEPATH += sources/cogre3d

DEFINES += InvNativeProject

win32 {
	DEFINES += WIN32

	INCLUDEPATH += $$(BOOST_SDK)
	INCLUDEPATH += $$(OGRE_SDK)include\OGRE
	INCLUDEPATH += $$(OGRE_SDK)include\OIS

	LIBS += -L$$(OGRE_SDK)lib/debug
	LIBS += -L$$(OGRE_SDK)lib/debug/opt
	LIBS += -lOgreMain_d -lOIS_d
}

macx {
	CONFIG += x86

	DEFINES += MACOSX

	INCLUDEPATH += /opt/local/include/
	INCLUDEPATH += /Library/Frameworks/OIS.framework/Headers/
	INCLUDEPATH += /Library/Frameworks/Ogre.framework/Headers/

	LIBS += -framework OIS
	LIBS += -framework Ogre
	LIBS += -framework Carbon -framework IOKit
}
