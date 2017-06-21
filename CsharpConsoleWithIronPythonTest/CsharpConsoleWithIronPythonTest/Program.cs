using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using IronPython.Hosting;
using Microsoft.Scripting.Hosting;

namespace CsharpConsoleWithIronPythonTest
{
    class Program
    {
        static void Main(string[] args)
        {

            ScriptRuntime myruntime = Python.CreateRuntime();

            Console.WriteLine("\n"+"We will use Python Script to print:" + "\n");
            


            dynamic obj = myruntime.UseFile("test.py");

            Console.WriteLine("没有文档，真TM是一个被上的故事!"+"\n");
            Console.WriteLine("Python不会说中国话，真傲娇，下面开始使用脚本列表执行器" + "\n");

            List<string> scriptPathList = new List<string>();
            string path1 = "test1.py";
            string path2 = "test2.py";
            string path3 = "test3.py";

            scriptPathList.Add(path1);
            scriptPathList.Add(path2);
            scriptPathList.Add(path3);


            foreach (var item in scriptPathList)
            {
                myruntime.UseFile(item);
            }

            Console.ReadKey();
        }
    }
}
