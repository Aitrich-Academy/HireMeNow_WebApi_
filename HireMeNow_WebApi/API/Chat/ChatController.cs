

using AutoMapper;
using Domain.Models;
using Domain.Service.Chat;
using Domain.Service.Chat.MessageGroupServices;
using Domain.Service.SignUp.DTOs;
using HireMeNow_WebApi.API.Chat.RequestObjects;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HireMeNow_WebApi.API.Chat
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        IChatRepository chatRepository;
        IMessageGroupRepository messageGroupRepository;
        IMapper mapper;
        public ChatController(IChatRepository _chatRepository,IMessageGroupRepository _messageGroupRepository, IMapper _mapper) {
            chatRepository= _chatRepository;
            messageGroupRepository= _messageGroupRepository;    
            mapper= _mapper;
        }

        [HttpPost]
        [Route("group/{groupId}/message")]
        public IActionResult AddMessage(Message message,Guid groupId)
        {
            chatRepository.AddMessage(message);
            return Ok();
        }

        [HttpPost]
        [Route("group")]
        public async Task<IActionResult> CreateNewChatGroupAsync(MessageGroup messagegroup)
        {
            var res=await messageGroupRepository.AddAsync(messagegroup);
            return Ok(res);
        }

        

        [HttpGet]
        [Route("group/{groupId}/messages")]
        public async Task<IActionResult> GetChatByGroupAsync(Guid groupId)
        {
            IList<Message> res = await chatRepository.GetMessagesByGroup(groupId);
            return Ok(res);
        }

        [HttpGet]
        [Route("user/{userId}/chatgroup")]
        public async Task<IActionResult> GetGroupsByUserAsync(Guid userId)
        {
            IList<MessageGroup> res = await messageGroupRepository.GetMessageGroupByUser(userId);
            return Ok(res);
        }
        [HttpGet]
        [Route("all-users")]
        public async Task<IActionResult> GetAllUsers()
        {
            IList<AuthUser> res = await messageGroupRepository.GetAllUsers();
            mapper.Map<IList<ChatUserDto>>(res);
            return Ok(res);
        }

    }
}
