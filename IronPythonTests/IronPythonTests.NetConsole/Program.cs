using System;
using IronPythonTests.Common;

namespace IronPythonTests.NetConsole
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Starting...");
            Test1.Run();
            Console.WriteLine("Finished!");
            Console.ReadLine();
        }
    }
}