using BudG.DataAccess.Repositories.Interface;
using BudG.UI.Interface;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }
        public Task CheckUserValid()
        {
            throw new NotImplementedException();
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
    }
}
