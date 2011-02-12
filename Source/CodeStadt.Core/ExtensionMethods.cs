using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeStadt.Core
{
    public static class ExtensionMethods
    {
        public static string Formatted(this string target, params object[] args) {

            return string.Format(target, args);
        }
        public static bool IsNullOrEmpty(this string target)
        {
            return string.IsNullOrEmpty(target);
        }
        public static T As<T>(this object target) where T : class
        {
            return target as T;
        }
        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> target, Action<T> task){
            foreach(var item in target){
                task.Invoke(item);
            }
            return target;
        }

    }
}
