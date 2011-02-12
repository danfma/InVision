using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace InVision.Ogre3D.Native
{
	internal static class MarshallExtensions
	{
		/// <summary>
		/// 	Marshals as handle.
		/// </summary>
		/// <typeparam name = "T"></typeparam>
		/// <param name = "pHandle">The p handle.</param>
		/// <param name = "creator">The creator.</param>
		/// <returns></returns>
		public static T AsHandle<T>(this IntPtr pHandle, Func<IntPtr, T> creator)
			where T : Handle
		{
			if (pHandle == IntPtr.Zero)
				return default(T);

			return creator(pHandle);
		}

		/// <summary>
		/// 	Marshals as string.
		/// </summary>
		/// <param name = "pString">The p string.</param>
		/// <returns></returns>
		public static string AsString(this IntPtr pString)
		{
			return Marshal.PtrToStringAnsi(pString);
		}

		/// <summary>
		/// 	Marshals as structure.
		/// </summary>
		/// <typeparam name = "T"></typeparam>
		/// <param name = "pStruct">The p struct.</param>
		/// <returns></returns>
		public static T AsStructure<T>(this IntPtr pStruct)
		{
			return (T)Marshal.PtrToStructure(pStruct, typeof(T));
		}

		/// <summary>
		/// 	Marshals as enumeration.
		/// </summary>
		/// <typeparam name = "T"></typeparam>
		/// <param name = "pEnumerator">The p enumerator.</param>
		/// <param name = "converter">The converter.</param>
		/// <param name = "cleaner">The cleaner.</param>
		/// <returns></returns>
		public static IEnumerable<T> AsEnumeration<T>(this IntPtr pEnumerator, Func<IntPtr, T> converter,
													  Action<IntPtr> cleaner = null)
		{
			using (var enumerator = new Enumerator<T>(pEnumerator))
			{
				enumerator.SetConverter(
					ptr =>
					{
						try
						{
							return converter(ptr);
						}
						finally
						{
							if (cleaner != null)
								cleaner(ptr);
						}
					});

				while (enumerator.MoveNext())
				{
					yield return enumerator.Current;
				}
			}
		}

		/// <summary>
		/// 	Marshals as enumeration.
		/// </summary>
		/// <typeparam name = "T"></typeparam>
		/// <param name = "pEnumerator">The p enumerator.</param>
		/// <param name = "cleaner">The cleaner.</param>
		/// <returns></returns>
		public static IEnumerable<T> AsEnumeration<T>(this IntPtr pEnumerator, Action<IntPtr> cleaner = null)
		{
			return AsEnumeration(pEnumerator, AsStructure<T>, cleaner);
		}
	}
}