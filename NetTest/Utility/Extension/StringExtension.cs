using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace NetTest
{
    public static class StringExtension
    {
        public static string Join(string[] array, string separator)
        {
            if (array != null || array.Length > 0)
            {
                return String.Join(separator, array);
            }
            return String.Empty;
        }

        public static int ToInt32(string value)
        {
            return Convert.ToInt32(value);
        }
    }
}
