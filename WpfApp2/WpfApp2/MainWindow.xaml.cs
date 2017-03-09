using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace WpfApp2
{
    /// <summary>
    /// INotifyPropertyChanged 实现列表更新信息后通知客户端
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
            stulist[2] = new student { name = "chen" };

            label.DataContext = names;//简单绑定，DataContext是一个依赖项属性，可以直接用类给它赋值以创建绑定
            label1.DataContext = names;
            label2.DataContext = names;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

            
            stulist[1].name = "Liu";
        }
    }

    public class student : Bindable
    {
        public string name { get { return _name; } set { SetProperty(ref _name, value); } }
        private string _name;
    }

    public class stunames : Bindable
    {
        public stunames()
        {
            namelist = temp;
            namelist.Add("Zhang");
            namelist.Add("Wang");
            namelist.Add("Chen");
        }
        private List<string> temp { get; set; } = new List<string>();
        public List<string> namelist { get { return _namelist; } set { SetProperty(ref _namelist, value); } }
        private List<string> _namelist;

    }

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
