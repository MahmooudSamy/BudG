using BudG.DataAccess.Repositories.Interface;
using BudG.Domain;
using BudG.Domain.DomainService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudG.DataAccess.Repositories.Lookups
{
    public class LookupDataServices:IUserLookup,IAccountLookup,IQuestionLookup
    {
        private Func<BudGDbContext> _contextCreator;

        public LookupDataServices(Func<BudGDbContext> contextCreator)
        {
            _contextCreator = contextCreator;
        }

        public async Task<IEnumerable<QuestionLookup>> GetQuestionsList()
        {
           using(var context=_contextCreator())
            {
                return await context.Questions.AsNoTracking().Select(q => new QuestionLookup
                {
                    Id = q.QuestionId,
                    Question = q.QuestionShape
                }).ToListAsync();
            }
        }

        public async Task<IEnumerable<UserLookupItems>> GetUserLookupItem()
        {
            using (var context = _contextCreator())
            {
                return await context.Users.AsNoTracking().Select(u => new UserLookupItems
                {
                    IdUser = u.UserId,
                    DisplayMember = u.FirstName + " " + u.LastName
                }).ToListAsync();
            }
        }
    }
}
