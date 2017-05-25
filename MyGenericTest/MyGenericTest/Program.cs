using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGenericTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Maintanence m1 = new Maintanence { loacal = "CKG" };
            ScheduledFlight f1 = new ScheduledFlight { depart = "PVG", };
            

            
        }

        
    }

    public class List<T>
    {
        private List<T> list;
        
        public void AddItem()
        {
            list
        }
    }
    


    class Maintanence
    {
        public string loacal { get; set; }
    }

    class ScheduledFlight
    {
        public string depart { get; set; }
        public int flightnumber = 111;
    }
}
