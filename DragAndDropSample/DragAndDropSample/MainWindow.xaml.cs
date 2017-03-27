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

        #region label的content属性拖拽进listbox
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
            if(e.Data.GetDataPresent(DataFormats.StringFormat))
            {
                var str = e.Data.GetData(DataFormats.StringFormat);
                list.Items.Add(str);
            }

        }

        private void listbox_DragLeave(object sender, DragEventArgs e)
        {
            var list = sender as ListBox;
            if (e.Data.GetDataPresent(DataFormats.StringFormat))
            {
                var str = e.Data.GetData(DataFormats.StringFormat);
                list.Items.Remove(str);
            }
            
        }

        private void listbox_DragOver(object sender, DragEventArgs e)
        {
            if(!e.Data.GetDataPresent(DataFormats.StringFormat))
            {
                e.Effects = DragDropEffects.None;
            }
        }

        private void listbox_Drop(object sender, DragEventArgs e)
        {
            
            var list = sender as ListBox;
            if (e.Data.GetDataPresent(DataFormats.StringFormat))
            {
                var str = e.Data.GetData(DataFormats.StringFormat);
                list.Items.Remove(str);
                list.Items.Add(str);
            }

        }
        #endregion



        #region 拖拽label时将自定义数据对象拖拽进listbox
        private void Label_MouseMove_1(object sender, MouseEventArgs e)
        {
            var _label = sender as Label;
            if((_label != null)&& e.LeftButton == MouseButtonState.Pressed)
            {
                string datacontent = "liu yi wei";
                DataObject dataobj = new DataObject(datacontent.GetType(), datacontent);
                DragDrop.DoDragDrop(_label, dataobj, DragDropEffects.Copy);
            }
        }
        #endregion


        #region rectangle拖拽进grid


        private void rec_MouseMove(object sender, MouseEventArgs e)
        {
            var _rec = sender as Rectangle;
            if ((_rec != null) && e.LeftButton == MouseButtonState.Pressed)
            {

                ((Grid)_rec.Parent).Children.Remove(_rec);
                Rectangle datacontent = _rec;

                DataObject dataobj = new DataObject("myrec", datacontent);
                DragDrop.DoDragDrop(rec, dataobj, DragDropEffects.Copy);
            }
        }

        private void Grid_DragEnter(object sender, DragEventArgs e)
        {
            var gd = sender as Grid;
            if (e.Data.GetDataPresent("myrec"))
            {
                var temp = e.Data.GetData("myrec");
                gd.Children.Add(temp as Rectangle);
            }
        }

        private void Grid_DragLeave(object sender, DragEventArgs e)
        {
            var gd = sender as Grid;
            if (e.Data.GetDataPresent("myrec"))
            {
                var temp = e.Data.GetData("myrec");
                gd.Children.Remove(temp as Rectangle);
            }
        }

        private void Grid_DragOver(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent("myrec"))
            {
                e.Effects = DragDropEffects.None;
            }
        }

        private void Grid_Drop(object sender, DragEventArgs e)
        {
            var gd = sender as Grid;
            if (e.Data.GetDataPresent("myrec"))
            {
                var temp = e.Data.GetData("myrec");
                gd.Children.Add(temp as Rectangle);
            }
        }        
        #endregion


    }
    



}
