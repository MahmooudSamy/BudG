using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudG.DataAccess.Repositories.Interface
{
    public interface IGenericReposetry<T>
    {
        Task<T> GetAsyncById(int Id);
        Task SaveAsync();
        bool HasChanges();
        void Add(T model);
        void Remove(T model);
    }
}
