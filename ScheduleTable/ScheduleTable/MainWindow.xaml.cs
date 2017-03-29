using System;
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

            ScheduleTablePanel.DataContext = SchedulePerWeek.Instance;

            MondaySlot.ItemsSource = SchedulePerWeek.Instance.FlightsInMonday;

            TuesdaySlot.DataContext = SchedulePerWeek.Instance.FlightsInTuesday;
            WednesdaySlot.DataContext = SchedulePerWeek.Instance.FlightsInWednesday;
            ThursdaySlot.DataContext = SchedulePerWeek.Instance.FlightsInThursday;
            FridaySlot.DataContext = SchedulePerWeek.Instance.FlightsInFriday;
            SaturdaySlot.DataContext = SchedulePerWeek.Instance.FlightsInSaturday;
            SundaySlot.DataContext = SchedulePerWeek.Instance.FlightsInSunday;
        }

        private void SetFlights()
        {
            Flight f1 = new Flight
            {
                starttime = new DateTime(1900, 1, 1, 12, 30, 0),
                timelength = new TimeSpan(2, 0, 0),
                StartDay = DayOfWeek.Monday,
                FlightNumber = "SLD1001",
                
            };
            Flight f2 = new Flight
            {
                starttime = new DateTime(1900, 1, 1, 8, 30, 0),
                timelength = new TimeSpan(2, 0, 0),
                StartDay = DayOfWeek.Monday,
                FlightNumber = "SLD1003",                
            };
            Flight f3 = new Flight
            {
                starttime = new DateTime(1900, 1, 1, 14, 30, 0),
                timelength = new TimeSpan(8, 16, 0),
                StartDay = DayOfWeek.Wednesday,
                FlightNumber = "SLD501",
            };
            Flight f4 = new Flight
            {
                starttime = new DateTime(1900, 1, 1, 20, 30, 0),
                timelength = new TimeSpan(7, 16, 0),
                StartDay = DayOfWeek.Friday,
                FlightNumber = "SLD501",
            };
            SchedulePerWeek.Instance.FlightsPerWeek.Add(f1);
            SchedulePerWeek.Instance.FlightsPerWeek.Add(f2);
            SchedulePerWeek.Instance.FlightsPerWeek.Add(f3);
            SchedulePerWeek.Instance.FlightsPerWeek.Add(f4);
        }


    }
}
