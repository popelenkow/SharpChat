using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpChat.Extentions
{
    public static class AddSortedExtention
    {
        public static TCollection AddSorted<TCollection, T>(this TCollection collection, T item, Func<T, int> func)
            where TCollection : ICollection<T>
        {
            int i = 0;
            for (; i < collection.Count; i++)
            {
                if (func((collection as dynamic)[i]) > func(item)) break;
            }
            (collection as dynamic).Insert(i, item);
            return collection;
        }
    }
}
