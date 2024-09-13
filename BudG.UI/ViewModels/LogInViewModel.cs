using BudG.DataAccess.Repositories.Interface;
using BudG.UI.Events;
using BudG.UI.Interface;
using Prism.Commands;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BudG.UI.ViewModels
{
    public class LogInViewModel : ViewModelBase, ILogInViewModel
    {
        private IUserReposetry _userReposetry;
        private IEventAggregator _eventAggregator;
        private string _username;
        private string _password;
        public LogInViewModel(IUserReposetry userReposetry,IEventAggregator eventAggregator)
        {
            _userReposetry = userReposetry;
            _eventAggregator = eventAggregator;
            LogInCommand= new DelegateCommand(OnLogInCommand);
        }

        private void OnLogInCommand()
        {
            //Check IF the Username and password Is true
            _eventAggregator.GetEvent<CloseOpenNotification>()
                 .Publish(new CloseOpenNotificationArgs
                 {
                     IsOpen = true
                 });

        }

        public Task CheckUserValid()
        {
            
            throw new NotImplementedException();
        }

        public Task LoadUserForValidAysnc()
        {
            var user = _userReposetry.GetAllUsersAsync();
            return user;
        }

        public string UserName
        {
            get { return _username; }
            set { _username = value; OnPropertyChanged(); }
        }
        

        public string Password
        {
            get { return _password; }
            set { _password = value; OnPropertyChanged(); }
        }

        public ICommand LogInCommand { get; }
    }
}
