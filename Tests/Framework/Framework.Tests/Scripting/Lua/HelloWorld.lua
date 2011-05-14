Console = luanet.import_type("System.Console")

Console.WriteLine("Hello lua")

function onLoad()
	Console.WriteLine("onLoad called")
end
