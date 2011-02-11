config = { 
	defines = {},
	includes = {},
	libdirs = {},
	debugLinks = {},
	ndebugLinks = {}
}

if os.is("windows") then
	local ogredir = "C:\\OgreSDK_vc10_v1-7-2\\"
	local boostdir = "C:\\boost_1_45_0\\"
	local qtsdk = "C:\\Qt\\2010.05\\qt\\include\\"
	
	config.defines = { "WIN32", "USE_SIMD" }
	
	config.includes = {
		"../Platform/InVisionWrap_Ogre3D/src/",
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
	
	os.copyfile("..\\Libs\\Mono\\Simd\\Mono.GameMath.dll", "..\\Libs\\Mono\\")
	os.copyfile("..\\Libs\\Mono\\Simd\\Mono.Simd.dll", "..\\Libs\\Mono\\")
end

-- Solution description
solution "InVisionWrap"
	configurations { "Debug", "Release" }
	location "projects/"
	
	-- PROJECT InVisionPlatform
	project "InVisionWrap_Ogre3D"
		kind "SharedLib"
		language "C++"
		files {
			"../Platform/InVisionWrap_Ogre3D/src/**.h",
			"../Platform/InVisionWrap_Ogre3D/src/**.cpp"
		}
		
		includedirs(config.includes)
		defines(config.defines)
		
		configuration "Debug"
			defines { "DEBUG" }
			flags { "Symbols" }
			targetdir "Bin/Debug/Platform/"
			
			libdirs(config.libdirs)
			links(config.debugLinks)
			
		configuration "Release"
			defines { "NDEBUG" }
			flags { "Optimize" }
			targetdir "Bin/Release/Platform/"
			
			libdirs(config.libdirs)
			links(config.ndebugLinks)
			