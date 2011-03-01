using InVision.Config;

var config = Configuration.Instance;


// window settings
var window = config.Window;
window.SetResolution(640, 480);
window.IsFullscreen = false;


// game workflow project
config.GameWorkflow = new NoneGameWorkflow();


// resources
var contents = config.Contents;
var group = contents.CreateGroup("common");
group.Add(ResourceType.FileSystem, "~/Contents/Materials/Textures");


// finishing the configurations
config.Flush();

