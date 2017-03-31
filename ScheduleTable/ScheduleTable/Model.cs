﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleTable
{
    public class Flight
    {
        public string FlightNumber { get; set; }
        public string Depart { get; set; }
        public string Arrival { get; set; }

        public DayOfWeek StartDay { get; set; }
        public DateTime starttime { get; set; }
        public TimeSpan timelength { get; set; }        

        #region readonly
        //转换成在槽中的坐标
        public double drawPosition { get { return (((double)starttime.Hour * 60) * 0.7 ); } }
        //转换成在槽中的长度
        public double darwWidth { get { return ((double)(timelength.Hours * 60) * 0.7); } }

        public DateTime endtime { get { return (starttime.Add(timelength)); } }


        public DayOfWeek EndDay
        {
            get
            {
                DayOfWeek endday;
                //判断是否跨日，如果跨日，+1天
                if (endtime.Day != starttime.Day)
                {

                    if( ((int)StartDay + 1)>6 )
                    {
                        endday = (DayOfWeek)Enum.ToObject(typeof(DayOfWeek), 0);
                    }
                    else { endday = StartDay + 1; }
                    
                    return endday;
                }
                else { endday = StartDay; return endday; }
            }
        }

        #endregion




    }    
}
