using SmartPos.DomainModel.Model;

namespace Smartpos.Api.Communication
{
    public interface ICommunicationHub
    {
        void SendAll(MessageModel message);
    }
}