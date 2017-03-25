using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;


namespace WpfApp2
{
    /// <summary>
    /// INotifyPropertyChanged 实现列表更新信息后通知客户端
    /// 此接口不能在集合属性身上实现
    /// 如果要在集合中使用此接口，确认集合的Item是实现了InotifyPropertyChanged接口的类，并且其属性调用了侦听方法
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public student zhang { get; set; } = new student { name = "Zhang" };
        public student[] stulist { get; set; } = new student[3];
        public stunames names { get; set; } = new stunames();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            stulist[0] = new student { name = "Zhang" };
            stulist[1] = new student { name = "Wang" };
            stulist[2] = new student { name = "Chen" };

            label.DataContext = names.namelist;//简单绑定，DataContext是一个依赖项属性，可以直接用类给它赋值以创建绑定
            label1.DataContext = names.namelist;
            label2.DataContext = names.namelist;

            label4.DataContext = stulist;//简单绑定，DataContext是一个依赖项属性，可以直接用类给它赋值以创建绑定
            label5.DataContext = stulist;
            label6.DataContext = stulist;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            names.namelist[1].name = "Liu";//更改值         
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            stulist[1].name = "Liu";//更改值
        }
    }

    public class student : Bindable
    {
        public string name { get { return _name; } set { SetProperty(ref _name, value); } }
        private string _name;
    }

    public class stunames 
    {
        public stunames()
        {
            namelist = temp;
            namelist.Add(new student { name = "Zhang" });
            namelist.Add(new student { name = "Wang" });
            namelist.Add(new student { name = "Chen" });

        }
        private List<student> temp { get; set; } = new List<student>();
        public List<student> namelist { get { return _namelist; } set { _namelist = value; } }
        private List<student> _namelist;
    }

    //抽象类实现INotifyPropertyChanged接口
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

        protected void SetProperty<T>(ref T item, T value, [CallerMemberName] string propertyName = null)
        {
            if (!EqualityComparer<T>.Default.Equals(item, value))
            {
                item = value;
                OnPropertyChanged(propertyName);
            }
        }
    }
}
