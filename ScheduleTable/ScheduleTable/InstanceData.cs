using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleTable
{

    public class SchedulePerWeek
    {
        #region 单例
        private SchedulePerWeek()
        {

        }

        private static SchedulePerWeek _SchedulePerWeek;

        public static SchedulePerWeek Instance
        {
            get
            {
                if (_SchedulePerWeek == null) { _SchedulePerWeek = new SchedulePerWeek(); }
                return _SchedulePerWeek;
            }
            set { }
        }
        #endregion

        public List<Flight> FlightsPerWeek { get; set; } = new List<Flight>();

        public List<Flight> FlightsInMonday { get { return FindFlightPerDay(DayOfWeek.Monday); } }
        public List<Flight> FlightsInTuesday { get { return FindFlightPerDay(DayOfWeek.Tuesday); } }
        public List<Flight> FlightsInWednesday { get { return FindFlightPerDay(DayOfWeek.Wednesday); } }
        public List<Flight> FlightsInThursday { get { return FindFlightPerDay(DayOfWeek.Thursday); } }
        public List<Flight> FlightsInFriday { get { return FindFlightPerDay(DayOfWeek.Friday); } }
        public List<Flight> FlightsInSaturday { get { return FindFlightPerDay(DayOfWeek.Saturday); } }
        public List<Flight> FlightsInSunday { get { return FindFlightPerDay(DayOfWeek.Sunday); } }


        //查找某天的所有航班并返回
        private List<Flight> FindFlightPerDay(DayOfWeek dayofweek)
        {
            var f = (from s in FlightsPerWeek
                     where s.StartDay == dayofweek
                     select s).ToList();
            return f as List<Flight>;
        }

    }
}
