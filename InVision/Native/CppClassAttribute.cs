using System;
using System.Collections.Generic;
using System.Linq;
using InVision.Extensions;

namespace InVision.Native
{
	public class CppClassAttribute : CppTypeAttribute
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="CppClassAttribute"/> class.
		/// </summary>
		public CppClassAttribute()
		{
			Type = ClassType.Concrete;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="CppClassAttribute"/> class.
		/// </summary>
		/// <param name="typename">The typename.</param>
		public CppClassAttribute(string typename)
			: base(typename)
		{
			Type = ClassType.Concrete;
		}

		/// <summary>
		/// Gets or sets the type of the interface.
		/// </summary>
		/// <value>The type of the interface.</value>
		public ClassType Type { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether this instance is abstract.
		/// </summary>
		/// <value>
		/// 	<c>true</c> if this instance is abstract; otherwise, <c>false</c>.
		/// </value>
		public bool IsAbstract { get; set; }

		/// <summary>
		/// Gets or sets the type of the descriptor.
		/// </summary>
		/// <value>The type of the descriptor.</value>
		public Type DescriptorType { get; set; }

		/// <summary>
		/// Gets or sets the type of the base.
		/// </summary>
		/// <value>The type of the base.</value>
		public Type BaseType { get; set; }

		/// <summary>
		/// Gets the type of the base.
		/// </summary>
		/// <param name="wrapperType">Type of the wrapper.</param>
		/// <returns></returns>
		public static Type GetBaseType(Type wrapperType)
		{
			var @interfaces =
				from @interface in wrapperType.GetInterfaces()
				where @interface.QueryAttribute<CppClassAttribute>(attr => attr.Type != ClassType.Interface)
				select @interface;

			if (@interfaces.Count() <= 1)
				return @interfaces.SingleOrDefault();

			return wrapperType.GetAttribute<CppClassAttribute>(true).BaseType;
		}

		/// <summary>
		/// Gets the interfaces.
		/// </summary>
		/// <param name="wrapperType">Type of the wrappper.</param>
		/// <param name="includeWrapperType">if set to <c>true</c> [include wrapper type].</param>
		/// <returns></returns>
		public static IEnumerable<Type> GetInterfaces(Type wrapperType, bool includeWrapperType = true)
		{
			var baseType = GetBaseType(wrapperType);

			var @interfaces =
				from @interface in wrapperType.GetInterfaces()
				where
					@interface.QueryAttribute<CppClassAttribute>(attr => attr.Type == ClassType.Interface) &&
					@interface != baseType
				select @interface;

			if (includeWrapperType)
				yield return wrapperType;

			foreach (var @interface in interfaces)
			{
				yield return @interface;
			}
		}
	}
}