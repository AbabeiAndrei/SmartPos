using SmartPos.Ui.Handlers;

namespace SmartPos.Ui.Components
{
    public class MessageInfo
    {
        public string Message { get;set; }

        public int? Duration { get; set; }

        public MessageType MessageType { get; set; }

        public bool Locked { get;set; }

        public MessageInfo(string message)
        {
            Message = message;
        }

        public MessageInfo(string message, MessageType messageType, int? duration, bool locked = false)
        {
            Message = message;
            MessageType = messageType;
            Duration = duration;
            Locked = locked;
        }
    }

    internal class MessageAnimation
    {
        public string Message { get; }
        public MessageType MessageType { get; }
        public int? Duration { get; set; }
        public bool Locked { get;set; }

        public int Height { get; }
        public bool Hiding { get; set; }

        public MessageAnimation(string message, MessageType messageType, int height)
        {
            Message = message;
            MessageType = messageType;
            Height = height;
            Hiding = false;
        }
    }
}