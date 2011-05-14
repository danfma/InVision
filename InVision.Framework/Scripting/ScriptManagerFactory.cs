using System;
using System.Collections.Generic;
using System.IO;
using InVision.Framework.Config;

namespace InVision.Framework.Scripting
{
	public class ScriptManagerFactory
	{
		private readonly Dictionary<string, IScriptManager> _managers;

		/// <summary>
		/// Initializes a new instance of the <see cref="ScriptManagerFactory"/> class.
		/// </summary>
		/// <param name="compilerOutput">The compiler output.</param>
		public ScriptManagerFactory(string compilerOutput = null)
		{
			_managers = new Dictionary<string, IScriptManager>();

			foreach (Type managerType in FxConfiguration.Instance.Scripting.ScriptManagers)
			{
				var manager = (IScriptManager)Activator.CreateInstance(managerType);
				manager.CompilerOutput = compilerOutput;
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