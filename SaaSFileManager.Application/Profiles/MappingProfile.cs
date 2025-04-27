using AutoMapper;
using SaaSFileManager.Application.Features.Auth.Commands.CreateCompany;
using SaaSFileManager.Domain.Entities;

namespace SaaSFileManager.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RegisterCompanyCommand, Company>().ReverseMap();
        }
    }
}
