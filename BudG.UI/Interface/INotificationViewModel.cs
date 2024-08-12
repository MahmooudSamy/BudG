namespace BudG.UI.Interface
{
    public interface INotificationViewModel
    {
        void ShowMessageNotification(string message, string title, NotificationType type);
    }

   public enum NotificationType
    {
        Error,
        Info,
        Warning,
        Success
    }
}
