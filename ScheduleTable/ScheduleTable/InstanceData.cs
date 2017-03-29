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
    }
}
