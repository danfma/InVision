// 
// MathHelper.cs
//  
// Author:
//       Michael Hutchinson <mhutchinson@novell.com>
// 
// Copyright (c) 2010 Novell, Inc.
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;

namespace InVision.GameMath
{
	public static class MathHelper
	{
		public const float E = (float)Math.E;
		public const float Log10E = 0.4342944819032f;
		public const float Log2E = 1.442695040888f;
		public const float Pi = (float)Math.PI;
		public const float PiOver2 = (float)(Math.PI / 2.0);
		public const float PiOver4 = (float)(Math.PI / 4.0);
		public const float TwoPi = (float)(Math.PI * 2.0);
		private const float Deg2Rad = (float)(Math.PI / 180f);
		private const float Rad2Deg = (float)(180f / Math.PI);
        
		/// <summary>
		/// Barycentrics the specified value1.
		/// </summary>
		/// <param name="value1">The value1.</param>
		/// <param name="value2">The value2.</param>
		/// <param name="value3">The value3.</param>
		/// <param name="amount1">The amount1.</param>
		/// <param name="amount2">The amount2.</param>
		/// <returns></returns>
		public static float Barycentric(float value1, float value2, float value3, float amount1, float amount2)
		{
			return value1 + (value2 - value1) * amount1 + (value3 - value1) * amount2;
		}

		public static float CatmullRom(float value1, float value2, float value3, float value4, float amount)
		{
			// http://stephencarmody.wikispaces.com/Catmull-Rom+splines

			//value1 *= ((-amount + 2.0f) * amount - 1) * amount * 0.5f;
			//value2 *= (((3.0f * amount - 5.0f) * amount) * amount + 2.0f) * 0.5f;
			//value3 *= ((-3.0f * amount + 4.0f) * amount + 1.0f) * amount * 0.5f;
			//value4 *= ((amount - 1.0f) * amount * amount) * 0.5f;
			//
			//return value1 + value2 + value3 + value4;

			// http://www.mvps.org/directx/articles/catmull/

			float amountSq = amount * amount;
			float amountCube = amountSq * amount;

			// value1..4 = P0..3
			// amount = t
			return ((2.0f * value2 +
					 (-value1 + value3) * amount +
					 (2.0f * value1 - 5.0f * value2 + 4.0f * value3 - value4) * amountSq +
					 (3.0f * value2 - 3.0f * value3 - value1 + value4) * amountCube) * 0.5f);
		}



		/// <summary>
		/// Hermites the specified value1.
		/// </summary>
		/// <param name="value1">The value1.</param>
		/// <param name="tangent1">The tangent1.</param>
		/// <param name="value2">The value2.</param>
		/// <param name="tangent2">The tangent2.</param>
		/// <param name="amount">The amount.</param>
		/// <returns></returns>
		public static float Hermite(float value1, float tangent1, float value2, float tangent2, float amount)
		{
			//http://www.cubic.org/docs/hermite.htm
			float s = amount;
			float s2 = s * s;
			float s3 = s2 * s;
			float h1 = 2 * s3 - 3 * s2 + 1;
			float h2 = -2 * s3 + 3 * s2;
			float h3 = s3 - 2 * s2 + s;
			float h4 = s3 - s2;
			return value1 * h1 + value2 * h2 + tangent1 * h3 + tangent2 * h4;
		}

		/// <summary>
		/// Lerps the specified value1.
		/// </summary>
		/// <param name="value1">The value1.</param>
		/// <param name="value2">The value2.</param>
		/// <param name="amount">The amount.</param>
		/// <returns></returns>
		public static float Lerp(float value1, float value2, float amount)
		{
			return value1 + (value2 - value1) * amount;
		}

		/// <summary>
		/// Maxes the specified value1.
		/// </summary>
		/// <param name="value1">The value1.</param>
		/// <param name="value2">The value2.</param>
		/// <returns></returns>
		public static float Max(float value1, float value2)
		{
			return Math.Max(value1, value2);
		}

		/// <summary>
		/// Mins the specified value1.
		/// </summary>
		/// <param name="value1">The value1.</param>
		/// <param name="value2">The value2.</param>
		/// <returns></returns>
		public static float Min(float value1, float value2)
		{
			return Math.Min(value1, value2);
		}

		/// <summary>
		/// Smoothes the step.
		/// </summary>
		/// <param name="value1">The value1.</param>
		/// <param name="value2">The value2.</param>
		/// <param name="amount">The amount.</param>
		/// <returns></returns>
		public static float SmoothStep(float value1, float value2, float amount)
		{
			//FIXME: check this
			//the function is Smoothstep (http://en.wikipedia.org/wiki/Smoothstep) but the usage has been altered
			// to be similar to Lerp
			amount = amount * amount * (3f - 2f * amount);

			return value1 + (value2 - value1) * amount;
		}

		#region Methods and extensions

		/// <summary>
		/// Gets the signed angle between.
		/// </summary>
		/// <param name="from">From.</param>
		/// <param name="target">The target.</param>
		/// <param name="targetRight">The target right.</param>
		/// <returns></returns>
		public static double GetSignedAngleBetween(Vector3 from, Vector3 target, Vector3 targetRight)
		{
			from.Normalize();
			target.Normalize();
			targetRight.Normalize();

			float forwardDot = Vector3.Dot(from, target);
			float rightDot = Vector3.Dot(from, targetRight);

			// Keep dot in range to prevent rounding errors
			forwardDot = forwardDot.Clamp(-1.0f, 1.0f);

			double angleBetween = Math.Acos(forwardDot);

			if (rightDot < 0.0f)
				angleBetween *= -1.0f;

			return angleBetween;
		}

		/// <summary>
		/// Wraps the angle.
		/// </summary>
		/// <param name="angle">The angle.</param>
		/// <returns></returns>
		public static float WrapAngle(this float angle)
		{
			angle = angle % TwoPi;

			if (angle > Pi)
				return angle - TwoPi;

			if (angle < -Pi)
				return angle + TwoPi;

			return angle;
		}

		/// <summary>
		/// Equals the specified a.
		/// </summary>
		/// <param name="a">A.</param>
		/// <param name="b">The b.</param>
		/// <param name="tolerance">The tolerance.</param>
		/// <returns></returns>
		public static bool Equal(this float a, float b, float tolerance = float.Epsilon)
		{
			return Math.Abs(b - a) <= tolerance;
		}

		/// <summary>
		/// Clamps the specified value.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <param name="min">The min.</param>
		/// <param name="max">The max.</param>
		/// <returns></returns>
		public static float Clamp(this float value, float min, float max)
		{
			return Math.Min(Math.Max(min, value), max);
		}

		/// <summary>
		/// Distances the specified value1.
		/// </summary>
		/// <param name="value1">The value1.</param>
		/// <param name="value2">The value2.</param>
		/// <returns></returns>
		public static float Distance(this float value1, float value2)
		{
			return Math.Abs(value1 - value2);
		}

		/// <summary>
		/// Convert from radian to degree.
		/// </summary>
		/// <param name="radians">The radians.</param>
		/// <returns></returns>
		public static float ToDegree(this float radians)
		{
			return radians * Rad2Deg;
		}

		/// <summary>
		/// Convert from degree to radian.
		/// </summary>
		/// <param name="degrees">The degrees.</param>
		/// <returns></returns>
		public static float ToRadian(this float degrees)
		{
			return degrees * Deg2Rad;
		}

		#endregion
	}
}