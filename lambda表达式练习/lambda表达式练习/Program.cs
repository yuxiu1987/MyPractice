using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lambda表达式练习
{
    delegate int TwoIntegerOperationDelegate(int paramA, int paramaB);
    class Program
    {
        static void PerformOperations(TwoIntegerOperationDelegate del)
        {
            for(int paraAVAL =1;paraAVAL <=5; paraAVAL++)
            {
                for(int paraBVAL =1; paraBVAL <=5; paraBVAL++)
                {
                    int delegateCallResult = del(paraAVAL, paraBVAL);
                    Console.Write("f({0},{1})={2}" , paraAVAL , paraBVAL , delegateCallResult);
                    if(paraBVAL != 5)
                    {
                        Console.Write(", ");
                    }
                }
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("f(a,b) = a + b:");
            PerformOperations((a, b) => a + b);
            Console.WriteLine();
            Console.WriteLine("f(a,b) = a * b:");
            PerformOperations((a, b) => a * b);
            Console.WriteLine();
            Console.WriteLine("f(a,b) = (a - b) % b:");
            PerformOperations((a, b) => (a - b) % b);
            Console.ReadKey();

        }
    }
}
