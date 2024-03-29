using Prism.Events;

namespace BudG.UI.ViewModels
{
    public class NavigationItemViewModel:ViewModelBase
    {
        private IEventAggregator _eventAggregator;
        private int _displaymember;
        public NavigationItemViewModel(int Id, string displayMember,
            IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            UserId = Id;
            DisplayMember = _displaymember;
        }

        public int UserId { get; set; }

       

        public int DisplayMember
        {
            get { return _displaymember; }
            set { _displaymember = value; OnPropertyChanged(); }
        }

    }
}
