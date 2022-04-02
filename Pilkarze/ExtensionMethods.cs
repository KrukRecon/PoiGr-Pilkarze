using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_02_4
{
    internal static class ExtensionMethods
    {
        public static int ToInt(this string item)
        {
            if (string.IsNullOrWhiteSpace(item))
            {
                return 0;
            }

            int.TryParse(item, out var intItem);
            return intItem;
        }
    }
}
