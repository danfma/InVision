using System;
using System.Linq.Expressions;
using System.Reflection;

namespace InVision.Extensions
{
	public static class ExpressionExtensions
	{
		/// <summary>
		/// Gets the name of the property.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <typeparam name="U"></typeparam>
		/// <param name="obj">The obj.</param>
		/// <param name="expression">The expression.</param>
		/// <returns></returns>
		public static string GetMemberName<T, U>(this T obj, Expression<Func<T, U>> expression)
		{
			return GetMemberName(expression.Body);
		}

		/// <summary>
		/// Gets the name of the member.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="obj">The obj.</param>
		/// <param name="expression">The expression.</param>
		/// <returns></returns>
		public static string GetMemberName<T>(this T obj, Expression<Action<T>> expression)
		{
			return GetMemberName(expression.Body);
		}

		/// <summary>
		/// Gets the name of the member.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="expression">The expression.</param>
		/// <returns></returns>
		public static string GetMemberName<T>(this Expression<Action<T>> expression)
		{
			return GetMemberName(expression.Body);
		}

		/// <summary>
		/// Gets the name of the member.
		/// </summary>
		/// <param name="expression">The expression.</param>
		/// <returns></returns>
		public static string GetMemberName(this Expression<Action> expression)
		{
			return GetMemberName(expression.Body);
		}

		/// <summary>
		/// Gets the name of the member.
		/// </summary>
		/// <param name="expression">The expression.</param>
		/// <returns></returns>
		private static string GetMemberName(Expression expression)
		{
			string memberName;

			if (expression is MemberExpression)
			{
				var memberExpression = (MemberExpression)expression;

				memberName = memberExpression.Member.Name;

			}
			else if (expression is MethodCallExpression)
			{
				var methodCallExpression = (MethodCallExpression)expression;

				memberName = methodCallExpression.Method.Name;

			}
			else
				throw new InvalidOperationException();

			return memberName;
		}

		/// <summary>
		/// Gets the name of the member by.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="selector">The selection.</param>
		/// <returns></returns>
		public static MemberInfo GetMemberByName<T>(this Expression<Action<T>> selector)
		{
			var body = selector.Body;

			return GetMemberByName(body);
		}

		/// <summary>
		/// Gets the name of the member by.
		/// </summary>
		/// <param name="action">The action.</param>
		/// <returns></returns>
		public static MemberInfo GetMemberByName(this Expression<Action> action)
		{
			return GetMemberByName(action.Body);
		}

		/// <summary>
		/// Gets the name of the member by.
		/// </summary>
		/// <param name="body">The body.</param>
		/// <returns></returns>
		private static MemberInfo GetMemberByName(Expression body)
		{
			MemberInfo member = null;

			if (body is MemberExpression)
			{
				var memberExpression = (MemberExpression)body;

				member = memberExpression.Member;
			}
			else if (body is MethodCallExpression)
			{
				var methodCallExpression = (MethodCallExpression)body;

				member = methodCallExpression.Method;
			}
			else
				throw new InvalidOperationException();

			return member;
		}
	}
}