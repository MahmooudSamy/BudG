using Autofac;
using BudG.UI.Container;
using System;
using System.Windows;

namespace BudG.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var bootstraper = new Bootstrapper();
            var container = bootstraper.Bootstrap();

            var Splas = container.Resolve<SplashScreen>();
            Splas.Show();
        }

        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show("Unexpected error occured.Please infromthe admin."
                + Environment.NewLine + e.Exception.Message, "Unexpected error");
            e.Handled = true;
        }
    }
}
