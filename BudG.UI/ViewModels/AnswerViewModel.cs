using BudG.DataAccess.Repositories.Interface;
using BudG.Domain;
using BudG.Domain.DomainService;
using BudG.UI.Events;
using BudG.UI.Interface;
using BudG.UI.Wrapar;
using Microsoft.EntityFrameworkCore;
using Prism.Commands;
using Prism.Events;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BudG.UI.ViewModels
{
    public class AnswerViewModel: ViewModelBase, IAnswerViewModel
    {
        private IQuestionLookup _questionLookup;
        private AnswerWrapper _answer;
        private bool _haschanges;
        private IAnswerReposetry _answerReposetry;
        private IEventAggregator _eventAggregator;

      
        public AnswerViewModel(IAnswerReposetry answerReposetry,IQuestionLookup questionLookup ,IEventAggregator eventAggregator)
        {
            _answerReposetry = answerReposetry;
            _eventAggregator = eventAggregator;
            _questionLookup = questionLookup;
            Questionslookups = new ObservableCollection<QuestionLookup>();
            SaveCommand = new DelegateCommand(OnSaveExecute, OnSaveCanExecute);
        }
        private async Task LoadQuestionsAsync()
        {
            Questionslookups.Clear();
            var lookup = await _questionLookup.GetQuestionsList();
            foreach (var item in lookup)
            {
                
                Questionslookups.Add(item);
            }
        }

        private bool OnSaveCanExecute()
        {
            return AnswerWrapper != null && !AnswerWrapper.HasErrors && HasChanges;
        }

        private async void OnSaveExecute()
        {
            try
            {
              
                
                await _answerReposetry.SaveAsync();
                _eventAggregator.GetEvent<OpenPopupsEvent>().Publish(new OpenPopupsEventArgs
                {
                    IsOpen = false,
                    PageName = PagesName.SecuertyQuestionPopupView

                }) ;
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
                    await _answerReposetry.SaveAsync();


                }
                else
                {
                    //reload the recourd from the database
                    await dbCEx.Entries.Single().ReloadAsync();
                    await CreateEditAnswer(AnswerWrapper.UserId,AnswerWrapper.Id);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unhandle error has occur {ex.Message}");

            }
            finally
            {
                HasChanges = _answerReposetry.HasChanges();
            }
        }

        public async Task CreateEditAnswer(int userID, int? answerId)
        {
             await LoadQuestionsAsync();

            var answer = answerId.HasValue
                ? await _answerReposetry.GetAsyncAnswerByUserId(userID)
                : CreatNewAnswer();

            InitilaizeAnswer(answer);
            if(AnswerWrapper.Id==0)
            {
                AnswerWrapper.AnswerQuestion = " ";
            }
            AnswerWrapper.UserId = userID;
        }

        private void InitilaizeAnswer(Answer answer)
        {
            AnswerWrapper = new AnswerWrapper(answer);
            AnswerWrapper.PropertyChanged += (s, e) =>
            {
                if(!HasChanges)
                {
                    HasChanges = _answerReposetry.HasChanges();
                }
                if (e.PropertyName == nameof(AnswerWrapper.HasErrors))
                {
                    ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
                }
            };
            ((DelegateCommand)SaveCommand).RaiseCanExecuteChanged();
        }

        private Answer CreatNewAnswer()
        {
            var answer = new Answer();
            _answerReposetry.Add(answer);
            return answer;
        }

       
       
        public AnswerWrapper AnswerWrapper
        {
            get { return _answer; }
            set { _answer = value; OnPropertyChanged(); }
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
        public ICommand SaveCommand { get; }
        public ObservableCollection<QuestionLookup> Questionslookups { get; }
    }
}
