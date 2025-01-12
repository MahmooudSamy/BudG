using BudG.Domain;
using System.Threading.Tasks;

namespace BudG.UI.Interface
{
    public interface ILogInViewModel
    {
        Task CheckUserValid();
        Task<User> LoadUserForValidAysnc();
    }
}
