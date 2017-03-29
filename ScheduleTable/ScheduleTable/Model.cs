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
        public DateTime endtime { get; set; }
        public TimeSpan timelength { get; set; }
        public DayOfWeek StartDay { get; set; }
        public DayOfWeek EndDay { get; set; }
    }
}

