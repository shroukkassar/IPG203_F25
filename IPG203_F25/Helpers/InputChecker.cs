using System;
using System.Collections.Generic;
using System.Text;

namespace IPG203_F25.Helpers
{
    namespace IPG203_F25.Helpers
    {
        public static class InputChecker
        {
            public static bool IsValidString(string text)
            {
                if (text != null && text != "")
                {
                    return true;
                }
                return false;
            }
            public static bool IsValidDate(DateTime date)
            {
                if (date <= DateTime.Now)
                {
                    return true;
                }
                return false;
            }
        }
    }
}
