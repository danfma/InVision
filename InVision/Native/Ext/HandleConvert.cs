using System;

namespace InVision.Native.Ext
{
    public static class HandleConvert
    {
        public static Handle ToHandle<T>(T data) where T : ICppInterface
        {
            return data.Self;
        }

        public static T FromHandle<T>(Handle handle) where T : ICppInterface
        {
            var impl = NativeFactory.Create<T>();
            impl.Self = handle;

            return impl;
        }
    }
}