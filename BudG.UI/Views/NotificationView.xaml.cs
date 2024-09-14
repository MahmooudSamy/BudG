﻿using System;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BudG.UI.Views
{
    /// <summary>
    /// Interaction logic for NotificationView.xaml
    /// </summary>
    public partial class NotificationView : UserControl
    {
        public NotificationView()
        {
            InitializeComponent();
        }
        private void storyboard()
        {
            Storyboard sb = Resources["SlideIn"] as Storyboard;
            sb.Begin(BrdLayout);
        }

        private void notificationCard_Loaded(object sender, RoutedEventArgs e)
        {
            storyboard();
        }
    }
}
