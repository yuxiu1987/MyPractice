﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MahApps.Metro.Controls;

namespace customControlsPractice
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {

        }

        public int progress { get; set; } = 30;  



        private void ToggleSwitchButton_Checked(object sender, RoutedEventArgs e)
        {            
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            progress += 10;
            progressbar.Value = progress;
        }


    }
}
