﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            for (int i=0;i<100;i++)
            {               
                Console.WriteLine(rand.Next(0, 20));
            }
            Console.ReadKey();
        }
    }
}
