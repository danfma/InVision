using System;
using System.Collections.Generic;
using System.Linq;
using Boo.Lang.Compiler;
using InVision.Framework.Scripting;

namespace InVision.Scripting.Boo
{
	internal abstract class ScriptableServiceFactory
	{
		/// <summary>
		/// Gets or sets the factories.
		/// </summary>
		/// <value>The factories.</value>
		public static readonly Dictionary<Type, ScriptableServiceFactory> Factories;

		/// <summary>
		/// Initializes the <see cref="ScriptableServiceFactory"/> class.
		/// </summary>
		static ScriptableServiceFactory()
		{
			Factories = new Dictionary<Type, ScriptableServiceFactory>();
		}

		/// <summary>
		/// Finds the specified context.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="context">The context.</param>
		/// <param name="script">The script.</param>
		/// <returns></returns>
		public static IEnumerable<T> Find<T>(CompilerContext context, IScript script) where T : IScriptable
		{
			ScriptableServiceFactory factory;

			if (context == null || context.GeneratedAssembly == null || !Factories.TryGetValue(typeof(T), out factory))
				return Enumerable.Empty<T>();

			return factory.FindServices<T>(context, script);
		}

		/// <summary>
		/// Finds the services.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="context">The context.</param>
		/// <param name="script"></param>
		/// <returns></returns>
		public abstract IEnumerable<T> FindServices<T>(CompilerContext context, IScript script) where T : IScriptable;
	}
}