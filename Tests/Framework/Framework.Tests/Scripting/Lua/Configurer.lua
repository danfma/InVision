Color = import_type("InVision.GameMath.Color")
Configuration = import_type("InVision.Framework.Config.FxConfiguration")

LuaConfigurator = {}

function LuaConfigurator.Configure(self, config)
	config.Screen.Width = 640
	config.Screen.Height = 480
	config.Screen.BackgroundColor = Color.Black
end

register_service("InVision.Framework.Config.IConfigurator,InVision.Framework", LuaConfigurator)
