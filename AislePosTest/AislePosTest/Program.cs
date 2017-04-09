using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AislePosTest
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 宽体
            int L, R, M, T = 12;

            int ALPos;
            int ARPos;

            if((T-2)%3 == 0)
            {
                L = (T - 2) / 3;
                R = L;
                M = L;
            }
            else
            {
                M = (T - 2) / 3 + 1;
                R = M - 1;
                L = M - 1;
            }

            ARPos = R;
            ALPos = T - L - 1;

            Console.WriteLine("L=" + L);
            Console.WriteLine("R=" + R);
            Console.WriteLine("M=" + M);
            Console.WriteLine("L+M+R=" + (M + L + R));
            Console.WriteLine("T=" + T);
            Console.ReadKey();
            #endregion

            #region 窄体
            int NL = 0, NR = 0, NT = 8;
            int NAPos;

            if ((NT - 1) % 2 == 0)
            {
                NL = (NT - 1) / 2;
                NR = NL;
            }
            else
            {
                NL = (NT - 1) / 2;
                NR = NL + 1;
            }
            NAPos = NR;

            Console.WriteLine("NL=" + NL);
            Console.WriteLine("NR=" + NR);
            Console.WriteLine("NR+NL=" + (NR + NL));
            Console.WriteLine("NT=" + NT);
            Console.ReadKey();


            #endregion
        }
    }
}
