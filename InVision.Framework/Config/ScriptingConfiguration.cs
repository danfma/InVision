using System;
using System.Xml.Serialization;

namespace InVision.Framework.Config
{
	[Serializable]
	public class ScriptingConfiguration
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ScriptingConfiguration"/> class.
		/// </summary>
		public ScriptingConfiguration()
		{
			ScriptManagers = new Type[0];
		}

		/// <summary>
		/// Gets or sets the script managers.
		/// </summary>
		/// <value>The script managers.</value>
		[XmlArray("script-managers")]
		[XmlArrayItem("script-manager", typeof(Type))]
		public Type[] ScriptManagers { get; set; }
	}
}