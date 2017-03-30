using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

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

        public BindingList<Flight> FlightsPerWeek { get; set; } = new BindingList<Flight>();

        public BindingList<Flight> FlightsInMonday { get { return FindFlightPerDay(DayOfWeek.Monday); } }
        public BindingList<Flight> FlightsInTuesday { get { return FindFlightPerDay(DayOfWeek.Tuesday); } }
        public BindingList<Flight> FlightsInWednesday { get { return FindFlightPerDay(DayOfWeek.Wednesday); } }
        public BindingList<Flight> FlightsInThursday { get { return FindFlightPerDay(DayOfWeek.Thursday); } }
        public BindingList<Flight> FlightsInFriday { get { return FindFlightPerDay(DayOfWeek.Friday); } }
        public BindingList<Flight> FlightsInSaturday { get { return FindFlightPerDay(DayOfWeek.Saturday); } }
        public BindingList<Flight> FlightsInSunday { get { return FindFlightPerDay(DayOfWeek.Sunday); } }


        //查找某天的所有航班并返回
        private BindingList<Flight> FindFlightPerDay(DayOfWeek dayofweek)
        {
            var f = (from s in FlightsPerWeek
                     where s.StartDay == dayofweek
                     select s).ToList();
            BindingList<Flight> bflight = new BindingList<Flight>();
            foreach(Flight fl in f)
            {
                bflight.Add(fl);
            }
            return bflight;
        }

    }
}
