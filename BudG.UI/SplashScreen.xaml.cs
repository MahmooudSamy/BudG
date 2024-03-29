using Autofac;
using BudG.UI.Container;
using BudG.UI.ViewModels;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace BudG.UI
{
    /// <summary>
    /// Interaction logic for SplashScreen.xaml
    /// </summary>
    public partial class SplashScreen : Window
    {
        private MainViewModel _viewmodel;

        public SplashScreen(MainViewModel mainViewModel)
        {
            InitializeComponent();
            _viewmodel = mainViewModel;
            DataContext = _viewmodel;
        }

        private void Splashwindow_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                TxtStatus.Text = "Starting long Task...";
                Thread.Sleep(1000);
                TxtStatus.Text = "In Progress...";
                StartPB.Value = 0;
                Task.Run(() =>
                {
                    for (int i = 0; i < 101; i++)
                    {

                        Thread.Sleep(50);
                        Dispatcher.Invoke(() => //Use Dispather to Update UI Immediately  
                        {
                            StartPB.Value = i;
                            TxtCountDown.Text = i.ToString() + "%";
                        });
                    }
                });
                Task.Run(() =>
                {
                    Thread.Sleep(6000);

                    Dispatcher.Invoke( async() => //Use Dispather to Update UI Immediately  
                    {
                        TxtStatus.Text = "Done...";
                     
                       await _viewmodel.Load();
                        var bootstraper = new Bootstrapper();
                        var container = bootstraper.Bootstrap();

                        var Azu = container.Resolve<AouthraizationWindow>();
                        Azu.Show();
                        Close();

                    });

                });
            }
            catch (TaskCanceledException)
            {
                Environment.Exit(Environment.ExitCode);
            }
        }
    }
}
