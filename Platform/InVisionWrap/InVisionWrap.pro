#-------------------------------------------------
#
# Project created by QtCreator 2011-02-15T16:53:30
#
#-------------------------------------------------

QT       -= core gui

TARGET = InVisionWrap
TEMPLATE = lib

SOURCES += \
	$$files(invision/*.cpp) \
	$$files(invision/ogre3d/*.cpp) \
	$$files(invision/ois/*.cpp)

HEADERS += \
	$$files(invision/*.h) \
	$$files(invision/ogre3d/*.h) \
	$$files(invision/ois/*.h)

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

INCLUDEPATH += .

win32 {
	DEFINES += WIN32 DEBUG

	INCLUDEPATH +=  \
		$$(OGRE_SDK)include\OGRE \
		$$(OGRE_SDK)include\OIS \
		$$(BOOST_SDK)

	LIBS += \
		-L$$(OGRE_SDK)lib\debug \
		-L$$(OGRE_SDK)lib\debug\opt \
		-L$$(BOOST_SDK)lib \
		-lOgreMain_d -lOIS_d
}

macx {
	DEFINES += DEBUG
	INCLUDEPATH += $$(OGRE_FRAMEWORK_DIR)/Headers
	LIBS += -framework Ogre
}

