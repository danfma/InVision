using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;

namespace InVision.Framework.Config
{
	/// <summary>
	/// 
	/// </summary>
	public static class Platform
	{
		public static readonly bool Is32Bits;
		public static readonly bool Is64Bits;
		public static readonly bool IsWindows;
		public static readonly bool IsMacOSX;
		public static readonly bool IsLinux;
		public static readonly bool IsUnix;
		public static readonly PlatformIdentity PlatformIdentity;

		/// <summary>
		/// Initializes the <see cref="Platform"/> class.
		/// </summary>
		static Platform()
		{
			Is64Bits = Environment.Is64BitProcess;
			Is32Bits = !Is64Bits;

			PlatformID osplatform = Environment.OSVersion.Platform;

			switch (osplatform)
			{
				case PlatformID.Win32NT:
				case PlatformID.Win32S:
				case PlatformID.Win32Windows:
				case PlatformID.WinCE:
					IsWindows = true;
					PlatformIdentity = PlatformIdentity.Windows;
					break;

				case PlatformID.MacOSX:
					IsMacOSX = true;
					PlatformIdentity = PlatformIdentity.MacOSX;
					break;

				case PlatformID.Unix:
					DetectUnix(out IsLinux, out IsUnix, out PlatformIdentity);
					break;

				default:
					if (osplatform == (PlatformID) 4)
						DetectUnix(out IsLinux, out IsUnix, out PlatformIdentity);

					break;
			}
		}

		/// <summary>
		/// Detects the unix.
		/// </summary>
		/// <param name="isLinux">if set to <c>true</c> [is linux].</param>
		/// <param name="isUnix">if set to <c>true</c> [is unix].</param>
		/// <param name="platformIdentity">The platform OS.</param>
		private static void DetectUnix(out bool isLinux, out bool isUnix, out PlatformIdentity platformIdentity)
		{
			string kernelName = DetectUnixKernel();

			switch (kernelName)
			{
				case null:
				case "":
					throw new PlatformNotSupportedException("Unknown platform");

				case "Linux":
					isLinux = true;
					isUnix = false;
					platformIdentity = PlatformIdentity.Linux;
					break;

				case "Darwin":
					isLinux = isUnix = true;
					platformIdentity = PlatformIdentity.MacOSX;
					break;

				default:
					isLinux = false;
					isUnix = true;
					platformIdentity = PlatformIdentity.Unix;
					break;
			}
		}

		/// <summary>
		/// Detects the unix kernel.
		/// </summary>
		/// <returns></returns>
		private static string DetectUnixKernel()
		{
			Debug.Print("Size: {0}", Marshal.SizeOf(typeof (Utsname)));
			Debug.Flush();

			var uts = new Utsname();
			uname(out uts);

			Debug.WriteLine("System:");
			Debug.Indent();
			Debug.WriteLine(uts.sysname);
			Debug.WriteLine(uts.nodename);
			Debug.WriteLine(uts.release);
			Debug.WriteLine(uts.version);
			Debug.WriteLine(uts.machine);
			Debug.Unindent();

			return uts.sysname;
		}

		/// <summary>
		/// Unames the specified uname.
		/// </summary>
		/// <param name="uname">The uname.</param>
		[DllImport("libc")]
		private static extern void uname(out Utsname uname);

		/// <summary>
		/// Adds the library path.
		/// </summary>
		/// <param name="path">The path.</param>
		public static void AddLibraryPath(string path)
		{
			if (IsWindows)
				AddWinLibraryPath(path);
		}

		/// <summary>
		/// Adds the win library path.
		/// </summary>
		/// <param name="path">The path.</param>
		public static void AddWinLibraryPath(string path)
		{
			const string varName = "PATH";
			const string separator = ";";

			string varPath = Environment.GetEnvironmentVariable(varName);

			varPath += separator + Path.GetFullPath(path);
			Environment.SetEnvironmentVariable(varName, varPath);
		}

		#region Nested type: Utsname

		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
		private struct Utsname
		{
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)] public readonly string sysname;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)] public readonly string nodename;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)] public readonly string release;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)] public readonly string version;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)] public readonly string machine;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)] public readonly string extraJustInCase;
		}

		#endregion
	}
}