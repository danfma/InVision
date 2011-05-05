using System;

namespace InVision.Bullet
{
	public interface IProfileManager
	{
		void Start_Profile(String name);
		void Stop_Profile();
		void CleanupMemory();
		void Reset();
		void Increment_Frame_Counter();
		int Get_Frame_Count_Since_Reset();
		float Get_Time_Since_Reset();

		void	dumpRecursive(IProfileIterator profileIterator, int spacing);
		void dumpAll();

		IProfileIterator getIterator();

	}
}