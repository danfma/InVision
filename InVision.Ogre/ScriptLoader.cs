using InVision.Native;
using InVision.Ogre.Native;

namespace InVision.Ogre
{
	public class ScriptLoader : CppWrapper<IScriptLoader>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ScriptLoader"/> class.
		/// </summary>
		/// <param name="nativeInstance">The native instance.</param>
		public ScriptLoader(IScriptLoader nativeInstance)
			: base(nativeInstance)
		{
		}
	}
}