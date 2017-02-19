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

namespace Grid_draw
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

        void Render()
        {
            for(int i = 0; i<3; i++)
            {
                drawmap.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(20) });
            }
            for(int i = 0; i < 10; i++)
            {
                drawmap.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(20) });
            }
            for(int i = 0; i<10; i++)
            {
                Rectangle childGrid = new Rectangle() { Height = 20, Width = 20 };
                Color color1 = (Color)ColorConverter.ConvertFromString("Blue");
                childGrid.Fill = new SolidColorBrush { Color = color1 };
                drawmap.Children.Add(childGrid);
                childGrid.SetValue(Grid.RowProperty, 0);
                childGrid.SetValue(Grid.ColumnProperty, i);
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Render();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(Convert.ToString(drawmap.RowDefinitions.Count) );

            /*
            Grid childGrid = new Grid() { Height = 20, Width = 20 };
            childGrid.Background = new SolidColorBrush { Color = new Color {A = 255 , R = 100 , G=0 , B = 200} };

            Color color = new Color { A = 255, R = 100, G = 100, B = 100 };
            

            Color color1 = (Color)ColorConverter.ConvertFromString("Blue");

            childGrid.Background = new SolidColorBrush { Color = color1 };
            drawmap.Children.Add(childGrid);
            childGrid.SetValue(Grid.RowProperty, 2);
            childGrid.SetValue(Grid.ColumnProperty, 3);
            */
        }
    }
}
