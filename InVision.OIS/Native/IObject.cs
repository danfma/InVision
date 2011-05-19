using System.Runtime.InteropServices;
using InVision.Native.Ext;
using InVision.OIS.Attributes;
using InVision.OIS.Components;

namespace InVision.OIS.Native
{
    [OISInterface("Object")]
    public interface IObject : ICppInterface
    {
		[Destructor]
		void Dispose();

        [Method]
        ComponentType Type();

        [Method]
        [return: MarshalAs(UnmanagedType.LPStr)]
        string Vendor();

        [Method]
        [return: MarshalAs(UnmanagedType.I1)]
        bool Buffered();

        [Method]
        void SetBuffered([MarshalAs(UnmanagedType.I1)] bool value);

        [Method]
        Handle GetCreator();

        [Method]
        void Capture();

        [Method]
        int GetID();

        [Method]
        Handle QueryInterface(InterfaceType interfaceType);
    }
}