using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using InVision.Ogre.Util;

namespace InVision.Ogre
{
	/// <summary>
	/// 	Class representing colour.
	/// 	<remarks>
	/// 		Colour is represented as 4 components, each of which is a floating-point value from 0.0 to 1.0.
	/// 		The 3 'normal' colour components are red, green and blue, a higher number indicating greater amounts of that component in the colour. The forth component is the 'alpha' value, which represents transparency. In this case, 0.0 is completely transparent and 1.0 is fully opaque.
	/// 	</remarks>
	/// </summary>
	[Serializable, StructLayout(LayoutKind.Explicit, Size = 16)]
	public struct ColourValue : IEquatable<ColourValue>
	{
		[FieldOffset(0)]
		public float Red;

		[FieldOffset(4)]
		public float Green;

		[FieldOffset(8)]
		public float Blue;

		[FieldOffset(12)]
		public float Alpha;

		/// <summary>
		/// 	Initializes a new instance of the <see cref = "ColourValue" /> struct.
		/// </summary>
		/// <param name = "red">The red.</param>
		/// <param name = "green">The green.</param>
		/// <param name = "blue">The blue.</param>
		/// <param name = "alpha">The alpha.</param>
		public ColourValue(byte red, byte green, byte blue, byte alpha)
			: this(red / 255f, green / 255f, blue / 255f, alpha / 255f)
		{
		}

		/// <summary>
		/// 	Initializes a new instance of the <see cref = "ColourValue" /> struct.
		/// </summary>
		/// <param name = "red">The red.</param>
		/// <param name = "green">The green.</param>
		/// <param name = "blue">The blue.</param>
		/// <param name = "alpha">The alpha.</param>
		public ColourValue(float red = 1f, float green = 1f, float blue = 1f, float alpha = 1f)
			: this()
		{
			Red = red;
			Green = green;
			Blue = blue;
			Alpha = alpha;
		}

		/// <summary>
		/// 	Gets the RGBA.
		/// </summary>
		/// <value>The RGBA.</value>
		public uint RGBA
		{
			get { return ColourRepresentation.Instance.ToInt32(Red, Green, Blue, Alpha); }
			set { ColourRepresentation.Instance.FromInt32(value, out Red, out Green, out Blue, out Alpha); }
		}

		/// <summary>
		/// 	Gets or sets the ARGB.
		/// </summary>
		/// <value>The ARGB.</value>
		public uint ARGB
		{
			get { return ColourRepresentation.Instance.ToInt32(Alpha, Red, Green, Blue); }
			set { ColourRepresentation.Instance.FromInt32(value, out Alpha, out Red, out Green, out Blue); }
		}

		/// <summary>
		/// 	Gets or sets the BGRA.
		/// </summary>
		/// <value>The BGRA.</value>
		public uint BGRA
		{
			get { return ColourRepresentation.Instance.ToInt32(Blue, Green, Red, Alpha); }
			set { ColourRepresentation.Instance.FromInt32(value, out Blue, out Green, out Red, out Alpha); }
		}

		/// <summary>
		/// 	Gets or sets the ABGR.
		/// </summary>
		/// <value>The ABGR.</value>
		public uint ABGR
		{
			get { return ColourRepresentation.Instance.ToInt32(Alpha, Blue, Green, Red); }
			set { ColourRepresentation.Instance.FromInt32(value, out Alpha, out Blue, out Green, out Red); }
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
						return Red;

					case 1:
						return Green;

					case 2:
						return Blue;

					case 3:
						return Alpha;

					default:
						throw new IndexOutOfRangeException();
				}
			}
			set
			{
				switch (index)
				{
					case 0:
						Red = value;
						break;

					case 1:
						Green = value;
						break;

					case 2:
						Blue = value;
						break;

					case 3:
						Alpha = value;
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
			Red = MathUtility.Clamp(Red, 0, 1);
			Green = MathUtility.Clamp(Green, 0, 1);
			Blue = MathUtility.Clamp(Blue, 0, 1);
			Alpha = MathUtility.Clamp(Alpha, 0, 1);
		}

		/// <summary>
		/// 	Saturates the copy.
		/// </summary>
		/// <returns></returns>
		public ColourValue SaturateCopy()
		{
			ColourValue copy = this;
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
			saturation = MathUtility.Clamp(saturation, 0, 1);
			brightness = MathUtility.Clamp(brightness, 0, 1);

			if (brightness == 0)
			{
				Red = Green = Blue = 0f;
				return;
			}

			if (saturation == 0)
			{
				Red = Green = Blue = brightness;
				return;
			}

			float hueDomain = hue * 6f;

			if (hueDomain >= 6f)
				hueDomain = 0f; // wrap around and allow mathematical errors

			ushort domain = (ushort)hueDomain;

			float f1 = brightness * (1 - saturation);
			float f2 = brightness * (1 - saturation * (hueDomain - domain));
			float f3 = brightness * (1 - saturation * (1 - (hueDomain - domain)));

			switch (domain)
			{
				case 0:
					// red domain: green ascends
					Red = brightness;
					Green = f3;
					Blue = f1;
					break;

				case 1:
					// yellow domain: red descends
					Red = f2;
					Green = brightness;
					Blue = f1;
					break;

				case 2:
					// green domain: blue ascends
					Red = f1;
					Green = brightness;
					Blue = f2;
					break;

				case 3:
					// cyan domain: green descends
					Red = f1;
					Green = f2;
					Blue = brightness;
					break;

				case 4:
					// blue domain: red ascends
					Red = f3;
					Green = f1;
					Blue = brightness;
					break;

				case 5:
					// magenta domain: blue descends
					Red = brightness;
					Green = f1;
					Blue = f2;
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
			float vMin = Math.Min(Red, Math.Min(Green, Blue));
			float vMax = Math.Max(Red, Math.Max(Green, Blue));
			float delta = vMax - vMin;

			brightness = vMax;

			if (MathUtility.Equal(delta, 0f, (float)1e-6))
			{
				hue = 0;
				saturation = 0;
			}
			else
			{
				hue = 0;
				saturation = delta / vMax;

				float deltaR = (((vMax - Red) / 6f) + (delta / 2f)) / delta;
				float deltaG = (((vMax - Green) / 6f) + (delta / 2f)) / delta;
				float deltaB = (((vMax - Blue) / 6f) + (delta / 2f)) / delta;

				if (MathUtility.Equal(Red, vMax))
					hue = deltaB - deltaG;
				else if (MathUtility.Equal(Green, vMax))
					hue = 0.3333333f + deltaR - deltaB;
				else if (MathUtility.Equal(brightness, vMax))
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
		public ColourValue Add(float scalar)
		{
			return Add(ref this, scalar);
		}

		/// <summary>
		/// 	Adds the specified other.
		/// </summary>
		/// <param name = "other">The other.</param>
		/// <returns></returns>
		public ColourValue Add(ColourValue other)
		{
			return Add(ref this, ref other);
		}

		/// <summary>
		/// 	Subtracts the specified scalar.
		/// </summary>
		/// <param name = "scalar">The scalar.</param>
		/// <returns></returns>
		public ColourValue Subtract(float scalar)
		{
			return Subtract(ref this, scalar);
		}

		/// <summary>
		/// 	Subtracts the specified other.
		/// </summary>
		/// <param name = "other">The other.</param>
		/// <returns></returns>
		public ColourValue Subtract(ColourValue other)
		{
			return Subtract(ref this, ref other);
		}

		/// <summary>
		/// 	Multiplies the specified scalar.
		/// </summary>
		/// <param name = "scalar">The scalar.</param>
		/// <returns></returns>
		public ColourValue Multiply(float scalar)
		{
			return Multiply(ref this, scalar);
		}

		/// <summary>
		/// 	Multiplies the specified other.
		/// </summary>
		/// <param name = "other">The other.</param>
		/// <returns></returns>
		public ColourValue Multiply(ColourValue other)
		{
			return Multiply(ref this, ref other);
		}

		/// <summary>
		/// 	Divides the specified scalar.
		/// </summary>
		/// <param name = "scalar">The scalar.</param>
		/// <returns></returns>
		public ColourValue Divide(float scalar)
		{
			return Divide(ref this, scalar);
		}

		/// <summary>
		/// 	Divides the specified other.
		/// </summary>
		/// <param name = "other">The other.</param>
		/// <returns></returns>
		public ColourValue Divide(ColourValue other)
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
			return string.Format("ColourValue({0}, {1}, {2}, {3})", Red, Green, Blue, Alpha);
		}

		/// <summary>
		/// 	Indicates whether the current object is equal to another object of the same type.
		/// </summary>
		/// <returns>
		/// 	true if the current object is equal to the <paramref name = "other" /> parameter; otherwise, false.
		/// </returns>
		/// <param name = "other">An object to compare with this object.</param>
		public bool Equals(ColourValue other)
		{
			return other.Red.Equals(Red) && other.Green.Equals(Green) && other.Blue.Equals(Blue) && other.Alpha.Equals(Alpha);
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
			if (obj.GetType() != typeof(ColourValue)) return false;

			return Equals((ColourValue)obj);
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
				int result = Red.GetHashCode();
				result = (result * 397) ^ Green.GetHashCode();
				result = (result * 397) ^ Blue.GetHashCode();
				result = (result * 397) ^ Alpha.GetHashCode();

				return result;
			}
		}

		/// <summary>
		/// 	Adds the specified colour.
		/// </summary>
		/// <param name = "colour">The colour.</param>
		/// <param name = "scalar">The scalar.</param>
		/// <returns></returns>
		public static ColourValue Add(ref ColourValue colour, float scalar)
		{
			colour.Red += scalar;
			colour.Green += scalar;
			colour.Blue += scalar;
			colour.Alpha += scalar;

			return colour;
		}

		/// <summary>
		/// 	Adds the specified scalar.
		/// </summary>
		/// <param name = "scalar">The scalar.</param>
		/// <param name = "colour">The colour.</param>
		/// <returns></returns>
		public static ColourValue Add(float scalar, ref ColourValue colour)
		{
			colour.Red = scalar + colour.Red;
			colour.Green = scalar + colour.Green;
			colour.Blue = scalar + colour.Blue;
			colour.Alpha = scalar + colour.Alpha;

			return colour;
		}

		/// <summary>
		/// 	Adds the specified a.
		/// </summary>
		/// <param name = "a">A.</param>
		/// <param name = "b">The b.</param>
		/// <returns></returns>
		public static ColourValue Add(ref ColourValue a, ref ColourValue b)
		{
			a.Red += b.Red;
			a.Green += b.Green;
			a.Blue += b.Blue;
			a.Alpha += b.Alpha;

			return a;
		}

		/// <summary>
		/// 	Subtracts the specified colour.
		/// </summary>
		/// <param name = "colour">The colour.</param>
		/// <param name = "scalar">The scalar.</param>
		/// <returns></returns>
		public static ColourValue Subtract(ref ColourValue colour, float scalar)
		{
			colour.Red -= scalar;
			colour.Green -= scalar;
			colour.Blue -= scalar;
			colour.Alpha -= scalar;

			return colour;
		}

		/// <summary>
		/// 	Subtracts the specified scalar.
		/// </summary>
		/// <param name = "scalar">The scalar.</param>
		/// <param name = "colour">The colour.</param>
		/// <returns></returns>
		public static ColourValue Subtract(float scalar, ref ColourValue colour)
		{
			colour.Red = scalar - colour.Red;
			colour.Green = scalar - colour.Green;
			colour.Blue = scalar - colour.Blue;
			colour.Alpha = scalar - colour.Alpha;

			return colour;
		}

		/// <summary>
		/// 	Substracts the specified a.
		/// </summary>
		/// <param name = "a">A.</param>
		/// <param name = "b">The b.</param>
		/// <returns></returns>
		public static ColourValue Subtract(ref ColourValue a, ref ColourValue b)
		{
			a.Red -= b.Red;
			a.Green -= b.Green;
			a.Blue -= b.Blue;
			a.Alpha -= b.Alpha;

			return a;
		}

		/// <summary>
		/// 	Multiplies the specified colour.
		/// </summary>
		/// <param name = "colour">The colour.</param>
		/// <param name = "scalar">The scalar.</param>
		/// <returns></returns>
		public static ColourValue Multiply(ref ColourValue colour, float scalar)
		{
			colour.Red *= scalar;
			colour.Green *= scalar;
			colour.Blue *= scalar;
			colour.Alpha *= scalar;

			return colour;
		}

		/// <summary>
		/// 	Multiplies the specified scalar.
		/// </summary>
		/// <param name = "scalar">The scalar.</param>
		/// <param name = "colour">The colour.</param>
		/// <returns></returns>
		public static ColourValue Multiply(float scalar, ref ColourValue colour)
		{
			colour.Red = scalar * colour.Red;
			colour.Green = scalar * colour.Green;
			colour.Blue = scalar * colour.Blue;
			colour.Alpha = scalar * colour.Alpha;

			return colour;
		}

		/// <summary>
		/// 	Multiplies the specified a.
		/// </summary>
		/// <param name = "a">A.</param>
		/// <param name = "b">The b.</param>
		/// <returns></returns>
		public static ColourValue Multiply(ref ColourValue a, ref ColourValue b)
		{
			a.Red *= b.Red;
			a.Green *= b.Green;
			a.Blue *= b.Blue;
			a.Alpha *= b.Alpha;

			return a;
		}

		/// <summary>
		/// 	Divides the specified colour.
		/// </summary>
		/// <param name = "colour">The colour.</param>
		/// <param name = "scalar">The scalar.</param>
		/// <returns></returns>
		public static ColourValue Divide(ref ColourValue colour, float scalar)
		{
			Debug.Assert(scalar != 0);

			colour.Red /= scalar;
			colour.Green /= scalar;
			colour.Blue /= scalar;
			colour.Alpha /= scalar;

			return colour;
		}

		/// <summary>
		/// 	Divides the specified scalar.
		/// </summary>
		/// <param name = "scalar">The scalar.</param>
		/// <param name = "colour">The colour.</param>
		/// <returns></returns>
		public static ColourValue Divide(float scalar, ref ColourValue colour)
		{
			colour.Red = scalar / colour.Red;
			colour.Green = scalar / colour.Green;
			colour.Blue = scalar / colour.Blue;
			colour.Alpha = scalar / colour.Alpha;

			return colour;
		}

		/// <summary>
		/// 	Divides the specified a.
		/// </summary>
		/// <param name = "a">A.</param>
		/// <param name = "b">The b.</param>
		/// <returns></returns>
		public static ColourValue Divide(ref ColourValue a, ref ColourValue b)
		{
			a.Red /= b.Red;
			a.Green /= b.Green;
			a.Blue /= b.Blue;
			a.Alpha /= b.Alpha;

			return a;
		}


		/// <summary>
		/// 	Implements the operator +.
		/// </summary>
		/// <param name = "colour">The colour.</param>
		/// <param name = "scalar">The scalar.</param>
		/// <returns>The result of the operator.</returns>
		public static ColourValue operator +(ColourValue colour, float scalar)
		{
			return Add(ref colour, scalar);
		}

		/// <summary>
		/// 	Implements the operator +.
		/// </summary>
		/// <param name = "scalar">The scalar.</param>
		/// <param name = "colour">The colour.</param>
		/// <returns>The result of the operator.</returns>
		public static ColourValue operator +(float scalar, ColourValue colour)
		{
			return Add(scalar, ref colour);
		}

		/// <summary>
		/// 	Implements the operator +.
		/// </summary>
		/// <param name = "a">A.</param>
		/// <param name = "b">The b.</param>
		/// <returns>The result of the operator.</returns>
		public static ColourValue operator +(ColourValue a, ColourValue b)
		{
			return Add(ref a, ref b);
		}

		/// <summary>
		/// 	Implements the operator -.
		/// </summary>
		/// <param name = "colour">The colour.</param>
		/// <param name = "scalar">The scalar.</param>
		/// <returns>The result of the operator.</returns>
		public static ColourValue operator -(ColourValue colour, float scalar)
		{
			return Subtract(ref colour, scalar);
		}

		/// <summary>
		/// 	Implements the operator -.
		/// </summary>
		/// <param name = "scalar">The scalar.</param>
		/// <param name = "colour">The colour.</param>
		/// <returns>The result of the operator.</returns>
		public static ColourValue operator -(float scalar, ColourValue colour)
		{
			return Subtract(scalar, ref colour);
		}

		/// <summary>
		/// 	Implements the operator -.
		/// </summary>
		/// <param name = "a">A.</param>
		/// <param name = "b">The b.</param>
		/// <returns>The result of the operator.</returns>
		public static ColourValue operator -(ColourValue a, ColourValue b)
		{
			return Subtract(ref a, ref b);
		}

		/// <summary>
		/// 	Implements the operator *.
		/// </summary>
		/// <param name = "colour">The colour.</param>
		/// <param name = "scalar">The scalar.</param>
		/// <returns>The result of the operator.</returns>
		public static ColourValue operator *(ColourValue colour, float scalar)
		{
			return Multiply(ref colour, scalar);
		}

		/// <summary>
		/// 	Implements the operator *.
		/// </summary>
		/// <param name = "scalar">The scalar.</param>
		/// <param name = "colour">The colour.</param>
		/// <returns>The result of the operator.</returns>
		public static ColourValue operator *(float scalar, ColourValue colour)
		{
			return Multiply(scalar, ref colour);
		}

		/// <summary>
		/// 	Implements the operator *.
		/// </summary>
		/// <param name = "a">A.</param>
		/// <param name = "b">The b.</param>
		/// <returns>The result of the operator.</returns>
		public static ColourValue operator *(ColourValue a, ColourValue b)
		{
			return Multiply(ref a, ref b);
		}

		/// <summary>
		/// 	Implements the operator /.
		/// </summary>
		/// <param name = "colour">The colour.</param>
		/// <param name = "scalar">The scalar.</param>
		/// <returns>The result of the operator.</returns>
		public static ColourValue operator /(ColourValue colour, float scalar)
		{
			return Divide(ref colour, scalar);
		}

		/// <summary>
		/// 	Implements the operator /.
		/// </summary>
		/// <param name = "scalar">The scalar.</param>
		/// <param name = "colour">The colour.</param>
		/// <returns>The result of the operator.</returns>
		public static ColourValue operator /(float scalar, ColourValue colour)
		{
			return Divide(scalar, ref colour);
		}

		/// <summary>
		/// 	Implements the operator /.
		/// </summary>
		/// <param name = "a">A.</param>
		/// <param name = "b">The b.</param>
		/// <returns>The result of the operator.</returns>
		public static ColourValue operator /(ColourValue a, ColourValue b)
		{
			return Divide(ref a, ref b);
		}

		/// <summary>
		/// 	Implements the operator ==.
		/// </summary>
		/// <param name = "left">The left.</param>
		/// <param name = "right">The right.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(ColourValue left, ColourValue right)
		{
			return left.Equals(right);
		}

		/// <summary>
		/// 	Implements the operator !=.
		/// </summary>
		/// <param name = "left">The left.</param>
		/// <param name = "right">The right.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(ColourValue left, ColourValue right)
		{
			return !left.Equals(right);
		}
	}
}