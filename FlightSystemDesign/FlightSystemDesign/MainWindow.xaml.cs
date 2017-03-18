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

namespace FlightSystemDesign
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
            MyDate.Instance.InitDate();

            MyDate.Instance.ActiveSettlementEvent += Settlement.Instance.DaySettlement;

            DataCenter.Instance.DataInit();
            

            dayofweeklabel.DataContext = MyDate.Instance;
            totaodayslabel.DataContext = MyDate.Instance;
            weekcountlabel.DataContext = MyDate.Instance;

            listBox.ItemsSource = DataCenter.Instance.WeeklyScheduledProp.ThisWeeklyScheduled[0].TodayTotalFlight;
            listBox1.ItemsSource = DataCenter.Instance.WeeklyScheduledProp.ThisWeeklyScheduled[1].TodayTotalFlight;
            listBox2.ItemsSource = DataCenter.Instance.WeeklyScheduledProp.ThisWeeklyScheduled[2].TodayTotalFlight;
            listBox3.ItemsSource = DataCenter.Instance.WeeklyScheduledProp.ThisWeeklyScheduled[3].TodayTotalFlight;
            listBox4.ItemsSource = DataCenter.Instance.WeeklyScheduledProp.ThisWeeklyScheduled[4].TodayTotalFlight;
            listBox5.ItemsSource = DataCenter.Instance.WeeklyScheduledProp.ThisWeeklyScheduled[5].TodayTotalFlight;
            listBox6.ItemsSource = DataCenter.Instance.WeeklyScheduledProp.ThisWeeklyScheduled[6].TodayTotalFlight;
        }

        private void DayStep1_Click(object sender, RoutedEventArgs e)
        {
            MyDate.Instance.DayStep();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            DataCenter.Instance.SLD1001.ScheduledTable.Add(DayOfWeek.Tuesday);
            DataCenter.Instance.SLD1001.ScheduledTable.Add(DayOfWeek.Thursday);
            DataCenter.Instance.SLD1001.ScheduledTable.Remove(DayOfWeek.Monday);
        }

        private void DayStep30_Click(object sender, RoutedEventArgs e)
        {
            for(int i=0;i<30;i++)
            {
                MyDate.Instance.DayStep();
            }
        }
    }
}
