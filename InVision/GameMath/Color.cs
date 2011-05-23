using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;
using InVision.GameMath.Endianess;

namespace InVision.GameMath
{
	/// <summary>
	/// 	Class representing colour.
	/// 	<remarks>
	/// 		Colour is represented as 4 components, each of which is a floating-point value from 0.0 to 1.0.
	/// 		The 3 'normal' colour components are red, green and blue, a higher number indicating greater amounts of that component in the colour. The forth component is the 'alpha' value, which represents transparency. In this case, 0.0 is completely transparent and 1.0 is fully opaque.
	/// 	</remarks>
	/// </summary>
	[Serializable, StructLayout(LayoutKind.Sequential)]
	[XmlRoot("color")]
	public struct Color : IEquatable<Color>, IXmlSerializable
	{
		private Vector4 values;

		/// <summary>
		/// Gets the R.
		/// </summary>
		/// <value>The R.</value>
		public float R
		{
			get { return values.X; }
			set { values.X = value; }
		}

		/// <summary>
		/// Gets the G.
		/// </summary>
		/// <value>The G.</value>
		public float G
		{
			get { return values.Y; }
			set { values.Y = value; }
		}

		/// <summary>
		/// Gets the B.
		/// </summary>
		/// <value>The B.</value>
		public float B
		{
			get { return values.Z; }
			set { values.Z = value; }
		}

		/// <summary>
		/// Gets the A.
		/// </summary>
		/// <value>The A.</value>
		public float A
		{
			get { return values.W; }
			set { values.W = value; }
		}

		/// <summary>
		/// 	Initializes a new instance of the <see cref = "Color" /> struct.
		/// </summary>
		/// <param name = "red">The red.</param>
		/// <param name = "green">The green.</param>
		/// <param name = "blue">The blue.</param>
		/// <param name = "alpha">The alpha.</param>
		public Color(byte red, byte green, byte blue, byte alpha)
			: this(red / 255f, green / 255f, blue / 255f, alpha / 255f)
		{
		}

		/// <summary>
		/// 	Initializes a new instance of the <see cref = "Color" /> struct.
		/// </summary>
		/// <param name = "r">The red.</param>
		/// <param name = "g">The green.</param>
		/// <param name = "b">The blue.</param>
		/// <param name = "a">The alpha.</param>
		public Color(float r = 1f, float g = 1f, float b = 1f, float a = 1f)
			: this()
		{
			values = new Vector4(r, g, b, a);
		}

		/// <summary>
		/// 	Gets the RGBA.
		/// </summary>
		/// <value>The RGBA.</value>
		public uint RGBA
		{
			get
			{
				return ColourRepresentation.Instance.ToInt32(R, G, B, A);
			}
			set
			{
				float r, g, b, a;

				ColourRepresentation.Instance.FromInt32(value, out r, out g, out b, out a);
				values = new Vector4(r, g, b, a);
			}
		}

		/// <summary>
		/// 	Gets or sets the ARGB.
		/// </summary>
		/// <value>The ARGB.</value>
		public uint ARGB
		{
			get { return ColourRepresentation.Instance.ToInt32(A, R, G, B); }
			set
			{
				float r, g, b, a;

				ColourRepresentation.Instance.FromInt32(value, out a, out r, out g, out b);
				values = new Vector4(r, g, b, a);
			}
		}

		/// <summary>
		/// 	Gets or sets the BGRA.
		/// </summary>
		/// <value>The BGRA.</value>
		public uint BGRA
		{
			get { return ColourRepresentation.Instance.ToInt32(B, G, R, A); }
			set
			{
				float r, g, b, a;

				ColourRepresentation.Instance.FromInt32(value, out b, out g, out r, out a);
				values = new Vector4(r, g, b, a);
			}
		}

		/// <summary>
		/// 	Gets or sets the ABGR.
		/// </summary>
		/// <value>The ABGR.</value>
		public uint ABGR
		{
			get { return ColourRepresentation.Instance.ToInt32(A, B, G, R); }
			set
			{
				float r, g, b, a;

				ColourRepresentation.Instance.FromInt32(value, out a, out b, out g, out r);
				values = new Vector4(r, g, b, a);
			}
		}

		/// <summary>
		/// 	Gets or sets the <see cref = "System.Single" /> at the specified index.
		/// </summary>
		/// <value></value>
		public float this[int index]
		{
			get
			{
				switch (index)
				{
					case 0:
						return R;

					case 1:
						return G;

					case 2:
						return B;

					case 3:
						return A;

					default:
						throw new IndexOutOfRangeException();
				}
			}
			set
			{
				switch (index)
				{
					case 0:
						R = value;
						break;

					case 1:
						G = value;
						break;

					case 2:
						B = value;
						break;

					case 3:
						A = value;
						break;

					default:
						throw new IndexOutOfRangeException();
				}
			}
		}

		/// <summary>
		/// Toes the HSB.
		/// </summary>
		/// <returns></returns>
		public float[] ToHSB()
		{
			float h, s, b;

			GetHSB(out h, out s, out b);

			return new[] { h, s, b };
		}

		/// <summary>
		/// Froms the HSB.
		/// </summary>
		/// <param name="value">The value.</param>
		public void FromHSB(float[] value)
		{
			SetHSB(value[0], value[1], value[2]);
		}

		/// <summary>
		/// 	Saturates this instance.
		/// </summary>
		public void Saturate()
		{
			R = R.Clamp(0, 1);
			G = G.Clamp(0, 1);
			B = B.Clamp(0, 1);
			A = A.Clamp(0, 1);
		}

		/// <summary>
		/// 	Saturates the copy.
		/// </summary>
		/// <returns></returns>
		public Color SaturateCopy()
		{
			Color copy = this;
			copy.Saturate();

			return copy;
		}

		/// <summary>
		/// 	Sets the HSB.
		/// </summary>
		/// <param name = "hue">The hue.</param>
		/// <param name = "saturation">The saturation.</param>
		/// <param name = "brightness">The brightness.</param>
		public void SetHSB(float hue, float saturation, float brightness)
		{
			if (hue > 1f)
				hue -= (int)hue;
			else if (hue < 0f)
				hue += (int)hue + 1;

			// clamp saturation / brightness
			saturation = saturation.Clamp(0, 1);
			brightness = brightness.Clamp(0, 1);

			if (brightness == 0)
			{
				R = G = B = 0f;
				return;
			}

			if (saturation == 0)
			{
				R = G = B = brightness;
				return;
			}

			float hueDomain = hue * 6f;

			if (hueDomain >= 6f)
				hueDomain = 0f; // wrap around and allow mathematical errors

			var domain = (ushort)hueDomain;

			float f1 = brightness * (1 - saturation);
			float f2 = brightness * (1 - saturation * (hueDomain - domain));
			float f3 = brightness * (1 - saturation * (1 - (hueDomain - domain)));

			switch (domain)
			{
				case 0:
					// red domain: green ascends
					R = brightness;
					G = f3;
					B = f1;
					break;

				case 1:
					// yellow domain: red descends
					R = f2;
					G = brightness;
					B = f1;
					break;

				case 2:
					// green domain: blue ascends
					R = f1;
					G = brightness;
					B = f2;
					break;

				case 3:
					// cyan domain: green descends
					R = f1;
					G = f2;
					B = brightness;
					break;

				case 4:
					// blue domain: red ascends
					R = f3;
					G = f1;
					B = brightness;
					break;

				case 5:
					// magenta domain: blue descends
					R = brightness;
					G = f1;
					B = f2;
					break;
			}
		}

		/// <summary>
		/// 	Gets the HSB.
		/// </summary>
		/// <param name = "hue">The hue.</param>
		/// <param name = "saturation">The saturation.</param>
		/// <param name = "brightness">The brightness.</param>
		public void GetHSB(out float hue, out float saturation, out float brightness)
		{
			float vMin = Math.Min(R, Math.Min(G, B));
			float vMax = Math.Max(R, Math.Max(G, B));
			float delta = vMax - vMin;

			brightness = vMax;

			if (delta.Equal(0f, (float)1e-6))
			{
				hue = 0;
				saturation = 0;
			}
			else
			{
				hue = 0;
				saturation = delta / vMax;

				float deltaR = (((vMax - R) / 6f) + (delta / 2f)) / delta;
				float deltaG = (((vMax - G) / 6f) + (delta / 2f)) / delta;
				float deltaB = (((vMax - B) / 6f) + (delta / 2f)) / delta;

				if (R.Equal(vMax))
					hue = deltaB - deltaG;
				else if (G.Equal(vMax))
					hue = 0.3333333f + deltaR - deltaB;
				else if (brightness.Equal(vMax))
					hue = 0.6666667f + deltaG - deltaR;

				if (hue < 0f)
					hue += 1f;

				if (hue > 1f)
					hue -= 1f;
			}
		}

		/// <summary>
		/// 	Adds the specified scalar.
		/// </summary>
		/// <param name = "scalar">The scalar.</param>
		public Color Add(float scalar)
		{
			return Add(ref this, scalar);
		}

		/// <summary>
		/// 	Adds the specified other.
		/// </summary>
		/// <param name = "other">The other.</param>
		/// <returns></returns>
		public Color Add(Color other)
		{
			return Add(ref this, ref other);
		}

		/// <summary>
		/// 	Subtracts the specified scalar.
		/// </summary>
		/// <param name = "scalar">The scalar.</param>
		/// <returns></returns>
		public Color Subtract(float scalar)
		{
			return Subtract(ref this, scalar);
		}

		/// <summary>
		/// 	Subtracts the specified other.
		/// </summary>
		/// <param name = "other">The other.</param>
		/// <returns></returns>
		public Color Subtract(Color other)
		{
			return Subtract(ref this, ref other);
		}

		/// <summary>
		/// 	Multiplies the specified scalar.
		/// </summary>
		/// <param name = "scalar">The scalar.</param>
		/// <returns></returns>
		public Color Multiply(float scalar)
		{
			return Multiply(ref this, scalar);
		}

		/// <summary>
		/// 	Multiplies the specified other.
		/// </summary>
		/// <param name = "other">The other.</param>
		/// <returns></returns>
		public Color Multiply(Color other)
		{
			return Multiply(ref this, ref other);
		}

		/// <summary>
		/// 	Divides the specified scalar.
		/// </summary>
		/// <param name = "scalar">The scalar.</param>
		/// <returns></returns>
		public Color Divide(float scalar)
		{
			return Divide(ref this, scalar);
		}

		/// <summary>
		/// 	Divides the specified other.
		/// </summary>
		/// <param name = "other">The other.</param>
		/// <returns></returns>
		public Color Divide(Color other)
		{
			return Divide(ref this, ref other);
		}

		/// <summary>
		/// 	Returns a <see cref = "System.String" /> that represents this instance.
		/// </summary>
		/// <returns>
		/// 	A <see cref = "System.String" /> that represents this instance.
		/// </returns>
		public override string ToString()
		{
			return string.Format("Color({0}, {1}, {2}, {3})", R, G, B, A);
		}

		/// <summary>
		/// 	Indicates whether the current object is equal to another object of the same type.
		/// </summary>
		/// <returns>
		/// 	true if the current object is equal to the <paramref name = "other" /> parameter; otherwise, false.
		/// </returns>
		/// <param name = "other">An object to compare with this object.</param>
		public bool Equals(Color other)
		{
			return other.R.Equals(R) && other.G.Equals(G) && other.B.Equals(B) && other.A.Equals(A);
		}

		/// <summary>
		/// 	Indicates whether this instance and a specified object are equal.
		/// </summary>
		/// <returns>
		/// 	true if <paramref name = "obj" /> and this instance are the same type and represent the same value; otherwise, false.
		/// </returns>
		/// <param name = "obj">Another object to compare to. </param>
		/// <filterpriority>2</filterpriority>
		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (obj.GetType() != typeof(Color)) return false;

			return Equals((Color)obj);
		}

		/// <summary>
		/// 	Returns the hash code for this instance.
		/// </summary>
		/// <returns>
		/// 	A 32-bit signed integer that is the hash code for this instance.
		/// </returns>
		/// <filterpriority>2</filterpriority>
		public override int GetHashCode()
		{
			unchecked
			{
				int result = R.GetHashCode();
				result = (result * 397) ^ G.GetHashCode();
				result = (result * 397) ^ B.GetHashCode();
				result = (result * 397) ^ A.GetHashCode();

				return result;
			}
		}

		/// <summary>
		/// Bytes to float.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		private static float ByteToFloat(byte value)
		{
			const float convertion = 1f / 255f;

			return value * convertion;
		}

		/// <summary>
		/// Floats to byte.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <returns></returns>
		private static byte FloatToByte(float value)
		{
			const float convertion = 255f;

			return (byte)(value * convertion).Clamp(0, 255f);
		}

		public static Color FromNonPremultiplied(byte r, byte g, byte b, byte a)
		{
			float scale = ByteToFloat(a);

			return new Color((byte)(r * scale), (byte)(g * scale), (byte)(b * scale), a);
		}

		public static Color FromNonPremultiplied(Vector4 vector)
		{
			return new Color(vector.X * vector.W, vector.Y * vector.W, vector.Z * vector.W, vector.W);
		}

		public static Color Lerp(Color value1, Color value2, float amount)
		{
			return new Color(
				Lerp(FloatToByte(value1.R), FloatToByte(value2.R), amount),
				Lerp(FloatToByte(value1.G), FloatToByte(value2.G), amount),
				Lerp(FloatToByte(value1.B), FloatToByte(value2.B), amount),
				Lerp(FloatToByte(value1.A), FloatToByte(value2.A), amount));
		}

		private static int Lerp(int i1, int i2, float amount)
		{
			return i1 + (int)((i2 - i1) * amount);
		}

		/// <summary>
		/// 	Adds the specified colour.
		/// </summary>
		/// <param name = "colour">The colour.</param>
		/// <param name = "scalar">The scalar.</param>
		/// <returns></returns>
		public static Color Add(ref Color colour, float scalar)
		{
			colour.R += scalar;
			colour.G += scalar;
			colour.B += scalar;
			colour.A += scalar;

			return colour;
		}

		/// <summary>
		/// 	Adds the specified scalar.
		/// </summary>
		/// <param name = "scalar">The scalar.</param>
		/// <param name = "colour">The colour.</param>
		/// <returns></returns>
		public static Color Add(float scalar, ref Color colour)
		{
			colour.R = scalar + colour.R;
			colour.G = scalar + colour.G;
			colour.B = scalar + colour.B;
			colour.A = scalar + colour.A;

			return colour;
		}

		/// <summary>
		/// 	Adds the specified a.
		/// </summary>
		/// <param name = "a">A.</param>
		/// <param name = "b">The b.</param>
		/// <returns></returns>
		public static Color Add(ref Color a, ref Color b)
		{
			a.R += b.R;
			a.G += b.G;
			a.B += b.B;
			a.A += b.A;

			return a;
		}

		/// <summary>
		/// 	Subtracts the specified colour.
		/// </summary>
		/// <param name = "colour">The colour.</param>
		/// <param name = "scalar">The scalar.</param>
		/// <returns></returns>
		public static Color Subtract(ref Color colour, float scalar)
		{
			colour.R -= scalar;
			colour.G -= scalar;
			colour.B -= scalar;
			colour.A -= scalar;

			return colour;
		}

		/// <summary>
		/// 	Subtracts the specified scalar.
		/// </summary>
		/// <param name = "scalar">The scalar.</param>
		/// <param name = "colour">The colour.</param>
		/// <returns></returns>
		public static Color Subtract(float scalar, ref Color colour)
		{
			colour.R = scalar - colour.R;
			colour.G = scalar - colour.G;
			colour.B = scalar - colour.B;
			colour.A = scalar - colour.A;

			return colour;
		}

		/// <summary>
		/// 	Substracts the specified a.
		/// </summary>
		/// <param name = "a">A.</param>
		/// <param name = "b">The b.</param>
		/// <returns></returns>
		public static Color Subtract(ref Color a, ref Color b)
		{
			a.R -= b.R;
			a.G -= b.G;
			a.B -= b.B;
			a.A -= b.A;

			return a;
		}

		/// <summary>
		/// 	Multiplies the specified colour.
		/// </summary>
		/// <param name = "colour">The colour.</param>
		/// <param name = "scalar">The scalar.</param>
		/// <returns></returns>
		public static Color Multiply(ref Color colour, float scalar)
		{
			colour.R *= scalar;
			colour.G *= scalar;
			colour.B *= scalar;
			colour.A *= scalar;

			return colour;
		}

		/// <summary>
		/// 	Multiplies the specified scalar.
		/// </summary>
		/// <param name = "scalar">The scalar.</param>
		/// <param name = "colour">The colour.</param>
		/// <returns></returns>
		public static Color Multiply(float scalar, ref Color colour)
		{
			colour.R = scalar * colour.R;
			colour.G = scalar * colour.G;
			colour.B = scalar * colour.B;
			colour.A = scalar * colour.A;

			return colour;
		}

		/// <summary>
		/// 	Multiplies the specified a.
		/// </summary>
		/// <param name = "a">A.</param>
		/// <param name = "b">The b.</param>
		/// <returns></returns>
		public static Color Multiply(ref Color a, ref Color b)
		{
			a.R *= b.R;
			a.G *= b.G;
			a.B *= b.B;
			a.A *= b.A;

			return a;
		}

		/// <summary>
		/// 	Divides the specified colour.
		/// </summary>
		/// <param name = "colour">The colour.</param>
		/// <param name = "scalar">The scalar.</param>
		/// <returns></returns>
		public static Color Divide(ref Color colour, float scalar)
		{
			Debug.Assert(scalar != 0);

			colour.R /= scalar;
			colour.G /= scalar;
			colour.B /= scalar;
			colour.A /= scalar;

			return colour;
		}

		/// <summary>
		/// 	Divides the specified scalar.
		/// </summary>
		/// <param name = "scalar">The scalar.</param>
		/// <param name = "colour">The colour.</param>
		/// <returns></returns>
		public static Color Divide(float scalar, ref Color colour)
		{
			colour.R = scalar / colour.R;
			colour.G = scalar / colour.G;
			colour.B = scalar / colour.B;
			colour.A = scalar / colour.A;

			return colour;
		}

		/// <summary>
		/// 	Divides the specified a.
		/// </summary>
		/// <param name = "a">A.</param>
		/// <param name = "b">The b.</param>
		/// <returns></returns>
		public static Color Divide(ref Color a, ref Color b)
		{
			a.R /= b.R;
			a.G /= b.G;
			a.B /= b.B;
			a.A /= b.A;

			return a;
		}


		/// <summary>
		/// 	Implements the operator +.
		/// </summary>
		/// <param name = "colour">The colour.</param>
		/// <param name = "scalar">The scalar.</param>
		/// <returns>The result of the operator.</returns>
		public static Color operator +(Color colour, float scalar)
		{
			return Add(ref colour, scalar);
		}

		/// <summary>
		/// 	Implements the operator +.
		/// </summary>
		/// <param name = "scalar">The scalar.</param>
		/// <param name = "colour">The colour.</param>
		/// <returns>The result of the operator.</returns>
		public static Color operator +(float scalar, Color colour)
		{
			return Add(scalar, ref colour);
		}

		/// <summary>
		/// 	Implements the operator +.
		/// </summary>
		/// <param name = "a">A.</param>
		/// <param name = "b">The b.</param>
		/// <returns>The result of the operator.</returns>
		public static Color operator +(Color a, Color b)
		{
			return Add(ref a, ref b);
		}

		/// <summary>
		/// 	Implements the operator -.
		/// </summary>
		/// <param name = "colour">The colour.</param>
		/// <param name = "scalar">The scalar.</param>
		/// <returns>The result of the operator.</returns>
		public static Color operator -(Color colour, float scalar)
		{
			return Subtract(ref colour, scalar);
		}

		/// <summary>
		/// 	Implements the operator -.
		/// </summary>
		/// <param name = "scalar">The scalar.</param>
		/// <param name = "colour">The colour.</param>
		/// <returns>The result of the operator.</returns>
		public static Color operator -(float scalar, Color colour)
		{
			return Subtract(scalar, ref colour);
		}

		/// <summary>
		/// 	Implements the operator -.
		/// </summary>
		/// <param name = "a">A.</param>
		/// <param name = "b">The b.</param>
		/// <returns>The result of the operator.</returns>
		public static Color operator -(Color a, Color b)
		{
			return Subtract(ref a, ref b);
		}

		/// <summary>
		/// 	Implements the operator *.
		/// </summary>
		/// <param name = "colour">The colour.</param>
		/// <param name = "scalar">The scalar.</param>
		/// <returns>The result of the operator.</returns>
		public static Color operator *(Color colour, float scalar)
		{
			return Multiply(ref colour, scalar);
		}

		/// <summary>
		/// 	Implements the operator *.
		/// </summary>
		/// <param name = "scalar">The scalar.</param>
		/// <param name = "colour">The colour.</param>
		/// <returns>The result of the operator.</returns>
		public static Color operator *(float scalar, Color colour)
		{
			return Multiply(scalar, ref colour);
		}

		/// <summary>
		/// 	Implements the operator *.
		/// </summary>
		/// <param name = "a">A.</param>
		/// <param name = "b">The b.</param>
		/// <returns>The result of the operator.</returns>
		public static Color operator *(Color a, Color b)
		{
			return Multiply(ref a, ref b);
		}

		/// <summary>
		/// 	Implements the operator /.
		/// </summary>
		/// <param name = "colour">The colour.</param>
		/// <param name = "scalar">The scalar.</param>
		/// <returns>The result of the operator.</returns>
		public static Color operator /(Color colour, float scalar)
		{
			return Divide(ref colour, scalar);
		}

		/// <summary>
		/// 	Implements the operator /.
		/// </summary>
		/// <param name = "scalar">The scalar.</param>
		/// <param name = "colour">The colour.</param>
		/// <returns>The result of the operator.</returns>
		public static Color operator /(float scalar, Color colour)
		{
			return Divide(scalar, ref colour);
		}

		/// <summary>
		/// 	Implements the operator /.
		/// </summary>
		/// <param name = "a">A.</param>
		/// <param name = "b">The b.</param>
		/// <returns>The result of the operator.</returns>
		public static Color operator /(Color a, Color b)
		{
			return Divide(ref a, ref b);
		}

		/// <summary>
		/// 	Implements the operator ==.
		/// </summary>
		/// <param name = "left">The left.</param>
		/// <param name = "right">The right.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(Color left, Color right)
		{
			return left.Equals(right);
		}

		/// <summary>
		/// 	Implements the operator !=.
		/// </summary>
		/// <param name = "left">The left.</param>
		/// <param name = "right">The right.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(Color left, Color right)
		{
			return !left.Equals(right);
		}

		#region Pre-defined colors

		public static Color Zero
		{
			get { return new Color(0, 0, 0, 0); }
		}

		public static Color Transparent
		{
			get { return new Color(0xff, 0xff, 0xff, 0); }
		}

		public static Color AliceBlue
		{
			get { return new Color(240, 0xf8, 0xff, 0xff); }
		}

		public static Color AntiqueWhite
		{
			get { return new Color(250, 0xeb, 0xd7, 0xff); }
		}

		public static Color Aqua
		{
			get { return new Color(0, 0xff, 0xff, 0xff); }
		}

		public static Color Aquamarine
		{
			get { return new Color(0x7f, 0xff, 0xd4, 0xff); }
		}

		public static Color Azure
		{
			get { return new Color(240, 0xff, 0xff, 0xff); }
		}

		public static Color Beige
		{
			get { return new Color(0xf5, 0xf5, 220, 0xff); }
		}

		public static Color Bisque
		{
			get { return new Color(0xff, 0xe4, 0xc4, 0xff); }
		}

		public static Color Black
		{
			get { return new Color(0, 0, 0, 0xff); }
		}

		public static Color BlanchedAlmond
		{
			get { return new Color(0xff, 0xeb, 0xcd, 0xff); }
		}

		public static Color Blue
		{
			get { return new Color(0, 0, 0xff, 0xff); }
		}

		public static Color BlueViolet
		{
			get { return new Color(0x8a, 0x2b, 0xe2, 0xff); }
		}

		public static Color Brown
		{
			get { return new Color(0xa5, 0x2a, 0x2a, 0xff); }
		}

		public static Color BurlyWood
		{
			get { return new Color(0xde, 0xb8, 0x87, 0xff); }
		}

		public static Color CadetBlue
		{
			get { return new Color(0x5f, 0x9e, 160, 0xff); }
		}

		public static Color Chartreuse
		{
			get { return new Color(0x7f, 0xff, 0, 0xff); }
		}

		public static Color Chocolate
		{
			get { return new Color(210, 0x69, 30, 0xff); }
		}

		public static Color Coral
		{
			get { return new Color(0xff, 0x7f, 80, 0xff); }
		}

		public static Color CornflowerBlue
		{
			get { return new Color(100, 0x95, 0xed, 0xff); }
		}

		public static Color Cornsilk
		{
			get { return new Color(0xff, 0xf8, 220, 0xff); }
		}

		public static Color Crimson
		{
			get { return new Color(220, 20, 60, 0xff); }
		}

		public static Color Cyan
		{
			get { return new Color(0, 0xff, 0xff, 0xff); }
		}

		public static Color DarkBlue
		{
			get { return new Color(0, 0, 0x8b, 0xff); }
		}

		public static Color DarkCyan
		{
			get { return new Color(0, 0x8b, 0x8b, 0xff); }
		}

		public static Color DarkGoldenrod
		{
			get { return new Color(0xb8, 0x86, 11, 0xff); }
		}

		public static Color DarkGray
		{
			get { return new Color(0xa9, 0xa9, 0xa9, 0xff); }
		}

		public static Color DarkGreen
		{
			get { return new Color(0, 100, 0, 0xff); }
		}

		public static Color DarkKhaki
		{
			get { return new Color(0xbd, 0xb7, 0x6b, 0xff); }
		}

		public static Color DarkMagenta
		{
			get { return new Color(0x8b, 0, 0x8b, 0xff); }
		}

		public static Color DarkOliveGreen
		{
			get { return new Color(0x55, 0x6b, 0x2f, 0xff); }
		}

		public static Color DarkOrange
		{
			get { return new Color(0xff, 140, 0, 0xff); }
		}

		public static Color DarkOrchid
		{
			get { return new Color(0x99, 50, 0xcc, 0xff); }
		}

		public static Color DarkRed
		{
			get { return new Color(0x8b, 0, 0, 0xff); }
		}

		public static Color DarkSalmon
		{
			get { return new Color(0xe9, 150, 0x7a, 0xff); }
		}

		public static Color DarkSeaGreen
		{
			get { return new Color(0x8f, 0xbc, 0x8b, 0xff); }
		}

		public static Color DarkSlateBlue
		{
			get { return new Color(0x48, 0x3d, 0x8b, 0xff); }
		}

		public static Color DarkSlateGray
		{
			get { return new Color(0x2f, 0x4f, 0x4f, 0xff); }
		}

		public static Color DarkTurquoise
		{
			get { return new Color(0, 0xce, 0xd1, 0xff); }
		}

		public static Color DarkViolet
		{
			get { return new Color(0x94, 0, 0xd3, 0xff); }
		}

		public static Color DeepPink
		{
			get { return new Color(0xff, 20, 0x93, 0xff); }
		}

		public static Color DeepSkyBlue
		{
			get { return new Color(0, 0xbf, 0xff, 0xff); }
		}

		public static Color DimGray
		{
			get { return new Color(0x69, 0x69, 0x69, 0xff); }
		}

		public static Color DodgerBlue
		{
			get { return new Color(30, 0x90, 0xff, 0xff); }
		}

		public static Color Firebrick
		{
			get { return new Color(0xb2, 0x22, 0x22, 0xff); }
		}

		public static Color FloralWhite
		{
			get { return new Color(0xff, 250, 240, 0xff); }
		}

		public static Color ForestGreen
		{
			get { return new Color(0x22, 0x8b, 0x22, 0xff); }
		}

		public static Color Fuchsia
		{
			get { return new Color(0xff, 0, 0xff, 0xff); }
		}

		public static Color Gainsboro
		{
			get { return new Color(220, 220, 220, 0xff); }
		}

		public static Color GhostWhite
		{
			get { return new Color(0xf8, 0xf8, 0xff, 0xff); }
		}

		public static Color Gold
		{
			get { return new Color(0xff, 0xd7, 0, 0xff); }
		}

		public static Color Goldenrod
		{
			get { return new Color(0xda, 0xa5, 0x20, 0xff); }
		}

		public static Color Gray
		{
			get { return new Color(0x80, 0x80, 0x80, 0xff); }
		}

		public static Color Green
		{
			get { return new Color(0, 0x80, 0, 0xff); }
		}

		public static Color GreenYellow
		{
			get { return new Color(0xad, 0xff, 0x2f, 0xff); }
		}

		public static Color Honeydew
		{
			get { return new Color(240, 0xff, 240, 0xff); }
		}

		public static Color HotPink
		{
			get { return new Color(0xff, 0x69, 180, 0xff); }
		}

		public static Color IndianRed
		{
			get { return new Color(0xcd, 0x5c, 0x5c, 0xff); }
		}

		public static Color Indigo
		{
			get { return new Color(0x4b, 0, 130, 0xff); }
		}

		public static Color Ivory
		{
			get { return new Color(0xff, 0xff, 240, 0xff); }
		}

		public static Color Khaki
		{
			get { return new Color(240, 230, 140, 0xff); }
		}

		public static Color Lavender
		{
			get { return new Color(230, 230, 250, 0xff); }
		}

		public static Color LavenderBlush
		{
			get { return new Color(0xff, 240, 0xf5, 0xff); }
		}

		public static Color LawnGreen
		{
			get { return new Color(0x7c, 0xfc, 0, 0xff); }
		}

		public static Color LemonChiffon
		{
			get { return new Color(0xff, 250, 0xcd, 0xff); }
		}

		public static Color LightBlue
		{
			get { return new Color(0xad, 0xd8, 230, 0xff); }
		}

		public static Color LightCoral
		{
			get { return new Color(240, 0x80, 0x80, 0xff); }
		}

		public static Color LightCyan
		{
			get { return new Color(0xe0, 0xff, 0xff, 0xff); }
		}

		public static Color LightGoldenrodYellow
		{
			get { return new Color(250, 250, 210, 0xff); }
		}

		public static Color LightGreen
		{
			get { return new Color(0x90, 0xee, 0x90, 0xff); }
		}

		public static Color LightGray
		{
			get { return new Color(0xd3, 0xd3, 0xd3, 0xff); }
		}

		public static Color LightPink
		{
			get { return new Color(0xff, 0xb6, 0xc1, 0xff); }
		}

		public static Color LightSalmon
		{
			get { return new Color(0xff, 160, 0x7a, 0xff); }
		}

		public static Color LightSeaGreen
		{
			get { return new Color(0x20, 0xb2, 170, 0xff); }
		}

		public static Color LightSkyBlue
		{
			get { return new Color(0x87, 0xce, 250, 0xff); }
		}

		public static Color LightSlateGray
		{
			get { return new Color(0x77, 0x88, 0x99, 0xff); }
		}

		public static Color LightSteelBlue
		{
			get { return new Color(0xb0, 0xc4, 0xde, 0xff); }
		}

		public static Color LightYellow
		{
			get { return new Color(0xff, 0xff, 0xe0, 0xff); }
		}

		public static Color Lime
		{
			get { return new Color(0, 0xff, 0, 0xff); }
		}

		public static Color LimeGreen
		{
			get { return new Color(50, 0xcd, 50, 0xff); }
		}

		public static Color Linen
		{
			get { return new Color(250, 240, 230, 0xff); }
		}

		public static Color Magenta
		{
			get { return new Color(0xff, 0, 0xff, 0xff); }
		}

		public static Color Maroon
		{
			get { return new Color(0x80, 0, 0, 0xff); }
		}

		public static Color MediumAquamarine
		{
			get { return new Color(0x66, 0xcd, 170, 0xff); }
		}

		public static Color MediumBlue
		{
			get { return new Color(0, 0, 0xcd, 0xff); }
		}

		public static Color MediumOrchid
		{
			get { return new Color(0xba, 0x55, 0xd3, 0xff); }
		}

		public static Color MediumPurple
		{
			get { return new Color(0x93, 0x70, 0xdb, 0xff); }
		}

		public static Color MediumSeaGreen
		{
			get { return new Color(60, 0xb3, 0x71, 0xff); }
		}

		public static Color MediumSlateBlue
		{
			get { return new Color(0x7b, 0x68, 0xee, 0xff); }
		}

		public static Color MediumSpringGreen
		{
			get { return new Color(0, 250, 0x9a, 0xff); }
		}

		public static Color MediumTurquoise
		{
			get { return new Color(0x48, 0xd1, 0xcc, 0xff); }
		}

		public static Color MediumVioletRed
		{
			get { return new Color(0xc7, 0x15, 0x85, 0xff); }
		}

		public static Color MidnightBlue
		{
			get { return new Color(0x19, 0x19, 0x70, 0xff); }
		}

		public static Color MintCream
		{
			get { return new Color(0xf5, 0xff, 250, 0xff); }
		}

		public static Color MistyRose
		{
			get { return new Color(0xff, 0xe4, 0xe1, 0xff); }
		}

		public static Color Moccasin
		{
			get { return new Color(0xff, 0xe4, 0xb5, 0xff); }
		}

		public static Color NavajoWhite
		{
			get { return new Color(0xff, 0xde, 0xad, 0xff); }
		}

		public static Color Navy
		{
			get { return new Color(0, 0, 0x80, 0xff); }
		}

		public static Color OldLace
		{
			get { return new Color(0xfd, 0xf5, 230, 0xff); }
		}

		public static Color Olive
		{
			get { return new Color(0x80, 0x80, 0, 0xff); }
		}

		public static Color OliveDrab
		{
			get { return new Color(0x6b, 0x8e, 0x23, 0xff); }
		}

		public static Color Orange
		{
			get { return new Color(0xff, 0xa5, 0, 0xff); }
		}

		public static Color OrangeRed
		{
			get { return new Color(0xff, 0x45, 0, 0xff); }
		}

		public static Color Orchid
		{
			get { return new Color(0xda, 0x70, 0xd6, 0xff); }
		}

		public static Color PaleGoldenrod
		{
			get { return new Color(0xee, 0xe8, 170, 0xff); }
		}

		public static Color PaleGreen
		{
			get { return new Color(0x98, 0xfb, 0x98, 0xff); }
		}

		public static Color PaleTurquoise
		{
			get { return new Color(0xaf, 0xee, 0xee, 0xff); }
		}

		public static Color PaleVioletRed
		{
			get { return new Color(0xdb, 0x70, 0x93, 0xff); }
		}

		public static Color PapayaWhip
		{
			get { return new Color(0xff, 0xef, 0xd5, 0xff); }
		}

		public static Color PeachPuff
		{
			get { return new Color(0xff, 0xda, 0xb9, 0xff); }
		}

		public static Color Peru
		{
			get { return new Color(0xcd, 0x85, 0x3f, 0xff); }
		}

		public static Color Pink
		{
			get { return new Color(0xff, 0xc0, 0xcb, 0xff); }
		}

		public static Color Plum
		{
			get { return new Color(0xdd, 160, 0xdd, 0xff); }
		}

		public static Color PowderBlue
		{
			get { return new Color(0xb0, 0xe0, 230, 0xff); }
		}

		public static Color Purple
		{
			get { return new Color(0x80, 0, 0x80, 0xff); }
		}

		public static Color Red
		{
			get { return new Color(0xff, 0, 0, 0xff); }
		}

		public static Color RosyBrown
		{
			get { return new Color(0xbc, 0x8f, 0x8f, 0xff); }
		}

		public static Color RoyalBlue
		{
			get { return new Color(0x41, 0x69, 0xe1, 0xff); }
		}

		public static Color SaddleBrown
		{
			get { return new Color(0x8b, 0x45, 0x13, 0xff); }
		}

		public static Color Salmon
		{
			get { return new Color(250, 0x80, 0x72, 0xff); }
		}

		public static Color SandyBrown
		{
			get { return new Color(0xf4, 0xa4, 0x60, 0xff); }
		}

		public static Color SeaGreen
		{
			get { return new Color(0x2e, 0x8b, 0x57, 0xff); }
		}

		public static Color SeaShell
		{
			get { return new Color(0xff, 0xf5, 0xee, 0xff); }
		}

		public static Color Sienna
		{
			get { return new Color(160, 0x52, 0x2d, 0xff); }
		}

		public static Color Silver
		{
			get { return new Color(0xc0, 0xc0, 0xc0, 0xff); }
		}

		public static Color SkyBlue
		{
			get { return new Color(0x87, 0xce, 0xeb, 0xff); }
		}

		public static Color SlateBlue
		{
			get { return new Color(0x6a, 90, 0xcd, 0xff); }
		}

		public static Color SlateGray
		{
			get { return new Color(0x70, 0x80, 0x90, 0xff); }
		}

		public static Color Snow
		{
			get { return new Color(0xff, 250, 250, 0xff); }
		}

		public static Color SpringGreen
		{
			get { return new Color(0, 0xff, 0x7f, 0xff); }
		}

		public static Color SteelBlue
		{
			get { return new Color(70, 130, 180, 0xff); }
		}

		public static Color Tan
		{
			get { return new Color(210, 180, 140, 0xff); }
		}

		public static Color Teal
		{
			get { return new Color(0, 0x80, 0x80, 0xff); }
		}

		public static Color Thistle
		{
			get { return new Color(0xd8, 0xbf, 0xd8, 0xff); }
		}

		public static Color Tomato
		{
			get { return new Color(0xff, 0x63, 0x47, 0xff); }
		}

		public static Color Turquoise
		{
			get { return new Color(0x40, 0xe0, 0xd0, 0xff); }
		}

		public static Color Violet
		{
			get { return new Color(0xee, 130, 0xee, 0xff); }
		}

		public static Color Wheat
		{
			get { return new Color(0xf5, 0xde, 0xb3, 0xff); }
		}

		public static Color White
		{
			get { return new Color(0xff, 0xff, 0xff, 0xff); }
		}

		public static Color WhiteSmoke
		{
			get { return new Color(0xf5, 0xf5, 0xf5, 0xff); }
		}

		public static Color Yellow
		{
			get { return new Color(0xff, 0xff, 0, 0xff); }
		}

		public static Color YellowGreen
		{
			get { return new Color(0x9a, 0xcd, 50, 0xff); }
		}

		#endregion

		/// <summary>
		/// This method is reserved and should not be used. When implementing the IXmlSerializable interface, you should return null (Nothing in Visual Basic) from this method, and instead, if specifying a custom schema is required, apply the <see cref="T:System.Xml.Serialization.XmlSchemaProviderAttribute"/> to the class.
		/// </summary>
		/// <returns>
		/// An <see cref="T:System.Xml.Schema.XmlSchema"/> that describes the XML representation of the object that is produced by the <see cref="M:System.Xml.Serialization.IXmlSerializable.WriteXml(System.Xml.XmlWriter)"/> method and consumed by the <see cref="M:System.Xml.Serialization.IXmlSerializable.ReadXml(System.Xml.XmlReader)"/> method.
		/// </returns>
		public XmlSchema GetSchema()
		{
			return null;
		}

		/// <summary>
		/// Generates an object from its XML representation.
		/// </summary>
		/// <param name="reader">The <see cref="T:System.Xml.XmlReader"/> stream from which the object is deserialized. </param>
		public void ReadXml(XmlReader reader)
		{
			if (!reader.MoveToAttribute("value"))
				throw new XmlSyntaxException("Expected value attribute");

			var value = reader.Value;

			if (!value.StartsWith("#"))
				throw new XmlSyntaxException("Expected value in format #00000000 (RGBA)");

			for (int i = value.Length; i < 9; i++)
			{
				value += "0";
			}

			RGBA = Convert.ToUInt32(value.Substring(1), 16);
		}

		/// <summary>
		/// Converts an object into its XML representation.
		/// </summary>
		/// <param name="writer">The <see cref="T:System.Xml.XmlWriter"/> stream to which the object is serialized. </param>
		public void WriteXml(XmlWriter writer)
		{
			writer.WriteAttributeString("value", "#" + RGBA.ToString("X"));
		}
	}
}