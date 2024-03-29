using BudG.Domain;
using System.Threading.Tasks;

namespace BudG.DataAccess.Repositories.Interface
{
    public interface IQuestionsReposetry
    {
        Task<Question> GetAsyncById(int questionId);
        Task SaveAsync();
        bool HasChanges();
        void Add(Question question);
        void Remove(Question question);
    }
}
