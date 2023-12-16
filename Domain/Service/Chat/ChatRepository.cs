
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Domain.Service.Chat
{
    public class ChatRepository: IChatRepository
    {
        private DbHireMeNowWebApiContext DbContext;
        public ChatRepository(DbHireMeNowWebApiContext _context)
        {
            DbContext = _context;
        }

        public void AddMessage(Message message)
        {
            DbContext.Messages.Add(message);
            DbContext.SaveChanges();
        }

        public async Task<IList<Message>> GetMessagesByGroup(Guid groupId)
        {
           var res=await  DbContext.Messages.Where(e=>e.MessageGroupId==groupId).ToListAsync();
            return res;

        }
    }
}
