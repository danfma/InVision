using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;

namespace InVision.Extensions
{
	public static class TypeExtensions
	{
		/// <summary>
		/// Creates the instance.
		/// </summary>
		/// <param name="type">The type.</param>
		/// <param name="args">The args.</param>
		/// <returns></returns>
		public static object CreateInstance(this Type type, params object[] args)
		{
			return Activator.CreateInstance(
				type,
				BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic,
				null,
				args,
				CultureInfo.CurrentCulture);
		}
	}
}
