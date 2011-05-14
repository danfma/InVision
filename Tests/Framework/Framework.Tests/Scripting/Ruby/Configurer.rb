include System
include InVision::GameMath
include InVision::Framework::Config

class RubyConfigurator
	include IConfigurator
	
	def Configure(config)
		config.Screen.Width = 640
		config.Screen.Height = 480
		config.Screen.BackgroundColor = Color.Black
	end
end
