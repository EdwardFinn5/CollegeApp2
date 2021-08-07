using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.DTOs;
using API.Entities;
using API.Helpers;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class LikesRepository : ILikesRepository
    {
        private readonly DataContext _context;
        public LikesRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<ColUserLike> GetColUserLike(int sourceColUserId, int likedColUserId)
        {
            return await _context.Likes.FindAsync(sourceColUserId, likedColUserId);
        }

        public async Task<PagedList<LikeDto>> GetColUserLikes(LikesParams likesParams)
        {
            var colUsers = _context.ColUsers.OrderBy(u => u.ColUserName).AsQueryable();
            var likes = _context.Likes.AsQueryable();

            if (likesParams.Predicate == "liked")
            {
                likes = likes.Where(like => like.SourceColUserId == likesParams.ColUserId);
                colUsers = likes.Select(like => like.LikedColUser);
            }

            if (likesParams.Predicate == "likedBy")
            {
                likes = likes.Where(like => like.LikedColUserId == likesParams.ColUserId);
                colUsers = likes.Select(like => like.SourceColUser);
            }

            var likedUsers = colUsers.Select(colUser => new LikeDto
            {
                ColUsername = colUser.ColUserName,
                FirstName = colUser.FirstName,
                ColUserType = colUser.ColUserType,
                CollegeName = colUser.CollegeName,
                CollegeLocation = colUser.CollegeLocation,
                HsName = colUser.HsName,
                HsLocation = colUser.HsLocation,
                HsStudentUrl = colUser.ColPhotos.FirstOrDefault(p => p.IsMainHs).HsStudentUrl,
                ColUrl = colUser.ColPhotos.FirstOrDefault(p => p.IsMainCol).ColUrl,
                ColUserId = colUser.ColUserId
            });

            return await PagedList<LikeDto>.CreateAsync(likedUsers,
                likesParams.PageNumber, likesParams.PageSize);
        }

        public async Task<ColUser> GetColUserWithLikes(int colUserId)
        {
            return await _context.ColUsers
             .Include(x => x.LikedColUsers)
             .FirstOrDefaultAsync(x => x.ColUserId == colUserId);
        }
    }
}