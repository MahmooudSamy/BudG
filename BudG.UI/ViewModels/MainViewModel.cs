using BudG.Domain;
using BudG.UI.Interface;
using BudG.UI.Pages;
using Prism.Commands;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace BudG.UI.ViewModels
{
    public class MainViewModel:ViewModelBase
    {
        private Func<IUserViewModel> _userViewModelCreator;

        private IUserViewModel _userViewModel;
        private Page _navigateToPageInFrame;
        public MainViewModel(Func<IUserViewModel> userViewModelCreator,
            INavigationViewModel navigationViewModel)
        {
            _userViewModelCreator = userViewModelCreator;
           
            Users = new ObservableCollection<User>();
            NavigationViewModel = navigationViewModel;
            OpenCreateAccCommand = new DelegateCommand(OnOpenCreateAccCommand);
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
            await NavigationViewModel.LoadAsync();
           
        }

        public INavigationViewModel NavigationViewModel { get; set; }

        
        public IUserViewModel UserViewModel
        {
            get { return _userViewModel; }
            set { _userViewModel = value; OnPropertyChanged(); }
        }
       
        public Page NavigateToPageInFrame
        {
            get { return _navigateToPageInFrame; }
            set { _navigateToPageInFrame = value; OnPropertyChanged(); }
        }
        public Func<IUserViewModel> UserViewModelCreator
        {
            get { return _userViewModelCreator; }
            set { _userViewModelCreator = value; OnPropertyChanged(); }
        }
        public ICommand OpenCreateAccCommand { get; set; }
        public ObservableCollection<User> Users { get; set; }
    }
}
