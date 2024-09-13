using BudG.Domain;
using BudG.UI.Events;
using BudG.UI.Interface;
using Prism.Commands;
using Prism.Events;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace BudG.UI.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        //Creators
        private Func<IUserViewModel> _userViewModelCreator;
        private Func<IAnswerViewModel> _answerViewModelCreator;
        private Func<INotificationViewModel> _notificationViewModelCreator;
        private Func<ILogInViewModel> _LoginViewModelCreator;

        //Creators

        //feilds
        private ILogInViewModel _loginviewmodel;
        private IEventAggregator _eventAggregator;
        private IUserViewModel _userViewModel;
        private IAnswerViewModel _answerViewModel;
        private INotificationViewModel _NotificationViewModel;
        private Page _navigateToPageInFrame;
        //feilds
        public MainViewModel(Func<IUserViewModel> userViewModelCreator, Func<IAnswerViewModel> answerViewModelCreator,
            INavigationViewModel navigationViewModel,Func<INotificationViewModel> NotificationViewModelCreator
            , Func<ILogInViewModel> LoginViewModelCreator, IEventAggregator eventAggregator)
        {
            _userViewModelCreator = userViewModelCreator;
            _answerViewModelCreator = answerViewModelCreator;
            _notificationViewModelCreator = NotificationViewModelCreator;
            _LoginViewModelCreator = LoginViewModelCreator;
            _eventAggregator = eventAggregator;
            Users = new ObservableCollection<User>();
            NavigationViewModel = navigationViewModel;
            //Comands
            OpenCreateAccCommand = new DelegateCommand(OnOpenCreateAccCommand);
            OpenSigninCommand = new DelegateCommand(OnSignInAccountCommand);
            //Comands
            //Events
            _eventAggregator.GetEvent<OpenPopupsEvent>().Subscribe(OnOpenPopupExecute);
            _eventAggregator.GetEvent<CloseOpenNotification>().Subscribe(OnNotifayClosingOpenExecute);
            //Events

        }

        private async void OnSignInAccountCommand()
        {
            LogInViewModel = _LoginViewModelCreator();
            await LogInViewModel.LoadUserForValidAysnc();
        }

        private void OnNotifayClosingOpenExecute(CloseOpenNotificationArgs OpninigNotifay)
        {
           if(OpninigNotifay.IsOpen)
            {
                if(OpninigNotifay.Id!=0)
                {
                    //sucsess
                }
                else
                {
                    NotificationViewModel = _notificationViewModelCreator();
                    NotificationViewModel.ShowMessageNotification("Saved Successfull", "Success", NotificationType.Success);
                }
               
            }
        }

        private void OnOpenPopupExecute(OpenPopupsEventArgs Validates)
        {
            switch (Validates.IsOpen)
            {
                case false:
                    if (Validates.PageName == PagesName.SecuertyQuestionPopupView)
                    {
                        _eventAggregator.GetEvent<RotatedEvent>().Publish(true);
                    }
                    AnswerViewModel = null;

                    break;
                case true:
                    if (Validates.PageName == PagesName.SecuertyQuestionPopupView)
                    {
                        AnswerViewModel = _answerViewModelCreator();
                        AnswerViewModel.CreateEditAnswer(Validates.UserId, null);
                    }
                    break;
            }
        }

        private void OnOpenCreateAccCommand()
        {
            //  MessageBox.Show("Done");
            UserViewModel = _userViewModelCreator();
            UserViewModel.LoadAsync(null);
        }

        public async Task Load()
        {
            //NavigateToPageInFrame = new SignIn(this);
            LogInViewModel = _LoginViewModelCreator();
            await NavigationViewModel.LoadAsync();

        }

        public INavigationViewModel NavigationViewModel { get; set; }

       

        public ILogInViewModel LogInViewModel
        {
            get { return _loginviewmodel; }
            set { _loginviewmodel = value; OnPropertyChanged(); }
        }

        public IUserViewModel UserViewModel
        {
            get { return _userViewModel; }
            set { _userViewModel = value; OnPropertyChanged(); }
        }


        public IAnswerViewModel AnswerViewModel
        {
            get { return _answerViewModel; }
            set { _answerViewModel = value; OnPropertyChanged(); }
        }

        public Page NavigateToPageInFrame
        {
            get { return _navigateToPageInFrame; }
            set { _navigateToPageInFrame = value; OnPropertyChanged(); }
        }

        public INotificationViewModel NotificationViewModel
        {
            get { return _NotificationViewModel; }
            set { _NotificationViewModel = value; OnPropertyChanged(); }
        }

        public ICommand OpenCreateAccCommand { get; set; }
        public ICommand OpenSigninCommand { get; set; }
        public ObservableCollection<User> Users { get; set; }
    }
}
