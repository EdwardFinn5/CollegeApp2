using System.Collections.Generic;
using System.Threading.Tasks;
using API.Data.DTOs;
using API.Entities;
using API.Helpers;

namespace API.Interfaces
{
    public interface ILikesRepository
    {
        Task<ColUserLike> GetColUserLike(int sourceColUserId, int likedColUserId);
        Task<ColUser> GetColUserWithLikes(int colUserId);
        Task<PagedList<LikeDto>> GetColUserLikes(LikesParams likesParams);
    }
}