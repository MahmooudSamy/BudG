using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using BudG.UI.ViewModels;

namespace BudG.UI
{
    /// <summary>
    /// Interaction logic for AouthraizationWindow.xaml
    /// </summary>
    public partial class AouthraizationWindow : Window
    {
        private MainViewModel _mainViewModel;

        public AouthraizationWindow(MainViewModel mainViewModel)
        {
            InitializeComponent();
            Width = 1000;
            Height = 600;
            WindowState = WindowState.Normal;
            _mainViewModel = mainViewModel;
            DataContext = _mainViewModel;
        }
        private void DataBinder(object sender, ExecutedRoutedEventArgs e)
        {
            ProjectorFrame.NavigationService.Navigate(new Uri((string)e.Parameter, UriKind.Relative));

        }

        private void DataBinderExecuter(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        private void Brdholder_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                if (WindowState == WindowState.Normal)
                {
                   // WindowState = WindowState.Maximized;
                }
                else
                {
                    Width = 1000;
                    Height = 600;
                    WindowState = WindowState.Normal;
                }
            }
            else
            {
                DragMove();
            }
        }
        public void OpenPage()
        {

            _mainViewModel.NavigateToPageInFrame = new Pages.SignIn(_mainViewModel);
            //ProjectorFrame.NavigationService.Navigate(new LogInPage(this, _viewmodel));

        }
        private  void mainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Task.Run(() =>
            {
                
                //Thread.Sleep(10);
                
                Dispatcher.Invoke(async () => //Use Dispather to Update UI Immediately  
                {
                    
                    await _mainViewModel.Load();
                    OpenPage();
                    //ProjectorFrame.Content = new Pages.SignIn();

                });

            });
        }
    }
}
