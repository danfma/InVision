using System;

namespace InVision.Bullet
{
	public interface IProfileIterator
	{
		void First();
		void Next();
		bool Is_Done();
		bool Is_Root();

		void Enter_Child( int index );		// Make the given child the new parent
		void Enter_Largest_Child();	// Make the largest child the new parent
		void Enter_Parent();			// Make the current parent's parent the new parent

		// Access the current child
		String Get_Current_Name();
		int Get_Current_Total_Calls();
		float Get_Current_Total_Time();

		// Access the current parent
		String Get_Current_Parent_Name();
		int Get_Current_Parent_Total_Calls();
		float Get_Current_Parent_Total_Time();

	}
}