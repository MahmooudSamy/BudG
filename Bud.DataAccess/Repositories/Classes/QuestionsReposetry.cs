using BudG.DataAccess.Repositories.Interface;
using BudG.Domain;
using System;
using System.Threading.Tasks;

namespace BudG.DataAccess.Repositories.Classes
{
    public class QuestionsReposetry : IDisposable ,IQuestionsReposetry
    {
        private BudGDbContext _context;

        public QuestionsReposetry(BudGDbContext budGDbContext)
        {
            _context = budGDbContext;
        }
        public void Add(Question question)
        {
            throw new NotImplementedException();
        }

        public Task<Question> GetAsyncById(int questionId)
        {
            throw new NotImplementedException();
        }

        public bool HasChanges()
        {
            throw new NotImplementedException();
        }

        public void Remove(Question question)
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync()
        {
            throw new NotImplementedException();
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
