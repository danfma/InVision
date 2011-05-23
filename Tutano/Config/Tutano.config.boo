import System
import InVision.Framework.Config

class TutanoConfigurer (IConfigurator):
	def Configure(config as FxConfiguration):
		if Platform.Is32Bits:
			Console.WriteLine("Boo config on 32bits")
