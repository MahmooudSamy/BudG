using BudG.DataAccess.Repositories.Interface;
using BudG.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace BudG.DataAccess.Repositories.Classes
{
    public class AnswerReposetry : IDisposable , IAnswerReposetry
    {
        private BudGDbContext _context;

        public AnswerReposetry(BudGDbContext budGDbContext)
        {
            _context = budGDbContext;
        }

        public void Add(Answer answer)
        {
            _context.Answers.Add(answer);
        }

        public async Task<Answer> CheckAnswerAsyncByAnswer(string answer)
        {
            return await _context.Answers.SingleOrDefaultAsync(u => u.AnswerQuestion == answer);
        }


        public async Task<Answer> GetAsyncAnswerByUserId(int userId)
        {
            return await _context.Answers.SingleOrDefaultAsync(a =>  a.UserId == userId);
        }

        public bool HasChanges()
        {
            return _context.ChangeTracker.HasChanges();
        }

        public void Remove(Answer answer)
        {
            _context.Answers.Remove(answer);
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
