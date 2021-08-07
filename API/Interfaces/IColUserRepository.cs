using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Helpers;

namespace API.Interfaces
{
    public interface IColUserRepository
    {
        void Update(ColUser coluser);
        Task<bool> SaveAllAsync();
        Task<IEnumerable<ColUser>> GetColUsersAsync();
        Task<ColUser> GetColUserByIdAsync(int coluserid);
        Task<ColUser> GetColUserByUsernameAsync(string colUsername);
        Task<PagedList<ColMemberDto>> GetColMembersAsync(ColUserParams colUserParams);
        Task<ColMemberDto> GetColMemberAsync(string colUsername);
    }
}