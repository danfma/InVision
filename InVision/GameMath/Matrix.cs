// 
// Matrix4.cs
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
using Mono.Simd;

namespace InVision.GameMath
{
	[Serializable]
	public struct Matrix : IEquatable<Matrix>
	{
#if SIMD
		internal Vector4f r1, r2, r3, r4;

		public float M11
		{
			get { return r1.X; }
			set { r1.X = value; }
		}

		public float M12
		{
			get { return r1.Y; }
			set { r1.Y = value; }
		}

		public float M13
		{
			get { return r1.Z; }
			set { r1.Z = value; }
		}

		public float M14
		{
			get { return r1.W; }
			set { r1.W = value; }
		}

		public float M21
		{
			get { return r2.X; }
			set { r2.X = value; }
		}

		public float M22
		{
			get { return r2.Y; }
			set { r2.Y = value; }
		}

		public float M23
		{
			get { return r2.Z; }
			set { r2.Z = value; }
		}

		public float M24
		{
			get { return r2.W; }
			set { r2.W = value; }
		}

		public float M31
		{
			get { return r3.X; }
			set { r3.X = value; }
		}

		public float M32
		{
			get { return r3.Y; }
			set { r3.Y = value; }
		}

		public float M33
		{
			get { return r3.Z; }
			set { r3.Z = value; }
		}

		public float M34
		{
			get { return r3.W; }
			set { r3.W = value; }
		}

		public float M41
		{
			get { return r4.X; }
			set { r4.X = value; }
		}

		public float M42
		{
			get { return r4.Y; }
			set { r4.Y = value; }
		}

		public float M43
		{
			get { return r4.Z; }
			set { r4.Z = value; }
		}

		public float M44
		{
			get { return r4.W; }
			set { r4.W = value; }
		}

		private Matrix(Vector4f r1, Vector4f r2, Vector4f r3, Vector4f r4)
		{
			this.r1 = r1;
			this.r2 = r2;
			this.r3 = r3;
			this.r4 = r4;
		}

		private Matrix(float v)
		{
			r1 = new Vector4f(v);
			r2 = new Vector4f(v);
			r3 = new Vector4f(v);
			r4 = new Vector4f(v);
		}
#else
		float
			m11, m12, m13, m14,
			m21, m22, m23, m24,
			m31, m32, m33, m34,
			m41, m42, m43, m44;
		
		public float M11 { get { return m11; } set { m11 = value; } }
		public float M12 { get { return m12; } set { m12 = value; } }
		public float M13 { get { return m13; } set { m13 = value; } }
		public float M14 { get { return m14; } set { m14 = value; } }
		public float M21 { get { return m21; } set { m21 = value; } }
		public float M22 { get { return m22; } set { m22 = value; } }
		public float M23 { get { return m23; } set { m23 = value; } }
		public float M24 { get { return m24; } set { m24 = value; } }
		public float M31 { get { return m31; } set { m31 = value; } }
		public float M32 { get { return m32; } set { m32 = value; } }
		public float M33 { get { return m33; } set { m33 = value; } }
		public float M34 { get { return m34; } set { m34 = value; } }
		public float M41 { get { return m41; } set { m41 = value; } }
		public float M42 { get { return m42; } set { m42 = value; } }
		public float M43 { get { return m43; } set { m43 = value; } }
		public float M44 { get { return m44; } set { m44 = value; } }
		
		Matrix (float v)
		{
			m11 = v; m12 = v; m13 = v; m14 = v;
			m21 = v; m22 = v; m23 = v; m24 = v;
			m31 = v; m32 = v; m33 = v; m34 = v;
			m41 = v; m42 = v; m43 = v; m44 = v;
		}
#endif

		public Matrix(
			float m11, float m12, float m13, float m14,
			float m21, float m22, float m23, float m24,
			float m31, float m32, float m33, float m34,
			float m41, float m42, float m43, float m44)
		{
#if SIMD
			r1 = new Vector4f(m11, m12, m13, m14);
			r2 = new Vector4f(m21, m22, m23, m24);
			r3 = new Vector4f(m31, m32, m33, m34);
			r4 = new Vector4f(m41, m42, m43, m44);
#else
			this.m11 = m11; this.m12 = m12; this.m13 = m13; this.m14 = m14;
			this.m21 = m21; this.m22 = m22; this.m23 = m23; this.m24 = m24;
			this.m31 = m31; this.m32 = m32; this.m33 = m33; this.m34 = m34;
			this.m41 = m41; this.m42 = m42; this.m43 = m43; this.m44 = m44;
#endif
		}

		/// <summary>
		/// Gets or sets the <see cref="System.Single"/> with the specified row and column.
		/// </summary>
		/// <value></value>
		public float this[int row, int col]
		{
			get
			{
				unsafe
				{
					int rowSpace = sizeof(Vector4f) * row;

					fixed (void* pself = &this)
					{
						var pData = (float*)pself;
						pData += rowSpace + col * sizeof(float);

						return *pData;
					}
				}
			}
			set
			{
				unsafe
				{
					int rowSpace = sizeof(Vector4f) * row;

					fixed (void* pself = &this)
					{
						var pData = (float*)pself;
						pData += rowSpace + col * sizeof(float);

						*pData = value;
					}
				}
			}
		}

		#region Vector Properties

		//See http://stevehazen.wordpress.com/2010/02/15/
		//matrix-basics-how-to-step-away-from-storing-an-orientation-as-3-angles/
		public Vector3 Right
		{
			get { return new Vector3(M11, M12, M13); }
			set
			{
				M11 = value.X;
				M12 = value.Y;
				M13 = value.Z;
			}
		}

		public Vector3 Up
		{
			get { return new Vector3(M21, M22, M23); }
			set
			{
				M21 = value.X;
				M22 = value.Y;
				M23 = value.Z;
			}
		}

		public Vector3 Backward
		{
			get { return new Vector3(M31, M32, M33); }
			set
			{
				M31 = value.X;
				M32 = value.Y;
				M33 = value.Z;
			}
		}

		public Vector3 Left
		{
			get
			{
#if SIMD
				return new Vector3(r1 ^ new Vector4f(-0.0f));
#else
				return new Vector3 (-m11, -m12, -m13);
#endif
			}
			set
			{
#if SIMD
				Vector4f minus = value.v4 ^ new Vector4f(-0.0f);
				minus.W = M14;
				r1 = minus;
#else
				m11 = -value.X;
				m12 = -value.Y;
				m13 = -value.Z;
#endif
			}
		}

		public Vector3 Down
		{
			get
			{
#if SIMD
				return new Vector3(r2 ^ new Vector4f(-0.0f));
#else
				return new Vector3 (-m21, -m22, -m23);
#endif
			}
			set
			{
#if SIMD
				Vector4f minus = value.v4 ^ new Vector4f(-0.0f);
				minus.W = M24;
				r2 = minus;
#else
				m21 = -value.X;
				m22 = -value.Y;
				m23 = -value.Z;
#endif
			}
		}

		public Vector3 Forward
		{
			get
			{
#if SIMD
				return new Vector3(r3 ^ new Vector4f(-0.0f));
#else
				return new Vector3 (-m31, -m32, -m33);
#endif
			}
			set
			{
#if SIMD
				Vector4f minus = value.v4 ^ new Vector4f(-0.0f);
				minus.W = M34;
				r3 = minus;
#else
				m31 = -value.X;
				m32 = -value.Y;
				m33 = -value.Z;
#endif
			}
		}

		public Vector3 Translation
		{
			get { return new Vector3(M41, M42, M43); }
			set
			{
				M41 = value.X;
				M42 = value.Y;
				M43 = value.Z;
			}
		}

		#endregion

		#region Static properties

		public static Matrix Identity
		{
			get
			{
				return new Matrix(
					1f, 0f, 0f, 0f,
					0f, 1f, 0f, 0f,
					0f, 0f, 1f, 0f,
					0f, 0f, 0f, 1f);
			}
		}

		#endregion

		#region Creation

		public static Matrix CreateBillboard(Vector3 objectPosition, Vector3 cameraPosition, Vector3 cameraUpVector,
											 Vector3? cameraForwardVector)
		{
			Matrix result;
			CreateBillboard(ref objectPosition, ref cameraPosition, ref cameraUpVector, cameraForwardVector, out result);
			return result;
		}

		public static void CreateBillboard(ref Vector3 objectPosition, ref Vector3 cameraPosition,
										   ref Vector3 cameraUpVector, Vector3? cameraForwardVector, out Matrix result)
		{
			Vector3 vector = default(Vector3);
			vector.X = objectPosition.X - cameraPosition.X;
			vector.Y = objectPosition.Y - cameraPosition.Y;
			vector.Z = objectPosition.Z - cameraPosition.Z;
			float num = vector.LengthSquared();
			if (num < 0.0001f)
			{
				vector = (cameraForwardVector.HasValue ? (-cameraForwardVector.Value) : Vector3.Forward);
			}
			else
			{
				Vector3.Multiply(ref vector, 1f / (float)Math.Sqrt(num), out vector);
			}
			Vector3 vector2 = default(Vector3);
			Vector3.Cross(ref cameraUpVector, ref vector, out vector2);
			vector2.Normalize();

			Vector3 vector3 = default(Vector3);
			Vector3.Cross(ref vector, ref vector2, out vector3);

			result = default(Matrix);
			result.M11 = vector2.X;
			result.M12 = vector2.Y;
			result.M13 = vector2.Z;
			result.M14 = 0f;
			result.M21 = vector3.X;
			result.M22 = vector3.Y;
			result.M23 = vector3.Z;
			result.M24 = 0f;
			result.M31 = vector.X;
			result.M32 = vector.Y;
			result.M33 = vector.Z;
			result.M34 = 0f;
			result.M41 = objectPosition.X;
			result.M42 = objectPosition.Y;
			result.M43 = objectPosition.Z;
			result.M44 = 1f;
		}

		public static Matrix CreateConstrainedBillboard(Vector3 objectPosition, Vector3 cameraPosition,
														Vector3 rotateAxis, Vector3? cameraForwardVector,
														Vector3? objectForwardVector)
		{
			Matrix result;
			CreateConstrainedBillboard(ref objectPosition, ref cameraPosition, ref rotateAxis, cameraForwardVector,
									   objectForwardVector, out result);
			return result;
		}

		public static void CreateConstrainedBillboard(ref Vector3 objectPosition, ref Vector3 cameraPosition,
													  ref Vector3 rotateAxis, Vector3? cameraForwardVector,
													  Vector3? objectForwardVector, out Matrix result)
		{
			Vector3 vector = default(Vector3);
			vector.X = objectPosition.X - cameraPosition.X;
			vector.Y = objectPosition.Y - cameraPosition.Y;
			vector.Z = objectPosition.Z - cameraPosition.Z;

			float num = vector.LengthSquared();

			if (num < 0.0001f)
			{
				vector = (cameraForwardVector.HasValue ? (-cameraForwardVector.Value) : Vector3.Forward);
			}
			else
			{
				Vector3.Multiply(ref vector, 1f / (float)Math.Sqrt(num), out vector);
			}

			Vector3 vector2 = rotateAxis;
			float value;
			Vector3.Dot(ref rotateAxis, ref vector, out value);
			Vector3 vector3 = default(Vector3);
			Vector3 vector4 = default(Vector3);

			if (Math.Abs(value) > 0.998254657f)
			{
				if (objectForwardVector.HasValue)
				{
					vector3 = objectForwardVector.Value;
					Vector3.Dot(ref rotateAxis, ref vector3, out value);
					if (Math.Abs(value) > 0.998254657f)
					{
						value = rotateAxis.X * Vector3.Forward.X + rotateAxis.Y * Vector3.Forward.Y + rotateAxis.Z * Vector3.Forward.Z;
						vector3 = ((Math.Abs(value) > 0.998254657f) ? Vector3.Right : Vector3.Forward);
					}
				}
				else
				{
					value = rotateAxis.X * Vector3.Forward.X + rotateAxis.Y * Vector3.Forward.Y + rotateAxis.Z * Vector3.Forward.Z;
					vector3 = ((Math.Abs(value) > 0.998254657f) ? Vector3.Right : Vector3.Forward);
				}
				Vector3.Cross(ref rotateAxis, ref vector3, out vector4);
				vector4.Normalize();
				Vector3.Cross(ref vector4, ref rotateAxis, out vector3);
				vector3.Normalize();
			}
			else
			{
				Vector3.Cross(ref rotateAxis, ref vector, out vector4);
				vector4.Normalize();
				Vector3.Cross(ref vector4, ref vector2, out vector3);
				vector3.Normalize();
			}

			result = new Matrix(
				vector4.X, vector4.Y, vector4.Z, 0f,
				vector2.X, vector2.Y, vector2.Z, 0f,
				vector3.X, vector3.Y, vector3.Z, 0f,
				objectPosition.X, objectPosition.Y, objectPosition.Z, 1f);
		}

		public static Matrix CreateFromAxisAngle(Vector3 axis, float angle)
		{
			Matrix result;
			CreateFromAxisAngle(ref axis, angle, out result);
			return result;
		}

		public static void CreateFromAxisAngle(ref Vector3 axis, float angle, out Matrix result)
		{
			float x = axis.X;
			float y = axis.Y;
			float z = axis.Z;
			var num = (float)Math.Sin(angle);
			var num2 = (float)Math.Cos(angle);
			float num3 = x * x;
			float num4 = y * y;
			float num5 = z * z;
			float num6 = x * y;
			float num7 = x * z;
			float num8 = y * z;

			result = default(Matrix);
			result.M11 = num3 + num2 * (1f - num3);
			result.M12 = num6 - num2 * num6 + num * z;
			result.M13 = num7 - num2 * num7 - num * y;
			result.M14 = 0f;

			result.M21 = num6 - num2 * num6 - num * z;
			result.M22 = num4 + num2 * (1f - num4);
			result.M23 = num8 - num2 * num8 + num * x;
			result.M24 = 0f;

			result.M31 = num7 - num2 * num7 + num * y;
			result.M32 = num8 - num2 * num8 - num * x;
			result.M33 = num5 + num2 * (1f - num5);
			result.M34 = 0f;

			result.M41 = 0f;
			result.M42 = 0f;
			result.M43 = 0f;
			result.M44 = 1f;
		}

		public static Matrix CreateFromQuaternion(Quaternion quaternion)
		{
			Matrix result;
			CreateFromQuaternion(ref quaternion, out result);
			return result;
		}

		public static void CreateFromQuaternion(ref Quaternion quaternion, out Matrix result)
		{
			result = Identity;

			result.M11 = 1 - 2 * (quaternion.Y * quaternion.Y + quaternion.Z * quaternion.Z);
			result.M12 = 2 * (quaternion.X * quaternion.Y + quaternion.W * quaternion.Z);
			result.M13 = 2 * (quaternion.X * quaternion.Z - quaternion.W * quaternion.Y);
			result.M21 = 2 * (quaternion.X * quaternion.Y - quaternion.W * quaternion.Z);
			result.M22 = 1 - 2 * (quaternion.X * quaternion.X + quaternion.Z * quaternion.Z);
			result.M23 = 2 * (quaternion.Y * quaternion.Z + quaternion.W * quaternion.X);
			result.M31 = 2 * (quaternion.X * quaternion.Z + quaternion.W * quaternion.Y);
			result.M32 = 2 * (quaternion.Y * quaternion.Z - quaternion.W * quaternion.X);
			result.M33 = 1 - 2 * (quaternion.X * quaternion.X + quaternion.Y * quaternion.Y);
		}

		public static Matrix CreateFromYawPitchRoll(float yaw, float pitch, float roll)
		{
			Matrix result;
			CreateFromYawPitchRoll(yaw, pitch, roll, out result);
			return result;
		}

		public static void CreateFromYawPitchRoll(float yaw, float pitch, float roll, out Matrix result)
		{
			Quaternion quat;
			Quaternion.CreateFromYawPitchRoll(yaw, pitch, roll, out quat);
			CreateFromQuaternion(ref quat, out result);
		}

		public static Matrix CreateLookAt(Vector3 cameraPosition, Vector3 cameraTarget, Vector3 cameraUpVector)
		{
			Matrix result;
			CreateLookAt(ref cameraPosition, ref cameraTarget, ref cameraUpVector, out result);
			return result;
		}

		public static void CreateLookAt(ref Vector3 cameraPosition, ref Vector3 cameraTarget, ref Vector3 cameraUpVector,
										out Matrix result
			)
		{
			// http://msdn.microsoft.com/en-us/library/bb205343%28VS.85%29.aspx

			Vector3 pos;
			Vector3.Subtract(ref cameraPosition, ref cameraTarget, out pos);
			Vector3 vz;
			Vector3.Normalize(ref pos, out vz);

			Vector3 cross;
			Vector3.Cross(ref cameraUpVector, ref vz, out cross);
			Vector3 vx;
			Vector3.Normalize(ref cross, out vx);

			Vector3 vy;
			Vector3.Cross(ref vz, ref vx, out vy);

			float dvx, dvy, dvz;
			Vector3.Dot(ref vx, ref cameraPosition, out dvx);
			Vector3.Dot(ref vy, ref cameraPosition, out dvy);
			Vector3.Dot(ref vz, ref cameraPosition, out dvz);

			result = Identity;
			result.M11 = vx.X;
			result.M12 = vy.X;
			result.M13 = vz.X;
			result.M21 = vx.Y;
			result.M22 = vy.Y;
			result.M23 = vz.Y;
			result.M31 = vx.Z;
			result.M32 = vy.Z;
			result.M33 = vz.Z;
			result.M41 = -dvx;
			result.M42 = -dvy;
			result.M43 = -dvz;
		}

		public static Matrix CreateOrthographic(float width, float height, float zNearPlane, float zFarPlane)
		{
			Matrix result;
			CreateOrthographic(width, height, zNearPlane, zFarPlane, out result);
			return result;
		}

		public static void CreateOrthographic(float width, float height, float zNearPlane, float zFarPlane,
											  out Matrix result)
		{
			result = default(Matrix);
			result.M11 = 2f / width;
			result.M12 = (result.M13 = (result.M14 = 0f));
			result.M22 = 2f / height;
			result.M21 = (result.M23 = (result.M24 = 0f));
			result.M33 = 1f / (zNearPlane - zFarPlane);
			result.M31 = (result.M32 = (result.M34 = 0f));
			result.M41 = (result.M42 = 0f);
			result.M43 = zNearPlane / (zNearPlane - zFarPlane);
			result.M44 = 1f;
		}

		public static Matrix CreateOrthographicOffCenter(float left, float right, float bottom, float top,
														 float zNearPlane, float zFarPlane)
		{
			Matrix result;
			CreateOrthographicOffCenter(left, right, bottom, top, zNearPlane, zFarPlane, out result);
			return result;
		}

		public static void CreateOrthographicOffCenter(float left, float right, float bottom, float top,
													   float zNearPlane, float zFarPlane, out Matrix result)
		{
			result = default(Matrix);
			result.M11 = 2f / (right - left);
			result.M12 = (result.M13 = (result.M14 = 0f));
			result.M22 = 2f / (top - bottom);
			result.M21 = (result.M23 = (result.M24 = 0f));
			result.M33 = 1f / (zNearPlane - zFarPlane);
			result.M31 = (result.M32 = (result.M34 = 0f));
			result.M41 = (left + right) / (left - right);
			result.M42 = (top + bottom) / (bottom - top);
			result.M43 = zNearPlane / (zNearPlane - zFarPlane);
			result.M44 = 1f;
		}

		public static Matrix CreatePerspective(float width, float height, float nearPlaneDistance,
											   float farPlaneDistance)
		{
			Matrix result;
			CreatePerspective(width, height, nearPlaneDistance, farPlaneDistance, out result);
			return result;
		}

		public static void CreatePerspective(float width, float height, float nearPlaneDistance,
											 float farPlaneDistance, out Matrix result)
		{
			if (nearPlaneDistance <= 0f)
				throw new ArgumentOutOfRangeException("nearPlaneDistance");

			if (farPlaneDistance <= 0f)
				throw new ArgumentOutOfRangeException("farPlaneDistance");

			if (nearPlaneDistance >= farPlaneDistance)
				throw new ArgumentOutOfRangeException("nearPlaneDistance");

			result = default(Matrix);
			result.M11 = 2f * nearPlaneDistance / width;
			result.M12 = (result.M13 = (result.M14 = 0f));
			result.M22 = 2f * nearPlaneDistance / height;
			result.M21 = (result.M23 = (result.M24 = 0f));
			result.M33 = farPlaneDistance / (nearPlaneDistance - farPlaneDistance);
			result.M31 = (result.M32 = 0f);
			result.M34 = -1f;
			result.M41 = (result.M42 = (result.M44 = 0f));
			result.M43 = nearPlaneDistance * farPlaneDistance / (nearPlaneDistance - farPlaneDistance);
		}

		public static Matrix CreatePerspectiveFieldOfView(float fieldOfView, float aspectRatio,
														  float nearPlaneDistance, float farPlaneDistance)
		{
			Matrix result;
			CreatePerspectiveFieldOfView(fieldOfView, aspectRatio, nearPlaneDistance, farPlaneDistance, out result);
			return result;
		}

		public static void CreatePerspectiveFieldOfView(float fieldOfView, float aspectRatio, float nearPlaneDistance,
														float farPlaneDistance, out Matrix result)
		{
			if (fieldOfView <= 0f || fieldOfView >= 3.14159274f)
				throw new ArgumentOutOfRangeException("fieldOfView");

			if (nearPlaneDistance <= 0f)
				throw new ArgumentOutOfRangeException("nearPlaneDistance");

			if (farPlaneDistance <= 0f)
				throw new ArgumentOutOfRangeException("farPlaneDistance");

			if (nearPlaneDistance >= farPlaneDistance)
				throw new ArgumentOutOfRangeException("nearPlaneDistance");

			float num = 1f / (float)Math.Tan((fieldOfView * 0.5f));
			float m = num / aspectRatio;

			result = default(Matrix);
			result.M11 = m;
			result.M12 = (result.M13 = (result.M14 = 0f));
			result.M22 = num;
			result.M21 = (result.M23 = (result.M24 = 0f));
			result.M31 = (result.M32 = 0f);
			result.M33 = farPlaneDistance / (nearPlaneDistance - farPlaneDistance);
			result.M34 = -1f;
			result.M41 = (result.M42 = (result.M44 = 0f));
			result.M43 = nearPlaneDistance * farPlaneDistance / (nearPlaneDistance - farPlaneDistance);
		}

		public static Matrix CreatePerspectiveOffCenter(float left, float right, float bottom, float top,
														float nearPlaneDistance, float farPlaneDistance)
		{
			Matrix result;
			CreatePerspectiveOffCenter(left, right, bottom, top, nearPlaneDistance, farPlaneDistance, out result);
			return result;
		}

		public static void CreatePerspectiveOffCenter(float left, float right, float bottom, float top,
													  float nearPlaneDistance, float farPlaneDistance, out Matrix result)
		{
			if (nearPlaneDistance <= 0f)
				throw new ArgumentOutOfRangeException("nearPlaneDistance");

			if (farPlaneDistance <= 0f)
				throw new ArgumentOutOfRangeException("farPlaneDistance");

			if (nearPlaneDistance >= farPlaneDistance)
				throw new ArgumentOutOfRangeException("nearPlaneDistance");

			result = default(Matrix);
			result.M11 = 2f * nearPlaneDistance / (right - left);
			result.M12 = (result.M13 = (result.M14 = 0f));
			result.M22 = 2f * nearPlaneDistance / (top - bottom);
			result.M21 = (result.M23 = (result.M24 = 0f));
			result.M31 = (left + right) / (right - left);
			result.M32 = (top + bottom) / (top - bottom);
			result.M33 = farPlaneDistance / (nearPlaneDistance - farPlaneDistance);
			result.M34 = -1f;
			result.M43 = nearPlaneDistance * farPlaneDistance / (nearPlaneDistance - farPlaneDistance);
			result.M41 = (result.M42 = (result.M44 = 0f));
		}

		public static Matrix CreateReflection(Plane value)
		{
			Matrix result;
			CreateReflection(ref value, out result);
			return result;
		}

		public static void CreateReflection(ref Plane value, out Matrix result)
		{
			Plane plane;
			Plane.Normalize(ref value, out plane);
			value.Normalize();

			float x = plane.Normal.X;
			float y = plane.Normal.Y;
			float z = plane.Normal.Z;
			float num = -2f * x;
			float num2 = -2f * y;
			float num3 = -2f * z;

			result = default(Matrix);
			result.M11 = num * x + 1f;
			result.M12 = num2 * x;
			result.M13 = num3 * x;
			result.M14 = 0f;
			result.M21 = num * y;
			result.M22 = num2 * y + 1f;
			result.M23 = num3 * y;
			result.M24 = 0f;
			result.M31 = num * z;
			result.M32 = num2 * z;
			result.M33 = num3 * z + 1f;
			result.M34 = 0f;
			result.M41 = num * plane.D;
			result.M42 = num2 * plane.D;
			result.M43 = num3 * plane.D;
			result.M44 = 1f;
		}

		public static Matrix CreateRotationX(float radians)
		{
			Matrix result;
			CreateRotationX(radians, out result);
			return result;
		}

		public static void CreateRotationX(float radians, out Matrix result)
		{
			var cos = (float)Math.Cos(radians);
			var sin = (float)Math.Sin(radians);

			result = new Matrix();
			result.M11 = 1.0f;
			result.M22 = cos;
			result.M23 = sin;
			result.M32 = -sin;
			result.M33 = cos;
			result.M44 = 1.0f;
		}

		public static Matrix CreateRotationY(float radians)
		{
			Matrix result;
			CreateRotationY(radians, out result);
			return result;
		}

		public static void CreateRotationY(float radians, out Matrix result)
		{
			var cos = (float)Math.Cos(radians);
			var sin = (float)Math.Sin(radians);

			result = new Matrix();
			result.M11 = cos;
			result.M13 = -sin;
			result.M22 = 1.0f;
			result.M31 = sin;
			result.M33 = cos;
			result.M44 = 1.0f;
		}

		public static Matrix CreateRotationZ(float radians)
		{
			Matrix result;
			CreateRotationZ(radians, out result);
			return result;
		}

		public static void CreateRotationZ(float radians, out Matrix result)
		{
			var cos = (float)Math.Cos(radians);
			var sin = (float)Math.Sin(radians);

			result = new Matrix();
			result.M11 = cos;
			result.M12 = sin;
			result.M21 = -sin;
			result.M22 = cos;
			result.M33 = 1.0f;
			result.M44 = 1.0f;
		}

		public static Matrix CreateScale(float scale)
		{
			return CreateScale(scale, scale, scale);
		}

		public static void CreateScale(float scale, out Matrix result)
		{
			CreateScale(scale, scale, scale, out result);
		}

		public static Matrix CreateScale(float xScale, float yScale, float zScale)
		{
			Matrix result;
			CreateScale(xScale, yScale, zScale, out result);
			return result;
		}

		public static void CreateScale(float xScale, float yScale, float zScale, out Matrix result)
		{
			var scale = new Vector3(xScale, yScale, zScale);
			CreateScale(ref scale, out result);
		}

		public static Matrix CreateScale(Vector3 scales)
		{
			Matrix result;
			CreateScale(ref scales, out result);
			return result;
		}

		public static void CreateScale(ref Vector3 scales, out Matrix result)
		{
			result = new Matrix();
			result.M11 = scales.X;
			result.M22 = scales.Y;
			result.M33 = scales.Z;
			result.M44 = 1.0f;
		}

		public static Matrix CreateShadow(Vector3 lightDirection, Plane plane)
		{
			Matrix result;
			CreateShadow(ref lightDirection, ref plane, out result);
			return result;
		}

		public static void CreateShadow(ref Vector3 lightDirection, ref Plane plane, out Matrix result)
		{
			Plane plane2;
			Plane.Normalize(ref plane, out plane2);
			float num = plane2.Normal.X * lightDirection.X + plane2.Normal.Y * lightDirection.Y + plane2.Normal.Z * lightDirection.Z;
			float num2 = -plane2.Normal.X;
			float num3 = -plane2.Normal.Y;
			float num4 = -plane2.Normal.Z;
			float num5 = -plane2.D;

			result = default(Matrix);
			result.M11 = num2 * lightDirection.X + num;
			result.M21 = num3 * lightDirection.X;
			result.M31 = num4 * lightDirection.X;
			result.M41 = num5 * lightDirection.X;
			result.M12 = num2 * lightDirection.Y;
			result.M22 = num3 * lightDirection.Y + num;
			result.M32 = num4 * lightDirection.Y;
			result.M42 = num5 * lightDirection.Y;
			result.M13 = num2 * lightDirection.Z;
			result.M23 = num3 * lightDirection.Z;
			result.M33 = num4 * lightDirection.Z + num;
			result.M43 = num5 * lightDirection.Z;
			result.M14 = 0f;
			result.M24 = 0f;
			result.M34 = 0f;
			result.M44 = num;
		}

		public static Matrix CreateTranslation(float xPosition, float yPosition, float zPosition)
		{
			Matrix result;
			CreateTranslation(xPosition, yPosition, zPosition, out result);
			return result;
		}

		public static void CreateTranslation(float xPosition, float yPosition, float zPosition, out Matrix result)
		{
			var position = new Vector3(xPosition, yPosition, zPosition);
			CreateTranslation(ref position, out result);
		}

		public static Matrix CreateTranslation(Vector3 position)
		{
			Matrix result;
			CreateTranslation(ref position, out result);
			return result;
		}

		public static void CreateTranslation(ref Vector3 position, out Matrix result)
		{
			result = new Matrix();
			result.M11 = 1.0f;
			result.M22 = 1.0f;
			result.M33 = 1.0f;
			result.M41 = position.X;
			result.M42 = position.Y;
			result.M43 = position.Z;
			result.M44 = 1.0f;
		}

		public static Matrix CreateWorld(Vector3 position, Vector3 forward, Vector3 up)
		{
			Matrix result;
			CreateWorld(ref position, ref forward, ref up, out result);
			return result;
		}

		public static void CreateWorld(ref Vector3 position, ref Vector3 forward, ref Vector3 up, out Matrix result)
		{
			Vector3 x, y, z;

			Vector3.Cross(ref forward, ref up, out x);
			Vector3.Cross(ref x, ref forward, out y);
			Vector3.Normalize(ref forward, out z);

			x.Normalize();
			y.Normalize();

			result = new Matrix();
			result.Right = x;
			result.Up = y;
			result.Forward = z;
			result.Translation = position;
			result.M44 = 1.0f;
		}

		#endregion

		#region Arithmetic

		public static Matrix Add(Matrix matrix1, Matrix matrix2)
		{
			Add(ref matrix1, ref matrix2, out matrix1);
			return matrix1;
		}

		public static void Add(ref Matrix matrix1, ref Matrix matrix2, out Matrix result)
		{
#if SIMD
			result.r1 = matrix1.r1 + matrix2.r1;
			result.r2 = matrix1.r2 + matrix2.r2;
			result.r3 = matrix1.r3 + matrix2.r3;
			result.r4 = matrix1.r4 + matrix2.r4;
#else
			result.m11 = matrix1.m11 + matrix2.m11;
			result.m12 = matrix1.m12 + matrix2.m12;
			result.m13 = matrix1.m13 + matrix2.m13;
			result.m14 = matrix1.m14 + matrix2.m14;
			
			result.m21 = matrix1.m21 + matrix2.m21;
			result.m22 = matrix1.m22 + matrix2.m22;
			result.m23 = matrix1.m23 + matrix2.m23;
			result.m24 = matrix1.m24 + matrix2.m24;
			
			result.m31 = matrix1.m31 + matrix2.m31;
			result.m32 = matrix1.m32 + matrix2.m32;
			result.m33 = matrix1.m33 + matrix2.m33;
			result.m34 = matrix1.m34 + matrix2.m34;
			
			result.m41 = matrix1.m41 + matrix2.m41;
			result.m42 = matrix1.m42 + matrix2.m42;
			result.m43 = matrix1.m43 + matrix2.m43;
			result.m44 = matrix1.m44 + matrix2.m44;
#endif
		}

		public static Matrix Multiply(Matrix matrix1, Matrix matrix2)
		{
			Matrix result;
			Multiply (ref matrix1, ref matrix2, out result);
			return result;
		}

		public static void Multiply(ref Matrix matrix1, ref Matrix matrix2, out Matrix result)
		{
			result = default(Matrix);
			result.M11 = matrix1.M11 * matrix2.M11 + matrix1.M12 * matrix2.M21 + matrix1.M13 * matrix2.M31 + matrix1.M14 * matrix2.M41;
			result.M12 = matrix1.M11 * matrix2.M12 + matrix1.M12 * matrix2.M22 + matrix1.M13 * matrix2.M32 + matrix1.M14 * matrix2.M42;
			result.M13 = matrix1.M11 * matrix2.M13 + matrix1.M12 * matrix2.M23 + matrix1.M13 * matrix2.M33 + matrix1.M14 * matrix2.M43;
			result.M14 = matrix1.M11 * matrix2.M14 + matrix1.M12 * matrix2.M24 + matrix1.M13 * matrix2.M34 + matrix1.M14 * matrix2.M44;

			result.M21 = matrix1.M21 * matrix2.M11 + matrix1.M22 * matrix2.M21 + matrix1.M23 * matrix2.M31 + matrix1.M24 * matrix2.M41;
			result.M22 = matrix1.M21 * matrix2.M12 + matrix1.M22 * matrix2.M22 + matrix1.M23 * matrix2.M32 + matrix1.M24 * matrix2.M42;
			result.M23 = matrix1.M21 * matrix2.M13 + matrix1.M22 * matrix2.M23 + matrix1.M23 * matrix2.M33 + matrix1.M24 * matrix2.M43;
			result.M24 = matrix1.M21 * matrix2.M14 + matrix1.M22 * matrix2.M24 + matrix1.M23 * matrix2.M34 + matrix1.M24 * matrix2.M44;

			result.M31 = matrix1.M31 * matrix2.M11 + matrix1.M32 * matrix2.M21 + matrix1.M33 * matrix2.M31 + matrix1.M34 * matrix2.M41;
			result.M32 = matrix1.M31 * matrix2.M12 + matrix1.M32 * matrix2.M22 + matrix1.M33 * matrix2.M32 + matrix1.M34 * matrix2.M42;
			result.M33 = matrix1.M31 * matrix2.M13 + matrix1.M32 * matrix2.M23 + matrix1.M33 * matrix2.M33 + matrix1.M34 * matrix2.M43;
			result.M34 = matrix1.M31 * matrix2.M14 + matrix1.M32 * matrix2.M24 + matrix1.M33 * matrix2.M34 + matrix1.M34 * matrix2.M44;

			result.M41 = matrix1.M41 * matrix2.M11 + matrix1.M42 * matrix2.M21 + matrix1.M43 * matrix2.M31 + matrix1.M44 * matrix2.M41;
			result.M42 = matrix1.M41 * matrix2.M12 + matrix1.M42 * matrix2.M22 + matrix1.M43 * matrix2.M32 + matrix1.M44 * matrix2.M42;
			result.M43 = matrix1.M41 * matrix2.M13 + matrix1.M42 * matrix2.M23 + matrix1.M43 * matrix2.M33 + matrix1.M44 * matrix2.M43;
			result.M44 = matrix1.M41 * matrix2.M14 + matrix1.M42 * matrix2.M24 + matrix1.M43 * matrix2.M34 + matrix1.M44 * matrix2.M44;
		}

		public static Matrix Multiply(Matrix matrix1, float scaleFactor)
		{
			Multiply(ref matrix1, scaleFactor, out matrix1);
			return matrix1;
		}

		public static void Multiply(ref Matrix matrix1, float scaleFactor, out Matrix result)
		{
#if SIMD
			var scale = new Vector4f(scaleFactor);
			result.r1 = matrix1.r1 * scale;
			result.r2 = matrix1.r2 * scale;
			result.r3 = matrix1.r3 * scale;
			result.r4 = matrix1.r4 * scale;
#else
			result.m11 = matrix1.m11 * scaleFactor;
			result.m12 = matrix1.m12 * scaleFactor;
			result.m13 = matrix1.m13 * scaleFactor;
			result.m14 = matrix1.m14 * scaleFactor;
			
			result.m21 = matrix1.m21 * scaleFactor;
			result.m22 = matrix1.m22 * scaleFactor;
			result.m23 = matrix1.m23 * scaleFactor;
			result.m24 = matrix1.m24 * scaleFactor;
			
			result.m31 = matrix1.m31 * scaleFactor;
			result.m32 = matrix1.m32 * scaleFactor;
			result.m33 = matrix1.m33 * scaleFactor;
			result.m34 = matrix1.m34 * scaleFactor;
			
			result.m41 = matrix1.m41 * scaleFactor;
			result.m42 = matrix1.m42 * scaleFactor;
			result.m43 = matrix1.m43 * scaleFactor;
			result.m44 = matrix1.m44 * scaleFactor;
#endif
		}

		public static Matrix Negate(Matrix matrix)
		{
			Negate(ref matrix, out matrix);
			return matrix;
		}

		public static void Negate(ref Matrix matrix, out Matrix result)
		{
#if SIMD
			var sign = new Vector4f(-0.0f);
			result.r1 = matrix.r1 ^ sign;
			result.r2 = matrix.r2 ^ sign;
			result.r3 = matrix.r3 ^ sign;
			result.r4 = matrix.r4 ^ sign;
#else
			result.m11 = -matrix.m11;
			result.m12 = -matrix.m12;
			result.m13 = -matrix.m13;
			result.m14 = -matrix.m14;
			
			result.m21 = -matrix.m21;
			result.m22 = -matrix.m22;
			result.m23 = -matrix.m23;
			result.m24 = -matrix.m24;
			
			result.m31 = -matrix.m31;
			result.m32 = -matrix.m32;
			result.m33 = -matrix.m33;
			result.m34 = -matrix.m34;
			
			result.m41 = -matrix.m41;
			result.m42 = -matrix.m42;
			result.m43 = -matrix.m43;
			result.m44 = -matrix.m44;
#endif
		}

		public static Matrix Subtract(Matrix matrix1, Matrix matrix2)
		{
			Subtract(ref matrix1, ref matrix2, out matrix1);
			return matrix1;
		}

		public static void Subtract(ref Matrix matrix1, ref Matrix matrix2, out Matrix result)
		{
#if SIMD
			result.r1 = matrix1.r1 - matrix2.r1;
			result.r2 = matrix1.r2 - matrix2.r2;
			result.r3 = matrix1.r3 - matrix2.r3;
			result.r4 = matrix1.r4 - matrix2.r4;
#else
			result.m11 = matrix1.m11 - matrix2.m11;
			result.m12 = matrix1.m12 - matrix2.m12;
			result.m13 = matrix1.m13 - matrix2.m13;
			result.m14 = matrix1.m14 - matrix2.m14;
			
			result.m21 = matrix1.m21 - matrix2.m21;
			result.m22 = matrix1.m22 - matrix2.m22;
			result.m23 = matrix1.m23 - matrix2.m23;
			result.m24 = matrix1.m24 - matrix2.m24;
			
			result.m31 = matrix1.m31 - matrix2.m31;
			result.m32 = matrix1.m32 - matrix2.m32;
			result.m33 = matrix1.m33 - matrix2.m33;
			result.m34 = matrix1.m34 - matrix2.m34;
			
			result.m41 = matrix1.m41 - matrix2.m41;
			result.m42 = matrix1.m42 - matrix2.m42;
			result.m43 = matrix1.m43 - matrix2.m43;
			result.m44 = matrix1.m44 - matrix2.m44;
#endif
		}

		public static Matrix Divide(Matrix matrix1, Matrix matrix2)
		{
			Divide(ref matrix1, ref matrix2, out matrix1);
			return matrix1;
		}

		public static void Divide(ref Matrix matrix1, ref Matrix matrix2, out Matrix result)
		{
#if SIMD
			result.r1 = matrix1.r1 * matrix2.r1;
			result.r2 = matrix1.r2 * matrix2.r2;
			result.r3 = matrix1.r3 * matrix2.r3;
			result.r4 = matrix1.r4 * matrix2.r4;
#else
			result.m11 = matrix1.m11 / matrix2.m11;
			result.m12 = matrix1.m12 / matrix2.m12;
			result.m13 = matrix1.m13 / matrix2.m13;
			result.m14 = matrix1.m14 / matrix2.m14;
			
			result.m21 = matrix1.m21 / matrix2.m21;
			result.m22 = matrix1.m22 / matrix2.m22;
			result.m23 = matrix1.m23 / matrix2.m23;
			result.m24 = matrix1.m24 / matrix2.m24;
			
			result.m31 = matrix1.m31 / matrix2.m31;
			result.m32 = matrix1.m32 / matrix2.m32;
			result.m33 = matrix1.m33 / matrix2.m33;
			result.m34 = matrix1.m34 / matrix2.m34;
			
			result.m41 = matrix1.m41 / matrix2.m41;
			result.m42 = matrix1.m42 / matrix2.m42;
			result.m43 = matrix1.m43 / matrix2.m43;
			result.m44 = matrix1.m44 / matrix2.m44;
#endif
		}

		public static Matrix Divide(Matrix matrix1, float divider)
		{
			Divide(ref matrix1, divider, out matrix1);
			return matrix1;
		}

		public static void Divide(ref Matrix matrix1, float divider, out Matrix result)
		{
#if SIMD
			var divisor = new Vector4f(divider);
			result.r1 = matrix1.r1 / divisor;
			result.r2 = matrix1.r2 / divisor;
			result.r3 = matrix1.r3 / divisor;
			result.r4 = matrix1.r4 / divisor;
#else
			result.m11 = matrix1.m11 / divider;
			result.m12 = matrix1.m12 / divider;
			result.m13 = matrix1.m13 / divider;
			result.m14 = matrix1.m14 / divider;
			
			result.m21 = matrix1.m21 / divider;
			result.m22 = matrix1.m22 / divider;
			result.m23 = matrix1.m23 / divider;
			result.m24 = matrix1.m24 / divider;
			
			result.m31 = matrix1.m31 / divider;
			result.m32 = matrix1.m32 / divider;
			result.m33 = matrix1.m33 / divider;
			result.m34 = matrix1.m34 / divider;
			
			result.m41 = matrix1.m41 / divider;
			result.m42 = matrix1.m42 / divider;
			result.m43 = matrix1.m43 / divider;
			result.m44 = matrix1.m44 / divider;
#endif
		}

		#endregion

		#region Operator overloads

		public static Matrix operator +(Matrix matrix1, Matrix matrix2)
		{
			Add(ref matrix1, ref matrix2, out matrix1);
			return matrix1;
		}

		public static Matrix operator /(Matrix matrix, float divider)
		{
			Divide(ref matrix, divider, out matrix);
			return matrix;
		}

		public static Matrix operator /(Matrix matrix1, Matrix matrix2)
		{
			Divide(ref matrix1, ref matrix2, out matrix1);
			return matrix1;
		}

		public static Matrix operator *(Matrix matrix1, Matrix matrix2)
		{
#if SIMD
			//sse version only sets the result when the calculation is complete
			Matrix result;
			Multiply(ref matrix1, ref matrix2, out result);
			return result;
#else
	//non-sse version needs m1 and m1 to remain unchanged
			Matrix result;
			Multiply (ref matrix1, ref matrix2, out result);
			return result;
#endif
		}

		public static Matrix operator *(Matrix matrix, float scaleFactor)
		{
			Multiply(ref matrix, scaleFactor, out matrix);
			return matrix;
		}

		public static Matrix operator *(float scaleFactor, Matrix matrix)
		{
			Multiply(ref matrix, scaleFactor, out matrix);
			return matrix;
		}

		public static Matrix operator -(Matrix matrix1, Matrix matrix2)
		{
			Subtract(ref matrix1, ref matrix2, out matrix1);
			return matrix1;
		}

		public static Matrix operator -(Matrix matrix)
		{
			Negate(ref matrix, out matrix);
			return matrix;
		}

		#endregion

		#region Other maths

		private struct VectorBasis
		{
			public unsafe Vector3* Element0;
			public unsafe Vector3* Element1;
			public unsafe Vector3* Element2;
		}

		private struct CanonicalBasis
		{
			public Vector3 Row0;
			public Vector3 Row1;
			public Vector3 Row2;
		}


		public bool Decompose(out Vector3 scale, out Quaternion rotation, out Vector3 translation)
		{
			/* Based on:
			 * http://assimp.svn.sourceforge.net/viewvc/assimp/trunk/include/aiMatrix4x4.inl?view=markup
			 * 
			 */

			translation = new Vector3(M41, M42, M43);

			var rows = new[] {
				new Vector3(M11, M12, M13),
 				new Vector3(M21, M22, M23),
				new Vector3(M31, M31, M33) 
			};

			// scaling factors
			scale = new Vector3(rows[0].Length(), rows[1].Length(), rows[2].Length());

			double trace = r1.X + r2.Y + r3.Z;
			double[] temp = new double[4];

			if (trace > 0.0)
			{
				double s = Math.Sqrt(trace + 1.0);
				temp[3] = s * 0.5;
				s = 0.5 / s;

				temp[0] = ((r3.Y - r2.Z) * s);
				temp[1] = ((r1.Z - r3.X) * s);
				temp[2] = (r2.X - r1.Y) * s;
			}
			else
			{
				int i = r1.X < r2.Y ? (r2.Y < r3.Z ? 2 : 1) : (r1.X < r3.Z ? 2 : 0);
				int j = (i + 1) % 3;
				int k = (i + 2) % 3;

				double s = Math.Sqrt(this[i, i] - this[j, j] - this[k, k] + 1.0);
				temp[i] = s * 0.5;
				s = 0.5 / s;

				temp[3] = (this[k, j] - this[j, k]) * s;
				temp[j] = (this[j, i] + this[i, j]) * s;
				temp[k] = (this[k, i] + this[i, k]) * s;
			}

			rotation = new Quaternion((float)temp[0], (float)temp[1], (float)temp[2], (float)temp[3]);

			/*var tmp = (Matrix)MemberwiseClone();

			var angleZ = (float)MathHelper.GetSignedAngleBetween(tmp.Right, Vector3.Right, Vector3.Right);

			if (angleZ != 0)
				tmp *= CreateRotationZ(angleZ);

			var angleY = (float)MathHelper.GetSignedAngleBetween(tmp.Up, Vector3.Up, Vector3.Right);

			if (angleY != 0)
				tmp *= CreateRotationY(angleY);

			var angleX = (float)MathHelper.GetSignedAngleBetween(tmp.Forward, Vector3.Forward, Vector3.Right);

			rotation = Quaternion.CreateFromYawPitchRoll(angleX, angleY, angleZ);
			*/

			//rotation = default(Quaternion);

			//// and remove all scaling from the matrix
			//if (Math.Abs(scale.X - 0f) > float.Epsilon)
			//    rows[0] /= scale.X;
			//else
			//    return false;

			//if (Math.Abs(scale.Y - 0) > float.Epsilon)
			//    rows[1] /= scale.Y;
			//else
			//    return false;

			//if (Math.Abs(scale.Z - 0) > float.Epsilon)
			//    rows[2] /= scale.Z;
			//else
			//    return false;

			//rotation = new Quaternion(new Matrix3(
			//    rows[0].X, rows[1].X, rows[2].X,
			//    rows[0].Y, rows[1].Y, rows[2].Y,
			//    rows[0].Z, rows[1].Z, rows[2].Z));)))))));)

			return true;
		}

		public float Determinant()
		{
			return
				M11 * M22 * M33 * M44 - M11 * M22 * M34 * M43 + M11 * M23 * M34 * M42 - M11 * M23 * M32 * M44 +
				M11 * M24 * M32 * M43 - M11 * M24 * M33 * M42 - M12 * M23 * M34 * M41 + M12 * M23 * M31 * M44 -
				M12 * M24 * M31 * M43 + M12 * M24 * M33 * M41 - M12 * M21 * M33 * M44 + M12 * M21 * M34 * M43 +
				M13 * M24 * M31 * M42 - M13 * M24 * M32 * M41 + M13 * M21 * M32 * M44 - M13 * M21 * M34 * M42 +
				M13 * M22 * M34 * M41 - M13 * M22 * M31 * M44 - M14 * M21 * M32 * M43 + M14 * M21 * M33 * M42 -
				M14 * M22 * M33 * M41 + M14 * M22 * M31 * M43 - M14 * M23 * M31 * M42 + M14 * M23 * M32 * M41;
		}

		public static Matrix Invert(Matrix matrix)
		{
			Matrix result;
			Invert(ref matrix, out result);
			return result;
		}

		public Vector4 Row0
		{
			get { return new Vector4(M11, M12, M13, M14); }
			set
			{
				M11 = value.X;
				M12 = value.Y;
				M13 = value.Z;
				M14 = value.W;
			}
		}

		public Vector4 Row1
		{
			get { return new Vector4(M21, M22, M23, M24); }
			set
			{
				M21 = value.X;
				M22 = value.Y;
				M23 = value.Z;
				M24 = value.W;
			}
		}

		public Vector4 Row2
		{
			get { return new Vector4(M31, M32, M33, M34); }
			set
			{
				M31 = value.X;
				M32 = value.Y;
				M33 = value.Z;
				M34 = value.W;
			}
		}

		public Vector4 Row3
		{
			get { return new Vector4(M41, M42, M43, M44); }
			set
			{
				M41 = value.X;
				M42 = value.Y;
				M43 = value.Z;
				M44 = value.W;
			}
		}

		public static void Invert(ref Matrix matrix, out Matrix result)
		{
			int[] colIdx = { 0, 0, 0, 0 };
			int[] rowIdx = { 0, 0, 0, 0 };
			int[] pivotIdx = { -1, -1, -1, -1 };

			// convert the matrix to an array for easy looping
			float[,] inverse = {
			                   	{matrix.Row0.X, matrix.Row0.Y, matrix.Row0.Z, matrix.Row0.W},
			                   	{matrix.Row1.X, matrix.Row1.Y, matrix.Row1.Z, matrix.Row1.W},
			                   	{matrix.Row2.X, matrix.Row2.Y, matrix.Row2.Z, matrix.Row2.W},
			                   	{matrix.Row3.X, matrix.Row3.Y, matrix.Row3.Z, matrix.Row3.W}
			                   };

			int icol = 0;
			int irow = 0;

			for (int i = 0; i < 4; i++)
			{
				// Find the largest pivot value
				float maxPivot = 0.0f;

				for (int j = 0; j < 4; j++)
				{
					if (pivotIdx[j] != 0)
					{
						for (int k = 0; k < 4; ++k)
						{
							if (pivotIdx[k] == -1)
							{
								float absVal = Math.Abs(inverse[j, k]);
								if (absVal > maxPivot)
								{
									maxPivot = absVal;
									irow = j;
									icol = k;
								}
							}
							else if (pivotIdx[k] > 0)
							{
								result = matrix;
								return;
							}
						}
					}
				}

				++(pivotIdx[icol]);

				// Swap rows over so pivot is on diagonal
				if (irow != icol)
				{
					for (int k = 0; k < 4; ++k)
					{
						float f = inverse[irow, k];
						inverse[irow, k] = inverse[icol, k];
						inverse[icol, k] = f;
					}
				}

				rowIdx[i] = irow;
				colIdx[i] = icol;

				float pivot = inverse[icol, icol];
				// check for singular matrix
				if (pivot == 0.0f)
				{
					throw new InvalidOperationException("Matrix is singular and cannot be inverted.");
					//return mat;
				}

				// Scale row so it has a unit diagonal
				float oneOverPivot = 1.0f / pivot;
				inverse[icol, icol] = 1.0f;
				for (int k = 0; k < 4; ++k)
					inverse[icol, k] *= oneOverPivot;

				// Do elimination of non-diagonal elements
				for (int j = 0; j < 4; ++j)
				{
					// check this isn't on the diagonal
					if (icol != j)
					{
						float f = inverse[j, icol];
						inverse[j, icol] = 0.0f;
						for (int k = 0; k < 4; ++k)
							inverse[j, k] -= inverse[icol, k] * f;
					}
				}
			}

			for (int j = 3; j >= 0; --j)
			{
				int ir = rowIdx[j];
				int ic = colIdx[j];
				for (int k = 0; k < 4; ++k)
				{
					float f = inverse[k, ir];
					inverse[k, ir] = inverse[k, ic];
					inverse[k, ic] = f;
				}
			}

#if SIMD
			result = new Matrix(
				new Vector4f(inverse[0, 0], inverse[0, 1], inverse[0, 2], inverse[0, 3]),
				new Vector4f(inverse[1, 0], inverse[1, 1], inverse[1, 2], inverse[1, 3]),
				new Vector4f(inverse[2, 0], inverse[2, 1], inverse[2, 2], inverse[2, 3]),
				new Vector4f(inverse[3, 0], inverse[3, 1], inverse[3, 2], inverse[3, 3]));
#else
			result = new Matrix(
				inverse[0, 0], inverse[0, 1], inverse[0, 2], inverse[0, 3],
				inverse[1, 0], inverse[1, 1], inverse[1, 2], inverse[1, 3],
				inverse[2, 0], inverse[2, 1], inverse[2, 2], inverse[2, 3],
				inverse[3, 0], inverse[3, 1], inverse[3, 2], inverse[3, 3]);
#endif
		}

		public static Matrix Lerp(Matrix matrix1, Matrix matrix2, float amount)
		{
			Lerp(ref matrix1, ref matrix2, amount, out matrix1);
			return matrix1;
		}

		public static void Lerp(ref Matrix matrix1, ref Matrix matrix2, float amount, out Matrix result)
		{
#if SIMD
			result.r1 = matrix1.r1 + amount * (matrix2.r1 - matrix1.r1);
			result.r2 = matrix1.r2 + amount * (matrix2.r2 - matrix1.r2);
			result.r3 = matrix1.r3 + amount * (matrix2.r3 - matrix1.r3);
			result.r4 = matrix1.r4 + amount * (matrix2.r4 - matrix1.r4);
#else
			result.m11 = matrix1.m11 + amount * (matrix2.m11 - matrix1.m11);
			result.m12 = matrix1.m12 + amount * (matrix2.m12 - matrix1.m12);
			result.m13 = matrix1.m13 + amount * (matrix2.m13 - matrix1.m13);
			result.m14 = matrix1.m14 + amount * (matrix2.m14 - matrix1.m14);
			
			result.m21 = matrix1.m21 + amount * (matrix2.m21 - matrix1.m21);
			result.m22 = matrix1.m22 + amount * (matrix2.m22 - matrix1.m22);
			result.m23 = matrix1.m23 + amount * (matrix2.m23 - matrix1.m23);
			result.m24 = matrix1.m24 + amount * (matrix2.m24 - matrix1.m24);
			
			result.m31 = matrix1.m31 + amount * (matrix2.m31 - matrix1.m31);
			result.m32 = matrix1.m32 + amount * (matrix2.m32 - matrix1.m32);
			result.m33 = matrix1.m33 + amount * (matrix2.m33 - matrix1.m33);
			result.m34 = matrix1.m34 + amount * (matrix2.m34 - matrix1.m34);
			
			result.m41 = matrix1.m41 + amount * (matrix2.m41 - matrix1.m41);
			result.m42 = matrix1.m42 + amount * (matrix2.m42 - matrix1.m42);
			result.m43 = matrix1.m43 + amount * (matrix2.m43 - matrix1.m43);
			result.m44 = matrix1.m44 + amount * (matrix2.m44 - matrix1.m44);
#endif
		}

		public static Matrix Transform(Matrix value, Quaternion rotation)
		{
			Matrix result;
			Transform(ref value, ref rotation, out result);
			return result;
		}

		public static void Transform(ref Matrix value, ref Quaternion rotation, out Matrix result)
		{
			float num = rotation.X + rotation.X;
			float num2 = rotation.Y + rotation.Y;
			float num3 = rotation.Z + rotation.Z;
			float num4 = rotation.W * num;
			float num5 = rotation.W * num2;
			float num6 = rotation.W * num3;
			float num7 = rotation.X * num;
			float num8 = rotation.X * num2;
			float num9 = rotation.X * num3;
			float num10 = rotation.Y * num2;
			float num11 = rotation.Y * num3;
			float num12 = rotation.Z * num3;
			float num13 = 1f - num10 - num12;
			float num14 = num8 - num6;
			float num15 = num9 + num5;
			float num16 = num8 + num6;
			float num17 = 1f - num7 - num12;
			float num18 = num11 - num4;
			float num19 = num9 - num5;
			float num20 = num11 + num4;
			float num21 = 1f - num7 - num10;

			float item11 = value.M11 * num13 + value.M12 * num14 + value.M13 * num15;
			float item12 = value.M11 * num16 + value.M12 * num17 + value.M13 * num18;
			float item13 = value.M11 * num19 + value.M12 * num20 + value.M13 * num21;
			float item14 = value.M14;

			float item21 = value.M21 * num13 + value.M22 * num14 + value.M23 * num15;
			float item22 = value.M21 * num16 + value.M22 * num17 + value.M23 * num18;
			float item23 = value.M21 * num19 + value.M22 * num20 + value.M23 * num21;
			float item24 = value.M24;

			float item31 = value.M31 * num13 + value.M32 * num14 + value.M33 * num15;
			float item32 = value.M31 * num16 + value.M32 * num17 + value.M33 * num18;
			float item33 = value.M31 * num19 + value.M32 * num20 + value.M33 * num21;
			float item34 = value.M34;

			float item41 = value.M41 * num13 + value.M42 * num14 + value.M43 * num15;
			float item42 = value.M41 * num16 + value.M42 * num17 + value.M43 * num18;
			float item43 = value.M41 * num19 + value.M42 * num20 + value.M43 * num21;
			float item44 = value.M44;

			result = new Matrix(
				item11, item12, item13, item14,
				item21, item22, item23, item24,
				item31, item32, item33, item34,
				item41, item42, item43, item44);
		}

		public static Matrix Transpose(Matrix matrix)
		{
#if SIMD
			Vector4f xmm0 = matrix.r1, xmm1 = matrix.r2, xmm2 = matrix.r3, xmm3 = matrix.r4;
			Vector4f xmm4 = xmm0;
			xmm0 = xmm0.InterleaveLow(xmm2);
			xmm4 = xmm4.InterleaveHigh(xmm2);
			xmm2 = xmm1;
			xmm1 = xmm1.InterleaveLow(xmm3);
			xmm2 = xmm2.InterleaveHigh(xmm3);
			xmm3 = xmm0;
			xmm0 = xmm0.InterleaveLow(xmm1);
			xmm3 = xmm3.InterleaveHigh(xmm1);
			xmm1 = xmm4;
			xmm1 = xmm1.InterleaveLow(xmm2);
			xmm4 = xmm4.InterleaveHigh(xmm2);

			return new Matrix(xmm0, xmm3, xmm1, xmm4);
#else
			return new Matrix (
				matrix.M11, matrix.M21, matrix.M31, matrix.M41,
				matrix.M12, matrix.M22, matrix.M32, matrix.M42,
				matrix.M13, matrix.M23, matrix.M33, matrix.M43,
				matrix.M14, matrix.M24, matrix.M34, matrix.M44);
#endif
		}

		public static void Transpose(ref Matrix matrix, out Matrix result)
		{
#if SIMD
			//algorithm from public domain - http://0x80.pl/snippets/asm/sse-transpose.c
			Vector4f xmm0 = matrix.r1; // xmm0 = a0 a1 a2 a3
			Vector4f xmm1 = matrix.r2; // xmm1 = b0 b1 b2 b3
			Vector4f xmm2 = matrix.r3; // xmm2 = c0 c1 c2 c3
			Vector4f xmm3 = matrix.r4; // xmm3 = d0 d1 d2 d3

			Vector4f xmm4 = xmm0;
			xmm0 = xmm0.InterleaveLow(xmm2); // xmm0 = a0 c0 a1 c1
			xmm4 = xmm4.InterleaveHigh(xmm2); // xmm4 = a2 c2 a3 c3

			xmm2 = xmm1;
			xmm1 = xmm1.InterleaveLow(xmm3); // xmm1 = b0 d0 b1 d1
			xmm2 = xmm2.InterleaveHigh(xmm3); // xmm2 = b2 d2 b3 d3

			xmm3 = xmm0;
			xmm0 = xmm0.InterleaveLow(xmm1); // xmm0 = a0 b0 c0 d0
			xmm3 = xmm3.InterleaveHigh(xmm1); // xmm3 = a1 b1 c1 d1

			xmm1 = xmm4;
			xmm1 = xmm1.InterleaveLow(xmm2); // xmm1 = a2 b2 c2 d2
			xmm4 = xmm4.InterleaveHigh(xmm2); // xmm4 = a3 b3 c3 d3

			result.r1 = xmm0;
			result.r2 = xmm3;
			result.r3 = xmm1;
			result.r4 = xmm4;
#else
			result.m11 = matrix.m11;
			result.m12 = matrix.m21;
			result.m13 = matrix.m31;
			result.m14 = matrix.m41;
			
			result.m21 = matrix.m12;
			result.m22 = matrix.m22;
			result.m23 = matrix.m32;
			result.m24 = matrix.m42;
			
			result.m31 = matrix.m13;
			result.m32 = matrix.m23;
			result.m33 = matrix.m33;
			result.m34 = matrix.m43;
			
			result.m41 = matrix.m14;
			result.m42 = matrix.m24;
			result.m43 = matrix.m34;
			result.m44 = matrix.m44;
#endif
		}

		#endregion

		#region Equality

		public bool Equals(Matrix other)
		{
#if SIMD
			return r1 == other.r1 && r2 == other.r2 && r3 == other.r3 && r4 == other.r4;
#else
			return
				m11 == other.m11 && m12 == other.m12 && m13 == other.m13 && m14 == other.m14 &&
				m21 == other.m21 && m22 == other.m22 && m23 == other.m23 && m24 == other.m24 &&
				m31 == other.m31 && m32 == other.m32 && m33 == other.m33 && m34 == other.m34 &&
				m41 == other.m41 && m42 == other.m42 && m43 == other.m43 && m44 == other.m44;
#endif
		}

		public override bool Equals(object obj)
		{
			return obj is Matrix && ((Matrix)obj) == this;
		}

		public override int GetHashCode()
		{
			return
				M11.GetHashCode () ^ M12.GetHashCode () ^ M13.GetHashCode () ^ M14.GetHashCode () ^
				M21.GetHashCode () ^ M22.GetHashCode () ^ M23.GetHashCode () ^ M24.GetHashCode () ^
				M31.GetHashCode () ^ M32.GetHashCode () ^ M33.GetHashCode () ^ M34.GetHashCode () ^
				M41.GetHashCode () ^ M42.GetHashCode () ^ M43.GetHashCode () ^ M44.GetHashCode ();
		}

		public static bool operator ==(Matrix a, Matrix b)
		{
#if SIMD
			return a.r1 == b.r1 && a.r2 == b.r2 && a.r3 == b.r3 && a.r4 == b.r4;
#else
			return
				a.m11 == b.m11 && a.m12 == b.m12 && a.m13 == b.m13 && a.m14 == b.m14 &&
				a.m21 == b.m21 && a.m22 == b.m22 && a.m23 == b.m23 && a.m24 == b.m24 &&
				a.m31 == b.m31 && a.m32 == b.m32 && a.m33 == b.m33 && a.m34 == b.m34 &&
				a.m41 == b.m41 && a.m42 == b.m42 && a.m43 == b.m43 && a.m44 == b.m44;
#endif
		}

		public static bool operator !=(Matrix a, Matrix b)
		{
#if SIMD
			return a.r1 != b.r1 || a.r2 != b.r2 || a.r3 != b.r3 || a.r4 != b.r4;
#else
			return
				a.m11 != b.m11 || a.m12 != b.m12 || a.m13 != b.m13 && a.m14 != b.m14 ||
				a.m21 != b.m21 || a.m22 != b.m22 || a.m23 != b.m23 && a.m24 != b.m24 ||
				a.m31 != b.m31 || a.m32 != b.m32 || a.m33 != b.m33 && a.m34 != b.m34 ||
				a.m41 != b.m41 || a.m42 != b.m42 || a.m43 != b.m43 && a.m44 != b.m44;
#endif
		}

		# endregion

		public override string ToString()
		{
			return string.Format(
				"{{ {0:0.0000} {1:0.0000} {2:0.0000} {3:0.0000} }} {16}" +
				"{{ {4:0.0000} {5:0.0000} {6:0.0000} {7:0.0000} }} {16}" +
				"{{ {8:0.0000} {9:0.0000} {10:0.0000} {11:0.0000} }} {16}" +
				"{{ {12:0.0000} {13:0.0000} {14:0.0000} {15:0.0000} }}",
				M11, M12, M13, M14,
				M21, M22, M23, M24,
				M31, M32, M33, M34,
				M41, M42, M43, M44,
				Environment.NewLine);
		}
	}
}