using AutoMapper;
using MediatR;
using SaaSFileManager.Application.Contracts.Infrastructure;
using SaaSFileManager.Application.Contracts.Persistence;

namespace SaaSFileManager.Application.Features.CompanySubscriptions.Queries.GetCompanyCurrentSubscription
{
    public class GetCompanyCurrentSubscriptionQueryHandler : IRequestHandler<GetCompanyCurrentSubscriptionQuery, CompanySubscriptionVM>
    {
        private readonly ICompanySubscriptionRepository _companySubscriptionRepository;
        private readonly ILoggedInUserService _loggedInUserService;
        private readonly IMapper _mapper;

        public GetCompanyCurrentSubscriptionQueryHandler (ICompanySubscriptionRepository companySubscriptionRepository, ILoggedInUserService loggedInUserService, IMapper mapper)
        {
            _companySubscriptionRepository = companySubscriptionRepository;
            _loggedInUserService = loggedInUserService;
            _mapper = mapper;
        }

        public async Task<CompanySubscriptionVM> Handle(GetCompanyCurrentSubscriptionQuery query, CancellationToken token)
        {
            var companyId = _loggedInUserService.UserId;

            var companySubscription = await _companySubscriptionRepository.GetActiveSubscriptionByCompanyId(Guid.Parse(companyId));
        
            if (companySubscription == null)
            {
                throw new Exceptions.NotFoundException("Company has not subscribed yet");
            }

            return _mapper.Map<CompanySubscriptionVM>(companySubscription);
        }
    }
}
