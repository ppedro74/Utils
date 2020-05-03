using System;
using System.IO;

namespace IronPythonTests.Common
{
    public static class Test1
    {
        public static void Run()
        {
            var pythonScript = new PythonEngine();

            pythonScript.Run(@"

def PrintType(arg):
	print 'pythonType={} netType={} value={}'.format(type(arg), __script.GetType(arg), arg)


__script.Foo()

int1 = 10
PrintType(int1)
__script.Foo(int1)

str1 = 'this is a string'
PrintType(str1)
__script.Foo(str1)

bytes1 = bytes(str1)
PrintType(bytes1)
__script.Foo(bytes1)

bytearray1 = bytearray(str1)
PrintType(bytearray1)
__script.Foo(bytearray1)

list1=[1, 2, 3, 4, 5]
PrintType(list1)
__script.Foo(list1)

tuple1 = (1, 2, 3, 4, 5, 'a')
PrintType(tuple1)
__script.Foo(tuple1)



            ");
        }
    }
}