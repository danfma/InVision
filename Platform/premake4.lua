config = { 
	defines = {},
	includes = {},
	libdirs = {},
	links = {}
}

if os.is("windows") then
	local ogredir = "C:\\OgreSDK_vc10_v1-7-2\\"
	local boostdir = "C:\\boost_1_45_0\\"
	local qtsdk = "C:\\Qt\\2010.05\\qt\\include\\"
	
	config.defines = { "WIN32" }
	
	config.includes = {
		"InVisionWrap_Ogre3D/src/",
		ogredir .. "include\\OGRE\\",
		ogredir .. "include\\OIS\\",
		boostdir,
		qtsdk
	}	
	
	config.libdirs = {
		ogredir .. "lib\\debug\\",
		ogredir .. "lib\\release\\",
		boostdir .. "stage\\lib"
	}
	
	config.debugLinks = {
		"OgreMain_d",
		"OIS_d"
	}
	
	config.ndebugLinks = {
		"OgreMain",
		"OIS"
	}
end

-- Solution description
solution "InVision"
	configurations { "Debug", "Release" }
	location "projects/"
	
	-- PROJECT InVisionPlatform
	project "InVisionWrap_Ogre3D"
		kind "SharedLib"
		language "C++"
		files {
			"InVisionWrap_Ogre3D/src/**.h",
			"InVisionWrap_Ogre3D/src/**.cpp"
		}
		
		includedirs(config.includes)
		defines(config.defines)
		
		configuration "Debug"
			defines { "DEBUG" }
			flags { "Symbols" }
			targetdir "Build/Bin/Debug"
			
			libdirs(config.libdirs)
			links(config.debugLinks)
			
		configuration "Release"
			defines { "NDEBUG" }
			flags { "Optimize" }
			targetdir "Build/Bin/Release"
			
			libdirs(config.libdirs)
			links(config.ndebugLinks)
			