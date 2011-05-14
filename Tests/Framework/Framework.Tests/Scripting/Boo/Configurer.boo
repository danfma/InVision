import InVision.GameMath
import InVision.Framework.Config

class Configurer (IConfigurator):
	def Configure (config as FxConfiguration):
		config.Screen.Width = 640
		config.Screen.Height = 480
		config.Screen.BackgroundColor = Color.Black
