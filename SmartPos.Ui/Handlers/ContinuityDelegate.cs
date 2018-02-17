namespace SmartPos.Ui.Handlers
{
    public interface IContinuityDelegate
    {
        bool Close { get; set; }

        void PresentMessage(string message, MessageType type, int? duration = null);
    }

    public class ContinuityDelegate : IContinuityDelegate
    {
        public string Message { get; private set; }
        public MessageType MessageType { get; private set; }
        public int? Duration { get; private set; }

        public bool Close { get; set; }

        public void PresentMessage(string message, MessageType type, int? duration = null)
        {
            Message = message;
            MessageType = type;
            Duration = duration;
        }
    }
}