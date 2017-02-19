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

namespace DrawingAppSample
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

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            inkcanvas.Strokes.Clear();
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        
        private void red_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            strokecolor.Fill = ((Rectangle)sender).Fill;
            Color color = (Color)ColorConverter.ConvertFromString(strokecolor.Fill.ToString());
            inkcanvas.DefaultDrawingAttributes.Color = color;
        }

        private void green_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            strokecolor.Fill = ((Rectangle)sender).Fill;
            Color color = (Color)ColorConverter.ConvertFromString(strokecolor.Fill.ToString());
            inkcanvas.DefaultDrawingAttributes.Color = color;
        }

        private void yellow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            strokecolor.Fill = ((Rectangle)sender).Fill;
            Color color = (Color)ColorConverter.ConvertFromString(strokecolor.Fill.ToString());
            inkcanvas.DefaultDrawingAttributes.Color = color;
        }

        private void blue_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            strokecolor.Fill = ((Rectangle)sender).Fill;
            Color color = (Color)ColorConverter.ConvertFromString(strokecolor.Fill.ToString());
            inkcanvas.DefaultDrawingAttributes.Color = color;
        }
        
        private void StackPanel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
