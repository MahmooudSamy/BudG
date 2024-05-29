using BudG.Domain;
using BudG.Domain.DomainService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudG.DataAccess.Repositories.Interface
{
  public  interface IQuestionLookup
    {
        Task<IEnumerable<QuestionLookup>> GetQuestionsList();
    }
}
