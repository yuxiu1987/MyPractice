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
using System.Runtime.CompilerServices;

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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //设置绑定
            dayslistbox.ItemsSource = curTime.DaysList;
            timercount.DataContext = curTime;
            timedisplay.DataContext = curTime;
        }

        public static CurTime curTime { get; set; } = new CurTime { time = DateTime.Now, TimerCount = 0 };
        BackgroundWorker mybackWorker = new BackgroundWorker();

        public volatile bool IsRunning = false;

        public delegate void UpdataHandle();



        public void CountTime(object sender, DoWorkEventArgs e)
        {
            UpdataHandle myupdata = new UpdataHandle(Updata);
            while (IsRunning)
            {
                Thread.Sleep(500);
                curTime.TimerCount++;
                curTime.time = curTime.time.AddDays(1);

                //通过委托去更新数据集合
                myupdata();
            }

            MessageBox.Show(curTime.DaysList.Count.ToString());
        }

        public void Updata()
        {
            //主线程不能直接维护被绑定到界面的bindingable集合，因此需要主线程的Dispatcher来执行一个任务来维护，注意Dispatcher并不是开启一个新线程
            //下面lambda表达式中执行的语句是在主线程中执行的，以便WPF的界面维护线程可以访问到该集合
            //如果是简单的一个变量，如本demo中的 curtime属性，就不需要dispatcher.Invoke方法
            this.Dispatcher.Invoke(new Action(() => { curTime.DaysList.Add(curTime.time); }));
        }

        public void ResetTimer()
        {
            curTime.TimerCount = 0;
            curTime.time = DateTime.Now;
        }

        public void StartTimer()
        {
            IsRunning = true;
        }

        public void StopTimer()
        {
            IsRunning = false;
        }



        private void startbutton_Click(object sender, RoutedEventArgs e)
        {
            mybackWorker.DoWork += CountTime;
            mybackWorker.RunWorkerAsync();
            StartTimer();
        }

        private void stopbutton_Copy_Click(object sender, RoutedEventArgs e)
        {
            StopTimer();
        }

        /// <summary>
        /// 时间类
        /// </summary>
        public class CurTime : INotifyPropertyChanged
        {
            public DateTime time { get { return _time; } set { SetProperty(ref _time, value); } }
            private DateTime _time;

            public long TimerCount { get { return _TimerCount; } set { SetProperty(ref _TimerCount, value); } }
            private long _TimerCount;

            public BindingList<DateTime> DaysList { get; set; } = new BindingList<DateTime>();

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

            protected void SetProperty<T>(ref T item, T value, [CallerMemberName] string propertyName = null)
            {
                if (!EqualityComparer<T>.Default.Equals(item, value))
                {
                    item = value;
                    OnPropertyChanged(propertyName);
                }
            }
        }

        private void add_button_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }   

}
