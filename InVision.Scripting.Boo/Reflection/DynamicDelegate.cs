using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;

namespace InVision.Scripting.Boo.Reflection
{
	public class DynamicDelegate
	{
		private static readonly ConcurrentDictionary<DynamicDelegateKey, Type> Delegates =
			new ConcurrentDictionary<DynamicDelegateKey, Type>();

		private static ulong _createdDelegatesCount;

		private readonly DynamicDelegateKey _key;
		private readonly MethodInfo _method;

		/// <summary>
		/// Initializes a new instance of the <see cref="DynamicDelegate"/> class.
		/// </summary>
		/// <param name="method">The method.</param>
		public DynamicDelegate(MethodInfo method)
		{
			_method = method;
			_key = CreateSignatureKey(method);
		}

		/// <summary>
		/// Creates the signature key.
		/// </summary>
		/// <param name="method">The method.</param>
		/// <returns></returns>
		private static DynamicDelegateKey CreateSignatureKey(MethodInfo method)
		{
			var nameBuilder = new StringBuilder();
			IEnumerable<Type> parameters = method.GetParameters().Select(p => p.ParameterType);
			Type first = parameters.FirstOrDefault();

			nameBuilder.AppendFormat("{0} (", method.ReturnType);

			if (first != null)
				nameBuilder.Append(first);

			foreach (Type parameterType in parameters.Skip(1))
			{
				nameBuilder.AppendFormat(", {0}", parameterType);
			}

			nameBuilder.Append(")");

			byte[] signatureBytes = SHA1.Create().ComputeHash(
				Encoding.Default.GetBytes(nameBuilder.ToString()));

			return new DynamicDelegateKey(signatureBytes);
		}

		/// <summary>
		/// Compiles this instance.
		/// </summary>
		/// <returns></returns>
		public Type CreateType()
		{
			return Delegates.GetOrAdd(_key, CreateDelegate);
		}

		/// <summary>
		/// Creates the delegate.
		/// </summary>
		/// <param name="key">The key.</param>
		/// <returns></returns>
		private Type CreateDelegate(DynamicDelegateKey key)
		{
			var assembly = new AssemblyName {
			                                	Version = new Version(0, 1, 0, 0),
			                                	Name = "DynamicDelegate" + ++_createdDelegatesCount
			                                };

			AssemblyBuilder assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(assembly,
			                                                                                AssemblyBuilderAccess.RunAndCollect);
			ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule("DDModule", assembly.Name + ".dll", true);

			TypeBuilder typeBuilder = moduleBuilder.DefineType(
				"BooDynamicDelegate",
				TypeAttributes.Class | TypeAttributes.Public | TypeAttributes.Sealed | TypeAttributes.AnsiClass |
				TypeAttributes.AutoClass,
				typeof (MulticastDelegate));

			ConstructorBuilder ctrBuilder = typeBuilder.DefineConstructor(
				MethodAttributes.RTSpecialName | MethodAttributes.HideBySig | MethodAttributes.Public,
				CallingConventions.Standard,
				new[] { typeof (object), typeof (IntPtr) });
			ctrBuilder.SetImplementationFlags(MethodImplAttributes.Runtime | MethodImplAttributes.Managed);

			MethodBuilder methodBuilder = typeBuilder.DefineMethod(
				"Invoke",
				MethodAttributes.Public | MethodAttributes.HideBySig | MethodAttributes.NewSlot | MethodAttributes.Virtual,
				_method.ReturnType,
				_method.GetParameters().Select(p => p.ParameterType).ToArray());
			methodBuilder.SetImplementationFlags(MethodImplAttributes.Runtime | MethodImplAttributes.Managed);

			Type delegateType = typeBuilder.CreateType();

			return delegateType;
		}
	}
}