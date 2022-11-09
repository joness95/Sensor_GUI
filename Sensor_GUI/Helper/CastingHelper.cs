using System.Runtime.InteropServices;

namespace Sensor_GUI.Helper
{
    public static class TernaryExtension
    {
        public static T Then<T>(this bool value, T result)
        {
            return value ? result : default(T);
        }
    }
    public static class CastingHelper
    {
        public static T CastToStruct<T>(this byte[] data) where T : struct
        {
            var pData = GCHandle.Alloc(data, GCHandleType.Pinned);
#pragma warning disable CS8605 // Unboxing eines möglichen NULL-Werts.
            T result = (T)Marshal.PtrToStructure(pData.AddrOfPinnedObject(), typeof(T));
#pragma warning restore CS8605 // Unboxing eines möglichen NULL-Werts.
            pData.Free();
            return result;
        }

        public static byte[] CastToArray<T>(this T data) where T : struct
        {
            var result = new byte[Marshal.SizeOf(typeof(T))];
            var pResult = GCHandle.Alloc(result, GCHandleType.Pinned);
            Marshal.StructureToPtr(data, pResult.AddrOfPinnedObject(), true);
            pResult.Free();
            return result;
        }
    }
}
