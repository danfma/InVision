#-------------------------------------------------
#
# Project created by QtCreator 2011-02-15T16:53:30
#
#-------------------------------------------------

QT       -= core gui

TARGET = InVisionNative
TEMPLATE = lib

SOURCES += $$files(sources/common/*.cpp)
HEADERS += $$files(sources/common/*.h)

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

INCLUDEPATH += sources/common $$(BOOST_SDK)

win32 {
	DEFINES += WIN32 DEBUG
}

macx {
	DEFINES += MACOSX DEBUG
}
