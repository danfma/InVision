using System;
using System.Runtime.InteropServices;
using InVision.Native;

namespace InVision.Ogre
{
	public class StringInterface : Handle
	{
		/// <summary>
		/// 	Initializes a new instance of the <see cref = "StringInterface" /> class.
		/// </summary>
		/// <param name = "pSelf">The p self.</param>
		/// <param name = "ownsHandle">if set to <c>true</c> [owns handle].</param>
		protected internal StringInterface(IntPtr pSelf, bool ownsHandle)
			: base(pSelf, ownsHandle)
		{
		}

		/// <summary>
		/// 	Initializes a new instance of the <see cref = "StringInterface" /> class.
		/// </summary>
		/// <param name = "ownsHandle">if set to <c>true</c> [owns handle].</param>
		protected internal StringInterface(bool ownsHandle)
			: base(ownsHandle)
		{
		}

		/// <summary>
		/// 	Initializes a new instance of the <see cref = "StringInterface" /> class.
		/// </summary>
		public StringInterface()
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// 	Releases the specified pointer to the unmanaged object.
		/// </summary>
		/// <returns></returns>
		protected override void ReleaseValidHandle()
		{
			throw new NotImplementedException();
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct ParameterDef
	{
		public string Name;
		public string Description;
		public ParameterType ParameterType;
	}

	public interface IInternalParamCommand
	{
		string DoGet(IntPtr target);
		void DoSet(IntPtr target, string value);
	}

	public interface IParamCommand
	{
		string DoGet(object target);
		void DoSet(object target, string value);
	}
}