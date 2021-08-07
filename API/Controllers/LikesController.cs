using System.Collections.Generic;
using System.Threading.Tasks;
using API.Data.DTOs;
using API.Entities;
using API.Extensions;
using API.Helpers;
using API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    public class LikesController : BaseApiController
    {
        private readonly IColUserRepository _colUserRepository;
        private readonly ILikesRepository _likesRepository;
        public LikesController(IColUserRepository colUserRepository, ILikesRepository likesRepository)
        {
            _colUserRepository = colUserRepository;
            _likesRepository = likesRepository;
        }

        [HttpPost("{colUsername}")]
        public async Task<ActionResult> AddLike(string colUsername)
        {
            var sourceColUserId = User.GetColUserId();
            var likedColUser = await _colUserRepository.GetColUserByUsernameAsync(colUsername);
            var sourceColUser = await _likesRepository.GetColUserWithLikes(sourceColUserId);

            if (likedColUser == null) return NotFound();

            if (sourceColUser.ColUserName == colUsername) return BadRequest("You cannot choose yourself as a good fit");

            var colUserLike = await _likesRepository.GetColUserLike(sourceColUserId, likedColUser.ColUserId);

            if (colUserLike != null) return BadRequest("You have already indicated a good fit for this one");

            colUserLike = new ColUserLike
            {
                SourceColUserId = sourceColUserId,
                LikedColUserId = likedColUser.ColUserId
            };

            sourceColUser.LikedColUsers.Add(colUserLike);

            if (await _colUserRepository.SaveAllAsync()) return Ok();

            return BadRequest("Falied to indicate a good fit");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LikeDto>>> GetColUserLikes([FromQuery] LikesParams likesParams)
        {
            likesParams.ColUserId = User.GetColUserId();
            var colUsers = await _likesRepository.GetColUserLikes(likesParams);

            Response.AddPaginationHeader(colUsers.CurrentPage,
                colUsers.PageSize, colUsers.TotalCount, colUsers.TotalPages);

            return Ok(colUsers);
        }
    }
}
