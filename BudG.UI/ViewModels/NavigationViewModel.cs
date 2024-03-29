using BudG.DataAccess.Repositories.Interface;
using BudG.DataAccess.Repositories.Lookups;
using BudG.UI.Interface;
using Prism.Events;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;

namespace BudG.UI.ViewModels
{
    public class NavigationViewModel : ViewModelBase, INavigationViewModel
    {
        private IUserLookup _lookupDataServices;
        private IEventAggregator _eventAggregator;

        public NavigationViewModel(IUserLookup lookupDataServices, IEventAggregator eventAggregator)
        {
            _lookupDataServices = lookupDataServices;
            _eventAggregator = eventAggregator;
            Users = new ObservableCollection<NavigationItemViewModel>();
        }
        public async Task LoadAsync()
        {
            try
            {
                var users = await _lookupDataServices.GetUserLookupItem();

                Users.Clear();
                foreach (var item in users)
                {

                    Users.Add(new NavigationItemViewModel(item.IdUser, item.DisplayMember, _eventAggregator));
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        public ObservableCollection<NavigationItemViewModel> Users { get; set; }
    }
}
