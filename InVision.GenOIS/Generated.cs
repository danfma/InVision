using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InVision.Native.Ext;

namespace InVision.GenOIS
{
    public static class NativeComponent
    {
        public static extern Handle New();
        public static extern Handle New(ComponentType componentType);
        public static extern void Delete(Handle self);
        public static extern ComponentDescriptor CreateDescriptor(Handle self);
    }

    [CppImplementation(typeof(IComponent))]
    public class NativeComponentWrapper : CppInstance, IComponent
    {
        IComponent IComponent.New()
        {
            Self = NativeComponent.New();

            return this;
        }

        IComponent IComponent.New(ComponentType componentType)
        {
            Self = NativeComponent.New(componentType);

            return this;
        }

        void IComponent.Delete()
        {
            NativeComponent.Delete(Self);
        }

        ComponentDescriptor IComponent.CreateDescriptor()
        {
            return NativeComponent.CreateDescriptor(Self);
        }
    }
}
