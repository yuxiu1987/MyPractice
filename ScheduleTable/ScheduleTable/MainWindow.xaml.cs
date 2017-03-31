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

namespace ScheduleTable
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
            SetFlights();

            MondaySlot.ItemsSource = SchedulePerWeek.Instance.FlightsInMonday;
            TuesdaySlot.ItemsSource = SchedulePerWeek.Instance.FlightsInTuesday;
            WednesdaySlot.ItemsSource = SchedulePerWeek.Instance.FlightsInWednesday;
            ThursdaySlot.ItemsSource = SchedulePerWeek.Instance.FlightsInThursday;
            FridaySlot.ItemsSource = SchedulePerWeek.Instance.FlightsInFriday;
            SaturdaySlot.ItemsSource = SchedulePerWeek.Instance.FlightsInSaturday;
            SundaySlot.ItemsSource = SchedulePerWeek.Instance.FlightsInSunday;
        }

        private void SetFlights()
        {
            Flight f1 = new Flight
            {
                starttime = new DateTime(1900, 1, 1, 6, 30, 0),
                timelength = new TimeSpan(1, 0, 0),
                StartDay = DayOfWeek.Monday,
                FlightNumber = "SLD1001",
                Depart = "HEL",
                Arrival = "ARN",
                
            };
            Flight f2 = new Flight
            {
                starttime = new DateTime(1900, 1, 1, 21, 30, 0),
                timelength = new TimeSpan(2, 28, 0),
                StartDay = DayOfWeek.Monday,
                FlightNumber = "SLD1003",
                Depart = "HEL",
                Arrival = "CPH",
            };
            Flight f3 = new Flight
            {
                starttime = new DateTime(1900, 1, 1, 14, 30, 0),
                timelength = new TimeSpan(8, 16, 0),
                StartDay = DayOfWeek.Wednesday,
                FlightNumber = "SLD501",
                Depart = "HEL",
                Arrival = "DXB",
            };
            Flight f4 = new Flight
            {
                starttime = new DateTime(1900, 1, 1, 20, 30, 0),
                timelength = new TimeSpan(7, 16, 0),
                StartDay = DayOfWeek.Friday,
                FlightNumber = "SLD501",
                Depart = "HEL",
                Arrival = "AUH",
            };

            Flight f5 = new Flight
            {
                starttime = new DateTime(1900, 1, 1, 18, 30, 0),
                timelength = new TimeSpan(9, 16, 0),
                StartDay = DayOfWeek.Tuesday,
                FlightNumber = "SLD505",
                Depart = "HEL",
                Arrival = "PVG",
            };

            SchedulePerWeek.Instance.FlightsPerWeek.Add(f1);
            SchedulePerWeek.Instance.FlightsPerWeek.Add(f2);
            SchedulePerWeek.Instance.FlightsPerWeek.Add(f3);
            SchedulePerWeek.Instance.FlightsPerWeek.Add(f4);
            SchedulePerWeek.Instance.FlightsPerWeek.Add(f5);
        }


    }
}