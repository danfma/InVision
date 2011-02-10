using System;
using InVision.Ogre3D.Native;

namespace InVision.Ogre3D.Util
{
	/// <summary>
	/// </summary>
	public static class MathUtility
	{
		private const float Deg2Rad = (float)(Math.PI / 180f);
		private const float Rad2Deg = (float)(180f / Math.PI);

		/// <summary>
		/// Initializes the <see cref="MathUtility"/> class.
		/// </summary>
		static MathUtility()
		{

		}

		/// <summary>
		/// Gets or sets the angle unit.
		/// </summary>
		/// <value>The angle unit.</value>
		public static AngleUnit AngleUnit
		{
			get { return NativeMath.GetAngleUnit(); }
			set { NativeMath.SetAngleUnit(value); }
		}

		/// <summary>
		/// Mins the max.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <param name="minimum">The minimum.</param>
		/// <param name="maximum">The maximum.</param>
		/// <returns></returns>
		public static float Clamp(float value, float minimum, float maximum)
		{
			if (value < minimum)
				return minimum;

			if (value > maximum)
				return maximum;

			return value;
		}

		/// <summary>
		/// Equals the specified a.
		/// </summary>
		/// <param name="a">A.</param>
		/// <param name="b">The b.</param>
		/// <param name="tolerance">The tolerance.</param>
		/// <returns></returns>
		public static bool Equal(float a, float b, float tolerance = float.Epsilon)
		{
			return Math.Abs(b - a) <= tolerance;
		}

		/// <summary>
		/// Radians to degree.
		/// </summary>
		/// <param name="radians">The radians.</param>
		/// <returns></returns>
		public static float RadianToDegree(float radians)
		{
			return radians * Rad2Deg;
		}

		/// <summary>
		/// Radians to angle unit.
		/// </summary>
		/// <param name="radians">The radians.</param>
		/// <returns></returns>
		public static float RadianToAngleUnit(float radians)
		{
			return NativeMath.RadianToAngleUnit(radians);
		}

		/// <summary>
		/// Degrees to radian.
		/// </summary>
		/// <param name="degrees">The degrees.</param>
		/// <returns></returns>
		public static float DegreeToRadian(float degrees)
		{
			return degrees * Deg2Rad;
		}

		/// <summary>
		/// Degrees to angle unit.
		/// </summary>
		/// <param name="degrees">The degrees.</param>
		/// <returns></returns>
		public static float DegreeToAngleUnit(float degrees)
		{
			return NativeMath.DegreeToAngleUnit(degrees);
		}
	}
}