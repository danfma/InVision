using InVision.FMod.Attributes;

namespace InVision.FMod
{
	[FModEnumeration("FMOD_SYSTEM_CALLBACKTYPE")]
	public enum SystemCallbackType
	{
		DeviceListChanged,
		DeviceLost,
		MemoryAllocationFailed,
		ThreadCreated,
		BaddspConnection,
		BaddspLevel,
		Max
	}
}