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
using System.Threading;
using System.ComponentModel;

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

        PositionOnEarth depart = new PositionOnEarth { longitude = 12.66, latitude = 55.62 };//CPH

        List<Route> RouteList = new List<Route>();

        private void mygrid_Loaded(object sender, RoutedEventArgs e)
        {           
            
            PositionOnEarth end1 = new PositionOnEarth { longitude = 151.18, latitude = -33.95 };//SYD
            PositionOnEarth end2 = new PositionOnEarth { longitude = 139.78, latitude = 35.55 };//HND
            PositionOnEarth end3 = new PositionOnEarth { longitude = 103.99, latitude = 1.36 };//SIN
            PositionOnEarth end4 = new PositionOnEarth { longitude = -118.41, latitude = 33.94 };//LAX
            PositionOnEarth end5 = new PositionOnEarth { longitude = 121.81, latitude = 31.14 };//PVG
            PositionOnEarth end6 = new PositionOnEarth { longitude = 24.96, latitude = 60.32 };//HEL

            Route route1 = new Route { StartOnEarth = depart, EndOnEarth = end1, StartName = "Shanghai(PVG)" , EndName = "Sydney(SYD)" };
            Route route2 = new Route { StartOnEarth = depart, EndOnEarth = end2, StartName = "Shanghai(PVG)", EndName = "Tokyo(HND)" };
            Route route3 = new Route { StartOnEarth = depart, EndOnEarth = end3, StartName = "Shanghai(PVG)", EndName = "Singapore(SIN)" };
            Route route4 = new Route { StartOnEarth = depart, EndOnEarth = end4, StartName = "Shanghai(PVG)", EndName = "Los Angeles(LAX)" };
            Route route5 = new Route { StartOnEarth = depart, EndOnEarth = end5, StartName = "Shanghai(PVG)", EndName = "Shanghai(PVG)" };
            Route route6 = new Route { StartOnEarth = depart, EndOnEarth = end6, StartName = "Shanghai(PVG)", EndName = "Helsiki(HEL)" };

     //       Route route7 = new Route { StartOnEarth = end5, EndOnEarth = end4, EndName = "Los Angeles(LAX)" };
            Route route8 = new Route { StartOnEarth = end5, EndOnEarth = end6, EndName = "Helsiki(HEL)" };

            RouteList.Add(route1);
            RouteList.Add(route2);
            RouteList.Add(route3);
            RouteList.Add(route4);
            RouteList.Add(route5);
            RouteList.Add(route6);
       //     RouteList.Add(route7);
            RouteList.Add(route8);

        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            /*
            Path newpath = new Path { StrokeThickness = 1};

            //SolidColorBrush color = new SolidColorBrush(new Color { R = (byte)rdm.Next(0, 255), G = (byte)rdm.Next(0, 255), B = (byte)rdm.Next(0, 255), A = 255 });
            //newpath.Stroke = color;
            newpath.Stroke = Brushes.Blue;
            string startPT = "M" + MX.ToString() + "," + MY.ToString() + " ";
            string CPT1 = "l" + rdm.Next(-400, 0).ToString() + "," + rdm.Next(-100, 100).ToString() + " ";
            string datastr = startPT + CPT1;
            newpath.Data = Geometry.Parse(datastr);

            RouteLayer.Children.Add(newpath);
            */


            for (int i = 0; i < RouteList.Count; i++)
            {

                DrawRoute(RouteList[i].StartOnMap, RouteList[i].MidOnMap, RouteList[i].EndOnMap);

                TextBlock txb = new TextBlock
                {
                    Text = RouteList[i].EndName ,
                    VerticalAlignment = VerticalAlignment.Top ,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    Foreground = Brushes.White
                };
                var x = RouteList[i].EndOnMap.Xpt;
                var y = RouteList[i].EndOnMap.Ypt + 5;
                RouteLayer.Children.Add(txb);
                txb.Margin = new Thickness(x, y, 0, 0);

                Rectangle rec = new Rectangle
                {
                    Fill = Brushes.AliceBlue,
                    Height = 8,
                    Width = 8,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top
                };
                RouteLayer.Children.Add(rec);
                rec.Margin = new Thickness(x-4, y - 5-4, 0, 0);
            }            
        }

        public void DrawRoute(PositionOnMap PtStart ,PositionOnMap PtMid, PositionOnMap PtEnd)
        {
            Path newpath = new Path { StrokeThickness = 1 };
            newpath.Stroke = Brushes.Red;
            string startPT = "M" + PtStart.Xpt.ToString() + "," + PtStart.Ypt.ToString() + " ";
            string midPT = "S" + PtMid.Xpt.ToString() + "," + PtMid.Ypt.ToString() + " ";
            string endPT = PtEnd.Xpt.ToString() + "," + PtEnd.Ypt.ToString() + " ";
            string datastr = startPT + midPT + endPT;
            newpath.Data = Geometry.Parse(datastr);
            RouteLayer.Children.Add(newpath);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var posstart = new PositionOnEarth { longitude = -71.6, latitude = -33 };
            var posend = new PositionOnEarth { longitude = 121.81, latitude = 31.4 };

            Route rte = new Route { StartOnEarth = posstart, EndOnEarth = posend };

            var start = rte.StartOnMap;
            var end = rte.EndOnMap;
            var mid = rte.MidOnMap;

            Path newpath = new Path { StrokeThickness = 2 };
            newpath.Stroke = Brushes.Red;

            string startPT = "M" + start.Xpt.ToString() + "," + start.Ypt.ToString() + " ";
            string MIDPT = "S" + mid.Xpt.ToString() + "," + mid.Ypt.ToString() + " ";
            string EndPT = end.Xpt.ToString() + "," + end.Ypt.ToString();
            string datastr = startPT + MIDPT+EndPT;
            newpath.Data = Geometry.Parse(datastr);
            RouteLayer.Children.Add(newpath);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }
    }
}
