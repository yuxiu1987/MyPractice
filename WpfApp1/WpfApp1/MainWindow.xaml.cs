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

        PositionOnEarth depart = new PositionOnEarth { longitude = 121.81 , latitude = 31.14 };//PVG

        List<Route> RouteList = new List<Route>();

        private void mygrid_Loaded(object sender, RoutedEventArgs e)
        {
            
            
            PositionOnEarth end1 = new PositionOnEarth { longitude = 103.95 , latitude = 30.58 };//CTU
            PositionOnEarth end2 = new PositionOnEarth { longitude = 116.58, latitude = 40.08 };//PEK
            PositionOnEarth end3 = new PositionOnEarth { longitude = 103.99, latitude = 1.36 };//SIN
            PositionOnEarth end4 = new PositionOnEarth { longitude = -0.46, latitude = 51.48 };//LHR
            PositionOnEarth end5 = new PositionOnEarth { longitude = 12.66, latitude = 55.62 };//CPH
            PositionOnEarth end6 = new PositionOnEarth { longitude = 24.96, latitude = 60.32 };//HEL

            Route route1 = new Route { StartOnEarth = depart, EndOnEarth = end1, StartName = "Shanghai(PVG)" , EndName = "Chengdu(CTU)" };
            Route route2 = new Route { StartOnEarth = depart, EndOnEarth = end2, StartName = "Shanghai(PVG)", EndName = "Beijing(PEK)" };
            Route route3 = new Route { StartOnEarth = depart, EndOnEarth = end3, StartName = "Shanghai(PVG)", EndName = "Singapore(SIN)" };
            Route route4 = new Route { StartOnEarth = depart, EndOnEarth = end4, StartName = "Shanghai(PVG)", EndName = "London(LHR)" };
            Route route5 = new Route { StartOnEarth = depart, EndOnEarth = end5, StartName = "Shanghai(PVG)", EndName = "Copenhagen(CPH)" };
            Route route6 = new Route { StartOnEarth = depart, EndOnEarth = end6, StartName = "Shanghai(PVG)", EndName = "Helsiki(HEL)" };

            RouteList.Add(route1);
            RouteList.Add(route2);
            RouteList.Add(route3);
            RouteList.Add(route4);
            RouteList.Add(route5);
            RouteList.Add(route6);



            for (int i = 0; i < RouteList.Count; i++)
            {
                var x = endlistinEarth[i].longitude;
                var y = endlistinEarth[i].latitude;
                PositionOnMap ptmap = Mercator_Converter.GetPTOnMap(x, y);
                endlistinMap.Add(ptmap);
            }


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

            for (int i = 0; i < endlistinMap.Count; i++)
            {
                var x = endlistinMap[i].Xpt;
                var y = endlistinMap[i].Ypt;
                DrawRoute(departinmap, endlistinMap[i]);

                switch(i)
                {
                    case 0: 
                        TextBlock txb1 = new TextBlock { Text = "Chengdu(CTU)", Foreground = Brushes.White };
                        RouteLayer.Children.Add(txb1);
                        txb1.Margin = new Thickness(x, y+10, 0, 0);                        break;
                    case 1:
                        TextBlock txb2 = new TextBlock { Text = "Beijing(PEK)", Foreground = Brushes.White };
                        RouteLayer.Children.Add(txb2);
                        txb2.Margin = new Thickness(x, y+10, 0, 0);
                        break;
                    case 2:
                        TextBlock txb3 = new TextBlock { Text = "Singapore(SIN)", Foreground = Brushes.White };
                        RouteLayer.Children.Add(txb3);
                        txb3.Margin = new Thickness(x, y+10, 0, 0);
                        break;
                    case 3:
                        TextBlock txb4 = new TextBlock { Text = "London(LHR)", Foreground = Brushes.White };
                        RouteLayer.Children.Add(txb4);
                        txb4.Margin = new Thickness(x, y+10, 0, 0);
                        break;
                    case 4:
                        TextBlock txb5 = new TextBlock { Text = "Copenhagen(CPH)", Foreground = Brushes.White };
                        RouteLayer.Children.Add(txb5);
                        txb5.Margin = new Thickness(x, y+10, 0, 0);
                        break;
                    case 5:
                        TextBlock txb6 = new TextBlock { Text = "Helsinki(HEL)", Foreground = Brushes.White };
                        RouteLayer.Children.Add(txb6);
                        txb6.Margin = new Thickness(x, y+10, 0, 0);
                        break;
                }

                switch(i)
                {
                    case 0:
                        Rectangle pin1 = new Rectangle
                        {
                            Height = 7, Width = 7, Fill = Brushes.AliceBlue ,
                            HorizontalAlignment = HorizontalAlignment.Left,
                            VerticalAlignment = VerticalAlignment.Top
                        };
                        PushpinLayer.Children.Add(pin1);
                        pin1.Margin = new Thickness(x,y, 0, 0);
                        break;
                    case 1:
                        Rectangle pin2 = new Rectangle
                        {
                            Height = 7,
                            Width = 7,
                            Fill = Brushes.AliceBlue,
                            HorizontalAlignment = HorizontalAlignment.Left,
                            VerticalAlignment = VerticalAlignment.Top
                        };
                        PushpinLayer.Children.Add(pin2);
                        pin2.Margin = new Thickness(x,y, 0, 0);
                        break;
                    case 2:
                        Rectangle pin3 = new Rectangle
                        {
                            Height = 7,
                            Width = 7,
                            Fill = Brushes.AliceBlue,
                            HorizontalAlignment = HorizontalAlignment.Left,
                            VerticalAlignment = VerticalAlignment.Top
                        };
                        PushpinLayer.Children.Add(pin3);
                        pin3.Margin = new Thickness(x,y, 0, 0);
                        break;
                    case 3:
                        Rectangle pin4 = new Rectangle
                        {
                            Height = 7,
                            Width = 7,
                            Fill = Brushes.AliceBlue,
                            HorizontalAlignment = HorizontalAlignment.Left,
                            VerticalAlignment = VerticalAlignment.Top
                        };
                        PushpinLayer.Children.Add(pin4);
                        pin4.Margin = new Thickness(x,y, 0, 0);
                        break;
                    case 4:
                        Rectangle pin5 = new Rectangle
                        {
                            Height = 7,
                            Width = 7,
                            Fill = Brushes.AliceBlue,
                            HorizontalAlignment = HorizontalAlignment.Left,
                            VerticalAlignment = VerticalAlignment.Top
                        };
                        PushpinLayer.Children.Add(pin5);
                        pin5.Margin = new Thickness(x,y, 0, 0);
                        break;
                    case 5:
                        Rectangle pin6 = new Rectangle
                        {
                            Height = 7,
                            Width = 7,
                            Fill = Brushes.AliceBlue,
                            HorizontalAlignment = HorizontalAlignment.Left,
                            VerticalAlignment = VerticalAlignment.Top
                        };
                        PushpinLayer.Children.Add(pin6);
                        pin6.Margin = new Thickness(x,y, 0, 0);
                        break;
                }
            }            
        }

        public void DrawRoute(PositionOnMap PtStart ,PositionOnMap PtMid, PositionOnMap PtEnd)
        {
            Path newpath = new Path { StrokeThickness = 2 };
            newpath.Stroke = Brushes.Blue;
            string startPT = "M" + PtStart.Xpt.ToString() + "," + PtStart.Ypt.ToString() + " ";
            string midPT = PtMid.Xpt.ToString() + "," + PtMid.Ypt.ToString();
            string endPT = "S" + PtEnd.Xpt.ToString() + "," + PtEnd.Ypt.ToString() + " ";
            string datastr = startPT + midPT + endPT;
            newpath.Data = Geometry.Parse(datastr);
            RouteLayer.Children.Add(newpath);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var start = Mercator_Converter.GetPTOnMap(-71.6, -33);
            var end = Mercator_Converter.GetPTOnMap(121.81, 31.14);

            var mid = Mercator_Converter.GetPTOnMap(25.1, 12.78);

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
            var start = Mercator_Converter.GetPTOnMap(-71.6, -33);
            var end = Mercator_Converter.GetPTOnMap(121.81, 31.14);

            DrawRoute(start, end);
        }
    }
}
