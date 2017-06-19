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
using System.Threading;

namespace ThreadTimerWPF
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


        MyTimer myTimer = new MyTimer();
        BackgroundWorker mybackWorker = new BackgroundWorker();

        public static long mytimecount { get; set; }     

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
            mybackWorker.DoWork += myTimer.CountTime;

            myTimer.StartTimer();

            mybackWorker.RunWorkerAsync();
            
            timercount.Text = mytimecount.ToString();            
        }

        private void startbutton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(myTimer.TimerCount.ToString());

            myTimer.DaysList.Add(myTimer.time);
            dayslistbox.ItemsSource = myTimer.DaysList;

            myTimer.StartTimer();

        }

        private void stopbutton_Copy_Click(object sender, RoutedEventArgs e)
        {
            myTimer.StopTimer();
        }

        public class MyTimer : INotifyPropertyChanged
        {

            public MyTimer()
            {
                IsRunning = false;
                TimerCount = 0;
                time = DateTime.Now;
            }

            public BindingList<DateTime> DaysList = new BindingList<DateTime>();

            public DateTime time { get; set; }
            public volatile bool IsRunning;
            public long TimerCount { get { return _TimerCount; } set { OnPropertyChanged("TimerCount"); _TimerCount = value; } }
            private long _TimerCount;

            public void CountTime(object sender, DoWorkEventArgs e)
            {
                while (IsRunning)
                {
                    Thread.Sleep(200);
                    TimerCount++;
                    time = time.AddDays(1);
                    mytimecount = TimerCount;
                }
            }

            public void ResetTimer()
            {
                TimerCount = 0;
            }

            public void StartTimer()
            {
                IsRunning = true;
            }

            public void StopTimer()
            {
                IsRunning = false;
            }


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
        }

    }   

}
