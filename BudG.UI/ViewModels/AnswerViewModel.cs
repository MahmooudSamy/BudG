using BudG.DataAccess.Repositories.Interface;
using BudG.Domain.DomainService;
using BudG.UI.Interface;
using BudG.UI.Wrapar;
using Prism.Commands;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BudG.UI.ViewModels
{
    public class AnswerViewModel: ViewModelBase, IAnswerViewModel
    {
        private IQuestionLookup _questionLookup;
        private AnswerWrapper _answer;
        private bool _haschanges;
        private IAnswerReposetry _answerReposetry;
        private async Task LoadQuestionsAsync()
        {
            Questionslookups.Clear();
            var lookup = await _questionLookup.GetQuestionsList();
            foreach (var item in lookup)
            {
                Questionslookups.Add(item);
            }
        }
        public AnswerViewModel(IAnswerReposetry answerReposetry)
        {
            _answerReposetry = answerReposetry;
            SaveCommand = new DelegateCommand(OnSaveExecute, OnSaveCanExecute);
        }

        private bool OnSaveCanExecute()
        {
            throw new NotImplementedException();
        }

        private void OnSaveExecute()
        {
            throw new NotImplementedException();
        }

        public async Task CreateEditAnswer(int userID)
        {
             await LoadQuestionsAsync();
        }

        public AnswerViewModel(IQuestionLookup questionLookup)
        {
            _questionLookup = questionLookup;
            Questionslookups = new ObservableCollection<QuestionLookup>();
        }
       
        public AnswerWrapper AnswerWrapper
        {
            get { return _answer; }
            set { _answer = value; OnPropertyChanged(); }
        }
        public ObservableCollection<QuestionLookup> Questionslookups { get; }
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
    }
}
