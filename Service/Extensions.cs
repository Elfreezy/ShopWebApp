using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopWebApp.Service
{
    public static class Extensions
    {
        public static string CutController(this string item)
        {
            return item.Replace("Controller", "");
        }
    }
}
