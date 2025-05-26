using BudG.DataAccess.Repositories.Interface;
using BudG.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace BudG.DataAccess.Repositories.Classes
{
    public class AnswerReposetry : GenericReposetry<Answer, BudGDbContext>, IDisposable , IAnswerReposetry
    {
        

        public AnswerReposetry(BudGDbContext budGDbContext):
              base(budGDbContext)
        {
            
        }

     

        public async Task<Answer> CheckAnswerAsyncByAnswer(string answer)
        {
            return await _context.Answers.SingleOrDefaultAsync(u => u.AnswerQuestion == answer);
        }


        public async Task<Answer> GetAsyncAnswerByUserId(int userId)
        {
            return await _context.Answers.SingleOrDefaultAsync(a =>  a.UserId == userId);
        }

        public override async Task<Answer> GetAsyncById(int Id)
        {
            return await _context.Answers.SingleOrDefaultAsync(a => a.AnswerId == Id);
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
