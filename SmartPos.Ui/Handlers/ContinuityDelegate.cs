using SmartPos.Ui.Components;

namespace SmartPos.Ui.Handlers
{
    public interface IContinuityDelegate : IMessagePresenter
    {
        bool Close { get; set; }
    }

    public class ContinuityDelegate : IContinuityDelegate
    {
        public string Message { get; private set; }
        public MessageType MessageType { get; private set; }
        public int? Duration { get; private set; }

        public bool Close { get; set; }

        public void PresentMessage(string message, MessageType type, MessageDurationLength duration)
        {
            PresentMessage(message, type, duration == MessageDurationLength.Infinite ? (int?)duration : null);
        }

        public void PresentMessage(string message, MessageType type, int? duration = null)
        {
            Message = message;
            MessageType = type;
            Duration = duration;
        }
    }
}