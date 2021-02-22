using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QianChuang.CompManage.Helper
{

    public static class CollectionExtensions
    {
        public static T Find<T>(this T[] items, Predicate<T> predicate)
        {
            return Array.Find<T>(items, predicate);
        }

        public static T[] FindAll<T>(this T[] items, Predicate<T> predicate)
        {
            return Array.FindAll<T>(items, predicate);
        }

        /// <summary>
        ///   Checks whether or not collection is null or empty. Assumes collection can be safely enumerated multiple times.
        /// </summary>
        public static bool IsNullOrEmpty(this IEnumerable @this)
        {
            if (@this != null)
                return !@this.GetEnumerator().MoveNext();
            return true;
        }

        /// <summary>
        ///   Generates a HashCode for the contents for the list. Order of items does not matter.
        /// </summary>
        /// <typeparam name="T">The type of object contained within the list.</typeparam>
        /// <param name="list">The list.</param>
        /// <returns>The generated HashCode.</returns>
        public static int GetContentsHashCode<T>(IList<T> list)
        {
            if (list == null)
                return 0;
            int num = 0;
            for (int index = 0; index < list.Count; ++index)
            {
                if ((object)list[index] != null)
                    num += list[index].GetHashCode();
            }
            return num;
        }

    }
}
