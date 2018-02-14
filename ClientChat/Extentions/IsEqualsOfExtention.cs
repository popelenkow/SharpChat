using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpChat.Extentions
{
    public static class IsEqualsOfExtention
    {
        public static bool IsEqualsOf<T>(this T elem, params T[] others)
            where T : class
        {
            foreach (var it in others)
            {
                if (elem.Equals(it))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
