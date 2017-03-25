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
        }

        private void label_MouseMove(object sender, MouseEventArgs e)
        {
            var _label = sender as Label;
            if((_label != null) && e.LeftButton == MouseButtonState.Pressed)
            {
                DragDrop.DoDragDrop(label, label.Content.ToString(), DragDropEffects.Copy);
            }
        }

        private void listbox_DragEnter(object sender, DragEventArgs e)
        {

        }

        private void listbox_DragLeave(object sender, DragEventArgs e)
        {

        }

        private void listbox_DragOver(object sender, DragEventArgs e)
        {
            var list = sender as ListBox;
            e.Effects = DragDropEffects.Copy;
        }

        private void listbox_Drop(object sender, DragEventArgs e)
        {
            var list = sender as ListBox;
            var str = e.Data.GetData(DataFormats.StringFormat);
            list.Items.Add(str);
        }
    }
}
