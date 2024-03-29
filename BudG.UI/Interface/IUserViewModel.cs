using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudG.UI.Interface
{
    public interface IUserViewModel
    {
        Task LoadAsync(int? Userid);
        Task GetUserByID(int Userid);
        //Task LoadAsyncByPassword(string UserName,string password);
        bool HasChanges { get; set; }
    }
}
