using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using InVision.Framework.Config;
using System.Linq;

namespace InVision.Framework.Scripting
{
	public class ScriptManagerFactory
	{
		private static ScriptManagerFactory _instance;

		private readonly Configuration _config;
		private readonly string _compilerOutput;
		private readonly ExecutionMode _executionMode;
		private readonly Dictionary<string, IScriptManager> _managers;

		/// <summary>
		/// Initializes a new instance of the <see cref="ScriptManagerFactory"/> class.
		/// </summary>
		/// <param name="config">The config.</param>
		/// <param name="compilerOutput">The compiler output.</param>
		/// <param name="executionMode">The execution mode.</param>
		public ScriptManagerFactory(Configuration config, string compilerOutput = null, ExecutionMode executionMode = ExecutionMode.Compiled)
		{
			_config = config;
			_compilerOutput = compilerOutput;
			_executionMode = executionMode;
			_managers = new Dictionary<string, IScriptManager>();

			if (!string.IsNullOrEmpty(compilerOutput) && !Directory.Exists(compilerOutput))
				Directory.CreateDirectory(compilerOutput);

			LoadManagers();
		}

		/// <summary>
		/// Gets the allowed script extensions.
		/// </summary>
		/// <value>The allowed script extensions.</value>
		public IEnumerable<string> AllowedScriptExtensions
		{
			get { return _managers.Keys; }
		}

		/// <summary>
		/// Loads the managers.
		/// </summary>
		public void LoadManagers()
		{
			foreach (Type managerType in _config.Scripting.ScriptManagers)
			{
				var manager = (IScriptManager)Activator.CreateInstance(managerType);
				manager.CompilerOutput = _compilerOutput;
				manager.PreferredExecution = _executionMode;
				_managers.Add(manager.TargetExtension, manager);
			}
		}

		/// <summary>
		/// Gets the script manager for.
		/// </summary>
		/// <param name="filename">The filename.</param>
		/// <returns></returns>
		public IScriptManager GetScriptManagerFor(string filename)
		{
			string extension = Path.GetExtension(filename);

			if (string.IsNullOrEmpty(extension))
				throw new InVisionException("Script file does not have an extension");

			IScriptManager scriptManager;

			if (_managers.TryGetValue(extension, out scriptManager))
				return scriptManager;

			return null;
		}

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>The instance.</value>
		public static ScriptManagerFactory Instance
		{
			get { return _instance; }
		}

		/// <summary>
		/// Initializes the specified config.
		/// </summary>
		/// <param name="config">The config.</param>
		/// <param name="compilerOutput">The compiler output.</param>
		/// <param name="executionMode">The execution mode.</param>
		public static void Initialize(Configuration config, string compilerOutput= null, ExecutionMode executionMode = ExecutionMode.Compiled)
		{
			_instance = new ScriptManagerFactory(config, compilerOutput, executionMode);
		}
	}
}