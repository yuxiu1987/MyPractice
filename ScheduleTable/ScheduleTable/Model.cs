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
        public string Depart { get; set; }
        public string Arrival { get; set; }

        public DayOfWeek FlightDay { get; set; }
        public DateTime starttime { get; set; }
        public TimeSpan timeOfFlight { get; set; }        

        #region readonly
        //转换成在槽中的坐标
        public double drawPosition { get { return (  ( (double)starttime.Hour) * 60  * 0.7 + ((double)starttime.Minute) * 0.7 ); } }
        //转换成在槽中的长度
        public double darwWidth { get { return ( (double)(timeOfFlight.Hours * 60) * 0.7 + ((double)timeOfFlight.Minutes)*0.7 ); } }

        public DateTime endtime { get { return (starttime.Add(timeOfFlight)); } }


        public DayOfWeek EndDay
        {
            get
            {
                DayOfWeek endday;
                //判断是否跨日，如果跨日，+1天
                if (endtime.Day != starttime.Day)
                {

                    if( ((int)FlightDay + 1)>6 )
                    {
                        endday = (DayOfWeek)Enum.ToObject(typeof(DayOfWeek), 0);
                    }
                    else { endday = FlightDay + 1; }
                    
                    return endday;
                }
                else { endday = FlightDay; return endday; }
            }
        }       

        #endregion

        /// <summary>
        /// 设置器，将某个Flight类的值赋值给此类的新实例
        /// </summary>
        /// <param name="f"></param>
        public void SetFlight(Flight f)
        {
            FlightNumber = f.FlightNumber;
            Depart = f.Depart;
            Arrival = f.Arrival;
            FlightDay = f.FlightDay;
            starttime = f.starttime;
            timeOfFlight = f.timeOfFlight;
        }
    }    
}

