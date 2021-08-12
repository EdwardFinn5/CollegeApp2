using System.Linq;
using API.Data.DTOs;
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
            CreateMap<Message, MessageDto>()
                .ForMember(dest => dest.SenderCollegePhotoUrl, opt => opt.MapFrom(src =>
                    src.Sender.ColPhotos.FirstOrDefault(x => x.IsMainCol).ColUrl))
                .ForMember(dest => dest.SenderHsPhotoUrl, opt => opt.MapFrom(src =>
                    src.Sender.ColPhotos.FirstOrDefault(x => x.IsMainHs).HsStudentUrl))
                    .ForMember(dest => dest.RecipientCollegePhotoUrl, opt => opt.MapFrom(src =>
                    src.Recipient.ColPhotos.FirstOrDefault(x => x.IsMainCol).ColUrl))
                .ForMember(dest => dest.RecipientHsPhotoUrl, opt => opt.MapFrom(src =>
                    src.Recipient.ColPhotos.FirstOrDefault(x => x.IsMainHs).HsStudentUrl));
        }
    }
}