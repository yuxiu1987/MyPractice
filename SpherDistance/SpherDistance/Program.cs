using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpherDistance
{
    /// <summary>
    /// 大圆距离计算,注意，C#下Math类中的参数均需要统一为弧度制
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //成都坐标
            double PosALongitude = 103.95 * Math.PI / 180;
            double PosALatitude = 30.58 * Math.PI / 180;

            //上海坐标
            double PosBLongitude = 121.34 * Math.PI / 180;
            double PosBLatitude = 31.2 * Math.PI / 180;

            double r = 6371;

            double distance = Math.Acos( Math.Cos(PosALatitude) * Math.Cos(PosBLatitude) * Math.Cos(PosALongitude - PosBLongitude) + Math.Sin(PosALatitude) * Math.Sin(PosBLatitude) ) * r;

            Console.WriteLine(Math.Sin(90*Math.PI/180));

            Console.WriteLine("Distance of Chengdu and Shanghai : " + distance +"Km");
            Console.ReadKey();

          //  dis = r * arccos[cos(y1) * cos(y2) * cos(x1 - x2) + sin(y1) * sin(y2)]
        }


    }
}
