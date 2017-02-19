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

namespace DragAndDropSample
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CreateFlight();            
        }

        public BindingList<Flight> FlightList { get; set; } = new BindingList<Flight>();

        //获取开始点
        Point startmousepos;

        private void rec_MouseDown(object sender, MouseButtonEventArgs e)
        {
            startmousepos.X = e.GetPosition(this).X;
        }
        private void rec_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
        }
        
        private void rec_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                var rectemp = sender as Rectangle;
                var margin = rectemp.Margin;
                var pos = e.GetPosition(this);
                double dx = pos.X - startmousepos.X;
                margin.Left += dx;
                rectemp.Margin = margin;
                startmousepos = pos;
            }
        }        

        void CreateFlight()
        {
            Flight f1 = new Flight { FLNum = 1001, Depart = "PEK", Arrival = "PVG", Length = 150 };
            Flight f2 = new Flight { FLNum = 1002, Depart = "PVG", Arrival = "PEK", Length = 150 };
            Flight f3 = new Flight { FLNum = 1003, Depart = "PEK", Arrival = "CTU", Length = 150 };
            Flight f4 = new Flight { FLNum = 1004, Depart = "CTU", Arrival = "PEK", Length = 150 };
            FlightList.Add(f1);
            FlightList.Add(f2);
            FlightList.Add(f3);
            FlightList.Add(f4);
        }


    }

    public class Flight
    {
        public int FLNum { get; set; }
        public string Depart { get; set; }
        public string Arrival { get; set; }
        public int Length { get; set; }
    }
}
