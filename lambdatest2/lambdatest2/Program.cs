using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lambdatest2
{
    class Program
    {
        static void Main(string[] args)
        {
            MUL method = (x, y) => x * y;//lambda表达式左侧是参数列表
            var j = method(3, 4);//调用委托实际上是调用lambda表达式右侧的实际执行方法
            Console.WriteLine(j);
            Console.ReadLine();           
        }

    }

    delegate int MUL(int x, int y);
    
}
