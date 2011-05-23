#-------------------------------------------------
#
# Project created by QtCreator 2011-02-15T16:53:30
#
#-------------------------------------------------

QT       -= core gui

TARGET = InVisionNative_Ogre
TEMPLATE = lib

SOURCES += $$files(sources/cogre3d/*.cpp)
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

INCLUDEPATH += sources/common sources/cogre3d

win32 {
	DEFINES += WIN32

	INCLUDEPATH +=  $$(OGRE_SDK)include\OGRE $$(BOOST_SDK)

	LIBS += -L$$(OGRE_SDK)lib/debug
	LIBS += -L$$(OGRE_SDK)lib/debug/opt
	LIBS += -L../build_InVisionNative/Bin/Debug/
	LIBS += -lOgreMain_d -lOIS_d -lInVisionNative
}

macx {
	DEFINES += DEBUG
	INCLUDEPATH += $$(OGRE_FRAMEWORK_DIR)/Headers
	LIBS += -framework Ogre
}
