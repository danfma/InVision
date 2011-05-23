using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace InVision.Framework.Scripting
{
	public abstract class Script : IScript
	{
		private readonly DateTime _fileLastChange;
		private readonly List<Assembly> _references;

		/// <summary>
		/// Initializes a new instance of the <see cref="Script"/> class.
		/// </summary>
		/// <param name="filename">The filename.</param>
		protected Script(string filename)
		{
			CheckFilename(filename);

			Filename = filename;

			_references = new List<Assembly>();
			_fileLastChange = File.GetLastWriteTime(filename);
		}

		/// <summary>
		/// Gets the filename.
		/// </summary>
		/// <value>The filename.</value>
		public string Filename { get; private set; }

		/// <summary>
		/// Gets the extension.
		/// </summary>
		/// <value>The extension.</value>
		protected abstract string Extension { get; }

		/// <summary>
		/// Gets the references.
		/// </summary>
		/// <value>The references.</value>
		protected IEnumerable<Assembly> References
		{
			get { return _references; }
		}

		#region IScript Members

		/// <summary>
		/// Gets the execution mode.
		/// </summary>
		/// <value>The execution mode.</value>
		public abstract ExecutionMode ExecutionMode { get; }

		/// <summary>
		/// Gets a value indicating whether the source file has changed.
		/// </summary>
		/// <value><c>true</c> if the source file has changed; otherwise, <c>false</c>.</value>
		public bool SourceChanged
		{
			get { return File.GetLastWriteTime(Filename) > _fileLastChange; }
		}

		/// <summary>
		/// Gets or sets the compiler output.
		/// </summary>
		/// <value>The compiler output.</value>
		public string CompilerOutput { protected get; set; }

		/// <summary>
		/// Adds the reference.
		/// </summary>
		/// <param name="assembly">The assembly.</param>
		public virtual void AddReference(Assembly assembly)
		{
			if (!_references.Contains(assembly))
				_references.Add(assembly);
		}

		/// <summary>
		/// Adds the references.
		/// </summary>
		/// <param name="assemblies">The assemblies.</param>
		public virtual void AddReferences(IEnumerable<Assembly> assemblies)
		{
			foreach (var assembly in assemblies)
			{
				AddReference(assembly);
			}
		}

		/// <summary>
		/// Loads this instance.
		/// </summary>
		public abstract void LoadOrExecute();

		/// <summary>
		/// Finds the service.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		public abstract IEnumerable<T> FindServices<T>();

		#endregion

		/// <summary>
		/// Checks the filename.
		/// </summary>
		/// <param name="filename">The filename.</param>
		private void CheckFilename(string filename)
		{
			if (filename == null)
				throw new ArgumentNullException("filename");

			if (!File.Exists(filename))
				throw new InvalidScriptFileException("File does not exist: " + filename);

			if (!filename.EndsWith(Extension))
				throw new InvalidScriptFileException(string.Format("File is not a recognized script ({0})", Extension));
		}
	}
}