config = { 
	defines = {},
	includes = {},
	libdirs = {},
	debugLinks = {},
	ndebugLinks = {}
}

if os.is("windows") then
	local ogredir = "C:\\OgreSDK_vc10_v1-7-2\\"
	local boostdir = "C:\\boost_1_46_1\\"
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
end

-- Solution description
solution "NativeLibs"
	configurations { "Debug", "Release" }
	location "../Platform/Projects/"
	
	project "InVisionNative"
		kind "SharedLib"
		language "C++"
		files {
			"../Platform/NativeLibs/sources/common/**.h",
			"../Platform/NativeLibs/sources/common/**.cpp",
			"../Platform/NativeLibs/sources/cois/**.h",
			"../Platform/NativeLibs/sources/cois/**.cpp",
			"../Platform/NativeLibs/sources/cogre3d/**.h",
			"../Platform/NativeLibs/sources/cogre3d/**.cpp"
		}
		
		table.insert(config.includes, "../Platform/NativeLibs/sources/common/")
		table.insert(config.includes, "../Platform/NativeLibs/sources/cois/")
		table.insert(config.includes, "../Platform/NativeLibs/sources/cogre/")
		
		includedirs(config.includes)
		defines(config.defines)
		
		configuration "Debug"
			defines { "DEBUG" }
			flags { "Symbols" }
			targetdir "Bin/Debug_x86/Platform/"
			
			libdirs(config.libdirs)
			links({ "OIS_d", "OgreMain_d" })
			
		configuration "Release"
			defines { "NDEBUG" }
			flags { "Optimize" }
			targetdir "Bin/Release_x86/Platform/"
			
			libdirs(config.libdirs)
			links({ "OIS", "OgreMain" })