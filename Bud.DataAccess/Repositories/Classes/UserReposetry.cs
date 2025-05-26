using BudG.DataAccess.Repositories.Interface;
using BudG.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;


namespace BudG.DataAccess.Repositories.Classes
{
    public class UserReposetry : GenericReposetry<User, BudGDbContext>, IDisposable , IUserReposetry
    {
        
        public UserReposetry(BudGDbContext budGDbContext):
            base(budGDbContext)
        {
            
        }
       

        public async Task<User> GetAsyncByEmail(string email)
        {
            return await _context.Users.SingleOrDefaultAsync(u => u.Email == email);
        }

        public override async Task<User> GetAsyncById(int userId)
        {
            return await _context.Users.AsNoTracking().SingleOrDefaultAsync(u => u.UserId == userId);
        }

        public async Task<User> GetAsyncByPassword(string userName, string password)
        {
            return await _context.Users.AsNoTracking().SingleOrDefaultAsync
                 (u => u.UserName == userName && u.Password == password);
        }

        public async Task<User> GetAllUsersAsync()
        {
            return await _context.Users.AsNoTracking().FirstOrDefaultAsync();
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
