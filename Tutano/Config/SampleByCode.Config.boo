import System
import InVision.Framework.Config

class TutanoConfigurer (ICustomConfigurator):
	def Configure(config as Configuration):
		if Platform.Is32Bits:
			Console.WriteLine("Boo config on 32bits")
			