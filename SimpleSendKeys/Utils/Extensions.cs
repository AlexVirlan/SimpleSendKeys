using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSendKeys.Utils
{
    public static class Extensions
    {
        #region String
        public static bool INOE(this string str) => string.IsNullOrEmpty(str);
        #endregion
    }
}
