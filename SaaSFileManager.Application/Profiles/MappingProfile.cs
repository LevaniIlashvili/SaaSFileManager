using AutoMapper;
using SaaSFileManager.Application.Features.Auth.Commands.CreateCompany;
using SaaSFileManager.Application.Features.Companies.Queries.GetCompanyDetails;
using SaaSFileManager.Application.Features.CompanySubscriptions.Queries.GetCompanyCurrentSubscription;
using SaaSFileManager.Application.Features.SubscriptionPlans.Queries.GetSubscriptionPlanDetails;
using SaaSFileManager.Application.Features.SubscriptionPlans.Queries.GetSubscriptionPlans;
using SaaSFileManager.Domain.Entities;

namespace SaaSFileManager.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RegisterCompanyCommand, Company>().ReverseMap();
            CreateMap<Company, CompanyDetailsVm>().ReverseMap();
            CreateMap<SubscriptionPlan, SubscriptionPlanVm>().ReverseMap();
            CreateMap<SubscriptionPlan, SubscriptionPlanDetailsVm>().ReverseMap();
            CreateMap<CompanySubscription, CompanySubscriptionVM>().ReverseMap();
        }
    }
}
