﻿using System;
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
        //周航班总表
        public BindingList<Flight> FlightsPerWeek { get; set; } = new BindingList<Flight>();
        //用于显示的周航班总表
        public BindingList<Flight> DisplayFlightsPerWeek { get { return AlignTable(FlightsPerWeek); } set { } }

        public BindingList<Flight> FlightsInMonday { get { return FindFlightPerDay(DayOfWeek.Monday); } }
        public BindingList<Flight> FlightsInTuesday { get { return FindFlightPerDay(DayOfWeek.Tuesday); } }
        public BindingList<Flight> FlightsInWednesday { get { return FindFlightPerDay(DayOfWeek.Wednesday); } }
        public BindingList<Flight> FlightsInThursday { get { return FindFlightPerDay(DayOfWeek.Thursday); } }
        public BindingList<Flight> FlightsInFriday { get { return FindFlightPerDay(DayOfWeek.Friday); } }
        public BindingList<Flight> FlightsInSaturday { get { return FindFlightPerDay(DayOfWeek.Saturday); } }
        public BindingList<Flight> FlightsInSunday { get { return FindFlightPerDay(DayOfWeek.Sunday); } }

                
        private BindingList<Flight> FindFlightPerDay(DayOfWeek dayofweek)
        {
            //在显示用航班表中查找出某天所有航班并转换为BindingList<Flight>
            var f = (from s in DisplayFlightsPerWeek
                     where s.StartDay == dayofweek
                     select s).ToList();
            BindingList<Flight> bindingflight = new BindingList<Flight>();
            foreach(Flight fl in f)
            {
                bindingflight.Add(fl);
            }
            return bindingflight;
        }

        //对齐周航班总表中的所有航班（拆分所有跨日航班）
        private BindingList<Flight> AlignTable(BindingList<Flight> _DisplayFlightsPerWeek)
        {
            //查找所有跨日航班
            var f1 = (from s in _DisplayFlightsPerWeek
                      where s.StartDay != s.EndDay
                      select s).ToList();

            
            //遍历跨日航班列表，并拆分跨日航班
            for(int i=0;i<f1.Count;i++)
            {
                var item = f1[i];

                //移除原航班
                _DisplayFlightsPerWeek.Remove(item);

                DateTime dayendtime = new DateTime(1900, 1, 2, 0, 0, 0);
                Flight firstday = new Flight
                {
                    Depart = item.Depart,
                    Arrival = item.Arrival,
                    FlightNumber = item.FlightNumber,
                    StartDay = item.StartDay,
                    starttime = item.starttime,
                    timelength = dayendtime.Subtract(item.starttime)
                };

                Flight secondday = new Flight
                {
                    Depart = item.Depart,
                    Arrival = item.Arrival,
                    FlightNumber = item.FlightNumber,
                    StartDay = item.EndDay,
                    starttime = new DateTime(1900, 1, 2, 0, 0, 0),
                    timelength = new TimeSpan(item.endtime.Hour, item.endtime.Minute, 0)
                };
                _DisplayFlightsPerWeek.Add(firstday);
                _DisplayFlightsPerWeek.Add(secondday);
            }
            

            return _DisplayFlightsPerWeek;
        }

    }
}
