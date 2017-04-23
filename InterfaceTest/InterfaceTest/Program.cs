using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceTest
{
    class Program
    {
        static void Main(string[] args)
        {
            ICarry B707 = new PassengerAirliner();
            CargoAirliner DC10F = new CargoAirliner();
            DC10F.Carry();
            B707.Carry();

            Console.ReadKey();

        }
    }

    
    public interface ICarry
    {
       void Carry();
    }

    public class PassengerAirliner : ICarry
    {
        public void Carry()
        {
            Console.WriteLine("300Passengers");
        }        
    }

    public class CargoAirliner
    {
        public void Carry()
        {
            Console.WriteLine("100TonsCargoes");
        }
    }
}
