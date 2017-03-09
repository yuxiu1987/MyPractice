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

        public Flight thisflight { get; set; } = new Flight { FlightNumber = 1001, Code = "SLD" };

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            thisflight.FlightTable.Clear();
            for(int i = 0; i<thisflight.FlightTable.Length;i++)
            {
                thisflight.FlightTable[i].ScheduledFlight = Schedule
            }

            Schedule mon = Schedule.Mon;
            Schedule wed = Schedule.Wed;
            Schedule fri = Schedule.Fri;

            thisflight.ScheduledFLight.Add(mon);
            thisflight.ScheduledFLight.Add(wed);
            thisflight.ScheduledFLight.Add(fri);

            foreach(Schedule s in thisflight.ScheduledFLight)
            {
                thisflight.FlightTable[(int)s] = true;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            thisflight.ScheduledFLight.Clear();
            Schedule tue = Schedule.Tue;
            Schedule thu = Schedule.Thu;
            Schedule sat = Schedule.Sat;

            thisflight.ScheduledFLight.Add(tue);
            thisflight.ScheduledFLight.Add(thu);
            thisflight.ScheduledFLight.Add(sat);

            foreach (Schedule s in thisflight.ScheduledFLight)
            {
                thisflight.FlightTable[(int)s] = true;
            }

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {            
            Binding bd = new Binding();
            bd.Source = thisflight.FlightTable;
            bd.Mode = BindingMode.OneWay;
            SetBinding(DataContextProperty, bd);
        }
    }

    public class Flight :Bindable
    {
        public int FlightNumber { get; set; }
        public string Code { get; set; }
        public string FullNumber { get { return Code + Convert.ToString(FlightNumber); } }
        public Schedule ScheduledFlight;

        public Flight[] FlightTable { get { return _FlightTable; } set { SetProperty(ref _FlightTable, value);  } }
        private Flight[] _FlightTable = new Flight[7];
        

    }
    public enum Schedule : int { Mon = 0, Tue, Wed, Thu, Fri, Sat, Sun, Null }

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
