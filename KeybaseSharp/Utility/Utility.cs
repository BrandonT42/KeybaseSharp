using System;

namespace KenBonny.KeybaseSharp.Utility
{
    internal static class Utility
    {
        public static T[] SubArray<T>(this T[] data, int index, int length = 0)
        {
            if (length.Equals(0))
            {
                length = data.Length - index;
            }
            var result = new T[length];

            Array.Copy(data, index, result, 0, length);
            return result;
        }
    }
}