using System;

namespace Ether.Data
{
    /// <summary>
    /// Data helpers for validating arguments
    /// </summary>
    public static class Helpers
    {
        public static void ThrowIfIntZero(int number)
        {
            if (number == 0) throw new ArgumentOutOfRangeException();
        }

        public static void ThrowIfEntityNull<T>(T entity) where T : class
        {
            if (entity is null) throw new ArgumentNullException(typeof(T).Name);
        }

        public static void ThrowIfStringEmpty(string str)
        {
            if (string.IsNullOrWhiteSpace(str)) throw new ArgumentNullException();
        }
    }
}