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

        public static PositionOnMap GetMidPTonMap(Route rte)
        {
            var lambda12 = (rte.EndOnEarth.longitude - rte.StartOnEarth.longitude) * (Math.PI / 180);
            var fy1 = rte.StartOnEarth.latitude * (Math.PI / 180);
            var fy2 = rte.EndOnEarth.latitude * (Math.PI / 180);
            var temp = Math.Sin(lambda12) / (Math.Cos(fy1) * Math.Tan(fy2) - Math.Sin(fy1) * Math.Cos(lambda12));

            var alpha1 = Math.Atan(temp);
            


            return 
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
        public PositionOnEarth MidOnEarth;
        public PositionOnEarth EndOnEarth;

        public PositionOnMap StartOnMap { get { return Mercator_Converter.GetPTOnMap(StartOnEarth); } }
        public PositionOnMap MidOnMap { get { return Mercator_Converter.GetPTOnMap(MidOnEarth); } }
        public PositionOnMap EndOnMap { get { return Mercator_Converter.GetPTOnMap(EndOnEarth); } }

        public string StartName;
        public string EndName;
    }

    
}
