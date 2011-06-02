using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Reflection;
using InVision.Framework.Config;
using InVision.Framework.Scripting;
using LuaInterface;

namespace InVision.Scripting.Lua
{
	public class LuaInterpretedScript : Script
	{
		private LuaInterface.Lua _runtime;
		private IDictionary<Type, LuaTable> _registration;

		/// <summary>
		/// Initializes a new instance of the <see cref="LuaInterpretedScript"/> class.
		/// </summary>
		/// <param name="filename">The filename.</param>
		/// <param name="compilerOutput">The compiler output.</param>
		public LuaInterpretedScript(string filename, string compilerOutput)
			: base(filename, compilerOutput)
		{
			Reset();
		}

		/// <summary>
		/// Gets the extension.
		/// </summary>
		/// <value>The extension.</value>
		protected override string Extension
		{
			get { return ".lua"; }
		}

		/// <summary>
		/// Gets the execution mode.
		/// </summary>
		/// <value>The execution mode.</value>
		public override ExecutionMode ExecutionMode
		{
			get { return ExecutionMode.Interpreted; }
		}

		/// <summary>
		/// Loads this instance.
		/// </summary>
		public override void LoadOrExecute()
		{
			try
			{
				_runtime.DoString("function load_assembly(ns) luanet.load_assembly(ns) end");
				_runtime.DoString("function import_type(fullname) return luanet.import_type(fullname) end");

				foreach (Assembly assembly in References)
				{
					_runtime.DoString(string.Format("load_assembly(\"{0}\")", assembly.FullName));
				}

				_runtime.RegisterFunction("register_service", this, GetType().GetMethod("RegisterService"));
				_runtime.DoString(File.ReadAllText(Filename));
			}
			catch (LuaException ex)
			{
				using (StreamWriter file = File.CreateText(Filename + ".errors"))
				{
					file.WriteLine("= ERROR ========================================================================");
					file.WriteLine(ex.ToString());
					file.WriteLine("================================================================================");
					file.Flush();
				}

				throw new ScriptErrorException(Filename, new[] { ex.ToString() });
			}
		}

		/// <summary>
		/// Gets the method or function.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <returns></returns>
		public override object GetMethodOrFunction(string name)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Finds the service.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		public override IEnumerable<T> FindServices<T>()
		{
			var service = _registration[typeof(T)];
			var function = (LuaFunction)service["Configure"];

			dynamic obj = new ExpandoObject();
			obj.Configure = new Action<Configuration>(cfg => function.Call(service, cfg));

			return obj;
		}

		/// <summary>
		/// Registers the service.
		/// </summary>
		/// <param name="key">The key.</param>
		/// <param name="value">The value.</param>
		public void RegisterService(string key, LuaTable value)
		{
			Type type = Type.GetType(key);

			_registration.Add(type, value);
		}

		/// <summary>
		/// Resets this instance.
		/// </summary>
		public void Reset()
		{
			if (_runtime != null)
				_runtime.Close();

			_runtime = new LuaInterface.Lua();
			_registration = new Dictionary<Type, LuaTable>();
		}
	}
}