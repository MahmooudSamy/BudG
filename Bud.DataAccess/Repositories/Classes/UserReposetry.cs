using BudG.DataAccess.Repositories.Interface;
using BudG.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace BudG.DataAccess.Repositories.Classes
{
    public class UserReposetry : IDisposable , IUserReposetry
    {
        private BudGDbContext _context;

        public UserReposetry(BudGDbContext budGDbContext)
        {
            _context = budGDbContext;
        }
        public void Add(User user)
        {
            _context.Users.Add(user);
        }

        public async Task<User> GetAsyncByEmail(string email)
        {
            return await _context.Users.SingleOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User> GetAsyncById(int userId)
        {
            return await _context.Users.AsNoTracking().SingleOrDefaultAsync(u => u.UserId == userId);
        }

        public async Task<User> GetAsyncByPassword(string userName, string password)
        {
            return await _context.Users.AsNoTracking().SingleOrDefaultAsync
                 (u => u.UserName == userName && u.Password == password);
        }

        public bool HasChanges()
        {
            return _context.ChangeTracker.HasChanges();
        }

        public void Remove(User user)
        {
            _context.Users.Remove(user);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
        }
    }
}
