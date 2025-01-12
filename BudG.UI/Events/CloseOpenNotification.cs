using BudG.UI.Interface;
using Prism.Events;

namespace BudG.UI.Events
{
    public class CloseOpenNotification: PubSubEvent<CloseOpenNotificationArgs>
    {
    }

    public class CloseOpenNotificationArgs
    {
        public bool IsOpen { get; set; }
        public int Id { get; set; }
        public  string Message { get; set; }
        public NotificationType NotificationType { get; set; }
    }
}
