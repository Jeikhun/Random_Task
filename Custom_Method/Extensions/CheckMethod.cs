using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom_Method.Extensions
{
    public static class CheckMethod
    {
        public static bool Check_Method(this string data)
        {
            if (data.Length < 3 || data.Length>30 || string.IsNullOrEmpty(data))
            {
                return false;
            }
            return true;

        }


    }
}
