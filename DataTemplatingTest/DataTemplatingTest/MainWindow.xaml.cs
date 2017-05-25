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

namespace DataTemplatingTest
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

        public BindingList<Task> TaskList { get; set; } = new BindingList<Task>();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Task task1 = new Task { Name = "Shopping", Description = "abc", Priority = 1 , type  = Task.TaskType.Home };
            Task task2 = new Task { Name = "Dinner", Description = "123", Priority = 2 , type = Task.TaskType.Home };
            Task task3 = new Task { Name = "Lunch", Description = "def", Priority = 3 , type = Task.TaskType.Office};

            TaskList.Add(task1);
            TaskList.Add(task2);
            TaskList.Add(task3);

            listBox.ItemsSource = TaskList;
            listBox1.ItemsSource = TaskList;
            listBox2.ItemsSource = TaskList;
        }
    }
}
