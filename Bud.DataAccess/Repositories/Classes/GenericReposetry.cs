using BudG.DataAccess.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudG.DataAccess.Repositories.Classes
{
    public class GenericReposetry<TEntity,TContext> : IGenericReposetry<TEntity>
        where TEntity:class
        where TContext:DbContext
    {
        protected  TContext _context;

        protected GenericReposetry(TContext context)
        {
            _context = context;
        }
        public void Add(TEntity model)
        {
            _context.Set<TEntity>().Add(model);
        }

        public virtual async  Task<TEntity> GetAsyncById(int Id)
        {
            return await _context.Set<TEntity>().FindAsync(Id);
        }

        public bool HasChanges()
        {
           return _context.ChangeTracker.HasChanges();
        }

        public void Remove(TEntity model)
        {
            _context.Set<TEntity>().Remove(model);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
