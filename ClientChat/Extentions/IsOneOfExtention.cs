using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpChat.Extentions
{
    public static class IsOneOfExtention
    {
        public static bool IsOneOf<T>(this T elem, params T[] others)
            where T : class
        {
            foreach(var it in others)
            {
                if (elem == it)
                {
                    return true;
                }
            }
            return false;
        }
        
    }
}
