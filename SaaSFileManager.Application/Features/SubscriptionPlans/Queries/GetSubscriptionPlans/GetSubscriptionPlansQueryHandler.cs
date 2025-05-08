using AutoMapper;
using MediatR;
using SaaSFileManager.Application.Contracts.Persistence;
using SaaSFileManager.Domain.Entities;

namespace SaaSFileManager.Application.Features.SubscriptionPlans.Queries.GetSubscriptionPlans
{
    public class GetSubscriptionPlanDetailsQueryHandler : IRequestHandler<GetSubscriptionPlansQuery, List<SubscriptionPlanVm>>
    {
        private readonly IAsyncRepository<SubscriptionPlan> _asyncRepository;
        private readonly IMapper _mapper;

        public GetSubscriptionPlanDetailsQueryHandler(IAsyncRepository<SubscriptionPlan> asyncRepository, IMapper mapper)
        {
            _asyncRepository = asyncRepository;
            _mapper = mapper;
        }

        public async Task<List<SubscriptionPlanVm>> Handle(GetSubscriptionPlansQuery query, CancellationToken token)
        {
            var subscriptionPlans = await _asyncRepository.ListAllAsync();
            return _mapper.Map<List<SubscriptionPlanVm>>(subscriptionPlans);
        }
    }
}
