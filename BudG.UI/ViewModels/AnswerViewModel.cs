using BudG.DataAccess.Repositories.Interface;
using BudG.Domain.DomainService;
using BudG.UI.Interface;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudG.UI.ViewModels
{
   public class AnswerViewModel: ViewModelBase, IAnswerViewModel
    {
        private IQuestionLookup _questionLookup;
        private async Task LoadQuestionsAsync()
        {
            Questionslookups.Clear();
            var lookup = await _questionLookup.GetQuestionsList();
            foreach (var item in lookup)
            {
                Questionslookups.Add(item);
            }
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

        public ObservableCollection<QuestionLookup> Questionslookups { get; }
    }
}
