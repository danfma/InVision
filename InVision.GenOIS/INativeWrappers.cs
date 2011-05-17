using System;
using System.Runtime.InteropServices;
using InVision.Native.Ext;

namespace InVision.GenOIS
{
    [CppInterface]
    public interface IComponent
    {
        [Constructor]
        IComponent Component();

        [Constructor]
        IComponent Component(ComponentType componentType);

        [Destructor]
        void Dispose();

        [Method]
        ComponentDescriptor CreateDescriptor();
    }

    [ValueObject]
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct ComponentDescriptor
    {
        public Handle Self;
        public ComponentType* CType;
    }

    [CppInterface(BaseType = typeof(IComponent))]
    public interface IButton : IComponent
    {
        [Constructor]
        IButton Button();

        [Constructor]
        IButton Button(bool pushed);

        [Method]
        new ButtonDescriptor CreateDescriptor();
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct ButtonDescriptor
    {
        public ComponentDescriptor Base;
        public bool* Pushed;
    }
}