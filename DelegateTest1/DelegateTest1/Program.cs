using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateTest1
{
    class Program
    {
        static void Main(string[] args)
        {

            person jon = new person("Jon");
            person tom = new person("Tom");

            //此处用了三种不同的方法给委托创建实例，无一例外都是需要给委托的实例传入函数签名，以便让委托实例知道究竟要去执行哪个方法
            StringProcessor jonvoice, tomvoice;
            jonvoice = new StringProcessor(jon.Say);//给委托变量赋值一个新的函数签名
            tomvoice = (str) => tom.Say(str);
            StringProcessor background = new StringProcessor(Background.Note);

            //调用委托
            jonvoice("Hello,son.");
            tomvoice("Hello,Daddy!");
            background("A airplane flies past.");

            Console.ReadKey();
        }

    }

    delegate void StringProcessor(string input);

    class person
    {
        string name;
        public person(string name)
        {
            this.name = name;
        }
        public void Say(string message)
        {
            Console.WriteLine("{0} says: {1}", name, message);
        }
    }
    class Background
    {
        public static void Note(string note)
        {
            Console.WriteLine("({0})", note);
        }
    }

}
