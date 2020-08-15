using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoWebAPIs.Common
{
    public static class Logger
    {
        public static void LogMessage(string Message)
        {
            Console.WriteLine(Message);
        }

        public static void LogException(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
