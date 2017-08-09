using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GetfilesTest
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo info = new DirectoryInfo("DATA");

            foreach(var item in info.GetFiles())
            {
                Console.WriteLine(item.Name);
            }
            Console.ReadKey();
        }
    }
}
