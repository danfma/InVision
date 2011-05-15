using System;
using System.Text;

namespace InVision.Extensions
{
	public static class StringExtensions
	{
		/// <summary>
		/// Toes the pascal case.
		/// </summary>
		/// <param name="this">The @this.</param>
		/// <returns></returns>
		public static string ToPascalCase(this string @this)
		{
			if (string.IsNullOrEmpty(@this))
				return @this;

			return Char.ToUpper(@this[0]) + (@this.Length > 1 ? @this.Substring(1) : string.Empty);
		}

		/// <summary>
		/// Toes the camel case.
		/// </summary>
		/// <param name="this">The @this.</param>
		/// <returns></returns>
		public static string ToCamelCase(this string @this)
		{
			if (string.IsNullOrEmpty(@this))
				return @this;

			return Char.ToLower(@this[0]) + (@this.Length > 1 ? @this.Substring(1) : string.Empty);
		}

		/// <summary>
		/// Toes the C style.
		/// </summary>
		/// <param name="this">The @this.</param>
		/// <returns></returns>
		public static string ToCStyle(this string @this)
		{
			if (string.IsNullOrEmpty(@this))
				return @this;


			bool lastConverted = true;
			char lastChar = @this[0];

			var builder = new StringBuilder(@this.Length);
			builder.Append(Char.ToLower(lastChar));

			for (int i = 1; i < @this.Length; i++)
			{
				char chr = @this[i];

				if (lastConverted && Char.IsUpper(chr))
				{
					builder.Append(lastChar = Char.ToLower(chr));
				}
				else if (!lastConverted && Char.IsUpper(chr))
				{
					if (lastChar != '_')
						builder.Append("_");

					lastConverted = true;
					builder.AppendFormat("{0}", lastChar = Char.ToLower(chr));
				}
				else
				{
					lastConverted = false;
					builder.Append(lastChar = Char.ToLower(chr));
				}
			}

			return builder.ToString();
		}
	}
}