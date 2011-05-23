using System;
using System.Collections.Generic;
using System.IO;
using InVision.Framework.Config;

namespace InVision.Framework.Scripting
{
	public class ScriptManagerFactory
	{
		private readonly string _compilerOutput;
		private readonly ExecutionMode _executionMode;
		private readonly Dictionary<string, IScriptManager> _managers;

		/// <summary>
		/// Initializes a new instance of the <see cref="ScriptManagerFactory"/> class.
		/// </summary>
		/// <param name="compilerOutput">The compiler output.</param>
		/// <param name="executionMode">The execution mode.</param>
		public ScriptManagerFactory(string compilerOutput = null, ExecutionMode executionMode = ExecutionMode.Interpreted)
		{
			_compilerOutput = compilerOutput;
			_executionMode = executionMode;
			_managers = new Dictionary<string, IScriptManager>();

			LoadManagers();
		}

		/// <summary>
		/// Loads the managers.
		/// </summary>
		public void LoadManagers()
		{
			foreach (Type managerType in FxConfiguration.Instance.Scripting.ScriptManagers)
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
	}
}