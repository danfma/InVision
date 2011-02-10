-- COMPILING WRAPPERS AND MANAGED
os.execute("premake4 --os=windows --platform=x32 vs2010")
os.execute("msbuild projects/InVisionWrap.sln")
os.execute("msbuild ../InVision.sln")

-- COPYING DEBUG FILES
os.execute("mkdir Bin\\Debug\\Managed")
os.execute("copy ..\\InVision\\bin\\Debug\\InVision.dll Bin\\Debug\\Managed\\")
os.execute("copy ..\\InVision.Ogre3D\\bin\\Debug\\InVision.Ogre3D.dll Bin\\Debug\\Managed\\")

-- COPYING RELEASE FILES
os.execute("mkdir Bin\\Release\\Managed")
os.execute("copy ..\\InVision\\Bin\\Release\\InVision.dll Bin\\Release\\Managed\\")
os.execute("copy ..\\InVision.Ogre3D\\Bin\\Release\\InVision.Ogre3D.dll Bin\\Release\\Managed\\")
