using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace InVision.Framework.Scripting
{
	public abstract class Script : IScript
	{
		private DateTime _fileLastChange;
		private readonly List<Assembly> _references;

		/// <summary>
		/// Initializes a new instance of the <see cref="Script"/> class.
		/// </summary>
		/// <param name="filename">The filename.</param>
		/// <param name="compilerOutput">The compiler output.</param>
		protected Script(string filename, string compilerOutput)
		{
			CheckFilename(filename);

			Filename = filename;
			CompilerOutput = compilerOutput;

			_references = new List<Assembly>();
			GetFileLastChange();
		}

		/// <summary>
		/// Gets the file last change.
		/// </summary>
		protected void GetFileLastChange()
		{
			_fileLastChange = File.GetLastWriteTime(Filename);
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
		/// Gets or sets the assembly prefix.
		/// </summary>
		/// <value>The assembly prefix.</value>
		public string AssemblyPrefix { get; set; }

		/// <summary>
		/// Gets or sets the name of the path.
		/// </summary>
		/// <value>The name of the path.</value>
		public string Path { get; set; }

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
			foreach (Assembly assembly in assemblies) {
				AddReference(assembly);
			}
		}

		/// <summary>
		/// Loads this instance.
		/// </summary>
		public abstract void LoadOrExecute();

		/// <summary>
		/// Gets the method or function.
		/// </summary>
		/// <typeparam name="TDelegate">The type of the delegate.</typeparam>
		/// <param name="name">The name.</param>
		/// <returns></returns>
		public virtual TDelegate GetMethodOrFunction<TDelegate>(string name)
		{
			return (TDelegate)GetMethodOrFunction(name);
		}

		/// <summary>
		/// Gets the method or function.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <returns></returns>
		public abstract object GetMethodOrFunction(string name);

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