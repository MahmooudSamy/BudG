using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace BudG.UI.Views
{
    /// <summary>
    /// Interaction logic for SignUpView.xaml
    /// </summary>
    public partial class SignUpView : UserControl
    {
        public SignUpView()
        {
            InitializeComponent();
        }

        private void CreateNewAccountView_Loaded(object sender, RoutedEventArgs e)
        {
            TxtFirstName.Focus();
        }

        private void TxtFirstName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
                {
                    TxtLastName.Focus();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Unhandle error has occur {ex.Message}");
            }
        }

        private void TxtLastName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
                {
                    TxtEmail.Focus();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Unhandle error has occur {ex.Message}");
            }
        }

        private void TxtEmail_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
                {
                    TxtUserName.Focus();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Unhandle error has occur {ex.Message}");
            }
        }

        private void TxtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
                {
                    BtnSignUp.Focus();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Unhandle error has occur {ex.Message}");
            }
        }

        private void TxtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
                {
                    TxtPassword.Focus();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Unhandle error has occur {ex.Message}");
            }
        }
    }
}
