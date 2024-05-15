using BudG.Domain;
using BudG.UI.Events;
using BudG.UI.Interface;
using BudG.UI.Pages;
using Prism.Commands;
using Prism.Events;
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
        //Creators
        private Func<IUserViewModel> _userViewModelCreator;
        private Func<IAnswerViewModel> _answerViewModelCreator;
        //Creators
        private IEventAggregator _eventAggregator;
        private IUserViewModel _userViewModel;
        private IAnswerViewModel _answerViewModel;
        private Page _navigateToPageInFrame;
        public MainViewModel(Func<IUserViewModel> userViewModelCreator, Func<IAnswerViewModel> answerViewModelCreator,
            INavigationViewModel navigationViewModel,IEventAggregator eventAggregator)
        {
            _userViewModelCreator = userViewModelCreator;
            _answerViewModelCreator = answerViewModelCreator;
            _eventAggregator = eventAggregator;
             Users = new ObservableCollection<User>();
            NavigationViewModel = navigationViewModel;
            //Comands
            OpenCreateAccCommand = new DelegateCommand(OnOpenCreateAccCommand);
            //Comands
            //Events
            _eventAggregator.GetEvent<OpenPopupsEvent>().Subscribe(OnOpenPopupExecute);
            //Events

        }

        private void OnOpenPopupExecute(OpenPopupsEventArgs Validates)
        {
            switch (Validates.IsOpen)
            {
                case false:
                    AnswerViewModel = null;
                    break;
                case true:
                    if(Validates.PageName==PagesName.SecuertyQuestionPopupView)
                    {
                        AnswerViewModel = _answerViewModelCreator();
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
            await NavigationViewModel.LoadAsync();
           
        }

        public INavigationViewModel NavigationViewModel { get; set; }

        
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
        //public Func<IUserViewModel> UserViewModelCreator
        //{
        //    get { return _userViewModelCreator; }
        //    set { _userViewModelCreator = value; OnPropertyChanged(); }
        //}
        //public Func<IAnswerViewModel> AnswerViewModelCreator
        //{
        //    get { return _answerViewModelCreator; }
        //    set { _answerViewModelCreator = value; OnPropertyChanged(); }
        //}

        public ICommand OpenCreateAccCommand { get; set; }
        public ObservableCollection<User> Users { get; set; }
    }
}
