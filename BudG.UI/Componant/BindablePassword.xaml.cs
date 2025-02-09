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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BudG.UI.Componant
{
    /// <summary>
    /// Interaction logic for BindablePassword.xaml
    /// </summary>
    public partial class BindablePassword : UserControl
    {

        public BindablePassword()
        {
            InitializeComponent();
        }

        private bool _isPasswordChanging;
        public string Password
        {
            get { return (string)GetValue(PasswordProperty); }
            set { SetValue(PasswordProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Password.
        // This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PasswordProperty =
            DependencyProperty.Register("Password", typeof(string), typeof(BindablePassword),
                new FrameworkPropertyMetadata(string.Empty,FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                    PasswordPropertyChange,null,false,UpdateSourceTrigger.PropertyChanged));

        private static void PasswordPropertyChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
           if(d is BindablePassword PasswordBox)
            {
                PasswordBox.UpdatePassword();
            }
        }

        private void UpdatePassword()
        {
           if(!_isPasswordChanging)
            {
                PasswordBox.Password = Password;
            }
           
            
        }

       

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            _isPasswordChanging = true;
            Password = PasswordBox.Password;
            _isPasswordChanging = false;
        }
    }
}
