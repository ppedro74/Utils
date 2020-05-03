using System;
using System.Linq;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;

namespace IronPythonTests.Common
{
    public class PythonEngine
    {
        private readonly ScriptEngine scriptEngine;

        public PythonEngine()
        {
            this.scriptEngine = Python.CreateEngine();
            this.scriptEngine.Runtime.IO.SetOutput(Console.OpenStandardOutput(), Console.Out);
            this.scriptEngine.Runtime.IO.SetErrorOutput(Console.OpenStandardOutput(), Console.Out);
        }

        public void Run(string expression)
        {
            try
            {
                var scriptSource = this.scriptEngine.CreateScriptSourceFromString(expression);
                var scriptScope = this.scriptEngine.CreateScope();
                scriptScope.SetVariable("__script", this);
                scriptSource.Execute(scriptScope);
            }
            catch (Exception e)
            {
                Console.Write(e.ToString());
                Console.WriteLine();
            }
        }

        public void Foo()
        {
            Console.WriteLine("Foo says hello");
        }

        public void Foo(int int1)
        {
            Console.WriteLine("Foo:int says hello");
        }

        public void Foo(string text)
        {
            Console.WriteLine("Foo:string says hello");
        }

        public void Foo(byte[] bytes)
        {
            //This method is never called from python engine
            Console.WriteLine("Foo:bytes[] says hello");
        }

        public void Foo(IronPython.Runtime.ByteArray byteArray)
        {
            Console.WriteLine("Foo:byteArray says hello");
            var bytes2 = byteArray.ToArray();
        }

        public void Foo(IronPython.Runtime.Bytes bytes)
        {
            Console.WriteLine("Foo:Bytes says hello");
            var bytes2 = bytes.ToByteArray();
        }

        public void Foo(IronPython.Runtime.List list)
        {
            Console.WriteLine("Foo:List says hello");

            object[] objects = list.ToArray();
        }

        public void Foo(IronPython.Runtime.PythonTuple tuple)
        {
            Console.WriteLine("Foo:Tuple says hello");

            object[] objects = tuple.ToArray();
        }

        public string GetType(object obj)
        {
            return obj.GetType().ToString();
        }
    }
}