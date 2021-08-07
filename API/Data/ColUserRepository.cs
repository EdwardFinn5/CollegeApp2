using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Helpers;
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

        public async Task<PagedList<ColMemberDto>> GetColMembersAsync(ColUserParams colUserParams)
        {
            var query = _context.ColUsers.AsQueryable();

            query = query.Where(u => u.ColUserName != colUserParams.CurrentColUsername);
            query = query.Where(u => u.ColUserType == colUserParams.ColUserType);

            if (colUserParams.ColUserType == "College")
            {
                query = query.Where(u => u.CollegeLocation == colUserParams.CollegeLocation);
                query = query.Where(u => u.CollegeEnrollment >= colUserParams.MinEnrollment && u.CollegeEnrollment <= colUserParams.MaxEnrollment);

                query = colUserParams.OrderBy switch
                {
                    "created" => query.OrderByDescending(u => u.Created),
                    _ => query.OrderByDescending(u => u.LastActive)
                };
            }

            if (colUserParams.ColUserType == "ColLead")
            {
                query = query.Where(u => u.ClassYear == colUserParams.ClassYear);
                query = query.Where(u => u.ProposedMajor == colUserParams.ProposedMajor);

                query = colUserParams.OrderBy switch
                {
                    "created" => query.OrderByDescending(u => u.Created),
                    _ => query.OrderByDescending(u => u.LastActive)
                };
            }


            return await PagedList<ColMemberDto>.CreateAsync(
                query.ProjectTo<ColMemberDto>(_mapper.ConfigurationProvider).AsNoTracking(),
                colUserParams.PageNumber, colUserParams.PageSize);
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