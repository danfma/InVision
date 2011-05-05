using System;
using InVision.Ogre.Native;

namespace InVision.Ogre.Util
{
	/// <summary>
	/// </summary>
	public static class MathUtility
	{
		/// <summary>
		/// Gets or sets the angle unit.
		/// </summary>
		/// <value>The angle unit.</value>
		public static AngleUnit AngleUnit
		{
			get { return NativeOgreMath.GetAngleUnit(); }
			set { NativeOgreMath.SetAngleUnit(value); }
		}

		/// <summary>
		/// Radians to angle unit.
		/// </summary>
		/// <param name="radians">The radians.</param>
		/// <returns></returns>
		public static float RadianToAngleUnit(float radians)
		{
			return NativeOgreMath.RadianToAngleUnit(radians);
		}


		/// <summary>
		/// Degrees to angle unit.
		/// </summary>
		/// <param name="degrees">The degrees.</param>
		/// <returns></returns>
		public static float DegreeToAngleUnit(float degrees)
		{
			return NativeOgreMath.DegreeToAngleUnit(degrees);
		}
	}
}