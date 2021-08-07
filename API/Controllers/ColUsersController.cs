using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using API.Interfaces;
using API.DTOs;
using API.Extensions;
using API.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Helpers;

namespace API.Controllers
{
    [Authorize]
    public class ColUsersController : BaseApiController
    {
        private readonly IColUserRepository _colUserRepository;
        private readonly IMapper _mapper;
        private readonly IPhotoService _photoService;
        public ColUsersController(IColUserRepository colUserRepository, IMapper mapper, IPhotoService photoService)
        {
            _photoService = photoService;
            _mapper = mapper;
            _colUserRepository = colUserRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ColMemberDto>>> GetColUsers([FromQuery] ColUserParams colUserParams)
        {
            var colUser = await _colUserRepository.GetColUserByUsernameAsync(User.GetColUserName());
            colUserParams.CurrentColUsername = colUser.ColUserName;

            if (string.IsNullOrEmpty(colUserParams.ColUserType))
                colUserParams.ColUserType = colUser.ColUserType == "College" ? "ColLead" : "College";

            // if (string.IsNullOrEmpty(colUserParams.CollegeLocation))
            //     colUserParams.CollegeLocation = colUser.CollegeLocation == "Des Moines, IA" ? "Cedar Rapids, IA" : "Des Moines, IA";


            var colUsers = await _colUserRepository.GetColMembersAsync(colUserParams);

            Response.AddPaginationHeader(colUsers.CurrentPage,
                                        colUsers.PageSize,
                                        colUsers.TotalCount,
                                        colUsers.TotalPages);

            return Ok(colUsers);
        }

        [HttpGet("{colUsername}", Name = "GetColUser")]
        public async Task<ActionResult<ColMemberDto>> GetColUser(string colUsername)
        {
            return await _colUserRepository.GetColMemberAsync(colUsername);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateColUser(ColMemberUpdateDto colMemberUpdateDto)
        {
            var colUser = await _colUserRepository.GetColUserByUsernameAsync(User.GetColUserName());

            _mapper.Map(colMemberUpdateDto, colUser);

            _colUserRepository.Update(colUser);

            if (await _colUserRepository.SaveAllAsync()) return NoContent();

            // _unitOfWork.UserRepository.Update(user);

            // var collegePrep = new CollegePrep
            // {
            //     AcademicPlus = memberUpdateDto.AcademicPlus
            // };

            // user.CollegePreps.Add(collegePrep);

            // user.CollegePreps.a Entry(user.CollegePreps.AcademicPlus).State = EntityState.Modified;

            // _context.Entry(user).State = EntityState.Modified;

            // if (await _unitOfWork.Complete()) return NoContent();

            return BadRequest("Failed to update colUser");
        }



        [HttpPost("add-photo")]
        public async Task<ActionResult<ColPhotoDto>> AddPhoto(IFormFile file)
        {
            var user = await _colUserRepository.GetColUserByUsernameAsync(User.GetColUserName());

            var result = await _photoService.AddPhotoAsync(file);

            if (result.Error != null) return BadRequest(result.Error.Message);

            var photo = new ColPhoto
            {
                ColUrl = null,
                HsStudentUrl = null
            };

            if (user.ColUserType == "College")
            {
                photo.ColUrl = result.SecureUrl.AbsoluteUri;
                photo.PublicId = result.PublicId;
            };

            if (user.ColUserType == "ColLead")
            {
                photo.HsStudentUrl = result.SecureUrl.AbsoluteUri;
                photo.PublicId = result.PublicId;
            };

            if (user.ColPhotos.Count == 0 && user.ColUserType == "College")
            {
                photo.IsMainCol = true;
            }

            if (user.ColPhotos.Count == 0 && user.ColUserType == "ColLead")
            {
                photo.IsMainHs = true;
            }

            user.ColPhotos.Add(photo);

            if (await _colUserRepository.SaveAllAsync())
            {
                // return CreatedAtRoute("GetColUser", _mapper.Map<ColPhotoDto>(photo));
                return CreatedAtRoute("GetColUser", new { colusername = user.ColUserName }, _mapper.Map<ColPhotoDto>(photo));
                // used 3rd overload which 
                // has the following parameters: string routename, object routeValues, object value
            }

            return BadRequest("Problem adding photo");
        }

        [HttpPut("set-main-photo/{photoId}")]
        public async Task<ActionResult> SetMainPhoto(int photoId)
        {
            var colUser = await _colUserRepository.GetColUserByUsernameAsync(User.GetColUserName());

            var colPhoto = colUser.ColPhotos.FirstOrDefault(x => x.ColPhotoId == photoId);

            if (colUser.ColUserType == "College")
            {
                if (colPhoto.IsMainCol) return BadRequest("This is already your main photo");

                var currentMain = colUser.ColPhotos.FirstOrDefault(x => x.IsMainCol);

                if (currentMain != null)
                {
                    currentMain.IsMainCol = false;
                    colPhoto.IsMainCol = true;
                }
            }

            if (colUser.ColUserType == "ColLead")
            {
                if (colPhoto.IsMainHs) return BadRequest("This is already your main logo");

                var currentMain = colUser.ColPhotos.FirstOrDefault(x => x.IsMainHs);

                if (currentMain != null)
                {
                    currentMain.IsMainHs = false;
                    colPhoto.IsMainHs = true;
                }
            }

            if (await _colUserRepository.SaveAllAsync()) return NoContent();

            return BadRequest("Failed to set main photo");
        }

        [HttpDelete("delete-colPhoto/{photoId}")]
        public async Task<ActionResult> DeleteColPhoto(int photoId)
        {
            var colUser = await _colUserRepository.GetColUserByUsernameAsync(User.GetColUserName());

            var colPhoto = colUser.ColPhotos.FirstOrDefault(x => x.ColPhotoId == photoId);

            if (colPhoto == null)
            {
                return NotFound();
            }

            if (colPhoto.IsMainCol)
            {
                return BadRequest("You cannot delete your main photo");
            }

            if (colPhoto.IsMainHs)
            {
                return BadRequest("You cannot delete your main photo");
            }

            if (colPhoto.PublicId != null)
            {
                var result = await _photoService.DeletePhotoAsync(colPhoto.PublicId);
                if (result.Error != null)
                {
                    return BadRequest(result.Error.Message);
                }
            }

            colUser.ColPhotos.Remove(colPhoto);

            if (await _colUserRepository.SaveAllAsync()) return Ok();

            return BadRequest("Failed to delete the photo");
        }

        public class PhotoDto
        {
            // }
        }

    }
}