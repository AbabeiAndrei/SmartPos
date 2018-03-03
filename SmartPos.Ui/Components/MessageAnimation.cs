using SmartPos.Ui.Handlers;

namespace SmartPos.Ui.Components
{
    internal class MessageAnimation
    {
        public string Message { get; }
        public MessageType MessageType { get; }
        public int Height { get; }

        public bool Hiding { get; set; }
        public int? Duration { get; set; }

        public MessageAnimation(string message, MessageType messageType, int height)
        {
            Message = message;
            MessageType = messageType;
            Height = height;
            Hiding = false;
        }
    }
}