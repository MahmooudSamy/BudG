using Prism.Events;

namespace BudG.UI.Events
{
    public class OpenPopupsEvent:PubSubEvent<OpenPopupsEventArgs>
    {
    }

    public class OpenPopupsEventArgs
    {
        public bool IsOpen { get; set; }
        public PagesName PageName { get; set; }
        public int UserId { get; set; }

    }

    public enum PagesName
    {
        SecuertyQuestionPopupView 
    };
}
