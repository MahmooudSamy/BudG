using BudG.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudG.UI.Wrapar
{
  public class AnswerWrapper :ModelWrapper<Answer>
    {
        public AnswerWrapper(Answer model):base(model)
        {
            
        }

        public int Id { get { return Model.AnswerId; } }
        public string AnswerQuestion
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        public int QuestionId
        {
            get { return GetValue<int>(); }
            set { SetValue(value); }
        }
        public int UserId
        {
            get { return GetValue<int>(); }
            set { SetValue(value); }
        }

        

    }
}
