using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;

namespace API.Interfaces
{
    public interface IColUserRepository
    {
        void Update(ColUser coluser);
        Task<bool> SaveAllAsync();
        Task<IEnumerable<ColUser>> GetColUsersAsync();
        Task<ColUser> GetColUserByIdAsync(int coluserid);
        Task<ColUser> GetColUserByUsernameAsync(string colUsername);
        Task<IEnumerable<ColMemberDto>> GetColMembersAsync();
        Task<ColMemberDto> GetColMemberAsync(string colUsername);
    }
}