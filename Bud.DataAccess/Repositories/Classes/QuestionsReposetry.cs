using BudG.DataAccess.Repositories.Interface;
using BudG.Domain;
using System;
using System.Threading.Tasks;

namespace BudG.DataAccess.Repositories.Classes
{
    public class QuestionsReposetry : GenericReposetry<Question, BudGDbContext>, IDisposable ,IQuestionsReposetry
    {
       

        public QuestionsReposetry(BudGDbContext budGDbContext):
            base(budGDbContext)
        {
           
        }
        

        public override Task<Question> GetAsyncById(int questionId)
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
