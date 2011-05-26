using System;
using System.Xml.Serialization;

namespace InVision.Framework.Config
{
	[Serializable]
	public struct NameValue
	{
		[XmlAttribute("name")]
		public string Name;

		[XmlAttribute("value")]
		public string Value;
	}
}