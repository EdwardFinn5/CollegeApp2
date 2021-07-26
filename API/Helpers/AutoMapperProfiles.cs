using System.Linq;
using API.DTOs;
using API.Entities;
using AutoMapper;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<ColUser, ColMemberDto>()
                .ForMember(dest => dest.ColUrl, opt => opt.MapFrom(src =>
                    src.ColPhotos.FirstOrDefault(x => x.IsMainCol).ColUrl))
                .ForMember(dest => dest.HsStudentUrl, opt => opt.MapFrom(src =>
                    src.ColPhotos.FirstOrDefault(x => x.IsMainHs).HsStudentUrl))
                .ForMember(dest => dest.AdminUrl, opt => opt.MapFrom(src =>
                    src.ColPhotos.FirstOrDefault(x => x.IsMainAdmin).AdminUrl));
            CreateMap<ColPhoto, ColPhotoDto>();
            CreateMap<FactFeature, FactFeatureDto>();
            CreateMap<ColMemberUpdateDto, ColUser>();
            CreateMap<HsRegisterDto, ColUser>();
            CreateMap<ColRegisterDto, ColUser>();
        }
    }
}