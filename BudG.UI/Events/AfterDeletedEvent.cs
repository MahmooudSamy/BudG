using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudG.UI.Events
{
    public class AfterDeletedEvent : PubSubEvent<AfterDeletedEventArgs>
    {
    }

    public class AfterDeletedEventArgs
    {
        public int Id { get; set; }
        public string ViewModelName { get; set; }
    }
}
