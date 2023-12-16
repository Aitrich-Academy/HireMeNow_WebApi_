
using Domain.Models;

namespace Domain.Service.Chat
{
    public interface IChatRepository
    {
        void AddMessage(Message message);
        Task<IList<Message>> GetMessagesByGroup(Guid groupId);
    }
}
