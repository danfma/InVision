// 
// Quaternion.cs
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

#if SIMD
using Mono.Simd;
#endif

namespace InVision.GameMath
{
	[Serializable]
	public struct Quaternion
	{
#if SIMD
		internal Vector4f v4;
		public float X { get { return v4.X; } set { v4.X = value; } }
		public float Y { get { return v4.Y; } set { v4.Y = value; } }
		public float Z { get { return v4.Z; } set { v4.Z = value; } }
		public float W { get { return v4.W; } set { v4.W = value; } }

		Quaternion(Vector4f v4) { this.v4 = v4; }
#else
		float x, y, z, w;
		public float X { get { return x; } set { x = value; } }
		public float Y { get { return y; } set { y = value; } }
		public float Z { get { return z; } set { z = value; } }
		public float W { get { return w; } set { w = value; } }
#endif

		public Quaternion(float x, float y, float z, float w)
		{
#if SIMD
			v4 = new Vector4f(x, y, z, w);
#else
			this.x = x;
			this.y = y;
			this.z = z;
			this.w = w;
#endif
		}

		public Quaternion(Vector3 vectorPart, float scalarPart)
		{
#if SIMD
			v4 = new Vector4f(vectorPart.X, vectorPart.Y, vectorPart.Z, scalarPart);
#else
			x = vectorPart.X;
			y = vectorPart.Y;
			z = vectorPart.Z;
			w = scalarPart;
#endif
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Quaternion"/> struct.
		/// </summary>
		/// <param name="rotation">The rot matrix.</param>
		internal Quaternion(Matrix3 rotation)
			: this()
		{
			float t = 1f + rotation.A1 + rotation.B2 + rotation.C3;
			const float tax = 0.25f;

			if (t > 0.001f)
			{
				float s = (float)(Math.Sqrt(t) * 2f);

				X = (rotation.C2 - rotation.B3) / s;
				Y = (rotation.A3 - rotation.C1) / s;
				Z = (rotation.B1 - rotation.A2) / s;
				W = tax * s;
			}
			else if (rotation.A1 > rotation.B2 && rotation.A1 > rotation.C3)
			{
				float s = (float)Math.Sqrt(1f + rotation.A1 - rotation.B2 - rotation.C3) * 2f;

				X = tax * s;
				Y = (rotation.B1 + rotation.A2) / s;
				Z = (rotation.A3 + rotation.C1) / s;
				W = (rotation.C2 - rotation.B3) / s;
			}
			else if (rotation.B2 > rotation.C3)
			{
				float s = (float)Math.Sqrt(1f + rotation.B2 - rotation.A1 - rotation.C3) * 2f;

				X = (rotation.B1 + rotation.A2) / s;
				Y = tax * s;
				Z = (rotation.C2 + rotation.B3) / s;
				W = (rotation.A3 - rotation.C1) / s;
			}
			else
			{
				float s = (float)Math.Sqrt(1f + rotation.C3 - rotation.A1 - rotation.B2) * 2f;

				X = (rotation.A3 + rotation.C1) / s;
				Y = (rotation.C2 + rotation.B3) / s;
				Z = tax * s;
				W = (rotation.B1 - rotation.A2) / s;
			}
		}

		public static Quaternion Identity
		{
			get
			{
				return new Quaternion(0, 0, 0, 1);
			}
		}

		#region Creation

		public static Quaternion CreateFromAxisAngle(Vector3 axis, float angle)
		{
			Quaternion result;
			CreateFromAxisAngle(ref axis, angle, out result);
			return result;
		}

		public static void CreateFromAxisAngle(ref Vector3 axis, float angle, out Quaternion result)
		{
			Vector3 vec = axis;
			vec.Normalize();
			float ang = angle * 0.5f;
			Vector3.Multiply(ref vec, (float)System.Math.Sin(ang), out vec);

			result = new Quaternion(vec, (float)System.Math.Cos(ang));
		}

		public static Quaternion CreateFromRotationMatrix(Matrix matrix)
		{
			Quaternion result;
			CreateFromRotationMatrix(ref matrix, out result);
			return result;
		}

		public static void CreateFromRotationMatrix(ref Matrix matrix, out Quaternion result)
		{
			result = default(Quaternion);

			if ((matrix.M11 + matrix.M22 + matrix.M33) > 0.0F)
			{
				float M1 = (float)System.Math.Sqrt((double)(matrix.M11 + matrix.M22 + matrix.M33 + 1.0F));
				result.W = M1 * 0.5F;
				M1 = 0.5F / M1;
				result.X = (matrix.M23 - matrix.M32) * M1;
				result.Y = (matrix.M31 - matrix.M13) * M1;
				result.Z = (matrix.M12 - matrix.M21) * M1;
			}
			if ((matrix.M11 >= matrix.M22) && (matrix.M11 >= matrix.M33))
			{
				float M2 = (float)System.Math.Sqrt((double)(1.0F + matrix.M11 - matrix.M22 - matrix.M33));
				float M3 = 0.5F / M2;
				result.X = 0.5F * M2;
				result.Y = (matrix.M12 + matrix.M21) * M3;
				result.Z = (matrix.M13 + matrix.M31) * M3;
				result.W = (matrix.M23 - matrix.M32) * M3;
			}
			if (matrix.M22 > matrix.M33)
			{
				float M4 = (float)System.Math.Sqrt((double)(1.0F + matrix.M22 - matrix.M11 - matrix.M33));
				float M5 = 0.5F / M4;
				result.X = (matrix.M21 + matrix.M12) * M5;
				result.Y = 0.5F * M4;
				result.Z = (matrix.M32 + matrix.M23) * M5;
				result.W = (matrix.M31 - matrix.M13) * M5;
			}
			float M6 = (float)System.Math.Sqrt((double)(1.0F + matrix.M33 - matrix.M11 - matrix.M22));
			float M7 = 0.5F / M6;
			result.X = (matrix.M31 + matrix.M13) * M7;
			result.Y = (matrix.M32 + matrix.M23) * M7;
			result.Z = 0.5F * M6;
			result.W = (matrix.M12 - matrix.M21) * M7;
		}

		public static Quaternion CreateFromYawPitchRoll(float yaw, float pitch, float roll)
		{
			Quaternion result;
			CreateFromYawPitchRoll(yaw, pitch, roll, out result);
			return result;
		}

		public static void CreateFromYawPitchRoll(float yaw, float pitch, float roll, out Quaternion result)
		{
			// http://en.wikipedia.org/wiki/Conversion_between_quaternions_and_Euler_angles
			// -> http://upload.wikimedia.org/math/8/f/2/8f24d7035f36dd398e6253a521d7ac0c.png

			yaw *= 0.5f;
			pitch *= 0.5f;
			roll *= 0.5f;

			float cosYaw = (float)System.Math.Cos(yaw);
			float sinYaw = (float)System.Math.Sin(yaw);
			float cosPitch = (float)System.Math.Cos(pitch);
			float sinPitch = (float)System.Math.Sin(pitch);
			float cosRoll = (float)System.Math.Cos(roll);
			float sinRoll = (float)System.Math.Sin(roll);

			float cosPitchCosYaw = cosPitch * cosYaw;
			float sinPitchSinYaw = sinPitch * sinYaw;

			float x = sinRoll * cosPitchCosYaw - cosRoll * sinPitchSinYaw;
			float y = cosRoll * sinPitch * cosYaw + sinRoll * cosPitch * sinYaw;
			float z = cosRoll * cosPitch * sinYaw - sinRoll * sinPitch * cosYaw;
			float w = cosRoll * cosPitchCosYaw + sinRoll * sinPitchSinYaw;

			result = new Quaternion(x, y, z, w);
		}

		#endregion

		#region Arithmetic

		public static Quaternion Add(Quaternion quaternion1, Quaternion quaternion2)
		{
#if SIMD
			return new Quaternion(quaternion1.v4 + quaternion2.v4);
#else
			return new Quaternion (quaternion1.X + quaternion2.X, quaternion1.Y + quaternion2.Y,
				quaternion1.Z + quaternion2.Z, quaternion1.W + quaternion2.W);
#endif
		}

		public static void Add(ref Quaternion quaternion1, ref Quaternion quaternion2, out Quaternion result)
		{
#if SIMD
			result = new Quaternion(quaternion1.v4 + quaternion2.v4);
#else
			result = default(Quaternion);
			result.X = quaternion1.X + quaternion2.X;
			result.Y = quaternion1.Y + quaternion2.Y;
			result.Z = quaternion1.Z + quaternion2.Z;
			result.W = quaternion1.W + quaternion2.W;
#endif
		}

		public static Quaternion Subtract(Quaternion quaternion1, Quaternion quaternion2)
		{
#if SIMD
			return new Quaternion(quaternion1.v4 - quaternion2.v4);
#else
			return new Quaternion (quaternion1.X - quaternion2.X, quaternion1.Y - quaternion2.Y,
				quaternion1.Z - quaternion2.Z, quaternion1.W - quaternion2.W);
#endif
		}

		public static void Subtract(ref Quaternion quaternion1, ref Quaternion quaternion2, out Quaternion result)
		{
#if SIMD
			result = new Quaternion(quaternion1.v4 - quaternion2.v4);
#else
			result = default(Quaternion);
			result.X = quaternion1.X - quaternion2.X;
			result.Y = quaternion1.Y - quaternion2.Y;
			result.Z = quaternion1.Z - quaternion2.Z;
			result.W = quaternion1.W - quaternion2.W;
#endif
		}

		public static Quaternion Multiply(Quaternion quaternion1, Quaternion quaternion2)
		{
			// TODO: SIMD optimization
			return new Quaternion(
				quaternion1.W * quaternion2.X + quaternion1.X * quaternion2.W + quaternion1.Y * quaternion2.Z - quaternion1.Z * quaternion2.Y,
				quaternion1.W * quaternion2.Y - quaternion1.X * quaternion2.Z + quaternion1.Y * quaternion2.W + quaternion1.Z * quaternion2.X,
				quaternion1.W * quaternion2.Z + quaternion1.X * quaternion2.Y - quaternion1.Y * quaternion2.X + quaternion1.Z * quaternion2.W,
				quaternion1.W * quaternion2.W - quaternion1.X * quaternion2.X - quaternion1.Y * quaternion2.Y - quaternion1.Z * quaternion2.Z);
		}

		public static void Multiply(ref Quaternion quaternion1, ref Quaternion quaternion2, out Quaternion result)
		{
			// TODO: SIMD optimization
			result = new Quaternion(
				quaternion1.W * quaternion2.X + quaternion1.X * quaternion2.W + quaternion1.Y * quaternion2.Z - quaternion1.Z * quaternion2.Y,
				quaternion1.W * quaternion2.Y - quaternion1.X * quaternion2.Z + quaternion1.Y * quaternion2.W + quaternion1.Z * quaternion2.X,
				quaternion1.W * quaternion2.Z + quaternion1.X * quaternion2.Y - quaternion1.Y * quaternion2.X + quaternion1.Z * quaternion2.W,
				quaternion1.W * quaternion2.W - quaternion1.X * quaternion2.X - quaternion1.Y * quaternion2.Y - quaternion1.Z * quaternion2.Z);
		}

		public static Quaternion Multiply(Quaternion quaternion1, float scaleFactor)
		{
#if SIMD
			return new Quaternion(quaternion1.v4 * new Vector4f(scaleFactor));
#else
			return new Quaternion (quaternion1.x * scaleFactor, quaternion1.y * scaleFactor,
				quaternion1.z * scaleFactor, quaternion1.w * scaleFactor);
#endif
		}

		public static void Multiply(ref Quaternion quaternion1, float scaleFactor, out Quaternion result)
		{
#if SIMD
			result.v4 = quaternion1.v4 * new Vector4f(scaleFactor);
#else
			result.x = quaternion1.x * scaleFactor;
			result.y = quaternion1.y * scaleFactor;
			result.z = quaternion1.z * scaleFactor;
			result.w = quaternion1.w * scaleFactor;
#endif
		}

		public static Quaternion Divide(Quaternion quaternion1, Quaternion quaternion2)
		{
			Quaternion result;
			Divide(ref quaternion1, ref quaternion2, out result);
			return result;
		}

		public static void Divide(ref Quaternion quaternion1, ref Quaternion quaternion2, out Quaternion result)
		{
			Quaternion inv;
			Inverse(ref quaternion2, out inv);
			Multiply(ref quaternion1, ref inv, out result);
		}

		public static Quaternion Divide(Quaternion quaternion1, float scaleFactor)
		{
#if SIMD
			return new Quaternion(quaternion1.v4 / new Vector4f(scaleFactor));
#else
			return new Quaternion (quaternion1.x / scaleFactor, quaternion1.y / scaleFactor,
				quaternion1.z / scaleFactor, quaternion1.w / scaleFactor);
#endif
		}

		public static void Divide(ref Quaternion quaternion1, float scaleFactor, out Quaternion result)
		{
#if SIMD
			result.v4 = quaternion1.v4 / new Vector4f(scaleFactor);
#else
			result.x = quaternion1.x / scaleFactor;
			result.y = quaternion1.y / scaleFactor;
			result.z = quaternion1.z / scaleFactor;
			result.w = quaternion1.w / scaleFactor;
#endif
		}

		public static Quaternion Negate(Quaternion quaternion)
		{
#if SIMD
			return new Quaternion(quaternion.v4 ^ new Vector4f(-0.0f));
#else
			return new Quaternion (- quaternion.x, - quaternion.y, - quaternion.z, - quaternion.w);
#endif
		}

		public static void Negate(ref Quaternion quaternion, out Quaternion result)
		{
#if SIMD
			result.v4 = quaternion.v4 ^ new Vector4f(-0.0f);
#else
			result.x = - quaternion.x;
			result.y = - quaternion.y;
			result.z = - quaternion.z;
			result.w = - quaternion.w;
#endif
		}

		#endregion

		#region Operator overloads

		public static Quaternion operator +(Quaternion quaternion1, Quaternion quaternion2)
		{
#if SIMD
			return new Quaternion(quaternion1.v4 + quaternion2.v4);
#else
			return Add (quaternion1, quaternion2);
#endif
		}

		public static Quaternion operator /(Quaternion quaternion1, Quaternion quaternion2)
		{
			Quaternion result;
			Divide(ref quaternion1, ref quaternion2, out result);
			return result;
		}

		public static Quaternion operator /(Quaternion quaternion, float scaleFactor)
		{
#if SIMD
			return new Quaternion(quaternion.v4 / new Vector4f(scaleFactor));
#else
			return Divide (quaternion, scaleFactor);
#endif
		}

		public static Quaternion operator *(Quaternion quaternion1, Quaternion quaternion2)
		{
			// TODO: SIMD optimization
			return new Quaternion(
				quaternion1.W * quaternion2.X + quaternion1.X * quaternion2.W + quaternion1.Y * quaternion2.Z - quaternion1.Z * quaternion2.Y,
				quaternion1.W * quaternion2.Y - quaternion1.X * quaternion2.Z + quaternion1.Y * quaternion2.W + quaternion1.Z * quaternion2.X,
				quaternion1.W * quaternion2.Z + quaternion1.X * quaternion2.Y - quaternion1.Y * quaternion2.X + quaternion1.Z * quaternion2.W,
				quaternion1.W * quaternion2.W - quaternion1.X * quaternion2.X - quaternion1.Y * quaternion2.Y - quaternion1.Z * quaternion2.Z);
		}

		public static Quaternion operator *(Quaternion quaternion, float scaleFactor)
		{
#if SIMD
			return new Quaternion(quaternion.v4 * scaleFactor);
#else
			return Multiply (quaternion, scaleFactor);
#endif
		}

		public static Quaternion operator -(Quaternion quaternion1, Quaternion quaternion2)
		{
#if SIMD
			return new Quaternion(quaternion1.v4 - quaternion2.v4);
#else
			return Subtract (quaternion1, quaternion2);
#endif
		}

		public static Quaternion operator -(Quaternion quaternion)
		{
#if SIMD
			return new Quaternion(quaternion.v4 ^ new Vector4f(-0.0f));
#else
			return Negate (quaternion);
#endif
		}

		#endregion

		#region Other maths

		public static Quaternion Concatenate(Quaternion value1, Quaternion value2)
		{
			Quaternion result;
			Concatenate(ref value1, ref value2, out result);
			return result;
		}

		public static void Concatenate(ref Quaternion value1, ref Quaternion value2, out Quaternion result)
		{
			Multiply(ref value1, ref value2, out result);
		}

		public void Conjugate()
		{
			Conjugate(ref this, out this);
		}

		public static Quaternion Conjugate(Quaternion value)
		{
			Conjugate(ref value, out value);
			return value;
		}

		public static void Conjugate(ref Quaternion value, out Quaternion result)
		{
			result = default(Quaternion);
			result.X = -value.X;
			result.Y = -value.Y;
			result.Z = -value.Z;
			result.W = value.W;
		}

		public static float Dot(Quaternion quaternion1, Quaternion quaternion2)
		{
			float result;
			Dot(ref quaternion1, ref quaternion2, out result);
			return result;
		}

		public static void Dot(ref Quaternion quaternion1, ref Quaternion quaternion2, out float result)
		{
			result = (quaternion1.X * quaternion2.X) + (quaternion1.Y * quaternion2.Y) +
				(quaternion1.Z * quaternion2.Z) + (quaternion1.W * quaternion2.W);
		}

		public static Quaternion Inverse(Quaternion quaternion)
		{
			Inverse(ref quaternion, out quaternion);
			return quaternion;
		}

		public static void Inverse(ref Quaternion quaternion, out Quaternion result)
		{
			// http://www.ncsa.illinois.edu/~kindr/emtc/quaternions/quaternion.c++
			Quaternion conj = new Quaternion(quaternion.X, quaternion.Y, quaternion.Z, quaternion.W);
			conj.Conjugate();

			result = conj * (1.0f / quaternion.LengthSquared());
		}

		public float Length()
		{
			return (float)System.Math.Sqrt(LengthSquared());
		}

		public float LengthSquared()
		{
			return (X * X) + (Y * Y) + (Z * Z) + (W * W);
		}

		public static Quaternion Lerp(Quaternion quaternion1, Quaternion quaternion2, float amount)
		{
			Quaternion result;
			Lerp(ref quaternion1, ref quaternion2, amount, out result);
			return result;
		}

		public static void Lerp(ref Quaternion quaternion1, ref Quaternion quaternion2, float amount, out Quaternion result)
		{
			Quaternion q1;
			Multiply(ref quaternion1, 1.0f - amount, out q1);

			Quaternion q2;
			Multiply(ref quaternion2, amount, out q2);

			Quaternion q1q2;
			Add(ref q1, ref q2, out q1q2);
			Normalize(ref q1q2, out result);
		}

		public void Normalize()
		{
			Normalize(ref this, out this);
		}

		public static Quaternion Normalize(Quaternion quaternion)
		{
			Normalize(ref quaternion, out quaternion);
			return quaternion;
		}

		public static void Normalize(ref Quaternion quaternion, out Quaternion result)
		{
			// TODO: SIMD optimization
			Multiply(ref quaternion, 1.0f / quaternion.Length(), out result);
		}

		public static Quaternion Slerp(Quaternion quaternion1, Quaternion quaternion2, float amount)
		{
			Quaternion result;
			Slerp(ref quaternion1, ref quaternion2, amount, out result);
			return result;
		}

		public static void Slerp(ref Quaternion quaternion1, ref Quaternion quaternion2, float amount, out Quaternion result)
		{
			float dot;
			Dot(ref quaternion1, ref quaternion2, out dot);

			Quaternion q3;

			if (dot < 0.0f)
			{
				dot = -dot;
				Negate(ref quaternion2, out q3);
			}
			else
			{
				q3 = quaternion2;
			}

			if (dot < 0.999999f)
			{
				float angle = (float)System.Math.Acos(dot);
				float sin1 = (float)System.Math.Sin(angle * (1.0f - amount));
				float sin2 = (float)System.Math.Sin(angle * amount);
				float sin3 = (float)System.Math.Sin(angle);

				Quaternion q1;
				Multiply(ref quaternion1, sin1, out q1);

				Quaternion q2;
				Multiply(ref q3, sin2, out q2);

				Quaternion q4;
				Add(ref q1, ref q2, out q4);

				Divide(ref q4, sin3, out result);
			}
			else
			{
				Lerp(ref quaternion1, ref q3, amount, out result);
			}
		}

		#endregion

		#region Equality

		public bool Equals(Quaternion other)
		{
			return other == this;
		}

		public override bool Equals(object obj)
		{
			return obj is Quaternion && ((Quaternion)obj) == this;
		}

		public override int GetHashCode()
		{
			return X.GetHashCode() ^ Y.GetHashCode() ^ Z.GetHashCode() ^ W.GetHashCode();
		}

		public static bool operator ==(Quaternion a, Quaternion b)
		{
			return a.X == b.X && a.Y == b.Y && a.Z == b.Z && a.W == b.W;
		}

		public static bool operator !=(Quaternion a, Quaternion b)
		{
			return a.X != b.X || a.Y != b.Y || a.Z != b.Z || a.W != b.W;
		}

		# endregion

		public override string ToString()
		{
			return string.Format("{{X:{0} Y:{1} Z:{2} W:{3}}}", X, Y, Z, W);
		}
	}
}