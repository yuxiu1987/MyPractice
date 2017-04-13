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

            ModelListBox.ItemsSource = FlightModelList.Instance.ModelList;

            flightperweeklist.ItemsSource = SchedulePerWeek.Instance.FlightsPerWeek;
        }

        private void SetFlights()
        {
            Flight f1 = new Flight
            {
                starttime = new DateTime(1900, 1, 1, 0, 0, 0),
                timeOfFlight = new TimeSpan(1, 0, 0),
                FlightDay = DayOfWeek.Monday,
                FlightNumber = "SLD1001",
                Depart = "HEL",
                Arrival = "ARN",
                
            };
            Flight f2 = new Flight
            {
                starttime = new DateTime(1900, 1, 1, 22, 30, 0),
                timeOfFlight = new TimeSpan(2, 28, 0),
                FlightDay = DayOfWeek.Monday,
                FlightNumber = "SLD1003",
                Depart = "HEL",
                Arrival = "CPH",
            };
            Flight f3 = new Flight
            {
                starttime = new DateTime(1900, 1, 1, 15, 30, 0),
                timeOfFlight = new TimeSpan(8, 16, 0),
                FlightDay = DayOfWeek.Wednesday,
                FlightNumber = "SLD501",
                Depart = "HEL",
                Arrival = "DXB",
            };
            Flight f4 = new Flight
            {
                starttime = new DateTime(1900, 1, 1, 20, 30, 0),
                timeOfFlight = new TimeSpan(7, 16, 0),
                FlightDay = DayOfWeek.Friday,
                FlightNumber = "SLD503",
                Depart = "HEL",
                Arrival = "AUH",
            };

            Flight f5 = new Flight
            {
                starttime = new DateTime(1900, 1, 1, 18, 30, 0),
                timeOfFlight = new TimeSpan(9, 16, 0),
                FlightDay = DayOfWeek.Tuesday,
                FlightNumber = "SLD505",
                Depart = "HEL",
                Arrival = "PVG",
            };

            Flight f6 = new Flight
            {
                starttime = new DateTime(1900, 1, 1, 11, 55, 0),
                timeOfFlight = new TimeSpan(12, 0, 0),
                FlightDay = DayOfWeek.Thursday,
                FlightNumber = "SLD507",
                Depart = "HEL",
                Arrival = "SFO",
            };

            FlightModelList.Instance.ModelList.Add(f1);
            FlightModelList.Instance.ModelList.Add(f2);
            FlightModelList.Instance.ModelList.Add(f3);
            FlightModelList.Instance.ModelList.Add(f4);
            FlightModelList.Instance.ModelList.Add(f5);
            FlightModelList.Instance.ModelList.Add(f6);
        }

        #region Drag航班模板进入时刻表
        private void ModelListBox_MouseMove(object sender, MouseEventArgs e)
        {
            var datasource = sender as ListBox;



            if( (datasource!=null) && (e.MouseDevice.LeftButton == MouseButtonState.Pressed) )
            {
                //自定义数据类型
                var datacontent = datasource.SelectedItem;
                string dataname = "flightmodel";
                DataObject dataobj = new DataObject(dataname, datacontent);

                //启动拖拽
                DragDrop.DoDragDrop(datasource, dataobj, DragDropEffects.Copy);
            }
        }

        private void DropProcess(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("flightmodel"))
            {
                var sourcedata = e.Data.GetData("flightmodel") as Flight;
                bool hasflight = false;
                foreach (Flight item in SchedulePerWeek.Instance.FlightsPerWeek)
                {
                    if (item.Equals(sourcedata)) { hasflight = true; break; }
                }
                if (hasflight == false) SchedulePerWeek.Instance.FlightsPerWeek.Add(sourcedata);

                //放入后设置绑定，否则界面不更新
                MondaySlot.ItemsSource = SchedulePerWeek.Instance.FlightsInMonday;
                TuesdaySlot.ItemsSource = SchedulePerWeek.Instance.FlightsInTuesday;
                WednesdaySlot.ItemsSource = SchedulePerWeek.Instance.FlightsInWednesday;
                ThursdaySlot.ItemsSource = SchedulePerWeek.Instance.FlightsInThursday;
                FridaySlot.ItemsSource = SchedulePerWeek.Instance.FlightsInFriday;
                SaturdaySlot.ItemsSource = SchedulePerWeek.Instance.FlightsInSaturday;
                SundaySlot.ItemsSource = SchedulePerWeek.Instance.FlightsInSunday;
            }
        }

        private void MondaySlot_Drop(object sender, DragEventArgs e)
        {
            DropProcess(sender, e);
        }

        private void TuesdaySlot_Drop(object sender, DragEventArgs e)
        {
            DropProcess(sender, e);
        }

        private void WednesdaySlot_Drop(object sender, DragEventArgs e)
        {
            DropProcess(sender, e);
        }

        private void ThursdaySlot_Drop(object sender, DragEventArgs e)
        {
            DropProcess(sender, e);
        }

        private void FridaySlot_Drop(object sender, DragEventArgs e)
        {
            DropProcess(sender, e);
        }

        private void SaturdaySlot_Drop(object sender, DragEventArgs e)
        {
            DropProcess(sender, e);
        }

        private void SundaySlot_Drop(object sender, DragEventArgs e)
        {
            DropProcess(sender, e);
        }
        #endregion

    }
}
