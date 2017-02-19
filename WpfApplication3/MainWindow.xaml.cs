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

namespace WpfApplication3 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        private Point _lastMousePos;
        public MainWindow() {
            InitializeComponent();
        }
        private void Rectangle_MouseMove(object sender, MouseEventArgs e) {
            if (e.LeftButton == MouseButtonState.Pressed) {
                var rect = (Rectangle)sender;
                var pos = e.GetPosition(this);
                var margin = rect.Margin;
                #region 这里可以做边界检查，以及对Y轴位移逻辑检查等
                margin.Left += pos.X - _lastMousePos.X;
                rect.Margin = margin;
                _lastMousePos = pos;
                #endregion
            }
        }

        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e) {
            _lastMousePos = e.GetPosition(this);
        }
    }
}
