using MediatR;
using SaaSFileManager.Application.Contracts.Infrastructure;
using SaaSFileManager.Application.Contracts.Persistence;
using SaaSFileManager.Domain.Entities;

namespace SaaSFileManager.Application.Features.CompanySubscriptions.Commands.ChooseSubscriptionPlan
{
    public class ChooseSubscriptionPlanCommandHandler : IRequestHandler<ChooseSubscriptionPlanCommand>
    {
        private readonly ICompanySubscriptionRepository _companySubscriptionRepository;
        private readonly IAsyncRepository<SubscriptionPlan> _subscriptionPlanRepository;
        private readonly ILoggedInUserService _loggedInUserService;

        public ChooseSubscriptionPlanCommandHandler(ICompanySubscriptionRepository companySubscriptionRepository, IAsyncRepository<SubscriptionPlan> subscriptionPlanRepository, ILoggedInUserService loggedInUserService)
        {
            _companySubscriptionRepository = companySubscriptionRepository;
            _subscriptionPlanRepository = subscriptionPlanRepository;
            _loggedInUserService = loggedInUserService;
        }

        public async Task Handle(ChooseSubscriptionPlanCommand command, CancellationToken token)
        {
            var subscriptionPlan = await _subscriptionPlanRepository.GetByIdAsync(Guid.Parse(command.SubscriptionPlanId));
            if (subscriptionPlan == null)
            {
                throw new Exceptions.NotFoundException($"Subscription plan with ID {command.SubscriptionPlanId} not found.");
            }

            var companyId = _loggedInUserService.UserId;

            var currentSubscription = await _companySubscriptionRepository.GetActiveSubscriptionByCompanyId(Guid.Parse(companyId));

            if (currentSubscription != null)
            {
                if (currentSubscription.SubscriptionPlanId.ToString() == command.SubscriptionPlanId)
                {
                    throw new Exceptions.ConflictException("Company is already subscribed to this plan.");
                }

                currentSubscription.CanceledAt = DateTime.Now;
                await _companySubscriptionRepository.UpdateAsync(currentSubscription);
            }

            var subscription = new CompanySubscription
            {
                Id = Guid.NewGuid(),
                CompanyId = Guid.Parse(companyId),
                SubscriptionPlanId = Guid.Parse(command.SubscriptionPlanId),
                SubscribedAt = DateTime.UtcNow,
                CanceledAt = null
            };
            await _companySubscriptionRepository.AddAsync(subscription);
        }
    }
}
