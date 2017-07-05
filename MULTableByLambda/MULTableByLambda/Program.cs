using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

/// <summary>
/// 使用lambda表达式打印乘法表
/// </summary>
namespace MULTableByLambda
{
    class Program
    {


        static void Main(string[] args)
        {
            //委托指向打印算式的具体方法
            PTequation printEqua = (x, y) =>
            {
                string a, b, c;
                a = x.ToString();
                b = y.ToString();
                c = (x * y).ToString();
                string restring = a + "*" + b + "=" + c+ "\t";
                return restring;
            };

            int z = 1;
            while(z<=9)
            {
                for (int j = 1; j <= z; j++)
                {
                    Console.Write(printEqua(j, z));
                    //调用委托，给委托传参，实际上是通过委托把参数传给了lambda右侧的具体方法
                    //委托本身不做事，做事的是具体方法，使用lambda表达式还省去了给做事的方法命名这一步
                    //委托定义时限定了参数个数，参数类型，返回值类型， 因此委托所调用的方法也必须有相同的参数个数，
                    //参数类型以及返回值类型，委托作为一个指向某种方法的媒介，是非常安全的
                }
                Console.Write("\n");
                z++;
            }
            Console.ReadLine();
        }

        delegate string PTequation(int x, int y);
    }

    



}
