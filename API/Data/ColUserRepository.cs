using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
// using AutoMapper;
// using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class ColUserRepository : IColUserRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public ColUserRepository(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ColMemberDto> GetColMemberAsync(string colUsername)
        {
            return await _context.ColUsers
                .Where(x => x.ColUserName == colUsername)
                .ProjectTo<ColMemberDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<ColMemberDto>> GetColMembersAsync()
        {
            return await _context.ColUsers
                .ProjectTo<ColMemberDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<ColUser> GetColUserByIdAsync(int coluserid)
        {
            return await _context.ColUsers.FindAsync(coluserid);
        }

        public async Task<ColUser> GetColUserByUsernameAsync(string colUsername)
        {
            return await _context.ColUsers
                .Include(p => p.ColPhotos)
                .Include(f => f.FactFeatures)
                // .Include(cm => cm.CollegeMajors)
                .SingleOrDefaultAsync(x => x.ColUserName == colUsername);
        }

        public async Task<IEnumerable<ColUser>> GetColUsersAsync()
        {
            return await _context.ColUsers
                .Include(p => p.ColPhotos)
                .Include(f => f.FactFeatures)
                // .Include(cm => cm.CollegeMajors)
                .ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(ColUser coluser)
        {
            _context.Entry(coluser).State = EntityState.Modified;
        }
    }
}