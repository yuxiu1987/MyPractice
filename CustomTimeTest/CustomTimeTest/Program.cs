using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CustomTimeTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Time mytime = new Time(1,55);

            
            /*
            while(true)
            {
                Thread.Sleep(500);
                Console.WriteLine(mytime.ToString());
                mytime.Minute++;
            }
            */
            Time stime = new Time(3, 57);
            if(mytime.CompareTo(stime)<0)
            {
                Console.WriteLine("mytime is earlier than stime");
            }

            Console.WriteLine("Two time span is :");
            Console.WriteLine(mytime.ReturnTimeSpan(stime).ToString());

            Console.ReadKey();
        }
    }

    /// <summary>
    /// 时刻类，只用于表示24小时制时刻
    /// </summary>
    public class Time
    {
        /// <summary>
        /// 构造时必须设置时刻
        /// </summary>
        /// <param name="hh"></param>
        /// <param name="mm"></param>
        public Time(int hh , int mm)
        {
            if (hh < 0 || hh > 23)
            {
                hh = 0;
            }
            if (mm < 0 || mm > 59)
            {
                mm = 0;
            }
            Hour = hh;
            Minute = mm;
        }
        /// <summary>
        /// 时，24小时制
        /// </summary>
        public int Hour
        {
            get { return _Hour; }
            set
            {
                if (_Hour > 22) _Hour = 0;
                else _Hour = value;
            }
        }
        private int _Hour;

        /// <summary>
        /// 分，分进位的时候，小时加一
        /// </summary>
        public int Minute
        {
            get { return _Minute; }
            set
            {
                if (_Minute > 58)
                {
                    _Minute = 0;
                    Hour++;
                }
                else _Minute = value;
            }
        }
        private int _Minute;

        /// <summary>
        /// 设置时刻，如果时刻非法，则自动设置为0时或0分
        /// </summary>
        /// <param name="hh"></param>
        /// <param name="mm"></param>
        public void SetTime(int hh , int mm)
        {
            if(hh <0 || hh>23)
            {
                hh = 0;                
            }
            if(mm<0 || mm>59)
            {
                mm = 0;                
            }
            Hour = hh;
            Minute = mm;
        }
        
        /// <summary>
        /// 按时刻格式输出字符串
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var hourString = string.Format("{0:D2}", Hour);
            var minuteString = string.Format("{0:D2}", Minute);
            var timeString = hourString + " : " + minuteString;
            return timeString;
        }

        /// <summary>
        /// 比较两个时刻，如果当前时刻早于参数，则返回值小于0；如果当前时刻等于参数，则返回值等于0；如果当前时刻迟于参数，则返回值大于0；
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public int CompareTo(Time time)
        {
            var temp = (Hour * 60 + Minute) - (time.Hour * 60 + time.Minute);
            return temp;
        }

        /// <summary>
        /// 返回当前时刻与参数时刻之间得时间间隔
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public Time ReturnTimeSpan(Time time)
        {
            Time timespan = new Time(0, 0);

            int time1 = Hour * 60 + Minute;
            int time2 = time.Hour * 60 + time.Minute;
            int restime = time2 - time1;

            timespan.Hour = restime / 60;
            timespan.Minute = restime % 60;
            return timespan;
        }
    }
}
