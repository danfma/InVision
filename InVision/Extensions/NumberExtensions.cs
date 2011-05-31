using System;
using System.Collections.Generic;

namespace InVision.Extensions
{
	public static class NumberExtensions
	{
		/// <summary>
		/// Ups to.
		/// </summary>
		/// <param name="start">The start.</param>
		/// <param name="end">The end.</param>
		/// <returns></returns>
		public static IEnumerable<int> UpTo(this int start, int end)
		{
			for (int i = start; i < end; i++) {
				yield return i;
			}
		}

		/// <summary>
		/// Secondses the specified value.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		public static TimeSpan Seconds(this int value)
		{
			return new TimeSpan(0, 0, value);
		}
	}
}