using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSystemDesign
{
    //日期类
    public class MyDate : Bindable
    {
        #region 单例模式
        private MyDate()
        {
        }

        private static MyDate _mydate;

        public static MyDate Instance
        {
            get { if (_mydate == null) { _mydate = new MyDate(); } return _mydate; }
            set { }
        }
        #endregion

        public int TotalDays { get { return _TotalDays; } set { SetProperty(ref (_TotalDays), value); } }
        private int _TotalDays;

        /// <summary>
        /// 当前日
        /// </summary>
        public DayOfWeek TodayOfWeek
        {
            get { return _TodayOfWeek; }
            set { SetProperty(ref (_TodayOfWeek), value); }
        }
        private DayOfWeek _TodayOfWeek;

        public void SetDayOfWeek()
        {
           TodayOfWeek =(DayOfWeek)Enum.ToObject(typeof(DayOfWeek), (TotalDays+1) % 7);
        }

        public int TotalWeeks { get { return _TotalWeeks; } set { SetProperty(ref (_TotalWeeks), value); } }
        private int _TotalWeeks;
        
        public void DayStep()
        {
            ActiveSettlementEvent();
            TotalDays++;
            SetDayOfWeek();
            if(TodayOfWeek == DayOfWeek.Monday)
            {
                TotalWeeks++;
            }
        }

        public void InitDate()
        {
            TotalDays = 0;
            TotalWeeks = 0;
            SetDayOfWeek();
        }

        public delegate void DaySettlementHandle();

        /// <summary>
        /// 激活结算，每天发生
        /// </summary>
        public event DaySettlementHandle ActiveSettlementEvent;
    }




    /// <summary>
    /// 结算器
    /// </summary>
    public class Settlement
    {
        #region 单例模式
        private Settlement()
        { }
        private static Settlement _Settlement;
        public static Settlement Instance { get { if(_Settlement == null) { _Settlement = new Settlement(); } return _Settlement; }
            set { }
        }
        #endregion

        /// <summary>
        /// 日结算
        /// </summary>
        public void DaySettlement()
        {
            //星期天进行周结算
            if(MyDate.Instance.TodayOfWeek == DayOfWeek.Sunday)
            {
                DataCenter.Instance.WeeklyScheduledProp.InitWeeklyScheduled();
                FindAndFillDayFlight();
            }
        }

        /// <summary>
        /// 月结算
        /// </summary>
        public void MonthlySettle()
        {

        }

        /// <summary>
        /// 更新周航班计划总表
        /// </summary>
        private void FindAndFillDayFlight()
        {
            //遍历航班号总表，根据航班的计划执行日定位到每周航班计划总表对应的日期（星期几）中，并向当日插入该航班
            foreach(Flight f in DataCenter.Instance.TotalFlights)
            {
                foreach(DayOfWeek d in f.ScheduledTable)
                {
                    DataCenter.Instance.WeeklyScheduledProp.ThisWeeklyScheduled[(int)d - 1].TodayTotalFlight.Add(f);
                }
            }
        }
    }

    /// <summary>
    /// 数据中心
    /// </summary>
    public class DataCenter
    {
        #region 单例模式
        private DataCenter() { }

        private static DataCenter _DataCenter;
        public static DataCenter Instance { get { if(_DataCenter == null) { _DataCenter = new DataCenter(); } return _DataCenter; }
        set { }
        }
        #endregion

        public void DataInit()
        {
            SLD1001.ScheduledTable.Add(DayOfWeek.Monday);
            SLD1001.ScheduledTable.Add(DayOfWeek.Wednesday);
            SLD1001.ScheduledTable.Add(DayOfWeek.Friday);

            SLD501.ScheduledTable.Add(DayOfWeek.Tuesday);
            SLD501.ScheduledTable.Add(DayOfWeek.Thursday);
            SLD501.ScheduledTable.Add(DayOfWeek.Saturday);

            for (int i = 1; i < 8; i++)
            {
                DayOfWeek temp = (DayOfWeek)Enum.ToObject(typeof(DayOfWeek), i);
                SLD1055.ScheduledTable.Add(temp);
            }
            TotalFlights.Add(SLD1001);
            TotalFlights.Add(SLD501);
            TotalFlights.Add(SLD1055);
        }

        public WeeklyScheduled WeeklyScheduledProp { get; set; } = new WeeklyScheduled();

        public List<Flight> TotalFlights { get; set; } = new List<Flight>();

        public Flight SLD1001 { get; set; } = new Flight { FlightNumber = 1001, Code = "SLD" };
        public Flight SLD501 { get; set; } = new Flight { FlightNumber = 501, Code = "SLD" };
        public Flight SLD1055 { get; set; } = new Flight { FlightNumber = 1055, Code = "SLD" };
    }
}
