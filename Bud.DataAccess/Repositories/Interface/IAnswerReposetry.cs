using BudG.Domain;
using System.Threading.Tasks;

namespace BudG.DataAccess.Repositories.Interface
{
    public interface IAnswerReposetry:IGenericReposetry<Answer>
    {
        Task<Answer> GetAsyncAnswerByUserId(int userId);
        Task<Answer> CheckAnswerAsyncByAnswer(string answer);
        
    }
}
