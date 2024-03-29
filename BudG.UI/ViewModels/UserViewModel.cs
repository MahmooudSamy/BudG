using BudG.DataAccess.Repositories.Interface;
using BudG.Domain;
using BudG.UI.Extentions;
using BudG.UI.Interface;
using BudG.UI.Wrapar;
using Microsoft.EntityFrameworkCore;
using Prism.Commands;
using Prism.Events;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace BudG.UI.ViewModels
{
    public class UserViewModel : ViewModelBase, IUserViewModel
    {
        private IUserReposetry _userReposetry;
        private IEventAggregator _eventAggregator;
        private UserWrapper _user;
        private bool _haschanges;
      
        public UserViewModel(IUserReposetry userReposetry, IEventAggregator eventAggregator)
        {
            _userReposetry = userReposetry;
            _eventAggregator = eventAggregator;
            SaveCommand = new DelegateCommand(OnSaveExecute, OnSaveCanExecute);
        }
      
        private bool OnSaveCanExecute()
        {
            
            return UserWrapper != null && !UserWrapper.HasErrors && HasChanges  ;
        }

        private async void OnSaveExecute()
        {
            try
            {
                UserWrapper.Password=UserWrapper.Password.ToHashSomeText();
                UserWrapper.ProfilePicture = getJPGFromImageControl(null);
                await _userReposetry.SaveAsync();
            }
            
            catch (DbUpdateConcurrencyException dbCEx)
            {

                var result = MessageBox.Show("This Record has been changed in the meantime by someone else."
                    + "Click OK to save your changes anyway, click Cancel to reload the Record from the database."
                    , "Question", MessageBoxButton.OKCancel);
                if (result == MessageBoxResult.OK)
                {
                    // Update the original value with database
                    var entry = dbCEx.Entries.Single();
                    entry.OriginalValues.SetValues(entry.GetDatabaseValues());
                    await _userReposetry.SaveAsync();
                }
                else
                {
                    //reload the recourd from the database
                    await dbCEx.Entries.Single().ReloadAsync();
                    await LoadAsync(UserWrapper.Id);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unhandle error has occur {ex.Message}");

            }
            finally
            {
                HasChanges = _userReposetry.HasChanges();
                //ToDo:
                //Error Send The picture and name to navtigation
            }
        }

        private  byte[] getJPGFromImageControl( BitmapImage imageC)
        {
            MemoryStream memStream = new MemoryStream();


            if (imageC == null)
            {
                imageC = new BitmapImage(new Uri("pack://application:,,,/BudG.UI;component/Images/SplashScreen1.jpg"));
            }


            PngBitmapEncoder encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(imageC));
            encoder.Save(memStream);
            return memStream.ToArray();
        }

        public async Task GetUserByID(int Userid)
        {
            var user = await _userReposetry.GetAsyncById(Userid);
            if (user != null)
            {
                //Publish EventSendUserdataToNav
                //_eventAggregator.GetEvent<AfterGetUserByIdEvent>()
                //    .Publish(new AfterGetUserByIdEventArgs
                //    {
                //        Id = user.IdAccount,
                //        DisplayMember = $"{user.FirstName}{user.LastName}",
                //        Picture = user.ProfilePicture
                //    });
            }
        }

        public async Task LoadAsync(int? Userid)
        {
            var user = Userid.HasValue
              ? await _userReposetry.GetAsyncById(Userid.Value)
              : CreateNewUser();
            InitilaizeUser(user);
            if (UserWrapper.Id == 0)
            {
                UserWrapper.FirstName = "";
                UserWrapper.LastName = "";
                UserWrapper.UserName = "";
                UserWrapper.Password = "";
                UserWrapper.Email = "";
            }
        }

        private void InitilaizeUser(User user)
        {
            UserWrapper = new UserWrapper(user);

            UserWrapper.PropertyChanged += (s , e) =>
            {
                if (!HasChanges)
                {
                    HasChanges = _userReposetry.HasChanges();
                }
                if (e.PropertyName == nameof(UserWrapper.HasErrors))
                {
                    ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
                }
            };
            ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
        }

        private User CreateNewUser()
        {
            var user = new User();
            _userReposetry.Add(user);
            return user;
        }

        public bool HasChanges
        {
            get { return _haschanges; }
            set
            {
                if (_haschanges != value)
                {
                    _haschanges = value;
                    OnPropertyChanged();
                    ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
                }

            }
        }
       

       

        public UserWrapper UserWrapper
        {
            get { return _user; }
            set { _user = value; OnPropertyChanged(); }
        }

        public ICommand SaveCommand { get; }
    }
}
