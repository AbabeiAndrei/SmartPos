namespace SmartPos.Ui.Components
{
    public enum MessageType : short
    {
        Info = 0, 
        Warning = 1,
        Error = 2
    }

    public enum MessageDurationLength
    {
        Short = 2000,
        Medium = 4000,
        Long = 10000,
        Infinite = -1
    }

    public interface IMessagePresenter
    {
        void PresentMessage(string message, MessageType type, int? duration = null);
        void PresentMessage(string message, MessageType type, MessageDurationLength duration);
    }
}