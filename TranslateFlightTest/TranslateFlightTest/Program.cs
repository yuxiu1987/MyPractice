using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TranslateFlightTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Flight SLD101 = new Flight
            {
                FlightNumber = "SLD101",
                Depart = "CTU",
                Arrival = "PVG",
                Capacity = 186
            };
            Flight SLD102 = new Flight
            {
                FlightNumber = "SLD103",
                Depart = "PVG",
                Arrival = "SIN",
                Capacity = 270
            };
            PassengersFlow CTUPVG = new PassengersFlow
            {
                Depart = "CTU",
                Arrival = "PVG",
                Quantity = 98
            };
            PassengersFlow CTUSIN = new PassengersFlow
            {
                Depart = "CTU",
                Arrival = "SIN",
                Quantity = 65
            };
            PassengersFlow PVGSIN = new PassengersFlow
            {
                Depart = "PVG",
                Arrival = "SIN",
                Quantity = 240
            };
            List<PassengersFlow> Flowlist = new List<PassengersFlow>();
            Flowlist.Add(CTUPVG);
            Flowlist.Add(CTUSIN);
            Flowlist.Add(PVGSIN);

            void FindFlight(Flight fli)
            {
                foreach(var item in Flowlist)
                {
                    if(item.Depart == fli.Depart && item.Arrival == fli.Arrival && fli.Capacity >= item.Quantity)
                    {
                        fli.DirectPAS = item.Quantity;
                    }
                }
            }

            void FindTranslateFlight(Flight fli1 ,Flight fli2)
            {
                foreach(var item in Flowlist)
                {
                    if(item.Depart == fli1.Depart && item.Arrival == fli2.Arrival )
                    {
                        fli1.TranslatePAS = item.Quantity;
                        fli2.TranslatePAS = item.Quantity;
                        var temptotal1 = fli1.TranslatePAS + fli1.DirectPAS;
                        var temptotal2 = fli2.TranslatePAS + fli2.DirectPAS;
                        if(temptotal1 > fli1.Capacity)
                        {
                            fli1.TranslatePAS -= (temptotal1 - fli1.Capacity);

                        }
                        if(temptotal2 > fli2.Capacity)
                        {
                            fli2.TranslatePAS -= (temptotal2 - fli2.Capacity);
                        }

                        //转机乘客以容量更小的一段为准
                        var temp = Math.Min(fli1.TranslatePAS, fli2.TranslatePAS);
                        fli1.TranslatePAS = temp;
                        fli2.TranslatePAS = temp;
                        fli1.TotalPAS = fli1.TranslatePAS + fli1.DirectPAS;
                        fli2.TotalPAS = fli2.TranslatePAS + fli2.DirectPAS;
                    }
                }
            }

            FindFlight(SLD101);
            FindFlight(SLD102);
            FindTranslateFlight(SLD101, SLD102);

            Console.WriteLine("From CTU to PVG");
            Console.WriteLine("SLD101 direct PAS :");
            Console.WriteLine(SLD101.DirectPAS);
            Console.WriteLine("From CTU to SIN");
            Console.WriteLine("SLD101 translate PAS :");
            Console.WriteLine(SLD101.TranslatePAS);
            Console.WriteLine("SLD101 total PAS :");
            Console.WriteLine(SLD101.TotalPAS);
            Console.WriteLine();


            Console.WriteLine("From PVG to SIN");
            Console.WriteLine("SLD102 direct PAS :");
            Console.WriteLine(SLD102.DirectPAS);
            Console.WriteLine("From CTU to SIN");
            Console.WriteLine("SLD102 translate PAS :");
            Console.WriteLine(SLD102.TranslatePAS);
            Console.WriteLine("SLD102 total PAS :");
            Console.WriteLine(SLD102.TotalPAS);
            Console.ReadKey();           
        }
    }
    

    public class Flight
    {
        public string FlightNumber { get; set; }
        public string Depart { get; set; }
        public string Arrival { get; set; }

        public int DirectPAS { get; set; }
        public int TranslatePAS { get; set; }   
        public int TotalPAS { get; set; }
        public int Capacity { get; set; }
    }

    public class PassengersFlow
    {
        public string Depart { get; set; }
        public string Arrival { get; set; }
        public int Quantity { get; set; }
    }
}
