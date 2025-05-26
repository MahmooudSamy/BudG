using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudG.UI.Events
{
    public class AfterSavedEvent:PubSubEvent<AfterSavedEventArgs>
    {
    }

    public class AfterSavedEventArgs
    {
        public int Id { get; set; }
        public string DisplayMember { get; set; }
        public string ViewModelName { get; set; }
    }
}
