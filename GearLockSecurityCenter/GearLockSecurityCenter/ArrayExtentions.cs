using System;
using System.Collections.Generic;
using System.Text;
namespace GearLockSecurityCenter
{
    static class ArrayExtentions
    {

        public delegate void exec<T>(T obj);

        public static void ForEach<T>(this IEnumerable<T> arr, exec<T> action) {

            foreach (T obj in arr) {
                action(obj);
            }
        }
    }
}
