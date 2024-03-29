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
using System.Windows.Media.Animation;
using System.Threading;
using BudG.UI.ViewModels;

namespace BudG.UI.Pages
{
    /// <summary>
    /// Interaction logic for SignIn.xaml
    /// </summary>
    public partial class SignIn : Page
    {
        private MainViewModel _viewModel;

        public SignIn(MainViewModel mainViewModel )
        {
            InitializeComponent();
            _viewModel = mainViewModel;
            DataContext = _viewModel;
        }

        private void OpenSignUpMode()
        {
            Storyboard sb1 = FindResource("MoveSignUp") as Storyboard;
            sb1.Begin();
            Storyboard sb2 = FindResource("MoveSignIn") as Storyboard;
            sb2.Begin();
            Storyboard sb3 = FindResource("MoveChild") as Storyboard;
            sb3.Begin();

        }

        private void OpenSignInMode()
        {
            Storyboard sb1 = FindResource("ReturnSignUp") as Storyboard;
            sb1.Begin();
            Storyboard sb2 = FindResource("ReturnSignIn") as Storyboard;
            sb2.Begin();
            Storyboard sb3 = FindResource("ReturnChild") as Storyboard;
            sb3.Begin();
        }
        private void SignUp_Click(object sender, RoutedEventArgs e)
        {
            Task.Run(() =>
            {
                Thread.Sleep(50);
                Dispatcher.Invoke(() =>
                {
                    OpenSignUpMode();


                });
            });

            Task.Run(() =>
            {
                Thread.Sleep(300);
                Dispatcher.Invoke(() =>
                {
                    Storyboard sb3 = FindResource("ReturnChild2") as Storyboard;
                    sb3.Begin();
                    ChildOne.Visibility = Visibility.Collapsed;
                    ChildTwo.Visibility = Visibility.Visible;

                    Storyboard sb4 = FindResource("MoveCreateAcc") as Storyboard;
                    sb4.Begin();
                    SignInPart.Visibility = Visibility.Collapsed;
                    CreateAccountPart.Visibility = Visibility.Visible;
                });
            });
        }

        private void SignUp_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Point p = e.GetPosition(SignInPart);

            if (p.X == 100)
            {
                MessageBox.Show("Hide");
            }
        }

        private void BtnSignin_Click(object sender, RoutedEventArgs e)
        {
            Task.Run(() =>
            {
                Thread.Sleep(50);
                Dispatcher.Invoke(() =>
                {
                    OpenSignInMode();

                });

            });

            Task.Run(() =>
            {
                Thread.Sleep(300);
                Dispatcher.Invoke(() =>
                {
                    Storyboard sb3 = FindResource("ReturnChild") as Storyboard;
                    sb3.Begin();
                    ChildOne.Visibility = Visibility.Visible;
                    ChildTwo.Visibility = Visibility.Collapsed;

                    Storyboard sb4 = FindResource("ReturnCreateAcc") as Storyboard;
                    sb4.Begin();
                    SignInPart.Visibility = Visibility.Visible;
                    CreateAccountPart.Visibility = Visibility.Collapsed;
                });
            });
        }
    }
}
