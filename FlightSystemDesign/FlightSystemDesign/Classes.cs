using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace FlightSystemDesign
{
    //航班类
    public class Flight : Bindable
    {
        public int FlightNumber { get; set; }

        public string Code { get; set; }
        public string FullNumber { get { return Code + Convert.ToString(FlightNumber); } }

        public List<DayOfWeek> ScheduledTable { get; set; } = new List<DayOfWeek>();

        public int income { get;} = 1000;
    }
    
    public class TotalFlightPerDay : Bindable
    {
        public BindingList<Flight> TodayTotalFlight { get; set; } = new BindingList<Flight>();
    }


    public class WeeklyScheduled : Bindable
    {

        public WeeklyScheduled()
        {
            //限定长度为7
            ThisWeeklyScheduled.Capacity = 7;
            for (int i = 0; i < 7; i++)
            {
                ThisWeeklyScheduled.Add(new TotalFlightPerDay());
            }
        }

        /// <summary>
        /// 本周每日所有航班计划
        /// </summary>
        public List<TotalFlightPerDay> ThisWeeklyScheduled = new List<TotalFlightPerDay>();

        /// <summary>
        /// 重置周计划，周结算时使用
        /// </summary>
        public void InitWeeklyScheduled()
        {
            //遍历一周并清除每日航班列表中的所有航班
            foreach (TotalFlightPerDay pd in ThisWeeklyScheduled)
            {
                pd.TodayTotalFlight.Clear();
            }
        }
    }

}
