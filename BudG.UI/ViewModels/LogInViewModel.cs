using BudG.DataAccess.Repositories.Interface;
using BudG.UI.Events;
using BudG.UI.Interface;
using BudG.UI.Extentions;
using Prism.Commands;
using Prism.Events;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using BudG.UI.Wrapar;
using BudG.Domain;



namespace BudG.UI.ViewModels
{
    public class LogInViewModel : ViewModelBase, ILogInViewModel
    {
        private IUserReposetry _userReposetry;
        private IEventAggregator _eventAggregator;
        private UserWrapper _user;
        public LogInViewModel(IUserReposetry userReposetry, IEventAggregator eventAggregator)
        {
            _userReposetry = userReposetry;
            _eventAggregator = eventAggregator;
            LogInCommand = new DelegateCommand(OnLogInCommand);
        }

        private async void OnLogInCommand()
        {
            //Check IF the Username and password Is true

            await CheckUserValid();
        }

        public async Task CheckUserValid()
        {

            if (string.IsNullOrWhiteSpace(UserName) || string.IsNullOrWhiteSpace(Password.ToHashSomeText()))
            {
                //publishEventforNotification("Please enter your username and password.", "Error");
                _eventAggregator.GetEvent<CloseOpenNotification>()
                .Publish(new CloseOpenNotificationArgs
                {
                    IsOpen = true,
                    Message = "Fill the required field",
                    NotificationType = NotificationType.Error

                });
            }
            else
            {
                var user = await _userReposetry.GetAsyncByPassword(UserName, Password.ToHashSomeText());
                if (user != null)
                {
                    
                    //_eventAggregator.GetEvent<OpenDetailViewEvent>().Publish(user.IdAccount);
                    _eventAggregator.GetEvent<CloseOpenNotification>()
                .Publish(new CloseOpenNotificationArgs
                {
                    IsOpen = true,
                    Id = user.UserId

                });
                }
                else
                {
                    _eventAggregator.GetEvent<CloseOpenNotification>()
               .Publish(new CloseOpenNotificationArgs
               {
                   IsOpen = true,
                   Message = "username or password is invalid.",
                   NotificationType = NotificationType.Error

               });
                    //publishEventforNotification("username or password is invalid.", "Error");
                }
            }
        }

        public async Task<User> LoadUserForValidAysnc()
        {
            var user = await _userReposetry.GetAllUsersAsync();
            UserWrapper = new UserWrapper(user);
            return user; 
        }
        private string _username;

        public string UserName
        {
            get { return _username; }
            set { _username = value; OnPropertyChanged(); }
        }
        private string _password;

        public string Password
        {
            get { return _password; }
            set { _password = value; OnPropertyChanged(); }
        }

        public UserWrapper UserWrapper
        {
            get { return _user; }
            set { _user = value; OnPropertyChanged(); }
        }

        public ICommand LogInCommand { get; }
    }
}
