namespace BudG.UI.Interface
{
    public interface INotificationViewModel
    {
        void ShowMessageNotification(string message, NotificationType type);
    }

   public enum NotificationType
    {
        Error,
        Info,
        Warning,
        Success
    }
}
