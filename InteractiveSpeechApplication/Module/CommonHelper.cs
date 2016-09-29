using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveSpeechApplication.Module
{
    static class CommonHelper
    {
        public static void print(string input)
        {
            Console.Write(input);
        }
        public static void printLine(string input)
        {
            Console.WriteLine(input);
        }

        public static string readLine()
        {
            return Console.ReadLine();
        }
    }
}
