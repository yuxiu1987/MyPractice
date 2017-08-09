using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public static class Mercator_Converter
    {
        public static PositionOnMap GetPTOnMap(PositionOnEarth pos)
        {
            double longitude = pos.longitude;
            double latitude = pos.latitude;

            int MapHeight = 873;
            int MapWidth = 1029;

            
            double R = 6371000;//地球半径6371km

            double RF = MapWidth / (2 * Math.PI * R);
            PositionOnMap PtInMap;

            double longrad = longitude * (Math.PI / 180);

            PtInMap.Xpt = R * longrad ;

            //转换弧度制
            double larad = latitude * (Math.PI / 180);

            double temp = Math.Tan((Math.PI / 4) + (larad / 2));

            var mercN = Math.Log(temp);

            PtInMap.Ypt = R * mercN ;

            PtInMap.Xpt *= RF;
            PtInMap.Ypt *= RF;

            PtInMap.Xpt += MapWidth / 2;
            PtInMap.Ypt = MapHeight / 2 - PtInMap.Ypt;

            return PtInMap;
        }

        /// <summary>
        /// 求出大圆中点的经纬度
        /// </summary>
        /// <param name="rte"></param>
        /// <returns></returns>
        public static PositionOnEarth GetMidPTonEarth(Route rte)
        {
            var fai1 = rte.StartOnEarth.latitude * (Math.PI / 180);
            var fai2 = rte.EndOnEarth.latitude * (Math.PI / 180);
            var lambda1 = rte.StartOnEarth.longitude * (Math.PI / 180);
            var lambda2 = rte.EndOnEarth.longitude * (Math.PI / 180);

            var lambda12 = lambda2 - lambda1;

            var temp = Math.Sin(lambda12) / (Math.Cos(fai1) * Math.Tan(fai2) - Math.Sin(fai1) * Math.Cos(lambda12));

            var alpha1 = Math.Atan(temp);

            var temp1 = Math.Sin(alpha1) * Math.Cos(fai1);
            var alpha0 = Math.Asin(temp1);

            var temp2 = Math.Tan(fai1) / Math.Cos(alpha1);
            var theta01 = Math.Atan(temp2);

            var temp3 = (Math.Sin(alpha0) * Math.Sin(theta01)) / Math.Cos(theta01);
            var lambda01 = Math.Atan(temp3);

            var lambda0 = lambda1 - lambda01;

            double lambdamid;
            if(Math.Abs(lambda12) <= Math.PI)
            {
                lambdamid = lambda2 - lambda12 / 2;
            }
            else
            {
                lambda12 = 360 * (Math.PI / 180) - lambda12;
                lambdamid = lambda2 - lambda12 / 2;
            }

            var temp4 = (1 / Math.Tan(alpha0)) * Math.Sin(lambdamid - lambda0);
            var faimid = Math.Atan(temp4);

            var temp5 = Math.PI / 180;
            PositionOnEarth ptmid = new PositionOnEarth { longitude = lambdamid/temp5, latitude = faimid/temp5 };

            return ptmid;
        }
    }

    public struct PositionOnMap
    {
        public double Xpt;
        public double Ypt;
    }

    public struct PositionOnEarth
    {
        public double longitude;
        public double latitude;
    }

    public struct Route
    {
        public PositionOnEarth StartOnEarth;
        public PositionOnEarth MidOnEarth
        { get
            {
                return Mercator_Converter.GetMidPTonEarth(this);
            }
                
        }
        public PositionOnEarth EndOnEarth;

        public PositionOnMap StartOnMap { get { return Mercator_Converter.GetPTOnMap(StartOnEarth); } }
        public PositionOnMap MidOnMap { get { return Mercator_Converter.GetPTOnMap(MidOnEarth); } }
        public PositionOnMap EndOnMap { get { return Mercator_Converter.GetPTOnMap(EndOnEarth); } }

        public string StartName;
        public string EndName;
    }

    
}
