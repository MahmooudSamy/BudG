using BudG.Domain;
using System.Threading.Tasks;

namespace BudG.DataAccess.Repositories.Interface
{
    public interface IUserReposetry
    {
        Task<User> GetAsyncById(int userId);
        Task<User> GetAsyncByPassword(string userName, string password);
        Task<User> GetAsyncByEmail(string email);
        Task SaveAsync();
        bool HasChanges();
        void Add(User user);
        void Remove(User user);
    }
}
