using System;
using System.Collections.Generic;
using System.Text;

namespace InVision.Extensions
{
	public static class UtilityExtensions
	{
		/// <summary>
		/// Fors the each.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="items">The items.</param>
		/// <param name="action">The action.</param>
		public static IEnumerable<T> ForEach<T>(this IEnumerable<T> items, Action<T> action)
		{
			foreach (T item in items)
			{
				action(item);
				yield return item;
			}
		}

		/// <summary>
		/// Glues the with.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="items">The items.</param>
		/// <param name="glue">The glue.</param>
		/// <returns></returns>
		public static string GlueWith<T>(this IEnumerable<T> items, string glue)
		{
			if (items is IList<T>)
				return ((IList<T>)items).GlueWith(glue);

			var builder = new StringBuilder();

			foreach (T item in items)
			{
				builder.AppendFormat("{0}{1}", item, glue);
			}

			return builder.Remove(builder.Length - glue.Length, glue.Length).ToString();
		}

		/// <summary>
		/// Glues the with.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="items">The items.</param>
		/// <param name="glue">The glue.</param>
		/// <returns></returns>
		public static string GlueWith<T>(this IList<T> items, string glue)
		{
			var builder = new StringBuilder();

			for (int i = 0; i < items.Count; i++)
			{
				builder.Append(items[i]);

				if (i < items.Count - 1)
					builder.Append(glue);
			}

			return builder.ToString();
		}
	}
}