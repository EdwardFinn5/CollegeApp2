using System.Threading.Tasks;
using API.Data.DTOs;
using API.Interfaces;
using API.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using API.Entities;
using AutoMapper;
using System.Collections.Generic;
using API.Helpers;

namespace API.Controllers
{
    [Authorize]
    public class MessagesController : BaseApiController
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IColUserRepository _colUserRepository;
        private readonly IMapper _mapper;
        public MessagesController(IColUserRepository colUserRepository, IMessageRepository messageRepository, IMapper mapper)
        {
            _mapper = mapper;
            _colUserRepository = colUserRepository;
            _messageRepository = messageRepository;
        }

        [HttpPost]
        public async Task<ActionResult<MessageDto>> CreateMessage(CreateMessageDto createMessageDto)
        {
            var colUsername = User.GetColUserName();

            if (colUsername == createMessageDto.RecipientColUsername.ToLower())
                return BadRequest("You cannot send messages to yourself");

            var sender = await _colUserRepository.GetColUserByUsernameAsync(colUsername);
            var recipient = await _colUserRepository.GetColUserByUsernameAsync(createMessageDto.RecipientColUsername);

            if (recipient == null) return NotFound();

            var message = new Message
            {
                Sender = sender,
                Recipient = recipient,
                SenderColUsername = sender.ColUserName,
                SenderFirstName = sender.FirstName,
                SenderCollegeName = sender.CollegeName,
                RecipientCollegeName = recipient.CollegeName,
                RecipientHsName = recipient.HsName,
                SenderHsName = sender.HsName,
                RecipientColUsername = recipient.ColUserName,
                RecipientFirstName = recipient.FirstName,
                Content = createMessageDto.Content,
                SenderColUserType = sender.ColUserType,
                RecipientColUserType = recipient.ColUserType
            };

            _messageRepository.AddMessage(message);

            if (await _messageRepository.SaveAllAsync()) return Ok(_mapper.Map<MessageDto>(message));

            return BadRequest("Failed to send message");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MessageDto>>> GetMessagesForColUser([FromQuery]
            MessageParams messageParams)
        {
            messageParams.ColUsername = User.GetColUserName();

            var messages = await _messageRepository.GetMessagesForColUser(messageParams);

            Response.AddPaginationHeader(messages.CurrentPage, messages.PageSize,
                messages.TotalCount, messages.TotalPages);

            return messages;
        }

        // not using this method anymore with signalRhub
        [HttpGet("thread/{colUsername}")]
        public async Task<ActionResult<IEnumerable<MessageDto>>> GetMessageThread(string colUsername)
        {
            var currentColUsername = User.GetColUserName();

            return Ok(await _messageRepository.GetMessageThread(currentColUsername, colUsername));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMessage(int id)
        {
            var colUsername = User.GetColUserName();

            var message = await _messageRepository.GetMessage(id);

            if (message.Sender.ColUserName != colUsername && message.Recipient.ColUserName != colUsername)
                return Unauthorized();

            if (message.Sender.ColUserName == colUsername) message.SenderDeleted = true;

            if (message.Recipient.ColUserName == colUsername) message.RecipientDeleted = true;

            if (message.SenderDeleted && message.RecipientDeleted)
                _messageRepository.DeleteMessage(message);

            if (await _messageRepository.SaveAllAsync()) return Ok();

            return BadRequest("Problem deleting the message");
        }
    }
}