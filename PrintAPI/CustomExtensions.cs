using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rowdy.API.PrintAPI
{
    /// <summary>
    /// Custom string extensions
    /// </summary>
    public static class StringExtension
    {
        /// <summary>
        /// Get a
        /// </summary>
        /// <param name="value"></param>
        /// <param name="maxLength"></param>
        /// <returns></returns>
        public static string TrimMaxLength(this string value, int maxLength)
        {
            return value.Substring(0, value.Length >= maxLength ? maxLength : value.Length);
        }
    }
}
