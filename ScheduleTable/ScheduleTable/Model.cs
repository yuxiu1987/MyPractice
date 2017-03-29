using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleTable
{
    public class Flight
    {
        public string FlightNumber { get; set; }
        public DateTime starttime { get; set; }
        public TimeSpan timelength { get; set; }
        public int drawlength { get { return (timelength.Hours * 100); } }

        public DateTime endtime { get { return (starttime.Add(timelength)); } }
        
        public DayOfWeek StartDay { get; set; }
        public DayOfWeek EndDay
        {
            get
            {
                int temp;
                DayOfWeek endday;
                if (endtime.Day != starttime.Day)
                {
                    temp = (int)StartDay + 1;
                    if (temp > 6) temp = 0;
                    endday = (DayOfWeek)Enum.ToObject(typeof(DayOfWeek), temp);
                    return endday;
                }
                else { endday = StartDay; return endday; }
            }
        }
    }    
}

