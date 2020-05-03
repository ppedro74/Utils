using System;
using IronPythonTests.Common;

namespace IronPythonTests.CoreConsole
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //Does not run!!!

            Console.WriteLine("Starting...");
            Test1.Run();
            Console.WriteLine("Finished!");
            Console.ReadLine();
        }
    }
}