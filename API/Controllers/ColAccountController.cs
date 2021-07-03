using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class ColAccountController : BaseApiController
    {
        private readonly DataContext _context;
        private readonly ITokenService _tokenService;
        public ColAccountController(DataContext context, ITokenService tokenService)
        {
            _tokenService = tokenService;
            _context = context;
        }

        [HttpPost("HsRegister")]
        public async Task<ActionResult<ColUserDto>> HsRegister(HsRegisterDto hsRegisterDto)
        {
            if (await ColUserExists(hsRegisterDto.ColUsername)) return BadRequest("Username is taken");

            using var hmac = new HMACSHA512();

            var colUser = new ColUser
            {
                ColUserName = hsRegisterDto.ColUsername.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(hsRegisterDto.Password)),
                PasswordSalt = hmac.Key,
                ColUserType = "ColLead"
            };

            _context.ColUsers.Add(colUser);
            await _context.SaveChangesAsync();

            return new ColUserDto
            {
                ColUserName = colUser.ColUserName,
                Token = _tokenService.CreateToken(colUser),
                ColUserType = colUser.ColUserType,
                FirstName = colUser.FirstName,
                // ColUrl = colUser.ColPhotos.FirstOrDefault(x => x.IsMainCol)?.ColUrl,
                // HsStudentUrl = colUser.ColPhotos.FirstOrDefault(x => x.IsMainHs)?.HsStudentUrl
            };
        }

        [HttpPost("CollegeRegister")]
        public async Task<ActionResult<ColUserDto>> CollegeRegister(ColRegisterDto colRegisterDto)
        {
            if (await ColUserExists(colRegisterDto.ColUsername)) return BadRequest("Username is taken");

            using var hmac = new HMACSHA512();

            var colUser = new ColUser
            {
                ColUserName = colRegisterDto.ColUsername.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(colRegisterDto.Password)),
                PasswordSalt = hmac.Key,
                ColUserType = "College"
            };

            _context.ColUsers.Add(colUser);
            await _context.SaveChangesAsync();

            return new ColUserDto
            {
                ColUserName = colUser.ColUserName,
                Token = _tokenService.CreateToken(colUser),
                ColUserType = colUser.ColUserType,
                FirstName = colUser.FirstName,
                // ColUrl = colUser.ColPhotos.FirstOrDefault(x => x.IsMainCol)?.ColUrl,
                // HsStudentUrl = colUser.ColPhotos.FirstOrDefault(x => x.IsMainHs)?.HsStudentUrl
            };
        }


        [HttpPost("colLogin")]
        public async Task<ActionResult<ColUserDto>> ColLogin(ColLoginDto colLoginDto)
        {

            var colUser = await _context.ColUsers
                .Include(p => p.ColPhotos)
                .SingleOrDefaultAsync(x => x.ColUserName == colLoginDto.ColUserName);

            if (colUser == null)
            {
                return Unauthorized("Invalid username");
            }

            using var hmac = new HMACSHA512(colUser.PasswordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(colLoginDto.Password));

            for (var i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != colUser.PasswordHash[i]) return Unauthorized("Invalid password");
            }

            return new ColUserDto
            {
                ColUserName = colUser.ColUserName,
                Token = _tokenService.CreateToken(colUser),
                ColUserType = colUser.ColUserType,
                FirstName = colUser.FirstName
                // ColUrl = colUser.ColPhotos.FirstOrDefault(x => x.IsMainCol)?.ColUrl,
                // HsStudentUrl = colUser.ColPhotos.FirstOrDefault(x => x.IsMainHs)?.HsStudentUrl
            };

        }

        private async Task<bool> ColUserExists(string colUsername)
        {
            return await _context.ColUsers.AnyAsync(x => x.ColUserName == colUsername.ToLower());
        }
    }
}