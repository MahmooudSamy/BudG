using BudG.UI.Events;
using BudG.UI.Interface;
using Prism.Commands;
using Prism.Events;
using System;
using System.Windows.Input;
using System.Windows.Media;

namespace BudG.UI.ViewModels
{
    public class NotificationViewModel : ViewModelBase, INotificationViewModel
    {

        private string _message;
        private string _title;
        private SolidColorBrush _background;
        private IEventAggregator _eventAggregator;
        public NotificationViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            NotifayClose = new DelegateCommand(OnNotifayClosingExecute);
        }

        private void OnNotifayClosingExecute()
        {
            _eventAggregator.GetEvent<CloseOpenNotification>()
                  .Publish(new CloseOpenNotificationArgs
                  {
                      IsOpen = false
                  }) ;
        }

        public void ShowMessageNotification(string message, string title, NotificationType type)
        {
            Message = message;
            Title = title;
            Message = message;
            switch (type)
            {
                case NotificationType.Error:
                    Background = new SolidColorBrush(Color.FromRgb(250, 0, 2));

                    break;
                case NotificationType.Info:
                    Background = new SolidColorBrush(Color.FromRgb(48, 134, 234));

                    break;
                case NotificationType.Warning:
                    Background = new SolidColorBrush(Color.FromRgb(255, 183, 0));

                    break;
                case NotificationType.Success:
                    Background = new SolidColorBrush(Color.FromRgb(22, 173, 37));

                    break;
                default:
                    Background = new SolidColorBrush(Color.FromRgb(22, 173, 37));
                    break;

            }
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; OnPropertyChanged(); }
        }

        public string Message
        {
            get { return _message; }
            set { _message = value; OnPropertyChanged(); }
        }
        public SolidColorBrush Background
        {
            get { return _background; }
            set { _background = value; OnPropertyChanged(); }
        }

      

        public ICommand NotifayClose { get; }
    }
}
