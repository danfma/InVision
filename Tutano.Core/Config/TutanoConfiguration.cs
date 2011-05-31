using System;
using System.Linq;
using System.Xml.Serialization;
using InVision.Framework;
using InVision.Framework.Config;

namespace Tutano.Core.Config
{
	[XmlRoot("configuration")]
	public class TutanoConfiguration : Configuration
	{
		private IGameFlow _gameFlow;

		/// <summary>
		/// Gets the game flow.
		/// </summary>
		/// <value>The game flow.</value>
		[XmlIgnore]
		public IGameFlow GameFlow
		{
			get
			{
				if (_gameFlow != null)
					return _gameFlow;

				if (string.IsNullOrEmpty(GameFlowType))
					return null;

				int separatorIndex = GameFlowType.LastIndexOf(",");

				if (separatorIndex == -1)
					throw new InvalidOperationException("GameFlowType can not be parsed");

				var assemblyName = GameFlowType.Substring(separatorIndex + 1).Trim();
				var typeName = GameFlowType.Substring(0, separatorIndex).Trim();

				var type =
					(from assembly in AppDomain.CurrentDomain.GetAssemblies()
					 where assembly.GetName().Name == assemblyName
					 select assembly.GetType(typeName)).FirstOrDefault();

				return _gameFlow = (IGameFlow)Activator.CreateInstance(type);
			}
		}

		/// <summary>
		/// Gets or sets the type of the game flow.
		/// </summary>
		/// <value>The type of the game flow.</value>
		[XmlElement("game-flow-type")]
		public string GameFlowType { get; set; }
	}
}