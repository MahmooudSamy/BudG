using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudG.UI.Interface
{
  public  interface IAnswerViewModel
    {
        Task CreateEditAnswer(int userID);
    }
}
