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

        #region label拖拽进listbox
        string previous;
        private void label_MouseMove(object sender, MouseEventArgs e)
        {
            var _label = sender as Label;
            if((_label != null) && e.LeftButton == MouseButtonState.Pressed)
            {
                DragDrop.DoDragDrop(label, label.Content.ToString(), DragDropEffects.Move);
            }
        }

        
        private void listbox_DragEnter(object sender, DragEventArgs e)
        {
            var list = sender as ListBox;
            var str = e.Data.GetData(DataFormats.StringFormat);
            list.Items.Add(str);
        }

        private void listbox_DragLeave(object sender, DragEventArgs e)
        {
            var list = sender as ListBox;
            var str = e.Data.GetData(DataFormats.StringFormat);
            list.Items.Remove(str);
        }

        private void listbox_DragOver(object sender, DragEventArgs e)
        {
            var list = sender as ListBox;
            e.Effects = DragDropEffects.Move;
        }

        private void listbox_Drop(object sender, DragEventArgs e)
        {
            /*
            var list = sender as ListBox;
            var str = e.Data.GetData(DataFormats.StringFormat);

            list.Items.Remove(str);


            list.Items.Add(str);
            */
            
        }
        #endregion

        #region rectangle拖拽进stacpanel

        Rectangle temprec;
        Point startpt;
        object captured;
        private void rec_MouseMove(object sender, MouseEventArgs e)
        {
            var rect = sender as Rectangle;
            DataObject dataobj = new DataObject("mydata", rect);
            if( (rect != null)&& e.LeftButton == MouseButtonState.Pressed )
            {
                DragDrop.DoDragDrop(rect, dataobj, DragDropEffects.Copy);
            }
        }


        private void stack_DragEnter(object sender, DragEventArgs e)
        {
            if(!e.Data.GetDataPresent("mydata"))
            {
                e.Effects = DragDropEffects.None;
            }
            Rectangle temp = (Rectangle)e.Data.GetData("mydata");

            temprec = new Rectangle { Height = temp.Height, Width = temp.Width, Fill = temp.Fill , Name = "newrec" };
            gd.Children.Add(temprec);            
        }

        private void gd_MouseMove(object sender, MouseEventArgs e)
        {
            var currentgd = sender as Grid;
            if ((currentgd != null) && e.LeftButton == MouseButtonState.Pressed)
            {
                startpt = e.GetPosition(currentgd);
                var margin = temprec.Margin;
                var currentpos = e.GetPosition(currentgd);
                e.MouseDevice.Capture(temprec);
                double dx = currentpos.X - startpt.X;
                double dy = currentpos.Y - startpt.Y;
                margin.Left += dx;
                margin.Right -= dx; margin.Top += dy; margin.Bottom -= dy;
            }
            else e.MouseDevice.Capture(null);
        }

        private void stack_DragLeave(object sender, DragEventArgs e)
        {
            gd.Children.Clear();
        }

        private void stack_DragOver(object sender, DragEventArgs e)
        {
            
        }

        private void stack_Drop(object sender, DragEventArgs e)
        {
            if(e.Data.GetDataPresent("mydata"))
            {
                Rectangle recin = new Rectangle();
                recin = e.Data.GetData("mydata") as Rectangle;

                gd.Children.Add(new Rectangle { Height = recin.Height , Width = recin.Width,
                Fill = recin.Fill});
            }
        }
        #endregion


    }
}
