﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;

using System.Runtime.CompilerServices;

namespace WpfApp1
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Binding bd = new Binding();
            bd.Source = SLD1001Table;
            bd.Mode = BindingMode.OneWay;
            SetBinding(DataContextProperty, bd);
            grid.DataContext = SLD1001Table;

            totaldayslabel.DataContext = myDate;
            currentday.DataContext = myDate;

            DaySettleEvent += DaySettleMethod;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SLD1001Table.ClearTable();
            for(int i =0;i<5;i=i+2)
            {
                //INT-->ENUM
                SLD1001Table.ThisFlightTable[i].ScheduledFlight = (Schedule)(Enum.ToObject(typeof(Schedule), i));
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SLD1001Table.ClearTable();
            SLD1001Table.ThisFlightTable[1].ScheduledFlight = Schedule.Tue;
            SLD1001Table.ThisFlightTable[3].ScheduledFlight = Schedule.Thu;
            SLD1001Table.ThisFlightTable[5].ScheduledFlight = Schedule.Sat;
        }

        public void DaySettleMethod(object sender, Flight fli)
        {
            Flight TodayFlight = fli;
            flightlabel.DataContext = TodayFlight;
            if(TodayFlight.ScheduledFlight != Schedule.Null)
            {
                TotalIncome = TodayFlight.income + TotalIncome;
            }
        }

        private void daysettle_Click(object sender, RoutedEventArgs e)
        {
            myDate.SetCurrentDay();
            DaySettleEvent(this, SLD1001Table.ThisFlightTable[myDate.CurrentDay]);
            myDate.TotalDays++;
            totalincomelabel.Content = TotalIncome;
        }

        private void settle30day_Click(object sender, RoutedEventArgs e)
        {
            for(int i=0; i<30; i++)
            {                
                myDate.SetCurrentDay();
                DaySettleEvent(this, SLD1001Table.ThisFlightTable[myDate.CurrentDay]);
                myDate.TotalDays++;
                totalincomelabel.Content = TotalIncome;
            }
        }

        public FlightTable SLD1001Table { get; set; } =
            new FlightTable(new Flight { FlightNumber = 1001, Code = "SLD", ScheduledFlight = Schedule.Null });        

        public MyDate myDate { get; set; } = new MyDate { TotalDays = 1 };

        public int TotalIncome { get; set; } = 0;

        public event DaySettleHandle DaySettleEvent;


    }

    public class Flight : Bindable
    {
        public int FlightNumber { get; set; }

        public string Code { get; set; }
        public string FullNumber { get { return Code + Convert.ToString(FlightNumber); } }
        public Schedule ScheduledFlight { get { return _ScheduledFlight; } set { SetProperty(ref _ScheduledFlight, value); } }
        private Schedule _ScheduledFlight;
        public int income { get; set; } = 1000;
    }

    public class FlightTable:Bindable
    {
        public FlightTable(Flight flimodel)
        {
            for (int i = 0; i < 7; i++)
            {
                Flight fli = new Flight { FlightNumber = flimodel.FlightNumber,
                    Code = flimodel.Code, ScheduledFlight = flimodel.ScheduledFlight
                };
                ThisFlightTable.Add(fli);
            }
        }

        public List<Flight> ThisFlightTable { get; set; } = new List<Flight>();


        public void ClearTable()
        {
            foreach(Flight f in ThisFlightTable)
            {
                f.ScheduledFlight = Schedule.Null;
            }
        }
    }

    //日期类
    public class MyDate:Bindable
    {
        public int TotalDays { get { return _TotalDays; } set { SetProperty(ref (_TotalDays), value); } }
        private int _TotalDays;

        public int CurrentDay { get { return _CurrentDay; }
            set { SetProperty(ref(_CurrentDay), value); } }
        private int _CurrentDay;

        public void SetCurrentDay()
        {
            CurrentDay = TotalDays % 7;
        }
    }

    //周计划
    public class WeeklyScheduled
    {
        public BindingList<FlightTable> WeeklyTableList { get; set; } = new BindingList<FlightTable>();
    }


    public enum Schedule : int { Mon = 0, Tue, Wed, Thu, Fri, Sat, Sun, Null }
    public delegate void DaySettleHandle(object sender , Flight fli);

    public abstract class Bindable : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// 侦听方法，在属性的设置器中直接调用此方法，参数为需要实时更新至界面的属性的名字
        /// </summary>
        /// <param name="propName"></param>
        protected void OnPropertyChanged(string propName)
        {
            PropertyChangedEventHandler propchanged = PropertyChanged;
            if (propchanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));//在侦听到更新时抛出更新事件(事件的处理程序及注册是WPF的内部机制)
            }
        }

        protected void SetProperty<T>(ref T item , T value , [CallerMemberName] string propertyName = null)
        {
            if(!EqualityComparer<T>.Default.Equals(item,value))
            {
                item = value;
                OnPropertyChanged(propertyName);
            }
        }
    }
}
