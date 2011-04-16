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
		"../Platform/InVisionWrap/",
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
solution "InVisionWrap"
	configurations { "Debug", "Release" }
	location "projects/"
	
	project "InVisionNative"
		kind "SharedLib"
		language "C++"
		files {
			"../Platform/NativeLibs/sources/common/**.h",
			"../Platform/NativeLibs/sources/common/**.cpp"
		}
		
		table.insert(config.includes, "../Platform/NativeLibs/sources/common/")
		
		includedirs(config.includes)
		defines(config.defines)
		
		configuration "Debug"
			defines { "DEBUG" }
			flags { "Symbols" }
			targetdir "Bin/Debug_x86/Platform/"
			
			libdirs(config.libdirs)
			
		configuration "Release"
			defines { "NDEBUG" }
			flags { "Optimize" }
			targetdir "Bin/Release_x86/Platform/"
			
			libdirs(config.libdirs)
			
	project "InVisionNative_OIS"
		kind "SharedLib"
		language "C++"
		files {
			"../Platform/NativeLibs/sources/common/**.h",
			"../Platform/NativeLibs/sources/cois/**.h",
			"../Platform/NativeLibs/sources/cois/**.cpp"
		}
		
		table.insert(config.includes, "../Platform/NativeLibs/sources/common/")
		table.insert(config.includes, "../Platform/NativeLibs/sources/cois/")
		
		includedirs(config.includes)
		defines(config.defines)
		
		configuration "Debug"
			defines { "DEBUG" }
			flags { "Symbols" }
			targetdir "Bin/Debug_x86/Platform/"
			
			libdirs(config.libdirs)
			links({ "OIS", "InVisionNative" })
			
		configuration "Release"
			defines { "NDEBUG" }
			flags { "Optimize" }
			targetdir "Bin/Release_x86/Platform/"
			
			libdirs(config.libdirs)
			links({ "OIS", "InVisionNative" })
			