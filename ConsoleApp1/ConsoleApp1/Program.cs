using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            TimeManager mytimemanager = new TimeManager();
            mytimemanager.TimerInit();
            mytimemanager.RunTimerInNewThread();

        }
    }

    public class TimeManager
    {
        #region Property
        /// <summary>
        /// 当前游戏时刻
        /// </summary>
        public DateTime CurrentTime
        {
            get { return _CurrentTime; }
            set { _CurrentTime = value; }
        }
        private DateTime _CurrentTime;

        /// <summary>
        /// 起始时刻（游戏开始的时刻）
        /// </summary>
        public DateTime StartTime
        {
            get { return _StartTime; }
            private set { _StartTime = value; }
        }
        private DateTime _StartTime;

        /// <summary>
        /// 结束时刻（游戏结束的时刻）
        /// </summary>
        public DateTime EndTime
        {
            get { return _EndTime; }
            set { _EndTime = value; }
        }
        private DateTime _EndTime;

        /// <summary>
        /// 总计时步数
        /// </summary>
        public int? TotalTimeCount
        {
            get { return _TotalTimeCount; }
            set { _TotalTimeCount = value; }
        }
        private int? _TotalTimeCount;

        public enum TimeStep : int { Slow = 1000, Normal = 500, Fast = 300, Fastest = 150 }

        /// <summary>
        /// 计时步长值（每8小时对应的毫秒数）
        /// </summary>
        public TimeStep TimeStepLength
        {
            get { return _TimeStepLength; }
            private set { _TimeStepLength = value; }
        }
        private TimeStep _TimeStepLength;

        /// <summary>
        /// 时间是否运行
        /// </summary>
        public bool? IsRunning
        {
            get { return _IsRunning; }
            private set { _IsRunning = value; }
        }
        private bool? _IsRunning;

        /// <summary>
        /// 进程是否运行
        /// </summary>
        public bool ThreadIsRunning
        {
            get { return _ThreadIsRuning; }
            private set { _ThreadIsRuning = value; }
        }
        private bool _ThreadIsRuning;
        #endregion

        #region Method

        public void SetStartTime(DateTime starttime)
        {
            StartTime = starttime;
        }

        public void SetTimeStepLength(TimeStep steplength)
        {
            TimeStepLength = steplength;
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public void TimerInit()
        {

            SetTimeStepLength(TimeStep.Normal);
            SetStartTime(new DateTime(1955, 1, 1, 0, 0, 0));
            ThreadIsRunning = true;
            IsRunning = true;


            CurrentTime = StartTime;
            TotalTimeCount = 0;


            ProcessPerDayEvent += Settle.SettlePerDay;
            ProcessPerWeekEvent += Settle.SettlePerWeek;
            ProcessPerMonthEvent += Settle.SettlePerMonth;
            ProcessPerYearEvent += Settle.SettlePerYear;
        }

        private void Running()
        {
            DateTime? time1;
            DateTime? time2;
            int deltaDay;
            int deltaMonth;
            int deltaYear;

            Console.WriteLine("Thread start.");

            while (ThreadIsRunning)
            {
                //时间线在运行
                if (IsRunning == true)
                {
                    time1 = CurrentTime;
                    CurrentTime = CurrentTime.AddHours(8);
                    TotalTimeCount += 1;
                    time2 = CurrentTime;
                    deltaDay = time2.Value.Day - time1.Value.Day;

                    Console.WriteLine("Current time is :" + CurrentTime);

                    //跨天，则抛出每日处理事件
                    if (deltaDay != 0) ProcessPerDayEvent(this);

                    //跨周，则抛出每周处理事件
                    if (time2.Value.DayOfWeek == DayOfWeek.Monday && time1.Value.DayOfWeek == DayOfWeek.Sunday)
                    {
                        ProcessPerWeekEvent(this);
                    }

                    deltaMonth = time2.Value.Month - time1.Value.Month;

                    //跨月，则抛出每月处理事件
                    if (deltaMonth != 0) ProcessPerMonthEvent(this);

                    //跨年，则抛出每年处理事件
                    deltaYear = time2.Value.Year - time1.Value.Year;
                    if (deltaYear != 0) ProcessPerYearEvent(this);
                }

                else if (IsRunning == false)
                {

                }

                Thread.Sleep((int)TimeStepLength);

            }
        }

        public void PauseTime()
        {
            IsRunning = false;
        }

        public void ResumeTime()
        {
            IsRunning = true;
        }

        public void RunTimerInNewThread()
        {
            Thread TimerThread = new Thread(this.Running);
            TimerThread.Start();
        }

        public void StopThread()
        {
            ThreadIsRunning = false;
        }


        #endregion

        #region Delegate & Event

        public delegate void ProcessPerDayHandle(TimeManager sender);
        public event ProcessPerDayHandle ProcessPerDayEvent;

        public delegate void ProcessPerWeekHandle(TimeManager sender);
        public event ProcessPerWeekHandle ProcessPerWeekEvent;

        public delegate void ProcessPerMonthHandle(TimeManager sender);
        public event ProcessPerMonthHandle ProcessPerMonthEvent;

        public delegate void ProcessPerYearHandle(TimeManager sender);
        public event ProcessPerYearHandle ProcessPerYearEvent;
        #endregion
    }

    /// <summary>
    /// 静态结算类，演示用
    /// </summary>
    public static class Settle
    {
        public static void SettlePerDay(TimeManager sender)
        {
            Console.WriteLine("Today is:" + sender.CurrentTime);
            Console.WriteLine("Daily process is completeed!");
        }

        public static void SettlePerWeek(TimeManager sender)
        {

        }

        public static void SettlePerMonth(TimeManager sender)
        {

        }

        public static void SettlePerYear(TimeManager sender)
        {

        }
    }
}
