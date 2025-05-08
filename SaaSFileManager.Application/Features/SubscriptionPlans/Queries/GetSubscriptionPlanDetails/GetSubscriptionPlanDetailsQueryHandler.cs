using AutoMapper;
using MediatR;
using SaaSFileManager.Application.Contracts.Persistence;
using SaaSFileManager.Domain.Entities;

namespace SaaSFileManager.Application.Features.SubscriptionPlans.Queries.GetSubscriptionPlanDetails
{
    public class GetSubscriptionPlanDetailsQueryHandler : IRequestHandler<GetSubscriptionPlanDetailsQuery, SubscriptionPlanDetailsVm>
    {
        private readonly IAsyncRepository<SubscriptionPlan> _asyncRepository;
        private readonly IMapper _mapper;

        public GetSubscriptionPlanDetailsQueryHandler(IAsyncRepository<SubscriptionPlan> asyncRepository, IMapper mapper)
        {
            _asyncRepository = asyncRepository;
            _mapper = mapper;
        }

        public async Task<SubscriptionPlanDetailsVm> Handle(GetSubscriptionPlanDetailsQuery query, CancellationToken token)
        {
            var subscriptionPlan = await _asyncRepository.GetByIdAsync(Guid.Parse(query.Id));
            return _mapper.Map<SubscriptionPlanDetailsVm>(subscriptionPlan);
        }
    }
}
