using BudG.Domain;
using System.Threading.Tasks;

namespace BudG.DataAccess.Repositories.Interface
{
    public interface IUserReposetry:IGenericReposetry<User>
    {
       
        Task<User> GetAllUsersAsync();
        Task<User> GetAsyncByPassword(string userName, string password);
        Task<User> GetAsyncByEmail(string email);
        
    }
}
