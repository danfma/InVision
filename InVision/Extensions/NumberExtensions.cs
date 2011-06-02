using System;
using System.Collections.Generic;
using InVision.GameMath;

namespace InVision.Extensions
{
	public static class NumberExtensions
	{
		public static IEnumerable<int> UpTo(this int start, int end)
		{
			for (int i = start; i < end; i++) {
				yield return i;
			}
		}

		public static TimeSpan Second(this int value)
		{
			return new TimeSpan(0, 0, value);
		}

		public static Degree Degree(this float value)
		{
			return new Degree(value);
		}

		public static Radian Radian(this float value)
		{
			return new Radian(value);
		}
	}
}