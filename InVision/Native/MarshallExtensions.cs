using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using InVision.Native.Ogre;

namespace InVision.Native
{
	internal static class MarshallExtensions
	{
		private static readonly ConcurrentDictionary<IntPtr, WeakReference> Handles = new ConcurrentDictionary<IntPtr, WeakReference>();

		/// <summary>
		/// Registers the handle.
		/// </summary>
		/// <param name="handle">The handle.</param>
		/// <returns></returns>
		public static bool RegisterHandle(this Handle handle)
		{
			return Handles.TryAdd(handle.DangerousGetHandle(), new WeakReference(handle));
		}

		/// <summary>
		/// Unregisters the handle.
		/// </summary>
		/// <param name="handle">The handle.</param>
		/// <returns></returns>
		public static bool UnregisterHandle(this Handle handle)
		{
			WeakReference weakRef;

			return Handles.TryRemove(handle.DangerousGetHandle(), out weakRef);
		}

		/// <summary>
		/// Changes the type of the handle.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="handle">The handle.</param>
		/// <param name="creator">The creator.</param>
		/// <returns></returns>
		public static T ChangeHandleType<T>(this Handle handle, Func<IntPtr, T> creator)
		{
			IntPtr pHandle = handle.DangerousGetHandle();

			if (pHandle == IntPtr.Zero)
				return default(T);

			WeakReference reference;

			lock (typeof(T))
			{
				var weakRefCreator = new Func<IntPtr, WeakReference>(ptr => new WeakReference(creator(pHandle)));

				try
				{
					reference = Handles.AddOrUpdate(
						pHandle,
						weakRefCreator,
						(ptr, weakReference) => weakRefCreator(ptr));

					return (T)reference.Target;
				}
				finally
				{
					handle.GiveUpHandleOwnership();
				}
			}
		}

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

			WeakReference reference;

			lock (typeof(T))
			{
				var weakRefCreator = new Func<IntPtr, WeakReference>(ptr => new WeakReference(creator(pHandle)));

				reference = Handles.GetOrAdd(pHandle, weakRefCreator);

				if (reference.Target == null) // object already collected
					Handles[pHandle] = reference = weakRefCreator(pHandle);
			}

			return (T)reference.Target;
		}

		/// <summary>
		/// 	Marshals as string.
		/// </summary>
		/// <param name = "pString">The p string.</param>
		/// <returns></returns>
		public static string AsConstString(this IntPtr pString)
		{
			return Marshal.PtrToStringAnsi(pString);
		}

		/// <summary>
		/// Ases the string.
		/// </summary>
		/// <param name="pString">The p string.</param>
		/// <returns></returns>
		public static string AsString(this IntPtr pString)
		{
			try
			{
				return Marshal.PtrToStringAnsi(pString);
			}
			finally
			{
				if (pString != IntPtr.Zero)
					NativeOgreUtilities.DeleteString(pString);
			}
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
		///  Converts the pEnumerator into an automatic enumeration.
		/// </summary>
		/// <remarks>
		/// Automatic enumerations deletes the resource automatically for each data item, using the deleter method specified.
		/// </remarks>
		/// <typeparam name="T"></typeparam>
		/// <param name="pEnumerator">The p enumerator.</param>
		/// <param name="converter">The converter.</param>
		/// <param name="deleter">The deleter.</param>
		/// <returns></returns>
		public static IEnumerable<T> AsAutoEnumeration<T>(this IntPtr pEnumerator, Func<IntPtr, T> converter, Action<IntPtr> deleter)
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
							if (deleter != null)
								deleter(ptr);
						}
					});

				while (enumerator.MoveNext())
				{
					yield return enumerator.Current.Value;
				}
			}
		}

		/// <summary>
		/// Converts the pEnumerator into an automatic enumeration.
		/// </summary>
		/// <remarks>
		/// Automatic enumerations deletes the resource automatically for each data item, using the deleter method specified.
		/// </remarks>
		/// <typeparam name="T"></typeparam>
		/// <param name="pEnumerator">The p enumerator.</param>
		/// <param name="deleter">The deleter.</param>
		/// <returns></returns>
		public static IEnumerable<T> AsAutoEnumeration<T>(this IntPtr pEnumerator, Action<IntPtr> deleter)
		{
			return AsAutoEnumeration(pEnumerator, AsStructure<T>, deleter);
		}

		/// <summary>
		///  Converts the pEnumerator into an enumeration.
		/// </summary>
		/// <remarks>
		/// Non automatic enumerations must delete manually the resource data for each item.
		/// </remarks>
		/// <typeparam name="T"></typeparam>
		/// <param name="pEnumerator">The p enumerator.</param>
		/// <param name="converter">The converter.</param>
		/// <returns></returns>
		public static IEnumerable<KeyValuePair<IntPtr, T>> AsEnumeration<T>(this IntPtr pEnumerator, Func<IntPtr, T> converter)
		{
			using (var enumerator = new Enumerator<T>(pEnumerator))
			{
				enumerator.SetConverter(converter);

				while (enumerator.MoveNext())
				{
					yield return enumerator.Current;
				}
			}
		}

		/// <summary>
		///  Converts the pEnumerator into an enumeration.
		/// </summary>
		/// <remarks>
		/// Non automatic enumerations must delete manually the resource data for each item.
		/// </remarks>
		/// <typeparam name="T"></typeparam>
		/// <param name="pEnumerator">The p enumerator.</param>
		/// <returns></returns>
		public static IEnumerable<KeyValuePair<IntPtr, T>> AsEnumeration<T>(this IntPtr pEnumerator)
		{
			return AsEnumeration(pEnumerator, AsStructure<T>);
		}
	}
}