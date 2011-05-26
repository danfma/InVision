using System;
using System.Xml.Serialization;
using InVision.Framework;
using InVision.Framework.Config;

namespace Tutano
{
	[XmlRoot("configuration")]
	public class TutanoConfiguration : Configuration
	{
		private IGameFlow _gameFlow;
		private Type _gameFlowType;

		/// <summary>
		/// Gets the game flow.
		/// </summary>
		/// <value>The game flow.</value>
		[XmlIgnore]
		public IGameFlow GameFlow
		{
			get { return _gameFlow ?? (_gameFlow = (IGameFlow) Activator.CreateInstance(_gameFlowType)); }
		}

		/// <summary>
		/// Gets or sets the type of the game flow.
		/// </summary>
		/// <value>The type of the game flow.</value>
		[XmlElement("game-flow-type")]
		public string GameFlowType
		{
			get { return _gameFlowType == null ? null : _gameFlowType.AssemblyQualifiedName; }
			set { _gameFlowType = Type.GetType(value, true); }
		}
	}
}